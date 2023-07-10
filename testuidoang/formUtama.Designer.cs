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
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnAnggota = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdmin
            // 
            this.btnAdmin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdmin.BackColor = System.Drawing.Color.Silver;
            this.btnAdmin.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnAdmin.Location = new System.Drawing.Point(501, 525);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(175, 67);
            this.btnAdmin.TabIndex = 0;
            this.btnAdmin.Text = "Admin Only";
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btnAnggota
            // 
            this.btnAnggota.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAnggota.BackColor = System.Drawing.Color.Silver;
            this.btnAnggota.Location = new System.Drawing.Point(947, 525);
            this.btnAnggota.Name = "btnAnggota";
            this.btnAnggota.Size = new System.Drawing.Size(175, 67);
            this.btnAnggota.TabIndex = 2;
            this.btnAnggota.Text = "Anggota\r\n perpustakaan";
            this.btnAnggota.UseVisualStyleBackColor = false;
            this.btnAnggota.Click += new System.EventHandler(this.btn2_Click);
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
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnAnggota);
            this.Controls.Add(this.btnAdmin);
            this.Name = "formUtama";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnAnggota;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

