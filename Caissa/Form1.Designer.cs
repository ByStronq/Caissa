namespace Caïssa
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.test = new System.Windows.Forms.Button();
            this.panelBotlaOynaSubMenu = new System.Windows.Forms.Panel();
            this.zor = new System.Windows.Forms.Button();
            this.orta = new System.Windows.Forms.Button();
            this.kolay = new System.Windows.Forms.Button();
            this.botlaOyna = new System.Windows.Forms.Button();
            this.panelMacKurSubMenu = new System.Windows.Forms.Panel();
            this.dortluMacKur = new System.Windows.Forms.Button();
            this.soloMacKur = new System.Windows.Forms.Button();
            this.macKur = new System.Windows.Forms.Button();
            this.panelMacBulSubMenu = new System.Windows.Forms.Panel();
            this.takimliSatranc = new System.Windows.Forms.Button();
            this.dortluSatranc = new System.Windows.Forms.Button();
            this.klasik = new System.Windows.Forms.Button();
            this.macBul = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelProfileBadge = new System.Windows.Forms.Panel();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelSideMenu.SuspendLayout();
            this.panelBotlaOynaSubMenu.SuspendLayout();
            this.panelMacKurSubMenu.SuspendLayout();
            this.panelMacBulSubMenu.SuspendLayout();
            this.panelChildForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelSideMenu.Controls.Add(this.test);
            this.panelSideMenu.Controls.Add(this.panelBotlaOynaSubMenu);
            this.panelSideMenu.Controls.Add(this.botlaOyna);
            this.panelSideMenu.Controls.Add(this.panelMacKurSubMenu);
            this.panelSideMenu.Controls.Add(this.macKur);
            this.panelSideMenu.Controls.Add(this.panelMacBulSubMenu);
            this.panelSideMenu.Controls.Add(this.macBul);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(250, 831);
            this.panelSideMenu.TabIndex = 0;
            // 
            // test
            // 
            this.test.Dock = System.Windows.Forms.DockStyle.Top;
            this.test.FlatAppearance.BorderSize = 0;
            this.test.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.test.ForeColor = System.Drawing.Color.Gainsboro;
            this.test.Location = new System.Drawing.Point(0, 679);
            this.test.Name = "test";
            this.test.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.test.Size = new System.Drawing.Size(250, 53);
            this.test.TabIndex = 6;
            this.test.Text = "Test";
            this.test.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.test.UseVisualStyleBackColor = true;
            this.test.Visible = false;
            this.test.Click += new System.EventHandler(this.test_Click);
            // 
            // panelBotlaOynaSubMenu
            // 
            this.panelBotlaOynaSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelBotlaOynaSubMenu.Controls.Add(this.zor);
            this.panelBotlaOynaSubMenu.Controls.Add(this.orta);
            this.panelBotlaOynaSubMenu.Controls.Add(this.kolay);
            this.panelBotlaOynaSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBotlaOynaSubMenu.Location = new System.Drawing.Point(0, 522);
            this.panelBotlaOynaSubMenu.Name = "panelBotlaOynaSubMenu";
            this.panelBotlaOynaSubMenu.Size = new System.Drawing.Size(250, 157);
            this.panelBotlaOynaSubMenu.TabIndex = 5;
            // 
            // zor
            // 
            this.zor.Dock = System.Windows.Forms.DockStyle.Top;
            this.zor.Enabled = false;
            this.zor.FlatAppearance.BorderSize = 0;
            this.zor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zor.ForeColor = System.Drawing.Color.LightGray;
            this.zor.Location = new System.Drawing.Point(0, 104);
            this.zor.Name = "zor";
            this.zor.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.zor.Size = new System.Drawing.Size(250, 52);
            this.zor.TabIndex = 4;
            this.zor.Text = "Zor";
            this.zor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.zor.UseVisualStyleBackColor = true;
            this.zor.Click += new System.EventHandler(this.zor_Click);
            // 
            // orta
            // 
            this.orta.Dock = System.Windows.Forms.DockStyle.Top;
            this.orta.Enabled = false;
            this.orta.FlatAppearance.BorderSize = 0;
            this.orta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.orta.ForeColor = System.Drawing.Color.LightGray;
            this.orta.Location = new System.Drawing.Point(0, 52);
            this.orta.Name = "orta";
            this.orta.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.orta.Size = new System.Drawing.Size(250, 52);
            this.orta.TabIndex = 3;
            this.orta.Text = "Orta";
            this.orta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.orta.UseVisualStyleBackColor = true;
            this.orta.Click += new System.EventHandler(this.orta_Click);
            // 
            // kolay
            // 
            this.kolay.Dock = System.Windows.Forms.DockStyle.Top;
            this.kolay.Enabled = false;
            this.kolay.FlatAppearance.BorderSize = 0;
            this.kolay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kolay.ForeColor = System.Drawing.Color.LightGray;
            this.kolay.Location = new System.Drawing.Point(0, 0);
            this.kolay.Name = "kolay";
            this.kolay.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.kolay.Size = new System.Drawing.Size(250, 52);
            this.kolay.TabIndex = 2;
            this.kolay.Text = "Kolay";
            this.kolay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kolay.UseVisualStyleBackColor = true;
            this.kolay.Click += new System.EventHandler(this.kolay_Click);
            // 
            // botlaOyna
            // 
            this.botlaOyna.Dock = System.Windows.Forms.DockStyle.Top;
            this.botlaOyna.FlatAppearance.BorderSize = 0;
            this.botlaOyna.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botlaOyna.ForeColor = System.Drawing.Color.Gainsboro;
            this.botlaOyna.Location = new System.Drawing.Point(0, 469);
            this.botlaOyna.Name = "botlaOyna";
            this.botlaOyna.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.botlaOyna.Size = new System.Drawing.Size(250, 53);
            this.botlaOyna.TabIndex = 4;
            this.botlaOyna.Text = "BOT İLE OYNA";
            this.botlaOyna.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botlaOyna.UseVisualStyleBackColor = true;
            this.botlaOyna.Click += new System.EventHandler(this.botlaOyna_Click);
            // 
            // panelMacKurSubMenu
            // 
            this.panelMacKurSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelMacKurSubMenu.Controls.Add(this.dortluMacKur);
            this.panelMacKurSubMenu.Controls.Add(this.soloMacKur);
            this.panelMacKurSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMacKurSubMenu.Location = new System.Drawing.Point(0, 364);
            this.panelMacKurSubMenu.Name = "panelMacKurSubMenu";
            this.panelMacKurSubMenu.Size = new System.Drawing.Size(250, 105);
            this.panelMacKurSubMenu.TabIndex = 3;
            // 
            // dortluMacKur
            // 
            this.dortluMacKur.Dock = System.Windows.Forms.DockStyle.Top;
            this.dortluMacKur.Enabled = false;
            this.dortluMacKur.FlatAppearance.BorderSize = 0;
            this.dortluMacKur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dortluMacKur.ForeColor = System.Drawing.Color.LightGray;
            this.dortluMacKur.Location = new System.Drawing.Point(0, 52);
            this.dortluMacKur.Name = "dortluMacKur";
            this.dortluMacKur.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.dortluMacKur.Size = new System.Drawing.Size(250, 52);
            this.dortluMacKur.TabIndex = 2;
            this.dortluMacKur.Text = "Dörtlü";
            this.dortluMacKur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dortluMacKur.UseVisualStyleBackColor = true;
            this.dortluMacKur.Click += new System.EventHandler(this.dortluMacKur_Click);
            // 
            // soloMacKur
            // 
            this.soloMacKur.Dock = System.Windows.Forms.DockStyle.Top;
            this.soloMacKur.Enabled = false;
            this.soloMacKur.FlatAppearance.BorderSize = 0;
            this.soloMacKur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.soloMacKur.ForeColor = System.Drawing.Color.LightGray;
            this.soloMacKur.Location = new System.Drawing.Point(0, 0);
            this.soloMacKur.Name = "soloMacKur";
            this.soloMacKur.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.soloMacKur.Size = new System.Drawing.Size(250, 52);
            this.soloMacKur.TabIndex = 1;
            this.soloMacKur.Text = "Solo";
            this.soloMacKur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.soloMacKur.UseVisualStyleBackColor = true;
            this.soloMacKur.Click += new System.EventHandler(this.soloMacKur_Click);
            // 
            // macKur
            // 
            this.macKur.Dock = System.Windows.Forms.DockStyle.Top;
            this.macKur.FlatAppearance.BorderSize = 0;
            this.macKur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.macKur.ForeColor = System.Drawing.Color.Gainsboro;
            this.macKur.Location = new System.Drawing.Point(0, 311);
            this.macKur.Name = "macKur";
            this.macKur.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.macKur.Size = new System.Drawing.Size(250, 53);
            this.macKur.TabIndex = 2;
            this.macKur.Text = "MAÇ KUR";
            this.macKur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.macKur.UseVisualStyleBackColor = true;
            this.macKur.Click += new System.EventHandler(this.macKur_Click);
            // 
            // panelMacBulSubMenu
            // 
            this.panelMacBulSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelMacBulSubMenu.Controls.Add(this.takimliSatranc);
            this.panelMacBulSubMenu.Controls.Add(this.dortluSatranc);
            this.panelMacBulSubMenu.Controls.Add(this.klasik);
            this.panelMacBulSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMacBulSubMenu.Location = new System.Drawing.Point(0, 153);
            this.panelMacBulSubMenu.Name = "panelMacBulSubMenu";
            this.panelMacBulSubMenu.Size = new System.Drawing.Size(250, 158);
            this.panelMacBulSubMenu.TabIndex = 1;
            // 
            // takimliSatranc
            // 
            this.takimliSatranc.Dock = System.Windows.Forms.DockStyle.Top;
            this.takimliSatranc.Enabled = false;
            this.takimliSatranc.FlatAppearance.BorderSize = 0;
            this.takimliSatranc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.takimliSatranc.ForeColor = System.Drawing.Color.LightGray;
            this.takimliSatranc.Location = new System.Drawing.Point(0, 104);
            this.takimliSatranc.Name = "takimliSatranc";
            this.takimliSatranc.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.takimliSatranc.Size = new System.Drawing.Size(250, 52);
            this.takimliSatranc.TabIndex = 2;
            this.takimliSatranc.Text = "Dörtlü Takımlı";
            this.takimliSatranc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.takimliSatranc.UseVisualStyleBackColor = true;
            this.takimliSatranc.Click += new System.EventHandler(this.takimliSatranc_Click);
            // 
            // dortluSatranc
            // 
            this.dortluSatranc.Dock = System.Windows.Forms.DockStyle.Top;
            this.dortluSatranc.Enabled = false;
            this.dortluSatranc.FlatAppearance.BorderSize = 0;
            this.dortluSatranc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dortluSatranc.ForeColor = System.Drawing.Color.LightGray;
            this.dortluSatranc.Location = new System.Drawing.Point(0, 52);
            this.dortluSatranc.Name = "dortluSatranc";
            this.dortluSatranc.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.dortluSatranc.Size = new System.Drawing.Size(250, 52);
            this.dortluSatranc.TabIndex = 1;
            this.dortluSatranc.Text = "Dörtlü Solo";
            this.dortluSatranc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dortluSatranc.UseVisualStyleBackColor = true;
            this.dortluSatranc.Click += new System.EventHandler(this.dortluSatranc_Click);
            // 
            // klasik
            // 
            this.klasik.Dock = System.Windows.Forms.DockStyle.Top;
            this.klasik.Enabled = false;
            this.klasik.FlatAppearance.BorderSize = 0;
            this.klasik.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.klasik.ForeColor = System.Drawing.Color.LightGray;
            this.klasik.Location = new System.Drawing.Point(0, 0);
            this.klasik.Name = "klasik";
            this.klasik.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.klasik.Size = new System.Drawing.Size(250, 52);
            this.klasik.TabIndex = 0;
            this.klasik.Text = "Klasik";
            this.klasik.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.klasik.UseVisualStyleBackColor = true;
            this.klasik.Click += new System.EventHandler(this.klasik_Click);
            // 
            // macBul
            // 
            this.macBul.Dock = System.Windows.Forms.DockStyle.Top;
            this.macBul.FlatAppearance.BorderSize = 0;
            this.macBul.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.macBul.ForeColor = System.Drawing.Color.Gainsboro;
            this.macBul.Location = new System.Drawing.Point(0, 100);
            this.macBul.Name = "macBul";
            this.macBul.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.macBul.Size = new System.Drawing.Size(250, 53);
            this.macBul.TabIndex = 0;
            this.macBul.Text = "MAÇ BUL";
            this.macBul.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.macBul.UseVisualStyleBackColor = true;
            this.macBul.Click += new System.EventHandler(this.macBul_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackgroundImage = global::Caïssa.Properties.Resources.logo;
            this.panelLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(250, 100);
            this.panelLogo.TabIndex = 0;
            // 
            // panelProfileBadge
            // 
            this.panelProfileBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.panelProfileBadge.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelProfileBadge.Location = new System.Drawing.Point(250, 731);
            this.panelProfileBadge.Name = "panelProfileBadge";
            this.panelProfileBadge.Size = new System.Drawing.Size(912, 100);
            this.panelProfileBadge.TabIndex = 1;
            // 
            // panelChildForm
            // 
            this.panelChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelChildForm.Controls.Add(this.pictureBox1);
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(250, 0);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(912, 731);
            this.panelChildForm.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::Caïssa.Properties.Resources.filigran;
            this.pictureBox1.Location = new System.Drawing.Point(216, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(479, 612);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 831);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panelProfileBadge);
            this.Controls.Add(this.panelSideMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1184, 887);
            this.Name = "Form1";
            this.Opacity = 0.9D;
            this.Text = "Caïssa";
            this.panelSideMenu.ResumeLayout(false);
            this.panelBotlaOynaSubMenu.ResumeLayout(false);
            this.panelMacKurSubMenu.ResumeLayout(false);
            this.panelMacBulSubMenu.ResumeLayout(false);
            this.panelChildForm.ResumeLayout(false);
            this.panelChildForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button macBul;
        private System.Windows.Forms.Panel panelMacBulSubMenu;
        private System.Windows.Forms.Panel panelProfileBadge;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Button macKur;
        private System.Windows.Forms.Panel panelMacKurSubMenu;
        private System.Windows.Forms.Button botlaOyna;
        private System.Windows.Forms.Panel panelBotlaOynaSubMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Button klasik;
        public System.Windows.Forms.Button dortluSatranc;
        public System.Windows.Forms.Button takimliSatranc;
        public System.Windows.Forms.Button dortluMacKur;
        public System.Windows.Forms.Button soloMacKur;
        public System.Windows.Forms.Button orta;
        public System.Windows.Forms.Button kolay;
        public System.Windows.Forms.Button zor;
        public System.Windows.Forms.Button test;
    }
}

