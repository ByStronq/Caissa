namespace Caïssa
{
    partial class macBul
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
            this.macBulSayaci = new System.Windows.Forms.Timer(this.components);
            this.hour = new System.Windows.Forms.Label();
            this.minute = new System.Windows.Forms.Label();
            this.second = new System.Windows.Forms.Label();
            this.ayrac1 = new System.Windows.Forms.Label();
            this.ayrac2 = new System.Windows.Forms.Label();
            this.durum = new System.Windows.Forms.Label();
            this.kabulEt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // macBulSayaci
            // 
            this.macBulSayaci.Enabled = true;
            this.macBulSayaci.Interval = 1000;
            this.macBulSayaci.Tick += new System.EventHandler(this.macBulSayaci_Tick);
            // 
            // hour
            // 
            this.hour.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.hour.AutoSize = true;
            this.hour.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.hour.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.hour.Location = new System.Drawing.Point(312, 335);
            this.hour.Name = "hour";
            this.hour.Size = new System.Drawing.Size(64, 46);
            this.hour.TabIndex = 0;
            this.hour.Text = "00";
            // 
            // minute
            // 
            this.minute.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.minute.AutoSize = true;
            this.minute.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.minute.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.minute.Location = new System.Drawing.Point(419, 335);
            this.minute.Name = "minute";
            this.minute.Size = new System.Drawing.Size(64, 46);
            this.minute.TabIndex = 1;
            this.minute.Text = "00";
            // 
            // second
            // 
            this.second.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.second.AutoSize = true;
            this.second.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.second.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.second.Location = new System.Drawing.Point(526, 335);
            this.second.Name = "second";
            this.second.Size = new System.Drawing.Size(64, 46);
            this.second.TabIndex = 2;
            this.second.Text = "00";
            // 
            // ayrac1
            // 
            this.ayrac1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ayrac1.AutoSize = true;
            this.ayrac1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ayrac1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ayrac1.Location = new System.Drawing.Point(489, 335);
            this.ayrac1.Name = "ayrac1";
            this.ayrac1.Size = new System.Drawing.Size(31, 46);
            this.ayrac1.TabIndex = 3;
            this.ayrac1.Text = ":";
            // 
            // ayrac2
            // 
            this.ayrac2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ayrac2.AutoSize = true;
            this.ayrac2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ayrac2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ayrac2.Location = new System.Drawing.Point(382, 335);
            this.ayrac2.Name = "ayrac2";
            this.ayrac2.Size = new System.Drawing.Size(31, 46);
            this.ayrac2.TabIndex = 4;
            this.ayrac2.Text = ":";
            // 
            // durum
            // 
            this.durum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.durum.AutoSize = true;
            this.durum.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.durum.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.durum.Location = new System.Drawing.Point(195, 187);
            this.durum.Name = "durum";
            this.durum.Size = new System.Drawing.Size(526, 69);
            this.durum.TabIndex = 5;
            this.durum.Text = "MAÇ ARANIYOR!!";
            // 
            // kabulEt
            // 
            this.kabulEt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.kabulEt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.kabulEt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kabulEt.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kabulEt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.kabulEt.Location = new System.Drawing.Point(206, 499);
            this.kabulEt.Name = "kabulEt";
            this.kabulEt.Size = new System.Drawing.Size(515, 66);
            this.kabulEt.TabIndex = 10;
            this.kabulEt.Text = "KABUL ET";
            this.kabulEt.UseVisualStyleBackColor = false;
            this.kabulEt.Visible = false;
            this.kabulEt.Click += new System.EventHandler(this.kabulEt_Click);
            // 
            // macBul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(912, 731);
            this.Controls.Add(this.kabulEt);
            this.Controls.Add(this.durum);
            this.Controls.Add(this.ayrac2);
            this.Controls.Add(this.ayrac1);
            this.Controls.Add(this.second);
            this.Controls.Add(this.minute);
            this.Controls.Add(this.hour);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "macBul";
            this.Text = "macBul";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer macBulSayaci;
        private System.Windows.Forms.Label hour;
        private System.Windows.Forms.Label minute;
        private System.Windows.Forms.Label second;
        private System.Windows.Forms.Label ayrac1;
        private System.Windows.Forms.Label ayrac2;
        private System.Windows.Forms.Label durum;
        private System.Windows.Forms.Button kabulEt;
    }
}