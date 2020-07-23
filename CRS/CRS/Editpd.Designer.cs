namespace CRS
{
    partial class Editpd
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
            this.oldpwd = new System.Windows.Forms.Label();
            this.Newpwd = new System.Windows.Forms.Label();
            this.NewRtPwd = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.editpwd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // oldpwd
            // 
            this.oldpwd.AutoSize = true;
            this.oldpwd.Location = new System.Drawing.Point(128, 76);
            this.oldpwd.Name = "oldpwd";
            this.oldpwd.Size = new System.Drawing.Size(41, 12);
            this.oldpwd.TabIndex = 0;
            this.oldpwd.Text = "旧密码";
            // 
            // Newpwd
            // 
            this.Newpwd.AutoSize = true;
            this.Newpwd.Location = new System.Drawing.Point(128, 129);
            this.Newpwd.Name = "Newpwd";
            this.Newpwd.Size = new System.Drawing.Size(41, 12);
            this.Newpwd.TabIndex = 1;
            this.Newpwd.Text = "新密码";
            // 
            // NewRtPwd
            // 
            this.NewRtPwd.AutoSize = true;
            this.NewRtPwd.Location = new System.Drawing.Point(128, 190);
            this.NewRtPwd.Name = "NewRtPwd";
            this.NewRtPwd.Size = new System.Drawing.Size(65, 12);
            this.NewRtPwd.TabIndex = 2;
            this.NewRtPwd.Text = "确认新密码";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(211, 76);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(211, 129);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(211, 187);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 21);
            this.textBox3.TabIndex = 5;
            // 
            // editpwd
            // 
            this.editpwd.Location = new System.Drawing.Point(222, 274);
            this.editpwd.Name = "editpwd";
            this.editpwd.Size = new System.Drawing.Size(67, 53);
            this.editpwd.TabIndex = 6;
            this.editpwd.Text = "修改";
            this.editpwd.UseVisualStyleBackColor = true;
            this.editpwd.Click += new System.EventHandler(this.editpwd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(12, 9);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(75, 23);
            this.back.TabIndex = 8;
            this.back.Text = "退出";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // Editpd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 410);
            this.Controls.Add(this.back);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.editpwd);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.NewRtPwd);
            this.Controls.Add(this.Newpwd);
            this.Controls.Add(this.oldpwd);
            this.Name = "Editpd";
            this.Text = "Editpd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label oldpwd;
        private System.Windows.Forms.Label Newpwd;
        private System.Windows.Forms.Label NewRtPwd;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button editpwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button back;
    }
}