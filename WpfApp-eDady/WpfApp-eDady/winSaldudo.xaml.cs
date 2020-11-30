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
    /// Lógica de interacción para winSaldudo.xaml
    /// </summary>
    public partial class winSaldudo : Window
    {
        public winSaldudo(string nombre, string apellido)
        {
            InitializeComponent();
            ResizeMode = ResizeMode.CanMinimize;
            txtBSALUDO.Text = "¡Hola "+nombre+" "+apellido+" ten un buen día y recuerda siempre sonreír!";
        }
    }
}
