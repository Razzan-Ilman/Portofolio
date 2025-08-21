using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace AplikasiPencatatanWarga
{
    public partial class frmDataWarga : Form
    {
        private SQLiteConnection conn;
        private string selectedNIK = string.Empty;

        public frmDataWarga()
        {
            InitializeComponent();
            conn = new SQLiteConnection("Data Source=warga.db;Version=3;");
            CreateTableIfNotExists();
            LoadData();

            // Isi ComboBox di sini
            cmbJenisKelamin.Items.AddRange(new[] { "Laki-laki", "Perempuan" });
            cmbStatusPerkawinan.Items.AddRange(new[] { "Belum Kawin", "Kawin", "Cerai Hidup", "Cerai Mati" });
        }

        private void CreateTableIfNotExists()
        {
            conn.Open();
            string sql = @"CREATE TABLE IF NOT EXISTS warga (
                            NIK TEXT PRIMARY KEY,
                            NamaLengkap TEXT,
                            TanggalLahir TEXT,
                            JenisKelamin TEXT,
                            Alamat TEXT,
                            Pekerjaan TEXT,
                            StatusPerkawinan TEXT)";
            var cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void LoadData()
        {
            conn.Open();
            var adapter = new SQLiteDataAdapter("SELECT * FROM warga", conn);
            var dt = new DataTable();
            adapter.Fill(dt);
            dgvWarga.DataSource = dt;
            conn.Close();
        }

        private void ResetForm()
        {
            txtNIK.Text = "";
            txtNamaLengkap.Text = "";
            dtpTanggalLahir.Value = DateTime.Now;
            cmbJenisKelamin.SelectedIndex = -1;
            txtAlamat.Text = "";
            txtPekerjaan.Text = "";
            cmbStatusPerkawinan.SelectedIndex = -1;
            txtNIK.ReadOnly = false;
            selectedNIK = string.Empty;
            dgvWarga.ClearSelection();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            conn.Open();
            string sql = "INSERT INTO warga VALUES (@nik, @nama, @tgl, @jk, @alamat, @pekerjaan, @status)";
            var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nik", txtNIK.Text);
            cmd.Parameters.AddWithValue("@nama", txtNamaLengkap.Text);
            cmd.Parameters.AddWithValue("@tgl", dtpTanggalLahir.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@jk", cmbJenisKelamin.Text);
            cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
            cmd.Parameters.AddWithValue("@pekerjaan", txtPekerjaan.Text);
            cmd.Parameters.AddWithValue("@status", cmbStatusPerkawinan.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            LoadData();
            ResetForm();
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedNIK)) return;

            conn.Open();
            string sql = @"UPDATE warga SET 
                            NamaLengkap = @nama,
                            TanggalLahir = @tgl,
                            JenisKelamin = @jk,
                            Alamat = @alamat,
                            Pekerjaan = @pekerjaan,
                            StatusPerkawinan = @status
                            WHERE NIK = @nik";
            var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nik", txtNIK.Text);
            cmd.Parameters.AddWithValue("@nama", txtNamaLengkap.Text);
            cmd.Parameters.AddWithValue("@tgl", dtpTanggalLahir.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@jk", cmbJenisKelamin.Text);
            cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
            cmd.Parameters.AddWithValue("@pekerjaan", txtPekerjaan.Text);
            cmd.Parameters.AddWithValue("@status", cmbStatusPerkawinan.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            LoadData();
            ResetForm();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedNIK)) return;

            conn.Open();
            string sql = "DELETE FROM warga WHERE NIK = @nik";
            var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nik", selectedNIK);
            cmd.ExecuteNonQuery();
            conn.Close();
            LoadData();
            ResetForm();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void dgvWarga_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvWarga.Rows[e.RowIndex];
                txtNIK.Text = row.Cells["NIK"].Value.ToString();
                txtNamaLengkap.Text = row.Cells["NamaLengkap"].Value.ToString();
                var tanggalLahirObj = row.Cells["TanggalLahir"].Value;
                dtpTanggalLahir.Value = !string.IsNullOrEmpty(tanggalLahirObj?.ToString())
                    ? DateTime.Parse(tanggalLahirObj.ToString())
                    : DateTime.Now;
                cmbJenisKelamin.Text = row.Cells["JenisKelamin"].Value.ToString();
                txtAlamat.Text = row.Cells["Alamat"].Value.ToString();
                txtPekerjaan.Text = row.Cells["Pekerjaan"].Value.ToString();
                cmbStatusPerkawinan.Text = row.Cells["StatusPerkawinan"].Value.ToString();
                selectedNIK = txtNIK.Text;
                txtNIK.ReadOnly = true;
            }
        }
    }
}
