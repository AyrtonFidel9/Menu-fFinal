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
using System.ComponentModel;
using MahApps.Metro.Controls.Dialogs;
using System.Threading;
using WpfAppCompra.Dialogs;

namespace WpfAppCompra
{
    /// <summary>
    /// Lógica de interacción para MainWindowCompra.xaml
    /// </summary>
    public partial class MainWindowCompra : MetroWindow
    {
        double valorPrecio = 0;
        string producto;
        int cantidad;
        string descripcion;
        string articulo = "";
        bool swTalla = false;
        compra objC = new compra();

        public MainWindowCompra()
        {
            InitializeComponent();
        }

        private void tlPeras_Click(object sender, RoutedEventArgs e)
        {
            cantidad = 0;
            stkDetalles.Children.Clear();
            this.flyoutsDETALLES.IsOpen = true;
            flyoutsDETALLES.Header = tlPeras.Content;
            producto = flyoutsDETALLES.Header.ToString();
            agregarDetalles(0.25, "/Images/peras.jpg", stkDetalles, "Peras verdes, producidas en el " +
                "olimpo de los dioses", "");
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void agregarDetalles(double precio, string source, StackPanel panel, string desc, string art)
        {
            List<string> numeros = new List<string>()
            {
                "1","2","3","4","5","6","7","8","9","10","11","12"
            };
            TextBlock txtTitDesc = new TextBlock();
            txtTitDesc.Name = "txtTitDesc";
            txtTitDesc.Text = "Descripción";
            txtTitDesc.FontSize = 20;
            txtTitDesc.Margin = new Thickness(5);
            txtTitDesc.FontFamily = new FontFamily("/Fonts/#SecularOne-Regular.ttf");

            FlowDocument myFlowDoc = new FlowDocument();
            myFlowDoc.Blocks.Add(new Paragraph(new Run(desc)));

            RichTextBox rchDescripcion = new RichTextBox();
            rchDescripcion.IsReadOnly = true;
            rchDescripcion.Name = "rchDescripcion";
            rchDescripcion.Height = 100;
            rchDescripcion.Width = 200;
            rchDescripcion.Document = myFlowDoc;
            rchDescripcion.FontSize = 15;
            rchDescripcion.VerticalContentAlignment = VerticalAlignment.Top;
            descripcion = desc;

            WrapPanel wrpDetCanti = new WrapPanel();
            wrpDetCanti.Name = "wrpDetCanti";
            wrpDetCanti.Margin = new Thickness(10);
            wrpDetCanti.HorizontalAlignment = HorizontalAlignment.Center;


            TextBlock txtCantidad = new TextBlock();
            txtCantidad.Text = "Cantidad";
            txtCantidad.HorizontalAlignment = HorizontalAlignment.Center;
            txtCantidad.FontSize = 20;
            txtCantidad.Margin = new Thickness(7);

            ComboBox cmbCantidad = new ComboBox();
            cmbCantidad.Name = "cmbCantidad";
            cmbCantidad.Width = 70;
            cmbCantidad.HorizontalAlignment = HorizontalAlignment.Center;
            cmbCantidad.ItemsSource = numeros;
            cmbCantidad.Height = 13;

            wrpDetCanti.Children.Add(txtCantidad);
            wrpDetCanti.Children.Add(cmbCantidad);

            Button btnAgregar = new Button();
            btnAgregar.Content = "Agregar a la cesta";
            btnAgregar.Width = 170;
            btnAgregar.Height = 50;
            btnAgregar.FontSize = 15;
            btnAgregar.Name = "btnAgregar";

            Image foto = new Image();
            foto.Source = new BitmapImage(new Uri(source, UriKind.Relative));
            foto.Height = 200;
            foto.Width = 200;
            foto.Margin = new Thickness(7);
            foto.Name = "foto";

            WrapPanel infoPrecio = new WrapPanel();
            infoPrecio.HorizontalAlignment = HorizontalAlignment.Center;
            infoPrecio.Margin = new Thickness(8);
            infoPrecio.Name = "wrpInfoPrecio";
            TextBlock txtPrecio = new TextBlock();
            txtPrecio.FontSize = 20;
            TextBlock txtValorPrecio = new TextBlock();
            txtValorPrecio.Name = "txtValorPrecio";
            txtValorPrecio.FontSize = 20;
            txtValorPrecio.Text = precio.ToString();
            txtPrecio.Text = "Precio: $";
            infoPrecio.Children.Add(txtPrecio);
            infoPrecio.Children.Add(txtValorPrecio);


            panel.Children.Add(txtTitDesc);
            panel.Children.Add(rchDescripcion);
            panel.Children.Add(wrpDetCanti);
            if (art == "Ropa")
            {
                List<string> tallas = new List<string>()
                {
                    "XS","S","M","L","XL","XLL"
                };

                TextBlock txtTalla = new TextBlock();
                txtTalla.Name = "txtTalla";
                txtTalla.FontSize = 20;
                txtTalla.Text = "Elija una talla";
                txtTalla.Margin = new Thickness(8);

                ComboBox cmbTalla = new ComboBox();
                cmbTalla.Name = "cmbTalla";
                cmbTalla.ItemsSource = tallas;
                cmbTalla.Width = 70;
                cmbTalla.Height = 13;

                WrapPanel wrpTallas = new WrapPanel();
                wrpTallas.Name = "wrpTallas";
                wrpTallas.Children.Add(txtTalla);
                wrpTallas.Children.Add(cmbTalla);
                wrpTallas.HorizontalAlignment = HorizontalAlignment.Center;

                panel.Children.Add(wrpTallas);
            }
            panel.Children.Add(infoPrecio);
            panel.Children.Add(btnAgregar);
            panel.Children.Add(foto);


            btnAgregar.Click += new RoutedEventHandler(btnAgregar_Click);
        }



        private async void btnAgregar_Click(object sender, RoutedEventArgs e)
        {

            foreach (FrameworkElement hijo in stkDetalles.Children)
            {
                string childname = null;
                childname = (hijo as FrameworkElement).Name;
                if (childname == "wrpInfoPrecio")
                {
                    EnumVisual(hijo as FrameworkElement);
                }
                if (childname == "wrpDetCanti")
                {
                    EnumVisual(hijo as FrameworkElement);
                }
                if (childname == "wrpTallas")
                {
                    EnumVisual(hijo as FrameworkElement);
                }
            }

            if (cantidad != 0)
            {
                if (articulo == "frutas" && swTalla == false)
                {
                    var data = new Datos
                    {
                        Producto = producto.ToString(),
                        Descripcion = descripcion,
                        Cantidad = cantidad.ToString(),
                        Precio = valorPrecio.ToString(),
                        Total = (cantidad * valorPrecio).ToString()
                    };
                    dgCesta.Items.Add(data);
                    this.flyoutsDETALLES.IsOpen = false;
                }

                if (articulo == "ropa" && swTalla != false)
                {
                    var data = new Datos
                    {
                        Producto = producto.ToString(),
                        Descripcion = descripcion,
                        Cantidad = cantidad.ToString(),
                        Precio = valorPrecio.ToString(),
                        Total = (cantidad * valorPrecio).ToString()
                    };
                    dgCesta.Items.Add(data);
                    this.flyoutsDETALLES.IsOpen = false;
                    swTalla = false;
                }
            }
            else
                await this.ShowMessageAsync("Atención", "Por favor, seleccione una cantidad a comprar");

        }
        public async void EnumVisual(Visual myVisual)
        {

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(myVisual); i++)
            {
                // Retrieve child visual at specified index value.
                Visual childVisual = (Visual)VisualTreeHelper.GetChild(myVisual, i);
                //// Do processing of the child visual object.
                if ((childVisual as FrameworkElement).Name == "txtValorPrecio")
                {

                    valorPrecio = double.Parse((childVisual as TextBlock).Text);

                }
                if ((childVisual as FrameworkElement).Name == "cmbCantidad")
                {
                    try
                    {

                        cantidad = int.Parse((childVisual as ComboBox).Text);
                        articulo = "frutas";
                        swTalla = false;
                    }
                    catch
                    {
                    }

                }
                if ((childVisual as FrameworkElement).Name == "cmbTalla")
                {
                    articulo = "ropa";
                    if (string.IsNullOrEmpty((childVisual as ComboBox).Text))
                    {

                        await this.ShowMessageAsync("Atención", "Por favor, seleccione una talla para su prenda");
                        swTalla = false;

                    }
                    else
                    {
                        swTalla = true;
                        descripcion += ", la Talla es " + (childVisual as ComboBox).Text;
                    }

                }

                // Enumerate children of the child visual object.
                EnumVisual(childVisual);
            }
        }

