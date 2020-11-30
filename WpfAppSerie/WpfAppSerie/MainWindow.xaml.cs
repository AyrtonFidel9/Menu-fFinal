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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using WpfAppSerie.Clases;
using ControlzEx.Theming;

namespace WpfAppSerie
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        
        public MainWindow()
        {
            InitializeComponent();
            txtNumero.Focus();
            ThemeManager.Current.ChangeTheme(this, "Light.Crimson");
        }

        private async void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                try
                {
                    if (int.Parse(txtNumero.Text) > 0 && int.Parse(txtNumero.Text) <= 15)
                    {
                        Serie objSerie = new Serie();
                        objSerie.Cantidad = int.Parse(txtNumero.Text);
                        txtBTitRes.Text = "El valor del elemento " + txtNumero.Text + " es: ";
                        txtBRespuesta.Text = (Math.Round(objSerie.valorSerie(), 3)).ToString();
                    }
                    else
                    {
                        await this.ShowMessageAsync("Atención", "Por favor, ingrese números que estén entre 1 y 15.");
                        txtNumero.Clear();
                        txtNumero.Focus();
                    }
                }
                catch (FormatException)
                {
                    await this.ShowMessageAsync("Error", "No se admiten caracteres o espacios vacíos. Inténtelo de nuevo, por favor.");
                    txtNumero.Clear();
                    txtNumero.Focus();
                }
                

            }
        }

        private async void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.Parse(txtNumero.Text) > 0 && int.Parse(txtNumero.Text) <= 15)
                {
                    Serie objSerie = new Serie();
                    objSerie.Cantidad = int.Parse(txtNumero.Text);
                    txtBTitRes.Text = "El valor del elemento " + txtNumero.Text + " es: ";
                    txtBRespuesta.Text = (Math.Round(objSerie.valorSerie(), 3)).ToString();
                }
                else
                {
                    await this.ShowMessageAsync("Atención", "Por favor, ingrese números que estén entre 1 y 15.");
                    txtNumero.Clear();
                    txtNumero.Focus();
                }
            }
            catch (FormatException)
            {
                await this.ShowMessageAsync("Error", "No se admiten caracteres o espacios vacíos. Inténtelo de nuevo, por favor.");
                txtNumero.Clear();
                txtNumero.Focus();
            }
        }

        private void btnCalcular_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCalcular_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }
    }
}
