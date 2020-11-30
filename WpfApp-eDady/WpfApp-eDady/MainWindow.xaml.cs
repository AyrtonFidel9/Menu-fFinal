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

namespace WpfApp_eDady
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string nombre;
        public MainWindow()
        {
            InitializeComponent();
            txtNombre.Focus();
            ResizeMode = ResizeMode.CanMinimize;
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.Key == Key.Enter)
            {
                    if (txtNombre.Text != "")
                    {
                        nombre = txtNombre.Text;
                        winApellido objApellido = new winApellido(nombre);
                        objApellido.Show();
                        this.Close();
                    }
                    else
                    {
                        System.Media.SystemSounds.Exclamation.Play();
                        MessageBox.Show("Por favor, no ingrese espacios vacios", "ATENCIÓN");
                        txtNombre.Focus();
                    }
                //}
                //else
                //{
                //    System.Media.SystemSounds.Exclamation.Play();
                //    MessageBox.Show("Por favor, ingrese caracteres ", "ATENCIÓN");
                //    txtNombre.Focus();
                //    txtNombre.Clear();
                //}
            }
        }

        private void txtNombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //bloquear el acceso de numeros
            int character = Convert.ToInt32(Convert.ToChar(e.Text));
            if ((character >= 65 && character <= 90) || (character >= 97 && character <= 122))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
