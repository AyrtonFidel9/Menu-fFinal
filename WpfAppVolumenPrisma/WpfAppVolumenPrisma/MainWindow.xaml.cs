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

namespace WpfAppVolumenPrisma
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        double altura;
        double ladoBase;
        string medida;
        public MainWindow()
        {
            InitializeComponent();
            btnNuevoCalculo.IsEnabled = false;
            ResizeMode = ResizeMode.CanMinimize;
            txtAltura.Focus();
            ThemeManager.Current.ChangeTheme(this, "Light.Purple");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private async void txtAltura_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                try
                {
                    if(double.Parse(txtAltura.Text) >= -9000000 && double.Parse(txtAltura.Text) <= 9000000)
                    {
                        //Verificar que el número sea positivo
                        if (double.Parse(txtAltura.Text) >= 0)
                        {
                            altura = double.Parse(txtAltura.Text);
                            txtLadoBase.Focus(); //ir al textbox del lado de la base
                        }
                        else
                        {
                            System.Media.SystemSounds.Exclamation.Play();
                            await this.ShowMessageAsync("Error", "No se admiten números negativos");
                            txtAltura.Clear();
                            txtAltura.Focus();
                        }
                    }
                    else //Capturar error cuando el numero sobrepasa los límites del double
                    {
                        System.Media.SystemSounds.Exclamation.Play();
                        await this.ShowMessageAsync("Error", "¡Número demasiado grande! El número debe estar entre 0 y 9000000");
                        txtAltura.Clear();
                        txtAltura.Focus();
                    }
                  
                }
                catch (FormatException) //Capturar el error para no admitir caracteres
                {
                    System.Media.SystemSounds.Exclamation.Play();
                    await this.ShowMessageAsync("Error", "No se admiten caracteres o espacios vacíos");
                    txtAltura.Clear();
                    txtAltura.Focus();
                }
            }
        }

        private async void txtLadoBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    if (double.Parse(txtLadoBase.Text) >= -9000000 && double.Parse(txtLadoBase.Text) <= 9000000)
                    {
                        //Verificar que el número sea positivo
                        if (double.Parse(txtLadoBase.Text) >= 0)
                        {
                            ladoBase = double.Parse(txtLadoBase.Text);
                            //capturar las medidas
                            medida = chekearMedidas();
                            //comprobar si se selecciono una medida
                            if (medida != "sin medida")
                            {
                                //Calcular el volumen
                                ClVolumen objVolumen = new ClVolumen();
                                double volumen = objVolumen.volumenPrismaCuadrado(altura, ladoBase);
                                double volumenTruncado = Math.Truncate(volumen * 100) / 100;
                                txtBVolumen.Text = "Volumen = " + volumenTruncado + " " + medida + "^3";

                                //Mostrar medidas en la figura
                                lblAlturaFig.Content = altura.ToString() + " " + medida;
                                lblBase1Fig.Content = ladoBase.ToString() + " " + medida;
                                lblBase2Fig.Content = ladoBase.ToString() + " " + medida;

                                //habilitar boton NUEVO CALCULO
                                btnNuevoCalculo.IsEnabled = true;

                            }
                            else
                            {
                                System.Media.SystemSounds.Exclamation.Play();
                                await this.ShowMessageAsync("Atención", "Seleccione una unidad de medida");
                            }

                        }
                        else
                        {
                            System.Media.SystemSounds.Exclamation.Play();
                            await this.ShowMessageAsync("Error", "No se admiten números negativos");
                            txtLadoBase.Clear();
                            txtLadoBase.Focus();
                        }
                    }
                    else //Capturar error cuando el numero sobrepasa los límites del double
                    {
                        System.Media.SystemSounds.Exclamation.Play();
                        await this.ShowMessageAsync("Error", "¡Número demasiado grande! El número debe estar entre 0 y 9000000");
                        txtLadoBase.Clear();
                        txtLadoBase.Focus();
                    }
                }
                catch (FormatException) //Capturar el error para no admitir caracteres
                {
                    System.Media.SystemSounds.Exclamation.Play();
                    await this.ShowMessageAsync("Error", "No se admiten caracteres o espacios vacíos");
                    txtLadoBase.Clear();
                    txtLadoBase.Focus();
                }
            }
        }

        private string chekearMedidas()
        {
            if(rdbMM.IsChecked == true)
            {
                return "mm";
            }
            else if(rdbCM.IsChecked == true)
            {
                return "cm";
            }
            else if(rdbM.IsChecked == true)
            {
                return "m";
            }
            else if(rbdDM.IsChecked == true)
            {
                return "dm";
            }
            return "sin medida";
        }

        private void rdbMM_Checked(object sender, RoutedEventArgs e)
        {
            if (rdbMM.IsChecked == true)
            {
                rdbM.IsEnabled = false;
                rdbCM.IsEnabled = false;
                rbdDM.IsEnabled = false;
            }
            medida = chekearMedidas();
            txtAltura.Focus();

        }

        private void rdbCM_Checked(object sender, RoutedEventArgs e)
        {
            if (rdbCM.IsChecked == true)
            {
                rdbM.IsEnabled = false;
                rdbMM.IsEnabled = false;
                rbdDM.IsEnabled = false;
            }
            medida = chekearMedidas();
            txtAltura.Focus();

        }

        private void rbdDM_Checked(object sender, RoutedEventArgs e)
        {
            if (rbdDM.IsChecked == true)
            {
                rdbM.IsEnabled = false;
                rdbMM.IsEnabled = false;
                rdbCM.IsEnabled = false;
            }
            medida = chekearMedidas();
            txtAltura.Focus();

        }
        private void rdbM_Checked(object sender, RoutedEventArgs e)
        {
            if (rdbM.IsChecked == true)
            {
                rbdDM.IsEnabled = false;
                rdbMM.IsEnabled = false;
                rdbCM.IsEnabled = false;
            }
            medida = chekearMedidas();
            txtAltura.Focus();
        }

        private void habilitar ()
        {
            rdbM.IsEnabled = true;
            rdbMM.IsEnabled = true;
            rdbCM.IsEnabled = true;
            rbdDM.IsEnabled = true;
            rbdDM.IsChecked = false;
            rdbCM.IsChecked = false;
            rdbMM.IsChecked = false;
            rdbM.IsChecked = false;

        }

        private void limpiar ()
        {
            txtAltura.Text = " ";
            txtLadoBase.Text = " ";
            lblAlturaFig.Content = " ";
            lblBase1Fig.Content = " ";
            lblBase2Fig.Content = " ";
            txtBVolumen.Text = " ";
        }


        //EVENTO DEL BOTON NUEVO CALCULO
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            habilitar();
            limpiar();
            btnNuevoCalculo.IsEnabled = false; // deshabilitar boton NUEVO CALCULO
            txtAltura.Focus();
        }

        private void btnCalcular_MouseMove(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Hand;
        }

        private void btnCalcular_MouseLeave(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void btnNuevoCalculo_MouseLeave(object sender, MouseEventArgs e)
        {
                Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void btnNuevoCalculo_MouseMove(object sender, MouseEventArgs e)
        {
            if (btnNuevoCalculo.IsEnabled == true)
                Mouse.OverrideCursor = Cursors.Hand;
        }

        private async void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            //ACCIONES DEL TEXTBOX DE LA ALTURA
            try
            {
                if (double.Parse(txtAltura.Text) >= -9000000 && double.Parse(txtAltura.Text) <= 9000000)
                {
                    //Verificar que el número sea positivo
                    if (double.Parse(txtAltura.Text) >= 0)
                    {
                        altura = double.Parse(txtAltura.Text);
                        txtLadoBase.Focus(); //ir al textbox del lado de la base
                    }
                    else
                    {
                        System.Media.SystemSounds.Exclamation.Play();
                        await this.ShowMessageAsync("Error", "No se admiten números negativos");
                        txtAltura.Clear();
                        txtAltura.Focus();
                    }
                }
                else //Capturar error cuando el numero sobrepasa los límites del double
                {
                    System.Media.SystemSounds.Exclamation.Play();
                    await this.ShowMessageAsync("Error", "¡Número demasiado grande! El número debe estar entre 0 y 9000000");
                    txtAltura.Clear();
                    txtAltura.Focus();
                }

            }
            catch (FormatException) //Capturar el error para no admitir caracteres
            {
                System.Media.SystemSounds.Exclamation.Play();
                await this.ShowMessageAsync("Error", "No se admiten caracteres o espacios vacíos");
                txtAltura.Clear();
                txtAltura.Focus();
            }

            //ACCIONES DEL TEXTBOX DEL LADO DE LA BASE
            try
            {
                if (double.Parse(txtLadoBase.Text) >= -9000000 && double.Parse(txtLadoBase.Text) <= 9000000)
                {
                    //Verificar que el número sea positivo
                    if (double.Parse(txtLadoBase.Text) >= 0)
                    {
                        ladoBase = double.Parse(txtLadoBase.Text);
                        //capturar las medidas
                        medida = chekearMedidas();
                        //comprobar si se selecciono una medida
                        if (medida != "sin medida")
                        {
                            //Calcular el volumen
                            ClVolumen objVolumen = new ClVolumen();
                            double volumen = objVolumen.volumenPrismaCuadrado(altura, ladoBase);
                            double volumenTruncado = Math.Truncate(volumen * 100) / 100;
                            txtBVolumen.Text = "Volumen = " + volumenTruncado + " " + medida + "^3";

                            //Mostrar medidas en la figura
                            lblAlturaFig.Content = altura.ToString() + " " + medida;
                            lblBase1Fig.Content = ladoBase.ToString() + " " + medida;
                            lblBase2Fig.Content = ladoBase.ToString() + " " + medida;

                            //habilitar boton NUEVO CALCULO
                            btnNuevoCalculo.IsEnabled = true;

                        }
                        else
                        {
                            System.Media.SystemSounds.Exclamation.Play();
                            await this.ShowMessageAsync("Atención", "Seleccione una unidad de medida");
                        }

                    }
                    else
                    {
                        System.Media.SystemSounds.Exclamation.Play();
                        await this.ShowMessageAsync("Error", "No se admiten números negativos");
                        txtLadoBase.Clear();
                        txtLadoBase.Focus();
                    }
                }
                else //Capturar error cuando el numero sobrepasa los límites del double
                {
                    System.Media.SystemSounds.Exclamation.Play();
                    await this.ShowMessageAsync("Error", "¡Número demasiado grande! El número debe estar entre 0 y 9000000");
                    txtLadoBase.Clear();
                    txtLadoBase.Focus();
                }
            }
            catch (FormatException) //Capturar el error para no admitir caracteres
            {
                System.Media.SystemSounds.Exclamation.Play();
                await this.ShowMessageAsync("Error", "No se admiten caracteres o espacios vacíos");
                txtLadoBase.Clear();
                txtLadoBase.Focus();
            }
        }
    }
}
