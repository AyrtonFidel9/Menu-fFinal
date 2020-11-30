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
using ControlzEx.Theming;

namespace WpfAppCalculadoraMath
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        double numero;
        bool ingresado = false;
        private IDialogCoordinator dialogCoordinator = DialogCoordinator.Instance;
        public MainWindow()
        {
            InitializeComponent();
            txtNumero.Focus();
            btnCE.IsEnabled = false;
            ThemeManager.Current.ChangeTheme(this, "Light.Amber");
            //this.DataContext = new MainWindowViewModel(DialogCoordinator.Instance);
            //MainWindowViewModel obj1 = new MainWindowViewModel(DialogCoordinator.Instance);
            //obj1.FooMessage();
            new MainWindowViewModel(DialogCoordinator.Instance);
            //_dialogCoordinator.ShowMessageAsync(this, "Message from VM", "MVVM based dialogs!");

        }

        private async void ShowMessageDialog(object sender, RoutedEventArgs e)
        {
            // This demo runs on .Net 4.0, but we're using the Microsoft.Bcl.Async package so we have async/await support
            // The package is only used by the demo and not a dependency of the library!
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Hi",
                NegativeButtonText = "Go away!",
                FirstAuxiliaryButtonText = "Cancel",
                ColorScheme = MetroDialogOptions.ColorScheme,
                DialogButtonFontSize = 20D
            };

            MessageDialogResult result = await this.ShowMessageAsync("Hello!", "Welcome to the world of metro!",
                                                                     MessageDialogStyle.AffirmativeAndNegativeAndSingleAuxiliary, mySettings);

            if (result != MessageDialogResult.FirstAuxiliary)
                await this.ShowMessageAsync("Result", "You said: " + (result == MessageDialogResult.Affirmative
                                                ? mySettings.AffirmativeButtonText
                                                : mySettings.NegativeButtonText +
                                                  Environment.NewLine + Environment.NewLine + "This dialog will follow the Use Accent setting."));
        }
        private void txtNumero_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //bloquear el acceso de letras
            int character = Convert.ToInt32(Convert.ToChar(e.Text));
            if ((character >= 48 && character <= 57) || character == 44 || character == 45)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private async void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                try
                {

                    try
                    {
                        numero = double.Parse(txtNumero.Text);
                        txtNumero.IsEnabled = false;
                        btnCE.IsEnabled = true;
                        btnIgual.IsEnabled = false;
                        ingresado = true;
                        await this.ShowMessageAsync("¡Datos Ingresados!", "Puede continuar con la operaciones",MessageDialogStyle.Affirmative);
                    }
                    catch (FormatException)
                    {
                        System.Media.SystemSounds.Exclamation.Play();
                        await this.ShowMessageAsync("Error", "Debe ingresar algun número, no se admiten espacios vacios");
                        txtNumero.Focus();
                    }
                }
                catch (OverflowException)
                {
                    System.Media.SystemSounds.Exclamation.Play();
                    await this.ShowMessageAsync("Atención", "Solo sea admiten número que esten entre " + double
                        .MinValue + " y " + double.MaxValue);
                    txtNumero.Clear();
                    txtNumero.Focus();
                }
            }
        }

        private async void btnIgual_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                try
                {
                    numero = double.Parse(txtNumero.Text);
                    txtNumero.IsEnabled = false;
                    btnCE.IsEnabled = true;
                    btnIgual.IsEnabled = false;
                    ingresado = true;
                    await this.ShowMessageAsync("¡Datos Ingresados!", "Puede continuar con la operaciones");
                }
                catch (FormatException)
                {
                    System.Media.SystemSounds.Exclamation.Play();
                    txtNumero.Focus();
                    await this.ShowMessageAsync("Error","Debe ingresar algun número, no se admiten espacios vacíos");
                   
                }
                

            }
            catch (OverflowException)
            {
                System.Media.SystemSounds.Asterisk.Play();
                await this.ShowMessageAsync("Atención", "Solo sea admiten número que esten entre " + double
                                        .MinValue + " y " + double.MaxValue);
                txtNumero.Clear();
                txtNumero.Focus();
            }
        }

        private async void btnRaizCua_Click(object sender, RoutedEventArgs e)
        {
            if(txtNumero.Text != string.Empty && ingresado == true) //si el texbox esta vacio
            {
                if (numero >= 0)
                {
                    txtBResultado.Text = Math.Sqrt(numero).ToString();
                }
                else
                {
                    txtBResultado.Text = "No existen las raíces negativas";
                }
            }
            else
            {
                System.Media.SystemSounds.Exclamation.Play();
                await this.ShowMessageAsync( "Atención", "Ingrese algun número entero o decimal");
                txtNumero.Focus();
            }
        }

        private void btnCE_Click(object sender, RoutedEventArgs e)
        {
            btnCE.IsEnabled = false;
            btnIgual.IsEnabled = true;
            txtNumero.Text = "";
            txtBResultado.Text = "";
            txtNumero.IsEnabled = true;
            txtNumero.Focus();
            numero = 0;
            ingresado = false;
        }

        private async void btnPotencia_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumero.Text != string.Empty && ingresado == true) //si el texbox esta vacio
            {
                txtBResultado.Text = Math.Pow(numero, 2).ToString();
            }
            else
            {
                System.Media.SystemSounds.Exclamation.Play();
                await this.ShowMessageAsync("Atención", "Ingrese algun número entero o decimal");
                txtNumero.Focus();
            }
        }

        private async void btnValorAbs_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumero.Text != string.Empty && ingresado == true) //si el texbox esta vacio
            {
                txtBResultado.Text = Math.Abs(numero).ToString();
            }
            else
            {
                System.Media.SystemSounds.Exclamation.Play();
                await this.ShowMessageAsync("Atención", "Ingrese algun número entero o decimal");

                txtNumero.Focus();
            }
        }

        private async void btnPtEntera_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumero.Text != string.Empty && ingresado == true) //si el texbox esta vacio
            {
                txtBResultado.Text = Math.Truncate(numero).ToString();
            }
            else
            {
                System.Media.SystemSounds.Exclamation.Play();
                await this.ShowMessageAsync("Atención", "Ingrese algun número entero o decimal");

                txtNumero.Focus();
            }
        }

        private async void btnRedondeo_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumero.Text != string.Empty && ingresado == true) //si el texbox esta vacio
            {
                txtBResultado.Text = Math.Round(numero).ToString();
            }
            else
            {
                System.Media.SystemSounds.Exclamation.Play();
                MessageBox.Show("Ingrese algun número entero o decimal", "Atención");
                await this.ShowMessageAsync("Atención", "Ingrese algun número entero o decimal");

                txtNumero.Focus();
            }
        }

        private async void btnMax_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumero.Text != string.Empty && ingresado == true) //si el texbox esta vacio
            {
                txtBResultado.Text = Math.Max(numero, 50).ToString();
            }
            else
            {
                System.Media.SystemSounds.Exclamation.Play();
                await this.ShowMessageAsync("Atención", "Ingrese algun número entero o decimal");

                txtNumero.Focus();
            }
        }

        private async void btnMin_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumero.Text != string.Empty && ingresado == true) //si el texbox esta vacio
            {
                txtBResultado.Text = Math.Min(numero,50).ToString();
            }
            else
            {
                System.Media.SystemSounds.Exclamation.Play();
                await this.ShowMessageAsync("Atención", "Ingrese algun número entero o decimal");
                txtNumero.Focus();
            }
        }

        private async void btnSen_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumero.Text != string.Empty && ingresado == true) //si el texbox esta vacio
            {
                txtBResultado.Text = Math.Sin(numero * Math.PI / 180).ToString();
            }
            else
            {
                System.Media.SystemSounds.Exclamation.Play();
                await this.ShowMessageAsync("Atención", "Ingrese algun número entero o decimal");
                txtNumero.Focus();
            }
        }

        private async void btnCos_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumero.Text != string.Empty && ingresado == true) //si el texbox esta vacio
            {
                txtBResultado.Text = Math.Cos(numero * Math.PI / 180).ToString();
            }
            else
            {
                System.Media.SystemSounds.Exclamation.Play();
                await this.ShowMessageAsync("Atención", "Ingrese algun número entero o decimal");
                txtNumero.Focus();
            }
        }

        private async void btnTg_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumero.Text != string.Empty && ingresado == true) //si el texbox esta vacio
            {
                txtBResultado.Text = Math.Tan(numero * Math.PI / 180).ToString();
            }
            else
            {
                System.Media.SystemSounds.Exclamation.Play();
                await this.ShowMessageAsync("Atención", "Ingrese algun número entero o decimal");
                txtNumero.Focus();
            }
        }

        private async void btnLog_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumero.Text != string.Empty && ingresado == true) //si el texbox esta vacio
            {
                if(numero > 0)
                {
                    txtBResultado.Text = Math.Log(numero).ToString();
                }
                else
                {
                    txtBResultado.Text = "No existen el LOG de números negativos y 0";
                }
                
            }
            else
            {
                System.Media.SystemSounds.Exclamation.Play();
                await this.ShowMessageAsync("Atención", "Ingrese algun número entero o decimal");
                txtNumero.Focus();
            }
        }
    }
}
