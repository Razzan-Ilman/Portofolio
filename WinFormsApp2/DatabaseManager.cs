using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;


namespace WinFormsApp2
{
    public class DatabaseManager
    {
        private string dbPath;

        public DatabaseManager()
        {
            string appDir = AppDomain.CurrentDomain.BaseDirectory;
            string dataFolder = Path.Combine(appDir, "Data");

            if (!Directory.Exists(dataFolder))
                Directory.CreateDirectory(dataFolder);

            dbPath = Path.Combine(dataFolder, "warga.db");
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            if (!File.Exists(dbPath))
                SQLiteConnection.CreateFile(dbPath);

            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                try
                {
                    conn.Open();
                    string sql = @"CREATE TABLE IF NOT EXISTS Warga (
                        NIK TEXT PRIMARY KEY,
                        NamaLengkap TEXT NOT NULL,
                        TanggalLahir TEXT,
                        JenisKelamin TEXT NOT NULL,
                        Alamat TEXT,
                        Pekerjaan TEXT,
                        StatusPerkawinan TEXT
                    );";

                    using (var cmd = new SQLiteCommand(sql, conn))
                        cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error DB: " + ex.Message);
                }
            }
        }

        public bool SaveWarga(string nik, string nama, DateTime lahir, string jk, string alamat, string kerja, string status)
        {
            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT OR REPLACE INTO Warga 
                        (NIK, NamaLengkap, TanggalLahir, JenisKelamin, Alamat, Pekerjaan, StatusPerkawinan)
                        VALUES (@nik, @nama, @lahir, @jk, @alamat, @kerja, @status);";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nik", nik);
                        cmd.Parameters.AddWithValue("@nama", nama);
                        cmd.Parameters.AddWithValue("@lahir", lahir.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@jk", jk);
                        cmd.Parameters.AddWithValue("@alamat", alamat);
                        cmd.Parameters.AddWithValue("@kerja", kerja);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.ExecuteNonQuery();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Simpan error: " + ex.Message);
                    return false;
                }
            }
        }

        public DataTable GetAllWarga()
        {
            var dt = new DataTable();

            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Warga ORDER BY NamaLengkap ASC;";
                    using (var cmd = new SQLiteCommand(query, conn))
                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Load error: " + ex.Message);
                }
            }

            return dt;
        }

        public bool DeleteWarga(string nik)
        {
            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM Warga WHERE NIK = @nik;";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nik", nik);
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hapus error: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
