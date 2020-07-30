namespace Caïssa
{
    partial class test
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
            this.notasyon = new System.Windows.Forms.TextBox();
            this.pozisyon = new System.Windows.Forms.TextBox();
            this.testEt = new System.Windows.Forms.Button();
            this.ntsynLabel = new System.Windows.Forms.Label();
            this.pzsynLabel = new System.Windows.Forms.Label();
            this.geriDon = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // notasyon
            // 
            this.notasyon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.notasyon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.notasyon.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.notasyon.Location = new System.Drawing.Point(229, 323);
            this.notasyon.Name = "notasyon";
            this.notasyon.Size = new System.Drawing.Size(188, 26);
            this.notasyon.TabIndex = 0;
            // 
            // pozisyon
            // 
            this.pozisyon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pozisyon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.pozisyon.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.pozisyon.Location = new System.Drawing.Point(463, 323);
            this.pozisyon.Name = "pozisyon";
            this.pozisyon.Size = new System.Drawing.Size(188, 26);
            this.pozisyon.TabIndex = 1;
            // 
            // testEt
            // 
            this.testEt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.testEt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.testEt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testEt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.testEt.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.testEt.Location = new System.Drawing.Point(354, 387);
            this.testEt.Name = "testEt";
            this.testEt.Size = new System.Drawing.Size(164, 49);
            this.testEt.TabIndex = 2;
            this.testEt.Text = "Test Et!";
            this.testEt.UseVisualStyleBackColor = false;
            this.testEt.Click += new System.EventHandler(this.button1_Click);
            // 
            // ntsynLabel
            // 
            this.ntsynLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ntsynLabel.AutoSize = true;
            this.ntsynLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ntsynLabel.Location = new System.Drawing.Point(337, 300);
            this.ntsynLabel.Name = "ntsynLabel";
            this.ntsynLabel.Size = new System.Drawing.Size(80, 20);
            this.ntsynLabel.TabIndex = 3;
            this.ntsynLabel.Text = "Notasyon:";
            // 
            // pzsynLabel
            // 
            this.pzsynLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pzsynLabel.AutoSize = true;
            this.pzsynLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.pzsynLabel.Location = new System.Drawing.Point(459, 300);
            this.pzsynLabel.Name = "pzsynLabel";
            this.pzsynLabel.Size = new System.Drawing.Size(76, 20);
            this.pzsynLabel.TabIndex = 3;
            this.pzsynLabel.Text = "Pozisyon:";
            // 
            // geriDon
            // 
            this.geriDon.AutoSize = true;
            this.geriDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.geriDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.geriDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.geriDon.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.geriDon.Location = new System.Drawing.Point(0, 0);
            this.geriDon.Name = "geriDon";
            this.geriDon.Size = new System.Drawing.Size(114, 86);
            this.geriDon.TabIndex = 49;
            this.geriDon.Text = "←";
            this.geriDon.Click += new System.EventHandler(this.geriDon_Click);
            // 
            // test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(912, 731);
            this.Controls.Add(this.geriDon);
            this.Controls.Add(this.pzsynLabel);
            this.Controls.Add(this.ntsynLabel);
            this.Controls.Add(this.testEt);
            this.Controls.Add(this.pozisyon);
            this.Controls.Add(this.notasyon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "test";
            this.Text = "test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox notasyon;
        private System.Windows.Forms.TextBox pozisyon;
        private System.Windows.Forms.Button testEt;
        private System.Windows.Forms.Label ntsynLabel;
        private System.Windows.Forms.Label pzsynLabel;
        private System.Windows.Forms.Label geriDon;
    }
}