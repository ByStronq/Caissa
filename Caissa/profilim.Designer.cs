namespace Caïssa
{
    partial class profilim
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LabelkAdi = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kAdi = new System.Windows.Forms.TextBox();
            this.GuncelleBtn = new System.Windows.Forms.Button();
            this.rutbeELO = new System.Windows.Forms.Label();
            this.rutbeAd = new System.Windows.Forms.Label();
            this.rutbeTas = new System.Windows.Forms.PictureBox();
            this.Labelcinsiyet = new System.Windows.Forms.Label();
            this.LabeldgmTarihi = new System.Windows.Forms.Label();
            this.dgmTarihi = new System.Windows.Forms.DateTimePicker();
            this.kadin = new System.Windows.Forms.RadioButton();
            this.erkek = new System.Windows.Forms.RadioButton();
            this.LabelsoyAd = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.soyad = new System.Windows.Forms.TextBox();
            this.Labelad = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ad = new System.Windows.Forms.TextBox();
            this.LabelGSM = new System.Windows.Forms.Label();
            this.LabelePosta = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gsm = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ePosta = new System.Windows.Forms.TextBox();
            this.Labelsifre = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sifre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rutbeTas)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Caïssa.Properties.Resources.img_avatar1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LabelkAdi
            // 
            this.LabelkAdi.AutoSize = true;
            this.LabelkAdi.BackColor = System.Drawing.Color.Transparent;
            this.LabelkAdi.Font = new System.Drawing.Font("Arial", 11F);
            this.LabelkAdi.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LabelkAdi.Location = new System.Drawing.Point(135, 9);
            this.LabelkAdi.Name = "LabelkAdi";
            this.LabelkAdi.Size = new System.Drawing.Size(136, 25);
            this.LabelkAdi.TabIndex = 26;
            this.LabelkAdi.Text = "Kullanıcı Adı:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Location = new System.Drawing.Point(152, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(131, 1);
            this.panel1.TabIndex = 25;
            // 
            // kAdi
            // 
            this.kAdi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.kAdi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.kAdi.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kAdi.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.kAdi.Location = new System.Drawing.Point(152, 37);
            this.kAdi.Name = "kAdi";
            this.kAdi.Size = new System.Drawing.Size(131, 19);
            this.kAdi.TabIndex = 24;
            // 
            // GuncelleBtn
            // 
            this.GuncelleBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GuncelleBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.GuncelleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GuncelleBtn.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.GuncelleBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.GuncelleBtn.Location = new System.Drawing.Point(193, 559);
            this.GuncelleBtn.Name = "GuncelleBtn";
            this.GuncelleBtn.Size = new System.Drawing.Size(515, 66);
            this.GuncelleBtn.TabIndex = 27;
            this.GuncelleBtn.Text = "Güncelle";
            this.GuncelleBtn.UseVisualStyleBackColor = false;
            this.GuncelleBtn.Click += new System.EventHandler(this.GuncelleBtn_Click);
            // 
            // rutbeELO
            // 
            this.rutbeELO.AutoSize = true;
            this.rutbeELO.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.rutbeELO.Location = new System.Drawing.Point(189, 110);
            this.rutbeELO.Name = "rutbeELO";
            this.rutbeELO.Size = new System.Drawing.Size(41, 20);
            this.rutbeELO.TabIndex = 30;
            this.rutbeELO.Text = "ELO";
            // 
            // rutbeAd
            // 
            this.rutbeAd.AutoSize = true;
            this.rutbeAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rutbeAd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.rutbeAd.Location = new System.Drawing.Point(189, 80);
            this.rutbeAd.Name = "rutbeAd";
            this.rutbeAd.Size = new System.Drawing.Size(94, 20);
            this.rutbeAd.TabIndex = 29;
            this.rutbeAd.Text = "GM (2500)";
            // 
            // rutbeTas
            // 
            this.rutbeTas.Image = global::Caïssa.Properties.Resources.gm;
            this.rutbeTas.Location = new System.Drawing.Point(135, 80);
            this.rutbeTas.Name = "rutbeTas";
            this.rutbeTas.Size = new System.Drawing.Size(48, 50);
            this.rutbeTas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rutbeTas.TabIndex = 28;
            this.rutbeTas.TabStop = false;
            // 
            // Labelcinsiyet
            // 
            this.Labelcinsiyet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Labelcinsiyet.AutoSize = true;
            this.Labelcinsiyet.BackColor = System.Drawing.Color.Transparent;
            this.Labelcinsiyet.Font = new System.Drawing.Font("Arial", 11F);
            this.Labelcinsiyet.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Labelcinsiyet.Location = new System.Drawing.Point(303, 503);
            this.Labelcinsiyet.Name = "Labelcinsiyet";
            this.Labelcinsiyet.Size = new System.Drawing.Size(95, 25);
            this.Labelcinsiyet.TabIndex = 67;
            this.Labelcinsiyet.Text = "Cinsiyet:";
            // 
            // LabeldgmTarihi
            // 
            this.LabeldgmTarihi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabeldgmTarihi.AutoSize = true;
            this.LabeldgmTarihi.BackColor = System.Drawing.Color.Transparent;
            this.LabeldgmTarihi.Font = new System.Drawing.Font("Arial", 11F);
            this.LabeldgmTarihi.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LabeldgmTarihi.Location = new System.Drawing.Point(303, 450);
            this.LabeldgmTarihi.Name = "LabeldgmTarihi";
            this.LabeldgmTarihi.Size = new System.Drawing.Size(146, 25);
            this.LabeldgmTarihi.TabIndex = 66;
            this.LabeldgmTarihi.Text = "Doğum Tarihi:";
            // 
            // dgmTarihi
            // 
            this.dgmTarihi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgmTarihi.Location = new System.Drawing.Point(463, 450);
            this.dgmTarihi.Name = "dgmTarihi";
            this.dgmTarihi.Size = new System.Drawing.Size(152, 26);
            this.dgmTarihi.TabIndex = 65;
            // 
            // kadin
            // 
            this.kadin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.kadin.AutoSize = true;
            this.kadin.Font = new System.Drawing.Font("Arial", 11F);
            this.kadin.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.kadin.Location = new System.Drawing.Point(522, 503);
            this.kadin.Name = "kadin";
            this.kadin.Size = new System.Drawing.Size(93, 29);
            this.kadin.TabIndex = 64;
            this.kadin.TabStop = true;
            this.kadin.Text = "Kadın";
            this.kadin.UseVisualStyleBackColor = true;
            this.kadin.CheckedChanged += new System.EventHandler(this.kadin_CheckedChanged);
            // 
            // erkek
            // 
            this.erkek.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.erkek.AutoSize = true;
            this.erkek.Font = new System.Drawing.Font("Arial", 11F);
            this.erkek.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.erkek.Location = new System.Drawing.Point(417, 503);
            this.erkek.Name = "erkek";
            this.erkek.Size = new System.Drawing.Size(91, 29);
            this.erkek.TabIndex = 63;
            this.erkek.TabStop = true;
            this.erkek.Text = "Erkek";
            this.erkek.UseVisualStyleBackColor = true;
            this.erkek.CheckedChanged += new System.EventHandler(this.erkek_CheckedChanged);
            // 
            // LabelsoyAd
            // 
            this.LabelsoyAd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelsoyAd.AutoSize = true;
            this.LabelsoyAd.BackColor = System.Drawing.Color.Transparent;
            this.LabelsoyAd.Font = new System.Drawing.Font("Arial", 11F);
            this.LabelsoyAd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LabelsoyAd.Location = new System.Drawing.Point(488, 173);
            this.LabelsoyAd.Name = "LabelsoyAd";
            this.LabelsoyAd.Size = new System.Drawing.Size(81, 25);
            this.LabelsoyAd.TabIndex = 62;
            this.LabelsoyAd.Text = "Soyad:";
            // 
            // panel6
            // 
            this.panel6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel6.Location = new System.Drawing.Point(469, 229);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(120, 1);
            this.panel6.TabIndex = 61;
            // 
            // soyad
            // 
            this.soyad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.soyad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.soyad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.soyad.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.soyad.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.soyad.Location = new System.Drawing.Point(469, 206);
            this.soyad.Name = "soyad";
            this.soyad.Size = new System.Drawing.Size(120, 19);
            this.soyad.TabIndex = 60;
            // 
            // Labelad
            // 
            this.Labelad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Labelad.AutoSize = true;
            this.Labelad.BackColor = System.Drawing.Color.Transparent;
            this.Labelad.Font = new System.Drawing.Font("Arial", 11F);
            this.Labelad.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Labelad.Location = new System.Drawing.Point(365, 173);
            this.Labelad.Name = "Labelad";
            this.Labelad.Size = new System.Drawing.Size(45, 25);
            this.Labelad.TabIndex = 59;
            this.Labelad.Text = "Ad:";
            // 
            // panel5
            // 
            this.panel5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel5.Location = new System.Drawing.Point(337, 229);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(120, 1);
            this.panel5.TabIndex = 58;
            // 
            // ad
            // 
            this.ad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ad.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ad.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ad.Location = new System.Drawing.Point(337, 206);
            this.ad.Name = "ad";
            this.ad.Size = new System.Drawing.Size(120, 19);
            this.ad.TabIndex = 57;
            // 
            // LabelGSM
            // 
            this.LabelGSM.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelGSM.AutoSize = true;
            this.LabelGSM.BackColor = System.Drawing.Color.Transparent;
            this.LabelGSM.Font = new System.Drawing.Font("Arial", 11F);
            this.LabelGSM.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LabelGSM.Location = new System.Drawing.Point(313, 371);
            this.LabelGSM.Name = "LabelGSM";
            this.LabelGSM.Size = new System.Drawing.Size(69, 25);
            this.LabelGSM.TabIndex = 56;
            this.LabelGSM.Text = "GSM:";
            // 
            // LabelePosta
            // 
            this.LabelePosta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelePosta.AutoSize = true;
            this.LabelePosta.BackColor = System.Drawing.Color.Transparent;
            this.LabelePosta.Font = new System.Drawing.Font("Arial", 11F);
            this.LabelePosta.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LabelePosta.Location = new System.Drawing.Point(313, 279);
            this.LabelePosta.Name = "LabelePosta";
            this.LabelePosta.Size = new System.Drawing.Size(97, 25);
            this.LabelePosta.TabIndex = 55;
            this.LabelePosta.Text = "E-Posta:";
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Location = new System.Drawing.Point(330, 427);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(265, 1);
            this.panel3.TabIndex = 54;
            // 
            // gsm
            // 
            this.gsm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gsm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.gsm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gsm.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gsm.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.gsm.Location = new System.Drawing.Point(330, 404);
            this.gsm.MaxLength = 10;
            this.gsm.Name = "gsm";
            this.gsm.Size = new System.Drawing.Size(265, 19);
            this.gsm.TabIndex = 53;
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.Location = new System.Drawing.Point(330, 330);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(265, 1);
            this.panel4.TabIndex = 52;
            // 
            // ePosta
            // 
            this.ePosta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ePosta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ePosta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ePosta.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ePosta.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ePosta.Location = new System.Drawing.Point(330, 307);
            this.ePosta.Name = "ePosta";
            this.ePosta.Size = new System.Drawing.Size(265, 19);
            this.ePosta.TabIndex = 51;
            // 
            // Labelsifre
            // 
            this.Labelsifre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Labelsifre.AutoSize = true;
            this.Labelsifre.BackColor = System.Drawing.Color.Transparent;
            this.Labelsifre.Font = new System.Drawing.Font("Arial", 11F);
            this.Labelsifre.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Labelsifre.Location = new System.Drawing.Point(313, 78);
            this.Labelsifre.Name = "Labelsifre";
            this.Labelsifre.Size = new System.Drawing.Size(64, 25);
            this.Labelsifre.TabIndex = 50;
            this.Labelsifre.Text = "Şifre:";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Location = new System.Drawing.Point(330, 134);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(265, 1);
            this.panel2.TabIndex = 49;
            // 
            // sifre
            // 
            this.sifre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sifre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.sifre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sifre.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sifre.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.sifre.Location = new System.Drawing.Point(330, 111);
            this.sifre.Name = "sifre";
            this.sifre.PasswordChar = '*';
            this.sifre.Size = new System.Drawing.Size(265, 19);
            this.sifre.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(12, 649);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(810, 17);
            this.label1.TabIndex = 68;
            this.label1.Text = "*Sadece değiştirmek istediğiniz alanları değiştirip \"Güncelle\" butonuna basınız. " +
    "Şifrenizi değiştirmek istemiyorsanız boş bırakınız.";
            // 
            // profilim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(890, 675);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Labelcinsiyet);
            this.Controls.Add(this.LabeldgmTarihi);
            this.Controls.Add(this.dgmTarihi);
            this.Controls.Add(this.kadin);
            this.Controls.Add(this.erkek);
            this.Controls.Add(this.LabelsoyAd);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.soyad);
            this.Controls.Add(this.Labelad);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.ad);
            this.Controls.Add(this.LabelGSM);
            this.Controls.Add(this.LabelePosta);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.gsm);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.ePosta);
            this.Controls.Add(this.Labelsifre);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.sifre);
            this.Controls.Add(this.rutbeELO);
            this.Controls.Add(this.rutbeAd);
            this.Controls.Add(this.rutbeTas);
            this.Controls.Add(this.GuncelleBtn);
            this.Controls.Add(this.LabelkAdi);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kAdi);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "profilim";
            this.Text = "profilim";
            this.Load += new System.EventHandler(this.profilim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rutbeTas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LabelkAdi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox kAdi;
        private System.Windows.Forms.Button GuncelleBtn;
        private System.Windows.Forms.Label rutbeELO;
        private System.Windows.Forms.Label rutbeAd;
        private System.Windows.Forms.PictureBox rutbeTas;
        private System.Windows.Forms.Label Labelcinsiyet;
        private System.Windows.Forms.Label LabeldgmTarihi;
        private System.Windows.Forms.DateTimePicker dgmTarihi;
        private System.Windows.Forms.RadioButton kadin;
        private System.Windows.Forms.RadioButton erkek;
        private System.Windows.Forms.Label LabelsoyAd;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox soyad;
        private System.Windows.Forms.Label Labelad;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox ad;
        private System.Windows.Forms.Label LabelGSM;
        private System.Windows.Forms.Label LabelePosta;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox gsm;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox ePosta;
        private System.Windows.Forms.Label Labelsifre;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox sifre;
        private System.Windows.Forms.Label label1;
    }
}