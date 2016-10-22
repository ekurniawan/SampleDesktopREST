using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SampleDesktop.Services;

using MyHospital.Billing.DataSosial.Bo;

namespace SampleDesktop
{
    public partial class Form1 : Form
    {
        private BindingSource bs;

        public Form1()
        {
            InitializeComponent();

            dgvAgama.AutoGenerateColumns = false;

            bs = new BindingSource();

            bs.ListChanged += Bs_ListChanged;
        }

        private void Bs_ListChanged(object sender, ListChangedEventArgs e)
        {
            Agama currData = (Agama)bs.Current;
            MessageBox.Show("Current Change " + currData.Nama);
        }

      

       
       

       

        private void HapusBinding()
        {
            txtKode.DataBindings.Clear();
            txtNama.DataBindings.Clear();
        }

        private void TambahBinding()
        {
            HapusBinding();
            txtKode.DataBindings.Add("Text", bs, "Kode");
            txtNama.DataBindings.Add("Text", bs, "Nama");
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            AgamaService agamaService = new AgamaService();

           
            bs.DataSource = agamaService.GetAll();
            TambahBinding();

        
            dgvAgama.DataSource = bs;

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            bs.MoveFirst();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            bs.MoveLast();
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            List<Agama> lstAgama = (List<Agama>)bs.List;

            string data = "";
            foreach(var agama in lstAgama)
            {
                data += agama.Nama + " , ";
            }

            MessageBox.Show(data, "Keterangan");
        }

        private void btnCurrent_Click(object sender, EventArgs e)
        {
            Agama currData = (Agama)bs.Current;
            MessageBox.Show(currData.Nama, "Keterangan");
        }
    }
}
