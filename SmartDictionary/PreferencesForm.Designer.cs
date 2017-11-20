using System.Drawing;
using System.Windows.Forms;
using Shortcut;
using Shortcut.Forms;
using SmartDictionary.Common;
using SmartDictionary.DataAccess.Persistence;

namespace SmartDictionary
{
    partial class PreferencesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CancelButton = new Button();
            this.SaveButton = new Button();
            this.TabControl = new TabControl();
            this.TabControl.Location = new Point(10, 10);
            this.TabControl.Size = new Size(780, 430);

            TablePage1 = new TabPage();
            SetupTab1(ref TablePage1);
            this.TabControl.TabPages.Add(TablePage1);

            /*var tabPage2 = new TabPage();
            tabPage2.Location = new System.Drawing.Point(4, 22);
            tabPage2.Name = "Account & Activation";
            tabPage2.Padding = new System.Windows.Forms.Padding(3);
            tabPage2.TabIndex = 0;
            tabPage2.Text = "Account & Activation";
            tabPage2.UseVisualStyleBackColor = true;
            this.TabControl.TabPages.Add(tabPage2);*/

            // 
            // CancelButton
            // 
            this.CancelButton.Location = new Point(625, 450);
            this.CancelButton.Name = "Cancel";
            this.CancelButton.Size = new Size(75, 23);
            this.CancelButton.TabIndex = 0;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += (sender, e) =>
            {
                this.Close();
            };

            // 
            // SaveButton
            // 
            this.SaveButton.Location = new Point(710, 450);
            this.SaveButton.Name = "Save";
            this.SaveButton.Size = new Size(75, 23);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += (sender, e) =>
            {
                SaveHotkeySetting();
                this.Close();
            };

            // 
            // Preferences
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 480);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.TabControl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Preferences";
            this.Text = "Preferences";
            this.Load += (sender, e) =>
            {
                var owner = Owner as MainForm;
                this.Location =
                new Point(owner.Location.X + ((owner.Size.Width - this.Size.Width) / 2),
                owner.Location.Y + ((owner.Size.Height - this.Size.Height) / 2));
                ToggleHotkeyTextBoxCaptureArea.Hotkey = owner.ToggleHotKey;
                SaveHotkeyTextBoxCaptureArea.Hotkey = owner.SaveHotKey;
            };
            this.ResumeLayout(false);

        }

        private void SetupTab1(ref TabPage tabPage1)
        {
            tabPage1.Location = new System.Drawing.Point(4, 22);
            tabPage1.Name = "General";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "General";
            tabPage1.UseVisualStyleBackColor = true;

            var toggleHotKeyLabel = new Label();
            toggleHotKeyLabel.AutoSize = true;
            toggleHotKeyLabel.Location = new System.Drawing.Point(20, 20);
            toggleHotKeyLabel.Name = "Toggle Window Hotkey";
            toggleHotKeyLabel.Size = new System.Drawing.Size(100, 15);
            toggleHotKeyLabel.TabIndex = 1;
            toggleHotKeyLabel.Text = "Toggle Window Hotkey:";

            ToggleHotkeyTextBoxCaptureArea = new HotkeyTextBox();
            ToggleHotkeyTextBoxCaptureArea.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ToggleHotkeyTextBoxCaptureArea.Location = new System.Drawing.Point(180, 15);
            ToggleHotkeyTextBoxCaptureArea.Name = "hotkeyTextBoxCaptureArea";
            ToggleHotkeyTextBoxCaptureArea.Size = new System.Drawing.Size(200, 25);
            ToggleHotkeyTextBoxCaptureArea.TabIndex = 0;

            var saveHotKeyLabel = new Label();
            saveHotKeyLabel.AutoSize = true;
            saveHotKeyLabel.Location = new System.Drawing.Point(20, 55);
            saveHotKeyLabel.Name = "Save From Clipboard Hotkey";
            saveHotKeyLabel.Size = new System.Drawing.Size(100, 15);
            saveHotKeyLabel.TabIndex = 1;
            saveHotKeyLabel.Text = "Save From Clipboard Hotkey:";

            SaveHotkeyTextBoxCaptureArea = new HotkeyTextBox();
            SaveHotkeyTextBoxCaptureArea.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            SaveHotkeyTextBoxCaptureArea.Location = new System.Drawing.Point(180, 50);
            SaveHotkeyTextBoxCaptureArea.Name = "hotkeyTextBoxCaptureArea";
            SaveHotkeyTextBoxCaptureArea.Size = new System.Drawing.Size(200, 25);
            SaveHotkeyTextBoxCaptureArea.TabIndex = 0;

            tabPage1.Controls.Add(toggleHotKeyLabel);
            tabPage1.Controls.Add(saveHotKeyLabel);
            tabPage1.Controls.Add(SaveHotkeyTextBoxCaptureArea);
            tabPage1.Controls.Add(ToggleHotkeyTextBoxCaptureArea);
        }
        #endregion

        private void SaveHotkeySetting()
        {
            // toggle hotkey
            IniFile.IniWriteValue(Consts.ToggleHotkeySectionName,
                Consts.ModifierKeyName,
                ToggleHotkeyTextBoxCaptureArea.Hotkey.Modifier.ToString());
            IniFile.IniWriteValue(Consts.ToggleHotkeySectionName,
                Consts.KeyKeyName,
                ToggleHotkeyTextBoxCaptureArea.Hotkey.Key.ToString());

            // save hotkey
            IniFile.IniWriteValue(Consts.SaveHotkeySectionName,
                Consts.ModifierKeyName,
                SaveHotkeyTextBoxCaptureArea.Hotkey.Modifier.ToString());
            IniFile.IniWriteValue(Consts.SaveHotkeySectionName,
                Consts.KeyKeyName,
                SaveHotkeyTextBoxCaptureArea.Hotkey.Key.ToString());

            // reset current hot key
            var owner = Owner as MainForm;
            if (owner == null) return;
            owner.HotkeyBinder.Dispose();
            owner.HotkeyBinder = new HotkeyBinder();
            owner.BindKeywords();
        }

        private new Button CancelButton;
        private Button SaveButton;
        private TabControl TabControl;
        private TabPage TablePage1;
        private HotkeyTextBox SaveHotkeyTextBoxCaptureArea;
        private HotkeyTextBox ToggleHotkeyTextBoxCaptureArea;
    }
}