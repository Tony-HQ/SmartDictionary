using System.Data;
using System.Windows.Forms;

namespace SmartDictionary
{
    partial class Form1
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

        private void InitializeComponent()
        {
            InitTextBox();
            InitMenu();
            InitListView();
            InitForm();
        }

        private void InitTextBox()
        {
            // 
            // SearchBox
            // 
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SearchBox.Location = new System.Drawing.Point(0, SearchBoxStartY);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(1200, 50);
            this.SearchBox.TabIndex = 2;
            this.SearchBox.Anchor = (AnchorStyles)((AnchorStyles.Top | (AnchorStyles.Left) | AnchorStyles.Right));
        }

        private void InitForm()
        {
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.MainMenuStrip = this.MainMenu;
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.MainListView);
            this.Name = "Form1";
            this.Text = "SmartDictionary";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void InitMenu()
        {
            this.FilesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PreferencesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu = new System.Windows.Forms.MenuStrip();

            // 
            // FilesMenuItem
            // 
            this.FilesMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PreferencesMenuItem,
            this.ExitMenuItem});
            this.FilesMenuItem.Name = "FilesMenuItem";
            this.FilesMenuItem.Size = new System.Drawing.Size(0, 20);
            this.FilesMenuItem.Text = "Files";

            // 
            // PreferencesMenuItem
            // 
            this.PreferencesMenuItem.Name = "PreferencesMenuItem";
            this.PreferencesMenuItem.Size = new System.Drawing.Size(135, 22);
            this.PreferencesMenuItem.Text = "Preferences";
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(135, 22);
            this.ExitMenuItem.Text = "Exit";
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FilesMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1200, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "MainMenu";
            this.MainMenu.SuspendLayout();
        }

        private void InitListView()
        {
            this.SentenceId = new ColumnHeader();
            this.SentenceKey = new ColumnHeader();
            this.LastUsedTime = new ColumnHeader();

            // SentenceId
            this.SentenceId.Name = "SentenceId";
            this.SentenceId.Text = "Id";
            this.SentenceId.Width = 80;
            this.SentenceId.TextAlign = HorizontalAlignment.Center;

            // SentenceKey
            this.SentenceKey.Name = "SentenceKey";
            this.SentenceKey.Text = "Value";
            this.SentenceKey.Width = 1000;

            // LastUsedTime
            this.LastUsedTime.Name = "LastUsedTime";
            this.LastUsedTime.Text = "LastUsedTime";
            this.LastUsedTime.Width = 120;
            this.LastUsedTime.TextAlign = HorizontalAlignment.Center;

            // MainListView
            this.MainListView = new System.Windows.Forms.ListView();
            this.MainListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.SentenceId,
                this.SentenceKey,
                this.LastUsedTime
            });

            this.MainListView.FullRowSelect = true;
            this.MainListView.GridLines = true;
            this.MainListView.Location = new System.Drawing.Point(0, ListViewStartY);
            this.MainListView.Name = "MainListView";
            this.MainListView.Size = new System.Drawing.Size(1200, 750);
            this.MainListView.TabIndex = 1;
            this.MainListView.UseCompatibleStateImageBehavior = false;
            this.MainListView.View = System.Windows.Forms.View.Details;
            this.MainListView.Anchor = (AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Top) | (AnchorStyles.Left | AnchorStyles.Right)));
        }

        private int SearchBoxStartY = 27;
        private int ListViewStartY = 50;

        private ToolStripMenuItem FilesMenuItem;
        private ToolStripMenuItem PreferencesMenuItem;
        private ToolStripMenuItem ExitMenuItem;
        private MenuStrip MainMenu;
        private ListView MainListView;
        private ColumnHeader SentenceId;
        private ColumnHeader SentenceKey;
        private ColumnHeader LastUsedTime;
        private TextBox SearchBox;
    }
}