        private void tlManzanas_Click(object sender, RoutedEventArgs e)
        {
            cantidad = 0;
            stkDetalles.Children.Clear();
            this.flyoutsDETALLES.IsOpen = true;
            flyoutsDETALLES.Header = tlManzanas.Content;
            producto = flyoutsDETALLES.Header.ToString();
            agregarDetalles(0.25, "/Images/manzana.jpg", stkDetalles, "Manzanas rojas, producidas en " +
                "los verdes campos de la patagonia", "");
        }

        private void tlPlatano_Click(object sender, RoutedEventArgs e)
        {
            cantidad = 0;
            stkDetalles.Children.Clear();
            this.flyoutsDETALLES.IsOpen = true;
            flyoutsDETALLES.Header = tlPlatano.Content;
            producto = flyoutsDETALLES.Header.ToString();
            agregarDetalles(0.15, "/Images/platano.jpg", stkDetalles, "Plátano producido en la bananera de " +
                "Alvarito Noboa", "");
        }

        private void tlCamisa_Click(object sender, RoutedEventArgs e)
        {
            cantidad = 0;
            stkDetalles.Children.Clear();
            this.flyoutsDETALLES.IsOpen = true;
            flyoutsDETALLES.Header = tlCamisa.Content;
            producto = flyoutsDETALLES.Header.ToString();
            agregarDetalles(15, "/Images/camisa2.jpg", stkDetalles, "Camisa Gucci de color celeste" +
                " ,de manga larga exportada desde Italia", "Ropa");
        }

