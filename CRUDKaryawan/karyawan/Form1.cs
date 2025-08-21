// Kode C# Windows Form dengan fitur Foto, TTL, Validasi, CRUD Lengkap, dan Pencarian
using System;
using System.Data.Odbc;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace karyawan
{
    public partial class Form1 : Form
    {
        TextBox txtNIK, txtNama, txtSearch;
        DateTimePicker dtpTTL;
        RadioButton rbLaki, rbPerempuan;
        ComboBox cmbAgama;
        DataGridView dgvKaryawan;
        Button btnSubmit, btnReset, btnEdit, btnRemove, btnSearch, btnPilihFoto;
        PictureBox picFoto;
        string fotoPath = "";

        OdbcConnection conn;
        bool isEditMode = false;
        string nikLama = "";

        public Form1()
        {
            InitializeComponent();
            this.Text = "Data Karyawan";
            this.Width = 1050;
            this.Height = 650;

            GroupBox groupBox = new GroupBox();
            groupBox.Text = "Input Data Karyawan";
            groupBox.SetBounds(20, 20, 1000, 250);

            Label lblNIK = new Label() { Text = "Nomor Induk", Left = 20, Top = 30, Width = 120 };
            txtNIK = new TextBox() { Left = 150, Top = 25, Width = 200 };

            Label lblNama = new Label() { Text = "Nama", Left = 20, Top = 65, Width = 120 };
            txtNama = new TextBox() { Left = 150, Top = 60, Width = 200 };

            Label lblTTL = new Label() { Text = "Tanggal Lahir", Left = 20, Top = 100, Width = 120 };
            dtpTTL = new DateTimePicker() { Left = 150, Top = 95, Width = 200, Format = DateTimePickerFormat.Short };

            Label lblJK = new Label() { Text = "Jenis Kelamin", Left = 20, Top = 135, Width = 120 };
            rbLaki = new RadioButton() { Text = "Laki-laki", Left = 150, Top = 130, Width = 80 };
            rbPerempuan = new RadioButton() { Text = "Perempuan", Left = 240, Top = 130, Width = 100 };

            Label lblAgama = new Label() { Text = "Agama", Left = 20, Top = 170, Width = 120 };
            cmbAgama = new ComboBox() { Left = 150, Top = 165, Width = 200 };
            cmbAgama.Items.AddRange(new string[] { "Islam", "Kristen", "Katolik", "Hindu", "Budha", "Konghucu" });

            btnSubmit = new Button() { Text = "Submit", Left = 370, Top = 25, Width = 100 };
            btnReset = new Button() { Text = "Reset", Left = 480, Top = 25, Width = 100 };
            btnEdit = new Button() { Text = "Edit", Left = 370, Top = 65, Width = 100 };
            btnRemove = new Button() { Text = "Remove", Left = 480, Top = 65, Width = 100 };

            Label lblFoto = new Label() { Text = "Foto", Left = 650, Top = 30 };
            picFoto = new PictureBox() { Left = 650, Top = 55, Width = 120, Height = 120, BorderStyle = BorderStyle.FixedSingle, SizeMode = PictureBoxSizeMode.StretchImage };
            btnPilihFoto = new Button() { Text = "Pilih Foto", Left = 650, Top = 180, Width = 120 };

            groupBox.Controls.AddRange(new Control[] {
                lblNIK, txtNIK,
                lblNama, txtNama,
                lblTTL, dtpTTL,
                lblJK, rbLaki, rbPerempuan,
                lblAgama, cmbAgama,
                btnSubmit, btnReset, btnEdit, btnRemove,
                lblFoto, picFoto, btnPilihFoto
            });

            txtSearch = new TextBox() { Left = 650, Top = 280, Width = 200 };
            btnSearch = new Button() { Text = "Search", Left = 860, Top = 278, Width = 80 };

            dgvKaryawan = new DataGridView()
            {
                Left = 20,
                Top = 320,
                Width = 980,
                Height = 280,
                ColumnCount = 5,
                AllowUserToAddRows = false
            };
            dgvKaryawan.Columns[0].Name = "NIK";
            dgvKaryawan.Columns[1].Name = "Nama";
            dgvKaryawan.Columns[2].Name = "TTL";
            dgvKaryawan.Columns[3].Name = "Jenis Kelamin";
            dgvKaryawan.Columns[4].Name = "Agama";

            btnPilihFoto.Click += (s, e) =>
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fotoPath = ofd.FileName;
                    picFoto.Image = Image.FromFile(fotoPath);
                }
            };

            btnSubmit.Click += (s, e) =>
            {
                string nik = txtNIK.Text.Trim();
                string nama = txtNama.Text.Trim();
                string ttl = dtpTTL.Value.ToString("yyyy-MM-dd");
                string jk = rbLaki.Checked ? "Laki-laki" : rbPerempuan.Checked ? "Perempuan" : "-";
                string agama = cmbAgama.Text;

                if (nik.Length != 10)
                {
                    MessageBox.Show("NIK harus 10 digit.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(jk) || string.IsNullOrWhiteSpace(agama))
                {
                    MessageBox.Show("Lengkapi semua data terlebih dahulu.");
                    return;
                }

                string filename = Path.GetFileName(fotoPath);
                string targetPath = Path.Combine("images", filename);
                if (!Directory.Exists("images")) Directory.CreateDirectory("images");
                if (!File.Exists(targetPath) && File.Exists(fotoPath)) File.Copy(fotoPath, targetPath);

                try
                {
                    Koneksi();
                    conn.Open();
                    string query = isEditMode
                        ? $"UPDATE tabel_karyawan SET nik='{nik}', nama='{nama}', ttl='{ttl}', jenis_kelamin='{jk}', agama='{agama}', foto='{filename}' WHERE nik='{nikLama}'"
                        : $"INSERT INTO tabel_karyawan (nik, nama, ttl, jenis_kelamin, agama, foto) VALUES ('{nik}', '{nama}', '{ttl}', '{jk}', '{agama}', '{filename}')";

                    OdbcCommand cmd = new OdbcCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show(isEditMode ? "Data berhasil diupdate." : "Data berhasil disimpan.");
                    TampilkanData();
                    isEditMode = false; nikLama = ""; txtNIK.Enabled = true;
                    txtNIK.Clear(); txtNama.Clear(); cmbAgama.SelectedIndex = -1;
                    rbLaki.Checked = rbPerempuan.Checked = false; picFoto.Image = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menyimpan: " + ex.Message);
                }
            };

            btnEdit.Click += (s, e) =>
            {
                if (dgvKaryawan.CurrentRow != null && dgvKaryawan.CurrentRow.Cells[0].Value != null)
                {
                    string nik = dgvKaryawan.CurrentRow.Cells[0].Value.ToString();
                    txtNIK.Text = nik;
                    txtNama.Text = dgvKaryawan.CurrentRow.Cells[1].Value.ToString();
                    dtpTTL.Value = DateTime.Parse(dgvKaryawan.CurrentRow.Cells[2].Value.ToString());
                    string jk = dgvKaryawan.CurrentRow.Cells[3].Value.ToString();
                    if (jk == "Laki-laki") rbLaki.Checked = true; else if (jk == "Perempuan") rbPerempuan.Checked = true;
                    cmbAgama.Text = dgvKaryawan.CurrentRow.Cells[4].Value.ToString();

                    isEditMode = true;
                    nikLama = nik;
                    txtNIK.Enabled = true;
                }
            };

            btnRemove.Click += (s, e) =>
            {
                if (dgvKaryawan.CurrentRow != null && dgvKaryawan.CurrentRow.Cells[0].Value != null)
                {
                    string nik = dgvKaryawan.CurrentRow.Cells[0].Value.ToString();
                    DialogResult dr = MessageBox.Show("Yakin hapus NIK: " + nik + "?", "Konfirmasi", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        try
                        {
                            Koneksi();
                            conn.Open();
                            string query = $"DELETE FROM tabel_karyawan WHERE nik='{nik}'";
                            new OdbcCommand(query, conn).ExecuteNonQuery();
                            conn.Close();
                            MessageBox.Show("Data dihapus.");
                            TampilkanData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Gagal hapus: " + ex.Message);
                        }
                    }
                }
            };

            btnSearch.Click += (s, e) =>
            {
                string keyword = txtSearch.Text.ToLower();
                try
                {
                    dgvKaryawan.Rows.Clear();
                    Koneksi();
                    conn.Open();
                    string query = $"SELECT nik, nama, ttl, jenis_kelamin, agama FROM tabel_karyawan WHERE LOWER(nik) LIKE '%{keyword}%' OR LOWER(nama) LIKE '%{keyword}%'";
                    OdbcCommand cmd = new OdbcCommand(query, conn);
                    OdbcDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        dgvKaryawan.Rows.Add(
                            reader["nik"].ToString(),
                            reader["nama"].ToString(),
                            reader["ttl"].ToString(),
                            reader["jenis_kelamin"].ToString(),
                            reader["agama"].ToString()
                        );
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal mencari: " + ex.Message);
                }
            };

            this.Controls.Add(groupBox);
            this.Controls.Add(txtSearch);
            this.Controls.Add(btnSearch);
            this.Controls.Add(dgvKaryawan);
            TampilkanData();
        }

        void Koneksi()
        {
            string connStr = "Driver={MySQL ODBC 9.4 Unicode Driver};Server=localhost;Database=db_karyawan;User=root;Password=;";
            conn = new OdbcConnection(connStr);
        }

        void TampilkanData()
        {
            try
            {
                dgvKaryawan.Rows.Clear();
                Koneksi();
                conn.Open();
                string query = "SELECT nik, nama, ttl, jenis_kelamin, agama FROM tabel_karyawan";
                OdbcCommand cmd = new OdbcCommand(query, conn);
                OdbcDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dgvKaryawan.Rows.Add(
                        reader["nik"].ToString(),
                        reader["nama"].ToString(),
                        reader["ttl"].ToString(),
                        reader["jenis_kelamin"].ToString(),
                        reader["agama"].ToString()
                    );
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan: " + ex.Message);
            }
        }
    }
}