// Copyright © Qiang Huang, All rights reserved.

using System.Windows.Forms;
using Shortcut;
using SmartDictionary.Common;
using SmartDictionary.Core;
using SmartDictionary.DataAccess.Persistence;

namespace SmartDictionary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitEventHandler();

            _hotkeyBinder.Bind(Modifiers.Control | Modifiers.Alt, Keys.C).To(HotkeyCallback);
            _hotkeyBinder.Bind(Modifiers.Shift, Keys.Space).To(ToggleTheWindow);
        }

        private static async void HotkeyCallback()
        {
            var toSave = Clipboard.GetText();
            if (toSave.Length < 2)
            {
                return;
            }
            await CoreService.SaveSentence(toSave, Configuration.GetKeywordMaxLength());
            MessageBox.Show(toSave);
        }

        private void InitEventHandler()
        {
            SearchBox.TextChanged += async (sender, e) =>
            {
                MainListView.Items.Clear();
                var box = sender as TextBox;
                var sentences = await CoreService.SearchBySentence(box?.Text, Configuration.GetKeywordMaxLength());
                MainListView.Items.AddRange(Helper.ConvertSentenceToListViewItem(sentences));
            };
        }

        private void ToggleTheWindow()
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Minimized;
            else
            {
                WindowState = FormWindowState.Normal;
                SearchBox.Focus();
            }
        }

        private readonly HotkeyBinder _hotkeyBinder = new HotkeyBinder();
    }
}