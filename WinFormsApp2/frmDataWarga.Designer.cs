namespace AplikasiPencatatanWarga
{
    partial class frmDataWarga : Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbJenisKelamin;
        private System.Windows.Forms.ComboBox cmbStatusPerkawinan;
        private System.Windows.Forms.DataGridView dgvWarga;
        private System.Windows.Forms.TextBox txtNIK;
        private System.Windows.Forms.TextBox txtNamaLengkap;
        private System.Windows.Forms.DateTimePicker dtpTanggalLahir;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.TextBox txtPekerjaan;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnUbah;
        private System.Windows.Forms.Button btnHapus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtNIK = new System.Windows.Forms.TextBox();
            this.txtNamaLengkap = new System.Windows.Forms.TextBox();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.txtPekerjaan = new System.Windows.Forms.TextBox();
            this.cmbJenisKelamin = new System.Windows.Forms.ComboBox();
            this.cmbStatusPerkawinan = new System.Windows.Forms.ComboBox();
            this.dtpTanggalLahir = new System.Windows.Forms.DateTimePicker();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnUbah = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.dgvWarga = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvWarga)).BeginInit();
            this.SuspendLayout();

            // txtNIK
            this.txtNIK.Location = new System.Drawing.Point(30, 30);
            this.txtNIK.Name = "txtNIK";
            this.txtNIK.Size = new System.Drawing.Size(200, 23);
            this.txtNIK.PlaceholderText = "NIK";

            // txtNamaLengkap
            this.txtNamaLengkap.Location = new System.Drawing.Point(30, 60);
            this.txtNamaLengkap.Name = "txtNamaLengkap";
            this.txtNamaLengkap.Size = new System.Drawing.Size(200, 23);
            this.txtNamaLengkap.PlaceholderText = "Nama Lengkap";

            // dtpTanggalLahir
            this.dtpTanggalLahir.Location = new System.Drawing.Point(30, 90);
            this.dtpTanggalLahir.Name = "dtpTanggalLahir";
            this.dtpTanggalLahir.Size = new System.Drawing.Size(200, 23);

            // cmbJenisKelamin
            this.cmbJenisKelamin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJenisKelamin.Location = new System.Drawing.Point(30, 120);
            this.cmbJenisKelamin.Name = "cmbJenisKelamin";
            this.cmbJenisKelamin.Size = new System.Drawing.Size(200, 23);

            // txtAlamat
            this.txtAlamat.Location = new System.Drawing.Point(30, 150);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(200, 23);
            this.txtAlamat.PlaceholderText = "Alamat";

            // txtPekerjaan
            this.txtPekerjaan.Location = new System.Drawing.Point(30, 180);
            this.txtPekerjaan.Name = "txtPekerjaan";
            this.txtPekerjaan.Size = new System.Drawing.Size(200, 23);
            this.txtPekerjaan.PlaceholderText = "Pekerjaan";

            // cmbStatusPerkawinan
            this.cmbStatusPerkawinan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusPerkawinan.Location = new System.Drawing.Point(30, 210);
            this.cmbStatusPerkawinan.Name = "cmbStatusPerkawinan";
            this.cmbStatusPerkawinan.Size = new System.Drawing.Size(200, 23);

            // btnSimpan
            this.btnSimpan.Location = new System.Drawing.Point(250, 30);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(100, 30);
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);

            // btnReset
            this.btnReset.Location = new System.Drawing.Point(250, 70);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 30);
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            // btnUbah
            this.btnUbah.Location = new System.Drawing.Point(250, 110);
            this.btnUbah.Name = "btnUbah";
            this.btnUbah.Size = new System.Drawing.Size(100, 30);
            this.btnUbah.Text = "Ubah";
            this.btnUbah.UseVisualStyleBackColor = true;
            this.btnUbah.Click += new System.EventHandler(this.btnUbah_Click);

            // btnHapus
            this.btnHapus.Location = new System.Drawing.Point(250, 150);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(100, 30);
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);

            // dgvWarga
            this.dgvWarga.Location = new System.Drawing.Point(30, 250);
            this.dgvWarga.Name = "dgvWarga";
            this.dgvWarga.Size = new System.Drawing.Size(500, 200);
            this.dgvWarga.TabIndex = 0;
            this.dgvWarga.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWarga_CellClick);

            // frmDataWarga
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 481);
            this.Controls.Add(this.txtNIK);
            this.Controls.Add(this.txtNamaLengkap);
            this.Controls.Add(this.dtpTanggalLahir);
            this.Controls.Add(this.cmbJenisKelamin);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.txtPekerjaan);
            this.Controls.Add(this.cmbStatusPerkawinan);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnUbah);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.dgvWarga);
            this.Name = "frmDataWarga";
            this.Text = "Aplikasi Pencatatan Warga";
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarga)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
