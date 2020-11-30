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
using WpfAppUnionMenu.Properties;
using System.Windows.Threading;

namespace WpfAppUnionMenu
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            txtBReloj.Text = DateTime.Now.ToLongTimeString();
        }

        private void tlPiramide_Click(object sender, RoutedEventArgs e)
        {
            WpfAppVolumenPrisma.MainWindow objVol = new WpfAppVolumenPrisma.MainWindow();
            objVol.ShowDialog();
        }

        private void tlSaludar_Click(object sender, RoutedEventArgs e)
        {
            WpfApp_eDady.MainWindow objSaludar = new WpfApp_eDady.MainWindow();
            objSaludar.ShowDialog();
        }

        private void tlVoz_Click(object sender, RoutedEventArgs e)
        {
            WpfAppInterfazVoz.MainWindow objVoz = new WpfAppInterfazVoz.MainWindow();
            objVoz.ShowDialog();
        }

        private void tlCalculadora_Click(object sender, RoutedEventArgs e)
        {
            WpfAppCalculadoraMath.MainWindow objMath = new WpfAppCalculadoraMath.MainWindow();
            objMath.ShowDialog();
        }

        private void tlJuego_Click(object sender, RoutedEventArgs e)
        {
            WpfAppJuego.MainWindow juego = new WpfAppJuego.MainWindow();
            juego.ShowDialog();
        }
        private void tlEditorTexto_Click(object sender, RoutedEventArgs e)
        {
            WpfAppEditorTexto.MainWindow editor = new WpfAppEditorTexto.MainWindow();
            editor.ShowDialog();
        }

        private void tlCompra_Click(object sender, RoutedEventArgs e)
        {
            WpfAppCompra.MainWindowCompra compra = new WpfAppCompra.MainWindowCompra();
            compra.ShowDialog();
        }

        private void tlSerie_Click(object sender, RoutedEventArgs e)
        {
            WpfAppSerie.MainWindow serie = new WpfAppSerie.MainWindow();
            serie.ShowDialog();
        }
        private void tlObjeto_Click(object sender, RoutedEventArgs e)
        {
            WpfAppObjetos.MainWindow objeto = new WpfAppObjetos.MainWindow();
            objeto.ShowDialog();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