        private void tlPantalon_Click(object sender, RoutedEventArgs e)
        {
            cantidad = 0;
            stkDetalles.Children.Clear();
            this.flyoutsDETALLES.IsOpen = true;
            flyoutsDETALLES.Header = tlPantalon.Content;
            producto = flyoutsDETALLES.Header.ToString();
            agregarDetalles(12, "/Images/pantalon.png", stkDetalles, "Pantalon jean, color azul oscuro",
                "Ropa");
        }

        private void tlMaleta_Click(object sender, RoutedEventArgs e)
        {
            cantidad = 0;
            stkDetalles.Children.Clear();
            this.flyoutsDETALLES.IsOpen = true;
            flyoutsDETALLES.Header = tlMaleta.Content;
            producto = flyoutsDETALLES.Header.ToString();
            agregarDetalles(39.99, "/Images/maleta.jpg", stkDetalles, "Maleta de color amarilla, con 4 ruedas" +
                ", con una dimensión de 55 cm", "Accesorio");
        }

        private void tlJabon_Click(object sender, RoutedEventArgs e)
        {
            cantidad = 0;
            stkDetalles.Children.Clear();
            this.flyoutsDETALLES.IsOpen = true;
            flyoutsDETALLES.Header = tlJabon.Content;
            producto = flyoutsDETALLES.Header.ToString();
            agregarDetalles(5, "/Images/jabon.jpg", stkDetalles, "Jabon blanco marca DOVE  ", "Limpieza");
        }

        private void tlJabon_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

        }

