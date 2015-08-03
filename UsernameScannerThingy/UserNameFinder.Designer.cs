namespace UsernameScannerThingy
{
    partial class UserNameFinder
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserNameFinder));
            this.toolStrip_01 = new System.Windows.Forms.ToolStrip();
            this.toolBut_File = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolBut_Load = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox_Users = new System.Windows.Forms.ListBox();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.textBox_Raw = new System.Windows.Forms.TextBox();
            this.label_Users = new System.Windows.Forms.Label();
            this.label_RawText = new System.Windows.Forms.Label();
            this.button_GetUsers = new System.Windows.Forms.Button();
            this.contextMenu_UserList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.but_Info = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_01.SuspendLayout();
            this.contextMenu_UserList.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip_01
            // 
            this.toolStrip_01.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBut_File});
            this.toolStrip_01.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_01.Name = "toolStrip_01";
            this.toolStrip_01.Size = new System.Drawing.Size(473, 25);
            this.toolStrip_01.TabIndex = 0;
            this.toolStrip_01.Text = "nondescript";
            // 
            // toolBut_File
            // 
            this.toolBut_File.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolBut_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBut_Load});
            this.toolBut_File.Image = ((System.Drawing.Image)(resources.GetObject("toolBut_File.Image")));
            this.toolBut_File.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBut_File.Name = "toolBut_File";
            this.toolBut_File.Size = new System.Drawing.Size(38, 22);
            this.toolBut_File.Text = "File";
            // 
            // toolBut_Load
            // 
            this.toolBut_Load.Name = "toolBut_Load";
            this.toolBut_Load.Size = new System.Drawing.Size(100, 22);
            this.toolBut_Load.Text = "Load";
            this.toolBut_Load.Click += new System.EventHandler(this.toolBut_Load_Click);
            // 
            // listBox_Users
            // 
            this.listBox_Users.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_Users.FormattingEnabled = true;
            this.listBox_Users.HorizontalScrollbar = true;
            this.listBox_Users.ItemHeight = 20;
            this.listBox_Users.Location = new System.Drawing.Point(249, 41);
            this.listBox_Users.Name = "listBox_Users";
            this.listBox_Users.Size = new System.Drawing.Size(212, 284);
            this.listBox_Users.TabIndex = 1;
            this.listBox_Users.DoubleClick += new System.EventHandler(this.listBox_Users_DoubleClick);
            this.listBox_Users.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_Users_MouseDown);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "OpenFileDialog";
            // 
            // textBox_Raw
            // 
            this.textBox_Raw.Location = new System.Drawing.Point(12, 41);
            this.textBox_Raw.Multiline = true;
            this.textBox_Raw.Name = "textBox_Raw";
            this.textBox_Raw.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Raw.Size = new System.Drawing.Size(231, 240);
            this.textBox_Raw.TabIndex = 2;
            // 
            // label_Users
            // 
            this.label_Users.AutoSize = true;
            this.label_Users.Location = new System.Drawing.Point(337, 25);
            this.label_Users.Name = "label_Users";
            this.label_Users.Size = new System.Drawing.Size(34, 13);
            this.label_Users.TabIndex = 3;
            this.label_Users.Text = "Users";
            // 
            // label_RawText
            // 
            this.label_RawText.AutoSize = true;
            this.label_RawText.Location = new System.Drawing.Point(102, 25);
            this.label_RawText.Name = "label_RawText";
            this.label_RawText.Size = new System.Drawing.Size(53, 13);
            this.label_RawText.TabIndex = 4;
            this.label_RawText.Text = "Raw Text";
            // 
            // button_GetUsers
            // 
            this.button_GetUsers.Location = new System.Drawing.Point(78, 287);
            this.button_GetUsers.Name = "button_GetUsers";
            this.button_GetUsers.Size = new System.Drawing.Size(95, 38);
            this.button_GetUsers.TabIndex = 5;
            this.button_GetUsers.Text = "Get Users!";
            this.button_GetUsers.UseVisualStyleBackColor = true;
            this.button_GetUsers.Click += new System.EventHandler(this.button_GetUsers_Click);
            // 
            // contextMenu_UserList
            // 
            this.contextMenu_UserList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.but_Info});
            this.contextMenu_UserList.Name = "contextMenu_UserList";
            this.contextMenu_UserList.Size = new System.Drawing.Size(96, 26);
            // 
            // but_Info
            // 
            this.but_Info.Name = "but_Info";
            this.but_Info.Size = new System.Drawing.Size(152, 22);
            this.but_Info.Text = "Info";
            this.but_Info.Click += new System.EventHandler(this.but_Info_Click);
            // 
            // UserNameFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 337);
            this.Controls.Add(this.button_GetUsers);
            this.Controls.Add(this.label_RawText);
            this.Controls.Add(this.label_Users);
            this.Controls.Add(this.textBox_Raw);
            this.Controls.Add(this.listBox_Users);
            this.Controls.Add(this.toolStrip_01);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UserNameFinder";
            this.Text = "UserName Thingy";
            this.toolStrip_01.ResumeLayout(false);
            this.toolStrip_01.PerformLayout();
            this.contextMenu_UserList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip_01;
        private System.Windows.Forms.ToolStripDropDownButton toolBut_File;
        private System.Windows.Forms.ToolStripMenuItem toolBut_Load;
        private System.Windows.Forms.ListBox listBox_Users;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.TextBox textBox_Raw;
        private System.Windows.Forms.Label label_Users;
        private System.Windows.Forms.Label label_RawText;
        private System.Windows.Forms.Button button_GetUsers;
        private System.Windows.Forms.ContextMenuStrip contextMenu_UserList;
        private System.Windows.Forms.ToolStripMenuItem but_Info;
    }
}

