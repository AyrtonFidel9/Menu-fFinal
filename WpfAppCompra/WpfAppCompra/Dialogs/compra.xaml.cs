using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Threading;
using System.ComponentModel;
using WpfAppCompra.Properties;

namespace WpfAppCompra.Dialogs
{
    /// <summary>
    /// Lógica de interacción para compra.xaml
    /// </summary>
    public partial class compra : CustomDialog
    {
        private double total;
        public ICommand YesNoCommand { get; private set; }
        public void setTotal (double value)
        {
            txtBTotal.Text = "Total a pagar: $" + value.ToString();
            this.total = value; 
        }

        public compra()
        {
            InitializeComponent();
            txtNombre.SelectAll();
            txtNombre.Focus();
            txtBTotal.Text = "Total a pagar: $" + total;
            
        }


        bool sw = false;
        private void btnComprar_Click(object sender, RoutedEventArgs e)
        {
            if((nombre(txtNombre.Text) == true) && (cedula(txtCedula.Text) == true) && (cmbPago.SelectedItem != null))
            {
                btnRegresar.IsEnabled = false;
                btnComprar.IsEnabled = false;
                BackgroundWorker worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.DoWork += worker_DoWork;
                worker.ProgressChanged += worker_ProgressChanged;

                worker.RunWorkerAsync();
            }

        }

        private bool nombre (string nom)
        {
            if (string.IsNullOrEmpty(nom))
            {
                return false;
            }
            else
            {
                for (int i = 0; i < nom.Length; i++)
                {
                    if ((int)nom[i] >= 48 && (int)nom[i] <= 57)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool cedula (string ced)
        {
            if (string.IsNullOrEmpty(ced))
            {
                return false;
            }
            else
            {
                for (int i = 0; i < ced.Length; i++)
                {
                    if (!((int)ced[i] >= 48 && (int)ced[i] <= 57))
                    {
                        return false;

                    }
                }
            }
            return true;
        }

        

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(50);

                if(i == 100)
                {
                    Thread.Sleep(50);
                    
                }
            }
        }

       void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            status.Value = e.ProgressPercentage;
            if(status.Value == 100)
            {
                btnRegresar.IsEnabled = true;
               
            }
                
        }

        private void diaCompra_Unloaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                txtCedula.Focus();
            }
        }
    }
}
