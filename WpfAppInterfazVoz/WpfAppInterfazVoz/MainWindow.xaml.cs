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
using System.Speech.Recognition;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace WpfAppInterfazVoz
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        SpeechRecognitionEngine objVoz = new SpeechRecognitionEngine();
        public MainWindow()
        {
            InitializeComponent();
            txtParrafo.Focus();
            ResizeMode = ResizeMode.CanMinimize;
        }

        private async void btnIniciar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                objVoz.SetInputToDefaultAudioDevice();
                objVoz.LoadGrammar(new DictationGrammar());
                objVoz.SpeechRecognized += enlazar;
                objVoz.RecognizeAsync(RecognizeMode.Multiple);
                await this.ShowMessageAsync("¡Micrófono habilitado!", "Puede hablar.");


            }
            catch (InvalidOperationException)
            {
                System.Media.SystemSounds.Exclamation.Play();
                await this.ShowMessageAsync("¡Atención!", "El microfono ya ha sido habilitado");
            }
        }

        private void enlazar (object sender, SpeechRecognizedEventArgs e)
        {
            //txtParrafo.Text = e.Result.Text;
            foreach (RecognizedWordUnit palabra in e.Result.Words)
            {
                txtParrafo.Text = palabra.Text;
                if (txtParrafo.Text == "casa" || txtParrafo.Text == "Casa")
                {
                    imgImagen.Source = new BitmapImage(new Uri("/Images/casa.png", UriKind.Relative));
                }
                else if(txtParrafo.Text == "Vaciar" || txtParrafo.Text == "vaciar")
                {
                    imgImagen.Source = new BitmapImage(new Uri("", UriKind.Relative));
                }
                else if(txtParrafo.Text == "Cerrar" || txtParrafo.Text == "cerrar")
                {
                    this.Close();
                }
                else if (txtParrafo.Text == "Teléfono" || txtParrafo.Text == "teléfono")
                {
                    imgImagen.Source = new BitmapImage(new Uri("/Images/telefono.png", UriKind.Relative));
                }
                else if (txtParrafo.Text == "Avión" || txtParrafo.Text == "avión")
                {
                    imgImagen.Source = new BitmapImage(new Uri("/Images/avion.png", UriKind.Relative));
                }
                else if (txtParrafo.Text == "balón" || txtParrafo.Text == "Balón" || txtParrafo.Text == "Pelota" || txtParrafo.Text == "pelota")
                {
                    imgImagen.Source = new BitmapImage(new Uri("/Images/balon.png", UriKind.Relative));
                }
            }
        }

        private async void btnPausar_Click(object sender, RoutedEventArgs e)
        {
            await this.ShowMessageAsync("¡Micrófono deshabilitado!", "El proceso ha sido pausado.");
            objVoz.RecognizeAsyncStop();
        }

    }
}
