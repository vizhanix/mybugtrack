namespace MyAssignmentBugTrack
{
    partial class RegesterForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_regsubmit = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtbox_pass = new System.Windows.Forms.TextBox();
            this.txtbox_email = new System.Windows.Forms.TextBox();
            this.txtbox_name = new System.Windows.Forms.TextBox();
            this.role = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.here = new System.Windows.Forms.Label();
            this.regester = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_regsubmit);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.txtbox_pass);
            this.panel1.Controls.Add(this.txtbox_email);
            this.panel1.Controls.Add(this.txtbox_name);
            this.panel1.Controls.Add(this.role);
            this.panel1.Controls.Add(this.password);
            this.panel1.Controls.Add(this.email);
            this.panel1.Controls.Add(this.name);
            this.panel1.Controls.Add(this.here);
            this.panel1.Controls.Add(this.regester);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(98, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 449);
            this.panel1.TabIndex = 0;
            // 
            // btn_regsubmit
            // 
            this.btn_regsubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_regsubmit.Location = new System.Drawing.Point(175, 360);
            this.btn_regsubmit.Name = "btn_regsubmit";
            this.btn_regsubmit.Size = new System.Drawing.Size(133, 48);
            this.btn_regsubmit.TabIndex = 11;
            this.btn_regsubmit.Text = "Submit";
            this.btn_regsubmit.UseVisualStyleBackColor = true;
            this.btn_regsubmit.Click += new System.EventHandler(this.btn_regsubmit_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "tester",
            "developer"});
            this.comboBox1.Location = new System.Drawing.Point(175, 305);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(175, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // txtbox_pass
            // 
            this.txtbox_pass.Location = new System.Drawing.Point(175, 267);
            this.txtbox_pass.Name = "txtbox_pass";
            this.txtbox_pass.PasswordChar = '*';
            this.txtbox_pass.Size = new System.Drawing.Size(175, 20);
            this.txtbox_pass.TabIndex = 9;
            // 
            // txtbox_email
            // 
            this.txtbox_email.Location = new System.Drawing.Point(175, 229);
            this.txtbox_email.Name = "txtbox_email";
            this.txtbox_email.Size = new System.Drawing.Size(175, 20);
            this.txtbox_email.TabIndex = 8;
            // 
            // txtbox_name
            // 
            this.txtbox_name.Location = new System.Drawing.Point(175, 190);
            this.txtbox_name.Name = "txtbox_name";
            this.txtbox_name.Size = new System.Drawing.Size(175, 20);
            this.txtbox_name.TabIndex = 7;
            // 
            // role
            // 
            this.role.AutoSize = true;
            this.role.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.role.Location = new System.Drawing.Point(52, 302);
            this.role.Name = "role";
            this.role.Size = new System.Drawing.Size(68, 25);
            this.role.TabIndex = 6;
            this.role.Text = "Role :";
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(52, 263);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(118, 25);
            this.password.TabIndex = 5;
            this.password.Text = "Password :";
            // 
            // email
            // 
            this.email.AutoSize = true;
            this.email.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email.Location = new System.Drawing.Point(52, 223);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(83, 25);
            this.email.TabIndex = 4;
            this.email.Text = "Email : ";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(52, 184);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(80, 25);
            this.name.TabIndex = 3;
            this.name.Text = "Name :";
            // 
            // here
            // 
            this.here.AutoSize = true;
            this.here.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.here.Location = new System.Drawing.Point(200, 86);
            this.here.Name = "here";
            this.here.Size = new System.Drawing.Size(66, 29);
            this.here.TabIndex = 2;
            this.here.Text = "Here";
            // 
            // regester
            // 
            this.regester.AutoSize = true;
            this.regester.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regester.Location = new System.Drawing.Point(198, 39);
            this.regester.Name = "regester";
            this.regester.Size = new System.Drawing.Size(152, 37);
            this.regester.TabIndex = 1;
            this.regester.Text = "Regester";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MyAssignmentBugTrack.Properties.Resources.UserLogin;
            this.pictureBox1.Location = new System.Drawing.Point(27, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(134, 133);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // RegesterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MyAssignmentBugTrack.Properties.Resources.untitled;
            this.ClientSize = new System.Drawing.Size(600, 505);
            this.Controls.Add(this.panel1);
            this.Name = "RegesterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegesterForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label regester;
        private System.Windows.Forms.TextBox txtbox_pass;
        private System.Windows.Forms.TextBox txtbox_email;
        private System.Windows.Forms.TextBox txtbox_name;
        private System.Windows.Forms.Label role;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.Label email;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label here;
        private System.Windows.Forms.Button btn_regsubmit;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}