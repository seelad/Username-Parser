namespace UsernameScannerThingy
{
    partial class UserLookUp
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
            this.textBox_Msg = new System.Windows.Forms.TextBox();
            this.Label_Name = new System.Windows.Forms.Label();
            this.textBox_MsgFilter = new System.Windows.Forms.TextBox();
            this.toolTip_FilterChats = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // textBox_Msg
            // 
            this.textBox_Msg.Location = new System.Drawing.Point(11, 52);
            this.textBox_Msg.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Msg.Multiline = true;
            this.textBox_Msg.Name = "textBox_Msg";
            this.textBox_Msg.ReadOnly = true;
            this.textBox_Msg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Msg.Size = new System.Drawing.Size(390, 167);
            this.textBox_Msg.TabIndex = 6;
            this.textBox_Msg.TextChanged += new System.EventHandler(this.textBox_Msg_TextChanged);
            // 
            // Label_Name
            // 
            this.Label_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Name.Location = new System.Drawing.Point(-14, 9);
            this.Label_Name.Name = "Label_Name";
            this.Label_Name.Size = new System.Drawing.Size(439, 37);
            this.Label_Name.TabIndex = 13;
            this.Label_Name.Text = "Name";
            this.Label_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_MsgFilter
            // 
            this.textBox_MsgFilter.Location = new System.Drawing.Point(11, 223);
            this.textBox_MsgFilter.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_MsgFilter.Multiline = true;
            this.textBox_MsgFilter.Name = "textBox_MsgFilter";
            this.textBox_MsgFilter.ReadOnly = true;
            this.textBox_MsgFilter.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_MsgFilter.Size = new System.Drawing.Size(390, 65);
            this.textBox_MsgFilter.TabIndex = 14;
            // 
            // UserLookUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 299);
            this.Controls.Add(this.textBox_MsgFilter);
            this.Controls.Add(this.Label_Name);
            this.Controls.Add(this.textBox_Msg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UserLookUp";
            this.Text = "UserLookUp";
            this.Load += new System.EventHandler(this.UserLookUp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Msg;
        private System.Windows.Forms.Label Label_Name;
        private System.Windows.Forms.TextBox textBox_MsgFilter;
        private System.Windows.Forms.ToolTip toolTip_FilterChats;
    }
}