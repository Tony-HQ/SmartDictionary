// Copyright © Qiang Huang, All rights reserved.

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Shortcut;
using SmartDictionary.Common;
using SmartDictionary.Const;
using SmartDictionary.Core;
using SmartDictionary.DataAccess.Persistence;
using SmartDictionary.Entity;

namespace SmartDictionary
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitEventHandler();
            BindKeywords();
        }

        public void BindKeywords()
        {
            var toggleModifier1 = Helper.ParseModifier(IniFile.IniReadValue(Consts.ToggleHotkeySectionName,
                Consts.ModifierKeyName));
            var toggleKey = Helper.ParseKey(IniFile.IniReadValue(Consts.ToggleHotkeySectionName,
                Consts.KeyKeyName));

            var saveModifier1 = Helper.ParseModifier(IniFile.IniReadValue(Consts.SaveHotkeySectionName,
                Consts.ModifierKeyName));
            var saveKey = Helper.ParseKey(IniFile.IniReadValue(Consts.SaveHotkeySectionName,
                Consts.KeyKeyName));

            if (saveModifier1 != Modifiers.None && saveKey != Keys.None)
            {
                SaveHotKey = new Hotkey(saveModifier1, saveKey);
                HotkeyBinder.Bind(SaveHotKey).To(HotkeyCallback);
            }
            if (toggleModifier1 != Modifiers.None && toggleKey != Keys.None)
            {
                ToggleHotKey = new Hotkey(toggleModifier1, toggleKey);
                HotkeyBinder.Bind(ToggleHotKey).To(ToggleTheWindow);
            }

            HotkeyBinder.Bind(Modifiers.None, Keys.Down).To(FoucsToListViewAndDown);
            HotkeyBinder.Bind(Modifiers.None, Keys.Up).To(FoucsToListViewAndUp);
        }

        private async void HotkeyCallback()
        {
            var toSave = Clipboard.GetText();
            if (toSave.Length < 2)
            {
                return;
            }
            await CoreService.SaveSentence(toSave, Configuration.GetKeywordMaxLength());
            SentenceLabel.Text = toSave;
            StatusLabel.Text = Constant.FromOut;
        }

        private void InitEventHandler()
        {
            Shown += async (sender, e) =>
            {
                SearchBox.Focus();
                var sentences = await CoreService.GetAllSentence();
                MainListView.BeginUpdate();
                MainListView.Items.Clear();
                MainListView.Items.AddRange(Helper.ConvertSentenceToListViewItem(sentences));
                MainListView.EndUpdate();
                TotalCountLabel.Text = $@"Total {MainListView.Items.Count} Sentences";
            };

            SearchBox.TextChanged += async (sender, e) =>
            {
                var box = sender as TextBox;
                IEnumerable<Sentence> sentences;
                if (box?.Text.Length >= 1)
                {
                    sentences = await CoreService.SearchBySentence(box.Text, Configuration.GetKeywordMaxLength());
                }
                else
                {
                    sentences = await CoreService.GetAllSentence();
                }
                var sentenceList = sentences as IList<Sentence> ?? sentences.ToList();

                MainListView.BeginUpdate();
                MainListView.Items.Clear();
                MainListView.Items.AddRange(Helper.ConvertSentenceToListViewItem(sentenceList));
                MainListView.EndUpdate();

                TotalCountLabel.Text = $@"Total {MainListView.Items.Count} Sentences";
            };

            MainListView.SelectedIndexChanged += (sender, e) =>
            {
                _listViewFoucsed = true;
                var listView = sender as ListView;
                if (listView == null) return;
                if (listView.SelectedIndices.Count == 0) return;
                var index = listView.SelectedIndices[0];
                var toCopy = MainListView.Items[index].SubItems[1];
                _listViewSelectedRowOffset = index;
                Clipboard.SetText(toCopy.Text);
                SentenceLabel.Text = toCopy.Text;
                StatusLabel.Text = Constant.Copyed;
            };

            SizeChanged += (sender, e) =>
            {
                MainListView.Columns[1].Width = Size.Width - MainListView.Columns[0].Width - MainListView.Columns[2].Width - 20;
            };
        }

        private void ToggleTheWindow()
        {
            _listViewFoucsed = false;
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Minimized;
            else
            {
                WindowState = FormWindowState.Normal;
                SearchBox.Focus();
            }
        }

        private void FoucsToListViewAndDown()
        {
            if (!_listViewFoucsed)
            {
                _listViewSelectedRowOffset = 0;
                _listViewFoucsed = true;
                MainListView.Focus();
                MainListView.Items[_listViewSelectedRowOffset].Selected = true;
            }
            else
            {
                _listViewSelectedRowOffset += 1;
                if (_listViewSelectedRowOffset >= MainListView.Items.Count)
                {
                    _listViewSelectedRowOffset = 0;
                }
                MainListView.Focus();
                MainListView.Items[_listViewSelectedRowOffset].Selected = true;
            }
        }

        private void FoucsToListViewAndUp()
        {
            if (!_listViewFoucsed)
            {
                _listViewSelectedRowOffset = MainListView.Items.Count - 1 > 0 ? MainListView.Items.Count - 1 : 0;
                _listViewFoucsed = true;
                MainListView.Focus();
                MainListView.Items[_listViewSelectedRowOffset].Selected = true;
            }
            else
            {
                _listViewSelectedRowOffset -= 1;
                if (_listViewSelectedRowOffset < 0)
                {
                    _listViewSelectedRowOffset = MainListView.Items.Count - 1 > 0 ? MainListView.Items.Count - 1 : 0;
                }
                MainListView.Focus();
                MainListView.Items[_listViewSelectedRowOffset].Selected = true;
            }
        }

        private static int _listViewSelectedRowOffset = 0;
        private static bool _listViewFoucsed;
        public HotkeyBinder HotkeyBinder = new HotkeyBinder();
        public Hotkey ToggleHotKey;
        public Hotkey SaveHotKey;
    }
}