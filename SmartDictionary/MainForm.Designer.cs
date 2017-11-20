using System.Windows.Forms;

namespace SmartDictionary
{
    partial class MainForm
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
            InitToolTip();
            InitForm();
        }

        private void InitTextBox()
        {
            // SearchBox
            this.SearchBox = new TextBox();
            this.SearchBox.Location = new System.Drawing.Point(0, SearchBoxStartY);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(1200, 50);
            this.SearchBox.TabIndex = 2;
            this.SearchBox.Anchor = (AnchorStyles)((AnchorStyles.Top | (AnchorStyles.Left) | AnchorStyles.Right));
        }

        private void InitForm()
        {
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.MainMenuStrip = this.MainMenu;
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.MainListView);
            this.Name = "Form1";
            this.Text = "SmartDictionary";
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void InitMenu()
        {
            this.FilesMenuItem = new ToolStripMenuItem();
            this.PreferencesMenuItem = new ToolStripMenuItem();
            this.ImportMenuItem = new ToolStripMenuItem();
            this.ExitMenuItem = new ToolStripMenuItem();
            this.ActivationAndAccountMenuItem = new ToolStripMenuItem();
            this.MainMenu = new MenuStrip();

            // FilesMenuItem
            this.FilesMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                this.ImportMenuItem,
                this.PreferencesMenuItem,
                this.ActivationAndAccountMenuItem,
                this.ExitMenuItem
            });

            this.FilesMenuItem.Name = "FilesMenuItem";
            this.FilesMenuItem.Size = new System.Drawing.Size(0, 20);
            this.FilesMenuItem.Text = "Files";

            // PreferencesMenuItem
            this.PreferencesMenuItem.Name = "PreferencesMenuItem";
            this.PreferencesMenuItem.Size = new System.Drawing.Size(135, 22);
            this.PreferencesMenuItem.Text = "Preferences";
            this.PreferencesMenuItem.Click += (sender, e) =>
            {
                using (var preferencesFrom = new PreferencesForm
                {
                    Owner = this
                })
                {
                    preferencesFrom.ShowDialog();
                    preferencesFrom.Dispose();
                }
            };

            // ExitMenuItem
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(135, 22);
            this.ExitMenuItem.Text = "Exit";

            // ImportMenuItem
            this.ImportMenuItem.Name = "ImportMenuItem";
            this.ImportMenuItem.Size = new System.Drawing.Size(135, 22);
            this.ImportMenuItem.Text = "Import";

            // ActivationAndAccountMenuItem
            this.ActivationAndAccountMenuItem.Name = "ActivationAndAccountMenuItem";
            this.ActivationAndAccountMenuItem.Size = new System.Drawing.Size(135, 22);
            this.ActivationAndAccountMenuItem.Text = @"Activation";

            // MainMenu
            this.MainMenu.Items.AddRange(new ToolStripItem[] {
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
            this.SentenceId.Width = 70;
            this.SentenceId.TextAlign = HorizontalAlignment.Center;

            // SentenceKey
            this.SentenceKey.Name = "SentenceKey";
            this.SentenceKey.Text = "Value";
            this.SentenceKey.Width = 990;

            // LastUsedTime
            this.LastUsedTime.Name = "LastUsedTime";
            this.LastUsedTime.Text = "LastUsedTime";
            this.LastUsedTime.Width = 140;
            this.LastUsedTime.TextAlign = HorizontalAlignment.Center;

            // MainListView
            this.MainListView = new ListView();
            this.MainListView.Columns.AddRange(new ColumnHeader[] {
                this.SentenceId,
                this.SentenceKey,
                this.LastUsedTime
            });

            this.MainListView.FullRowSelect = true;
            this.MainListView.GridLines = true;
            this.MainListView.MultiSelect = false;
            this.MainListView.Location = new System.Drawing.Point(0, ListViewStartY);
            this.MainListView.Name = "MainListView";
            this.MainListView.Size = new System.Drawing.Size(1298, 750);
            this.MainListView.TabIndex = 1;
            this.MainListView.UseCompatibleStateImageBehavior = false;
            this.MainListView.View = View.Details;
            this.MainListView.Anchor = (AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Top) | (AnchorStyles.Left | AnchorStyles.Right)));
        }

        private void InitToolTip()
        {
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.TotalCountLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SentenceLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();

            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();

            // StatusStrip
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.TotalCountLabel,this.SentenceLabel,this.StatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 521);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(964, 22);
            this.StatusStrip.TabIndex = 0;
            this.StatusStrip.Text = "StatusStrip";

            // TotalCountLabel
            this.TotalCountLabel.Name = "TotalCountLabel";
            this.TotalCountLabel.Size = new System.Drawing.Size(120, 17);
            this.TotalCountLabel.Text = $@"Initing program";
            this.TotalCountLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                                                                                                         | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                                                                                                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));

            // SentenceLabel
            this.SentenceLabel.Name = "SentenceLabel";
            this.SentenceLabel.Size = new System.Drawing.Size(600, 17);
            this.SentenceLabel.Text = $@"中文";
            this.SentenceLabel.Padding = new Padding(5, 0, 5, 0);
            this.SentenceLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                                                                                                         | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                                                                                                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));

            // StatusLabel
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(120, 17);
            this.StatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                                                                                                                           | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                                                                                                                          | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));

            this.StatusLabel.Text = $@"Copyed";
        }

        private int SearchBoxStartY = 27;
        private int ListViewStartY = 50;

        private ToolStripMenuItem FilesMenuItem;
        private ToolStripMenuItem ImportMenuItem;
        private ToolStripMenuItem PreferencesMenuItem;
        private ToolStripMenuItem ActivationAndAccountMenuItem;
        private ToolStripMenuItem ExitMenuItem;
        private MenuStrip MainMenu;
        private ListView MainListView;
        private ColumnHeader SentenceId;
        private ColumnHeader SentenceKey;
        private ColumnHeader LastUsedTime;
        private TextBox SearchBox;
        private StatusStrip StatusStrip;
        private ToolStripStatusLabel TotalCountLabel;
        private ToolStripStatusLabel SentenceLabel;
        private ToolStripStatusLabel StatusLabel;
    }
}
