namespace AplikasiPencatatanWarga
{
    partial class FormMenuUtama
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dataWargaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kegiatanWargaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keluarToolStripMenuItem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dataWargaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kegiatanWargaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keluarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.dataWargaToolStripMenuItem,
                this.kegiatanWargaToolStripMenuItem,
                this.keluarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dataWargaToolStripMenuItem
            // 
            this.dataWargaToolStripMenuItem.Name = "dataWargaToolStripMenuItem";
            this.dataWargaToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.dataWargaToolStripMenuItem.Text = "Data Warga";
            this.dataWargaToolStripMenuItem.Click += new System.EventHandler(this.dataWargaToolStripMenuItem_Click);
            // 
            // kegiatanWargaToolStripMenuItem
            // 
            this.kegiatanWargaToolStripMenuItem.Name = "kegiatanWargaToolStripMenuItem";
            this.kegiatanWargaToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.kegiatanWargaToolStripMenuItem.Text = "Kegiatan Warga";
            this.kegiatanWargaToolStripMenuItem.Click += new System.EventHandler(this.kegiatanWargaToolStripMenuItem_Click);
            // 
            // keluarToolStripMenuItem
            // 
            this.keluarToolStripMenuItem.Name = "keluarToolStripMenuItem";
            this.keluarToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.keluarToolStripMenuItem.Text = "Keluar";
            this.keluarToolStripMenuItem.Click += new System.EventHandler(this.keluarToolStripMenuItem_Click);
            // 
            // FormMenuUtama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMenuUtama";
            this.Text = "Menu Utama";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
