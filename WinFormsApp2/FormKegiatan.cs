using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace AplikasiPencatatanWarga
{
    public partial class FormKegiatan : Form
    {
        SQLiteConnection conn;

        public FormKegiatan()
        {
            InitializeComponent();
            conn = new SQLiteConnection("Data Source=database.db;Version=3;");
            CekAtauBuatTabelKegiatan();
            IsiDataContoh();
            TampilkanDataKegiatan();
        }

        private void CekAtauBuatTabelKegiatan()
        {
            try
            {
                conn.Open();
                string sql = @"CREATE TABLE IF NOT EXISTS kegiatan (
                                id INTEGER PRIMARY KEY AUTOINCREMENT,
                                nama_kegiatan TEXT NOT NULL,
                                tanggal TEXT NOT NULL,
                                lokasi TEXT
                            );";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membuat tabel kegiatan: " + ex.Message);
            }
        }

        private void IsiDataContoh()
        {
            try
            {
                conn.Open();
                string cekData = "SELECT COUNT(*) FROM kegiatan;";
                SQLiteCommand cekCmd = new SQLiteCommand(cekData, conn);
                long jumlah = (long)cekCmd.ExecuteScalar();

                if (jumlah == 0)
                {
                    string sql = "INSERT INTO kegiatan (nama_kegiatan, tanggal, lokasi) VALUES " +
                                 "('Kerja Bakti', '2025-08-10', 'RT 01')," +
                                 "('Pengajian Rutin', '2025-08-15', 'Mushola Al-Ikhlas');";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengisi data contoh: " + ex.Message);
            }
        }

        private void TampilkanDataKegiatan()
        {
            try
            {
                conn.Open();
                string sql = "SELECT * FROM kegiatan;";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan data: " + ex.Message);
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sql = "INSERT INTO kegiatan (nama_kegiatan, tanggal, lokasi) VALUES (@nama, @tanggal, @lokasi);";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nama", txtNama.Text);
                cmd.Parameters.AddWithValue("@tanggal", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@lokasi", txtLokasi.Text);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Data berhasil ditambahkan!");
                TampilkanDataKegiatan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menambah data: " + ex.Message);
            }
        }
    }
}
