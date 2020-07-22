namespace CRS
{
    partial class Registered
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RegistName = new System.Windows.Forms.TextBox();
            this.registpwd = new System.Windows.Forms.TextBox();
            this.registRpwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Back_Login = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "账号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码";
            // 
            // RegistName
            // 
            this.RegistName.Enabled = false;
            this.RegistName.Location = new System.Drawing.Point(184, 65);
            this.RegistName.Name = "RegistName";
            this.RegistName.Size = new System.Drawing.Size(123, 21);
            this.RegistName.TabIndex = 2;
            this.RegistName.TextChanged += new System.EventHandler(this.RegistName_TextChanged);
            // 
            // registpwd
            // 
            this.registpwd.Location = new System.Drawing.Point(184, 123);
            this.registpwd.Name = "registpwd";
            this.registpwd.PasswordChar = '*';
            this.registpwd.Size = new System.Drawing.Size(123, 21);
            this.registpwd.TabIndex = 3;
            // 
            // registRpwd
            // 
            this.registRpwd.Location = new System.Drawing.Point(184, 179);
            this.registRpwd.Name = "registRpwd";
            this.registRpwd.PasswordChar = '*';
            this.registRpwd.Size = new System.Drawing.Size(123, 21);
            this.registRpwd.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "确认密码";
            // 
            // Back_Login
            // 
            this.Back_Login.Location = new System.Drawing.Point(21, 12);
            this.Back_Login.Name = "Back_Login";
            this.Back_Login.Size = new System.Drawing.Size(61, 21);
            this.Back_Login.TabIndex = 7;
            this.Back_Login.Text = "返回登录";
            this.Back_Login.UseVisualStyleBackColor = true;
            this.Back_Login.Click += new System.EventHandler(this.Back_Login_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(210, 262);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 42);
            this.button1.TabIndex = 8;
            this.button1.Text = "注册";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Registered
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 386);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Back_Login);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.registRpwd);
            this.Controls.Add(this.registpwd);
            this.Controls.Add(this.RegistName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Registered";
            this.Text = "Registered";
            this.Load += new System.EventHandler(this.Registered_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RegistName;
        private System.Windows.Forms.TextBox registpwd;
        private System.Windows.Forms.TextBox registRpwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Back_Login;
        private System.Windows.Forms.Button button1;
    }
}