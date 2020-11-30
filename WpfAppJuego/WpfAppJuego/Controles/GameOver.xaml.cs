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

namespace WpfAppJuego.Controles
{
    /// <summary>
    /// Lógica de interacción para GameOver.xaml
    /// </summary>
    public partial class GameOver : UserControl
    {
        Window ventana = new Window();
        public GameOver()
        {
            InitializeComponent();
            ventana.Focus();
        }

        public void setVentana(Window v)
        {
           this.ventana = v;
        }

        private void PackIconModern_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.ventana.Close();
            MainWindow objA = new MainWindow();
            objA.Show();
        }



        private void Text(object sender, MouseButtonEventArgs e)
        {
            ventana.Close();
        }
    }
}
