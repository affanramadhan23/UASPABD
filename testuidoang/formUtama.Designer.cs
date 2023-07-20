namespace testuidoang
{
    partial class formUtama
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
            this.Login = new System.Windows.Forms.Button();
            this.btnAnggota = new System.Windows.Forms.Button();
            this.Username = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // Login
            // 
            this.Login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Login.BackColor = System.Drawing.Color.Silver;
            this.Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login.ForeColor = System.Drawing.Color.Black;
            this.Login.Location = new System.Drawing.Point(1014, 707);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(175, 67);
            this.Login.TabIndex = 0;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = false;
            this.Login.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btnAnggota
            // 
            this.btnAnggota.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAnggota.BackColor = System.Drawing.Color.Silver;
            this.btnAnggota.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAnggota.Location = new System.Drawing.Point(494, 707);
            this.btnAnggota.Name = "btnAnggota";
            this.btnAnggota.Size = new System.Drawing.Size(175, 67);
            this.btnAnggota.TabIndex = 2;
            this.btnAnggota.Text = "Clear";
            this.btnAnggota.UseVisualStyleBackColor = false;
            this.btnAnggota.Click += new System.EventHandler(this.btn2_Click);
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(690, 531);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(304, 22);
            this.Username.TabIndex = 8;
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(690, 595);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(304, 22);
            this.Password.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(580, 534);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Username";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(580, 601);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Password";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = global::testuidoang.Properties.Resources.libraryfoto2_fotor_bg_remover_20230705104929;
            this.pictureBox2.Location = new System.Drawing.Point(399, 83);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(839, 396);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // formUtama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(1543, 865);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnAnggota);
            this.Controls.Add(this.Login);
            this.Name = "formUtama";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Button btnAnggota;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

