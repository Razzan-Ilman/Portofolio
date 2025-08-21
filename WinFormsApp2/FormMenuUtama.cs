using System;
using System.Windows.Forms;

namespace AplikasiPencatatanWarga
{
    public partial class FormMenuUtama : Form
    {
        public FormMenuUtama()
        {
            InitializeComponent();
        }

        private void dataWargaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDataWarga formWarga = new frmDataWarga();
            formWarga.Show();
        }

        private void kegiatanWargaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKegiatan formKegiatan = new FormKegiatan();
            formKegiatan.Show();
        }

        private void keluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
