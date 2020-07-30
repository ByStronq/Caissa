namespace Caïssa
{
    partial class Home
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
            this.pp = new System.Windows.Forms.PictureBox();
            this.kAdi = new System.Windows.Forms.Label();
            this.rutbeTas = new System.Windows.Forms.PictureBox();
            this.rutbeAd = new System.Windows.Forms.Label();
            this.arkadaslikContainer = new System.Windows.Forms.Panel();
            this.istekler = new System.Windows.Forms.FlowLayoutPanel();
            this.arkadaslar = new System.Windows.Forms.FlowLayoutPanel();
            this.rutbeELO = new System.Windows.Forms.Label();
            this.arkadasListeGetir = new System.Windows.Forms.Timer(this.components);
            this.mesajGetirici = new System.Windows.Forms.Timer(this.components);
            this.profilDuzenle = new System.Windows.Forms.Label();
            this.posts = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rutbeTas)).BeginInit();
            this.arkadaslikContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pp
            // 
            this.pp.Image = global::Caïssa.Properties.Resources.img_avatar3;
            this.pp.Location = new System.Drawing.Point(0, 0);
            this.pp.Name = "pp";
            this.pp.Size = new System.Drawing.Size(100, 96);
            this.pp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pp.TabIndex = 0;
            this.pp.TabStop = false;
            // 
            // kAdi
            // 
            this.kAdi.AutoSize = true;
            this.kAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kAdi.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.kAdi.Location = new System.Drawing.Point(106, 9);
            this.kAdi.Name = "kAdi";
            this.kAdi.Size = new System.Drawing.Size(158, 29);
            this.kAdi.TabIndex = 1;
            this.kAdi.Text = "Kullanıcı Adı";
            // 
            // rutbeTas
            // 
            this.rutbeTas.Image = global::Caïssa.Properties.Resources.gm;
            this.rutbeTas.Location = new System.Drawing.Point(106, 46);
            this.rutbeTas.Name = "rutbeTas";
            this.rutbeTas.Size = new System.Drawing.Size(48, 50);
            this.rutbeTas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rutbeTas.TabIndex = 2;
            this.rutbeTas.TabStop = false;
            // 
            // rutbeAd
            // 
            this.rutbeAd.AutoSize = true;
            this.rutbeAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rutbeAd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.rutbeAd.Location = new System.Drawing.Point(160, 46);
            this.rutbeAd.Name = "rutbeAd";
            this.rutbeAd.Size = new System.Drawing.Size(94, 20);
            this.rutbeAd.TabIndex = 3;
            this.rutbeAd.Text = "GM (2500)";
            // 
            // arkadaslikContainer
            // 
            this.arkadaslikContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.arkadaslikContainer.Controls.Add(this.istekler);
            this.arkadaslikContainer.Controls.Add(this.arkadaslar);
            this.arkadaslikContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.arkadaslikContainer.Location = new System.Drawing.Point(632, 0);
            this.arkadaslikContainer.Name = "arkadaslikContainer";
            this.arkadaslikContainer.Size = new System.Drawing.Size(280, 731);
            this.arkadaslikContainer.TabIndex = 4;
            // 
            // istekler
            // 
            this.istekler.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.istekler.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.istekler.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.istekler.Location = new System.Drawing.Point(0, 531);
            this.istekler.Name = "istekler";
            this.istekler.Size = new System.Drawing.Size(280, 200);
            this.istekler.TabIndex = 0;
            // 
            // arkadaslar
            // 
            this.arkadaslar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.arkadaslar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.arkadaslar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.arkadaslar.Location = new System.Drawing.Point(0, 0);
            this.arkadaslar.Name = "arkadaslar";
            this.arkadaslar.Size = new System.Drawing.Size(280, 731);
            this.arkadaslar.TabIndex = 1;
            // 
            // rutbeELO
            // 
            this.rutbeELO.AutoSize = true;
            this.rutbeELO.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.rutbeELO.Location = new System.Drawing.Point(160, 76);
            this.rutbeELO.Name = "rutbeELO";
            this.rutbeELO.Size = new System.Drawing.Size(41, 20);
            this.rutbeELO.TabIndex = 5;
            this.rutbeELO.Text = "ELO";
            // 
            // arkadasListeGetir
            // 
            this.arkadasListeGetir.Enabled = true;
            this.arkadasListeGetir.Interval = 10000;
            this.arkadasListeGetir.Tick += new System.EventHandler(this.arkadasListeGetir_Tick);
            // 
            // mesajGetirici
            // 
            this.mesajGetirici.Enabled = true;
            this.mesajGetirici.Interval = 1000;
            this.mesajGetirici.Tick += new System.EventHandler(this.mesajGetirici_Tick);
            // 
            // profilDuzenle
            // 
            this.profilDuzenle.BackColor = System.Drawing.Color.Transparent;
            this.profilDuzenle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.profilDuzenle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.profilDuzenle.ForeColor = System.Drawing.Color.Silver;
            this.profilDuzenle.Location = new System.Drawing.Point(261, 16);
            this.profilDuzenle.Name = "profilDuzenle";
            this.profilDuzenle.Size = new System.Drawing.Size(158, 22);
            this.profilDuzenle.TabIndex = 0;
            this.profilDuzenle.Text = "Profili Düzenle ✎";
            this.profilDuzenle.Click += new System.EventHandler(this.profilDuzenle_Click);
            // 
            // posts
            // 
            this.posts.Location = new System.Drawing.Point(12, 125);
            this.posts.Name = "posts";
            this.posts.Size = new System.Drawing.Size(614, 594);
            this.posts.TabIndex = 6;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(912, 731);
            this.Controls.Add(this.posts);
            this.Controls.Add(this.profilDuzenle);
            this.Controls.Add(this.rutbeELO);
            this.Controls.Add(this.arkadaslikContainer);
            this.Controls.Add(this.rutbeAd);
            this.Controls.Add(this.rutbeTas);
            this.Controls.Add(this.kAdi);
            this.Controls.Add(this.pp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rutbeTas)).EndInit();
            this.arkadaslikContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pp;
        private System.Windows.Forms.Label kAdi;
        private System.Windows.Forms.PictureBox rutbeTas;
        private System.Windows.Forms.Label rutbeAd;
        private System.Windows.Forms.Panel arkadaslikContainer;
        private System.Windows.Forms.Label rutbeELO;
        private System.Windows.Forms.FlowLayoutPanel arkadaslar;
        private System.Windows.Forms.FlowLayoutPanel istekler;
        private System.Windows.Forms.Timer arkadasListeGetir;
        private System.Windows.Forms.Timer mesajGetirici;
        private System.Windows.Forms.Label profilDuzenle;
        private System.Windows.Forms.FlowLayoutPanel posts;
    }
}