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

namespace WpfApp_eDady
{
    /// <summary>
    /// Lógica de interacción para winApellido.xaml
    /// </summary>
    public partial class winApellido : Window
    {
        string nombre;
        string apellido;
        public winApellido(string nombre)
        {
            InitializeComponent();
            this.nombre = nombre;
            ResizeMode = ResizeMode.CanMinimize;
            txtApellido.Focus();
        }

        private void txtApellido_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                try
                {
                    if (txtApellido.Text != "")
                    {
                        apellido = txtApellido.Text;
                        winSaldudo objSaludo = new winSaldudo(nombre, apellido);
                        objSaludo.Show();
                        this.Close();
                    }
                    else
                    {
                        System.Media.SystemSounds.Exclamation.Play();
                        MessageBox.Show("Por favor, no ingrese espacios vacios", "ATENCIÓN");
                        txtApellido.Focus();
                    }
                }
                catch
                {

                }
            }
        }

        private void txtApellido_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //bloquear el acceso de numeros
            int character = Convert.ToInt32(Convert.ToChar(e.Text));
            if ((character >= 65 && character <= 90) || (character >= 97 && character <= 122))
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
