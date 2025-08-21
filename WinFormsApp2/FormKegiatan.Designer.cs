namespace AplikasiPencatatanWarga
{
    partial class FormKegiatan
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtLokasi;
        private System.Windows.Forms.Button btnTambah;

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtLokasi = new System.Windows.Forms.TextBox();
            this.btnTambah = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(560, 300);
            this.dataGridView1.TabIndex = 0;
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(12, 320);
            this.txtNama.Size = new System.Drawing.Size(150, 20);
            this.txtNama.PlaceholderText = "Nama Kegiatan";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(170, 320);
            this.dateTimePicker1.Size = new System.Drawing.Size(150, 20);
            // 
            // txtLokasi
            // 
            this.txtLokasi.Location = new System.Drawing.Point(330, 320);
            this.txtLokasi.Size = new System.Drawing.Size(150, 20);
            this.txtLokasi.PlaceholderText = "Lokasi";
            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(490, 318);
            this.btnTambah.Size = new System.Drawing.Size(75, 23);
            this.btnTambah.Text = "Tambah";
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // FormKegiatan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtLokasi);
            this.Controls.Add(this.btnTambah);
            this.Name = "FormKegiatan";
            this.Text = "Data Kegiatan Warga";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
