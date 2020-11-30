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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppObjetos.Clases;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Threading;
using System.ComponentModel;
using ControlzEx.Theming;

namespace WpfAppObjetos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        Cliente[] clientes = new Cliente[10];
        int contador = 0;
        public MainWindow()
        {
            InitializeComponent();
            txtNombre.Focus();
            ThemeManager.Current.ChangeTheme(this, "Light.Emerald");
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtApellido.Focus();
            }
        }

        private void txtApellido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtCedula.Focus();
            }
        }

        private void txtCedula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtTelefono.Focus();
            }
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtDireccion.Focus();
            }
        }

        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnIngresar.Focus();
            }
        }

        private void btnIngresar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ingresar();
            }
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            ingresar();
        }

        private async void ingresar()
        {
            Validacion objVal = new Validacion();
            if (contador < 10)
            {
                if(objVal.camposVacios(txtNombre.Text) == true && objVal.camposVacios(txtApellido.Text)== true
                   && objVal.camposVacios(txtCedula.Text) == true && objVal.camposVacios(txtTelefono.Text) == true
                   && objVal.camposVacios(txtDireccion.Text) == true && objVal.camposVacios(txtEmail.Text) == true)
                {
                    if(objVal.nombre(txtNombre.Text) == true && objVal.nombre(txtApellido.Text)==true
                       && objVal.cedula(txtCedula.Text) == true && objVal.cedula(txtTelefono.Text) == true
                        && objVal.email_bien_escrito(txtEmail.Text) == true)
                    {
                        Cliente objC = new Cliente();
                        objC.Nombre = txtNombre.Text;
                        objC.Apellido = txtApellido.Text;
                        objC.Cedula = txtCedula.Text;
                        objC.Telefono = txtTelefono.Text;
                        objC.Direccion = txtDireccion.Text;
                        objC.Email = txtEmail.Text;


                        clientes[contador] = objC;

                        btnNuevo.IsEnabled = false;
                        btnIngresar.IsEnabled = false;

                        BackgroundWorker worker = new BackgroundWorker();
                        worker.WorkerReportsProgress = true;
                        worker.DoWork += worker_DoWork;
                        worker.ProgressChanged += worker_ProgressChanged;

                        worker.RunWorkerAsync();
                        contador++;
                    }
                    
                }
                
                
            }
            else
                await this.ShowMessageAsync("Límite de clientes rebasado", "Lo siento. Solo se aceptan 10 clientes en el sistema");



        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(10);
                if (i == 100)
                {
                    Thread.Sleep(50);
                }

            }
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            status.Value = e.ProgressPercentage;
            if (status.Value == 100)
            {
                btnNuevo.IsEnabled = true;
                btnIngresar.IsEnabled = true;
                ventana.Title = "Clientes | Ingresados: " + contador.ToString();
            }

        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCedula.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtEmail.Clear();
            txtNombre.Focus();
            status.Value = 0;
        }

        private async void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (vacio())
            {
                dgClientes.Items.Clear();

                foreach (Cliente indice in clientes)
                {
                    if (indice != null)
                    {
                        //var data = new Datos
                        //{
                        //    Nombre = indice.Nombre.ToString(),
                        //    Apellido = indice.Apellido.ToString(),
                        //    Cedula = indice.Cedula.ToString(),
                        //    Telefono = indice.Telefono.ToString(),
                        //    Direccion = indice.Direccion,
                        //    Email = indice.Email.ToString()
                        //};
                        dgClientes.Items.Add(indice);
                    }

                }
            }
            else
                await this.ShowMessageAsync("¡Atención!","No se ha ingresado ningún cliente, ingrese uno por favor");
            
        }

        private bool vacio()
        {
            int i = 0;
            foreach (Cliente indice in clientes)
            {
                if (indice != null)
                {
                    i++;
                }
            }
            if (i != 0)
            {
                return true;
            }
            else
                return false;
        }
        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgClientes.SelectedItem != null)
            {
                string valor = (dgClientes.Columns[2].GetCellContent(dgClientes.SelectedItem) as TextBlock).Text;
                
                foreach (Cliente indice in clientes)
                {
                   try
                    {
                        if (indice.Cedula == valor)
                        {
                            remover(valor);
                        }
                    }
                    catch
                    {

                    }
                }
                contador--;
                ventana.Title = "Clientes | Ingresados: " + contador.ToString();
                dgClientes.Items.Remove(dgClientes.SelectedItem);
            }
            else
                await this.ShowMessageAsync("¡Atención!","No se ha seleccionado ningun cliente de la lista, seleccione uno por favor.");
        }

        private void remover (string valor)
        {
            for (int i = 0; i < clientes.Length; i++)
            {
                try
                {
                    if (clientes[i].Cedula == valor)
                    {
                        clientes[i] = clientes[i + 1];
                    }
                    if (clientes[i] == null)
                    {
                        try
                        {
                            clientes[i] = clientes[i + 1];
                        }
                        catch
                        {

                        }
                    }
                }
                catch
                {

                }
                

            }
        }
    }

    public class Datos
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
    }
}