        private void tlFoco_Click(object sender, RoutedEventArgs e)
        {
            cantidad = 0;
            stkDetalles.Children.Clear();
            this.flyoutsDETALLES.IsOpen = true;
            flyoutsDETALLES.Header = tlFoco.Content;
            producto = flyoutsDETALLES.Header.ToString();
            agregarDetalles(19.00, "/Images/foco.jpeg", stkDetalles, "Foco Inteligente Nexxt Wifi RGB 16 Millones Colores"
             , "Accesorio");
        }

        private void tlPelota_Click(object sender, RoutedEventArgs e)
        {
            cantidad = 0;
            stkDetalles.Children.Clear();
            this.flyoutsDETALLES.IsOpen = true;
            flyoutsDETALLES.Header = tlPelota.Content;
            producto = flyoutsDETALLES.Header.ToString();
            agregarDetalles(32.71, "/Images/pelota.jpeg", stkDetalles, "Pelota plateada para fútbol 11"
             , "Deportivo");
        }

        private void tlLibraArroz_Click(object sender, RoutedEventArgs e)
        {
            cantidad = 0;
            stkDetalles.Children.Clear();
            this.flyoutsDETALLES.IsOpen = true;
            flyoutsDETALLES.Header = tlLibraArroz.Content;
            producto = flyoutsDETALLES.Header.ToString();
            agregarDetalles(0.45, "/Images/arroz.jpg", stkDetalles, "Arroz conejo viejo"
             , "Alimento");
        }

        private void tlHelado_Click(object sender, RoutedEventArgs e)
        {
            cantidad = 0;
            stkDetalles.Children.Clear();
            this.flyoutsDETALLES.IsOpen = true;
            flyoutsDETALLES.Header = tlHelado.Content;
            producto = flyoutsDETALLES.Header.ToString();
            agregarDetalles(1, "/Images/helado.jpg", stkDetalles, "Helado sabor a fresa"
             , "Alimento");
        }

        private void tlPan_Click(object sender, RoutedEventArgs e)
        {
            cantidad = 0;
            stkDetalles.Children.Clear();
            this.flyoutsDETALLES.IsOpen = true;
            flyoutsDETALLES.Header = tlPan.Content;
            producto = flyoutsDETALLES.Header.ToString();
            agregarDetalles(0.25, "/Images/pan.jpg", stkDetalles, "Pan francés casero"
             , "Alimento");
        }

        private async void btnNuevaCompra_Click(object sender, RoutedEventArgs e)
        {
            if (dgCesta.Items.Count != 0)
            {
                dgCesta.Items.Clear();
            }
            else
                await this.ShowMessageAsync("Error", "No hay productos en la cesta, al menos ingrese uno. Por favor");

        }

        private async void btnEliminarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (dgCesta.SelectedItem != null)
            {
                dgCesta.Items.Remove(dgCesta.SelectedItem);
            }
            else
                await this.ShowMessageAsync("Error", "No se ha seleccionado un elemento. Por favor seleccione uno para borrar de su cesta");
        }
       
        private async void btnPagar_Click(object sender, RoutedEventArgs e)
        {
            if (dgCesta.Items.Count != 0)
            {
                double total = 0;
                int limite = dgCesta.Items.Count;
                for (int i = 0; i < limite; i++)
                {
                    total += Double.Parse((dgCesta.Columns[4].GetCellContent(dgCesta.Items[i]) as TextBlock).Text);
                }
                
                objC.setTotal(total);
                objC.btnRegresar.Click += btnCerrar_Click;
                await this.ShowMetroDialogAsync(objC);
            }
            else
                await this.ShowMessageAsync("Atención", "No hay productos en su cesta. Por favor agregue algunos para poder continuar con el pago");

        }

        private async void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            await this.HideMetroDialogAsync(objC);
        }
    }

    public class Datos
    {
        public string Producto { get; set; }
        public string Descripcion { get; set; }
        public string Cantidad { get; set; }
        public string Precio { get; set; }
        public string Total { get; set; }
    }
}
