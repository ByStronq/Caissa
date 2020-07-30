namespace Caïssa
{
    partial class mesaj
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
            this.mesajlarPanel = new System.Windows.Forms.Panel();
            this.mesajTBx = new System.Windows.Forms.TextBox();
            this.mesajGetirici = new System.Windows.Forms.Timer(this.components);
            this.cevrimiciDurum = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // mesajlarPanel
            // 
            this.mesajlarPanel.Location = new System.Drawing.Point(0, 0);
            this.mesajlarPanel.Name = "mesajlarPanel";
            this.mesajlarPanel.Size = new System.Drawing.Size(800, 372);
            this.mesajlarPanel.TabIndex = 0;
            // 
            // mesajTBx
            // 
            this.mesajTBx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.mesajTBx.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.mesajTBx.Location = new System.Drawing.Point(0, 378);
            this.mesajTBx.Multiline = true;
            this.mesajTBx.Name = "mesajTBx";
            this.mesajTBx.Size = new System.Drawing.Size(800, 66);
            this.mesajTBx.TabIndex = 1;
            this.mesajTBx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mesajTBx_KeyDown);
            // 
            // mesajGetirici
            // 
            this.mesajGetirici.Enabled = true;
            this.mesajGetirici.Interval = 1000;
            this.mesajGetirici.Tick += new System.EventHandler(this.mesajGetirici_Tick);
            // 
            // cevrimiciDurum
            // 
            this.cevrimiciDurum.Enabled = true;
            this.cevrimiciDurum.Interval = 1000;
            this.cevrimiciDurum.Tick += new System.EventHandler(this.cevrimiciDurum_Tick);
            // 
            // mesaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mesajTBx);
            this.Controls.Add(this.mesajlarPanel);
            this.Name = "mesaj";
            this.Text = "mesaj";
            this.Load += new System.EventHandler(this.mesaj_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mesajlarPanel;
        private System.Windows.Forms.TextBox mesajTBx;
        private System.Windows.Forms.Timer mesajGetirici;
        private System.Windows.Forms.Timer cevrimiciDurum;
    }
}