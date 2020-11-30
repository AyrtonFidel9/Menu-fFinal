using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing.Design;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using ControlzEx.Theming;

namespace WpfAppEditorTexto
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        int tam;
        public MainWindow()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.CanMinimize;
            drpTamanio.Content = rchCaja.FontSize;
            ThemeManager.Current.ChangeTheme(this, "Light.Orange");

        }

        private async void btnPegar_Click(object sender, RoutedEventArgs e)
        {
            this.vistoBueno.Badge = " ";
            if (System.Windows.Forms.Clipboard.ContainsText()) // verifica si se ha seleccionado el texto
                rchCaja.Paste();
            else
                await this.ShowMessageAsync("Atención", "No hay nada copiado en el portapapeles");
            rchCaja.Focus();

        }

        private async void btnCopiar_Click(object sender, RoutedEventArgs e)
        {

            if (!rchCaja.Selection.IsEmpty) // verifica si se a seleccionado el texto
            {
                rchCaja.Copy();
                this.vistoBueno.Badge = "✓";
            }
            else
                await this.ShowMessageAsync("Atención", "Seleccione una palabra, oración o párrafo. Por favor");


        }

        private async void btnCortar_Click(object sender, RoutedEventArgs e)
        {
            if (!rchCaja.Selection.IsEmpty) // verifica si se ha seleccionado el texto
            {
                rchCaja.Cut();
            }
            else
                await this.ShowMessageAsync("Atención", "Seleccione una palabra, oración o párrafo. Por favor");
        }

        private async void btnNegrita_Click(object sender, RoutedEventArgs e)
        {
            if (!rchCaja.Selection.IsEmpty)// verifica si se ha seleccionado el texto
            {
                var selection = rchCaja.Selection;
                if (selection.GetPropertyValue(TextElement.FontWeightProperty).ToString() == "Bold") // tomar la propiedad del texto seleccionado y verificar si esta en negrita
                    selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Normal);
                else
                    selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
            }
            else
                await this.ShowMessageAsync("Atención", "Seleccione una palabra, oración o párrafo. Por favor");
        }

        private async void btnCursiva_Click(object sender, RoutedEventArgs e)
        {
            var selection = rchCaja.Selection;
            if (!rchCaja.Selection.IsEmpty)
            {
                if (selection.GetPropertyValue(Inline.FontStyleProperty).ToString() == "Italic")
                    selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Normal);// tomar la propiedad del texto seleccionado y verificar si esta en cursiva
                else
                    selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Italic);
            }
            else
                await this.ShowMessageAsync("Atención", "Seleccione una palabra, oración o párrafo. Por favor");
        }

        private async void btnUnderline_Click(object sender, RoutedEventArgs e)
        {
            var selection = rchCaja.Selection;
            if (!rchCaja.Selection.IsEmpty)
            {
                if (selection.GetPropertyValue(Inline.TextDecorationsProperty).Equals(TextDecorations.Underline)) // tomar la propiedad del texto seleccionado y verificar si esta en underline
                    selection.ApplyPropertyValue(Inline.TextDecorationsProperty, null);
                else
                    selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);

            }
            else
                await this.ShowMessageAsync("Atención", "Seleccione una palabra, oración o párrafo. Por favor");
        }

        private async void btnAumentarTamanio_Click(object sender, RoutedEventArgs e)
        {
            var selection = rchCaja.Selection;
            if (!rchCaja.Selection.IsEmpty)
            {
                tam++;
                selection.ApplyPropertyValue(TextElement.FontSizeProperty, FontSize = tam);
                drpTamanio.Content = tam;
            }
            else
                await this.ShowMessageAsync("Atención", "Seleccione una palabra, oración o párrafo. Por favor");
        }


        private void rchCaja_MouseMove(object sender, MouseEventArgs e)
        {
            var selection = rchCaja.Selection;
            if (!rchCaja.Selection.IsEmpty && 
                selection.GetPropertyValue(TextElement.FontSizeProperty) != DependencyProperty.UnsetValue)
            {
                drpTamanio.Content = selection.GetPropertyValue(TextElement.FontSizeProperty).ToString();
                tam = int.Parse(drpTamanio.Content.ToString());
            }

                
        }

        private async void btnDisminuir_Click(object sender, RoutedEventArgs e)
        {
            var selection = rchCaja.Selection;
            if (!rchCaja.Selection.IsEmpty)
            {
                if (tam >= 2)
                {
                    tam--;
                    selection.ApplyPropertyValue(TextElement.FontSizeProperty, FontSize = tam);
                    drpTamanio.Content = tam;
                }
                
            }
            else
                await this.ShowMessageAsync("Atención", "Seleccione una palabra, oración o párrafo. Por favor");
        }

        private async void txtAcme_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var selection = rchCaja.Selection;
            if (!rchCaja.Selection.IsEmpty)
            {
                selection.ApplyPropertyValue(Inline.FontFamilyProperty, txtAcme.FontFamily);
            }
            else
                await this.ShowMessageAsync("Atención", "Seleccione una palabra, oración o párrafo. Por favor");

        }

        private async void txtLobster_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var selection = rchCaja.Selection;
            if (!rchCaja.Selection.IsEmpty)
            {
                selection.ApplyPropertyValue(Inline.FontFamilyProperty, txtLobster.FontFamily);
            }
            else
                await this.ShowMessageAsync("Atención", "Seleccione una palabra, oración o párrafo. Por favor");
        }

        private async void txtOpenSans_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var selection = rchCaja.Selection;
            if (!rchCaja.Selection.IsEmpty)
            {
                selection.ApplyPropertyValue(Inline.FontFamilyProperty, txtOpenSans.FontFamily);
            }
            else
                await this.ShowMessageAsync("Atención", "Seleccione una palabra, oración o párrafo. Por favor");
        }

        private async void txtPassion_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var selection = rchCaja.Selection;
            if (!rchCaja.Selection.IsEmpty)
            {
                selection.ApplyPropertyValue(Inline.FontFamilyProperty, txtPassion.FontFamily);
            }
            else
                await this.ShowMessageAsync("Atención", "Seleccione una palabra, oración o párrafo. Por favor");
        }

        private async void txtDefecto_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var selection = rchCaja.Selection;
            if (!rchCaja.Selection.IsEmpty)
            {
                selection.ApplyPropertyValue(Inline.FontFamilyProperty, txtDefecto.FontFamily);
            }
            else
                await this.ShowMessageAsync("Atención", "Seleccione una palabra, oración o párrafo. Por favor");
        }

        private async void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var selection = rchCaja.Selection;
            if (!rchCaja.Selection.IsEmpty)
            {
                selection.ApplyPropertyValue(Inline.FontSizeProperty, FontSize = 2);
            }
            else
                await this.ShowMessageAsync("Atención", "Seleccione una palabra, oración o párrafo. Por favor");
        }

        private async void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            var selection = rchCaja.Selection;
            if (!rchCaja.Selection.IsEmpty)
            {
                selection.ApplyPropertyValue(Inline.FontSizeProperty, cuatro.Text);
            }
            else
                await this.ShowMessageAsync("Atención", "Seleccione una palabra, oración o párrafo. Por favor");
        }

        private async void seis_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var selection = rchCaja.Selection;
            if (!rchCaja.Selection.IsEmpty)
            {
                selection.ApplyPropertyValue(Inline.FontSizeProperty, seis.Text);
            }
            else
                await this.ShowMessageAsync("Atención", "Seleccione una palabra, oración o párrafo. Por favor");
        }

        private async void ocho_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var selection = rchCaja.Selection;
            if (!rchCaja.Selection.IsEmpty)
            {
                selection.ApplyPropertyValue(Inline.FontSizeProperty, ocho.Text);
            }
            else
                await this.ShowMessageAsync("Atención", "Seleccione una palabra, oración o párrafo. Por favor");
        }

        private async void diez_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var selection = rchCaja.Selection;
            if (!rchCaja.Selection.IsEmpty)
            {
                selection.ApplyPropertyValue(Inline.FontSizeProperty, diez.Text);
            }
            else
                await this.ShowMessageAsync("Atención", "Seleccione una palabra, oración o párrafo. Por favor");
        }

        private async void doce_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var selection = rchCaja.Selection;
            if (!rchCaja.Selection.IsEmpty)
            {
                selection.ApplyPropertyValue(Inline.FontSizeProperty, doce.Text);
            }
            else
                await this.ShowMessageAsync("Atención", "Seleccione una palabra, oración o párrafo. Por favor");
        }

        private async void catorce_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var selection = rchCaja.Selection;
            if (!rchCaja.Selection.IsEmpty)
            {
                selection.ApplyPropertyValue(Inline.FontSizeProperty, catorce.Text);
            }
            else
                await this.ShowMessageAsync("Atención", "Seleccione una palabra, oración o párrafo. Por favor");
        }

        private async void dieciseis_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var selection = rchCaja.Selection;
            if (!rchCaja.Selection.IsEmpty)
            {
                selection.ApplyPropertyValue(Inline.FontSizeProperty, dieciseis.Text);
            }
            else
                await this.ShowMessageAsync("Atención", "Seleccione una palabra, oración o párrafo. Por favor");
        }

        private async void dieziocho_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var selection = rchCaja.Selection;
            if (!rchCaja.Selection.IsEmpty)
            {
                selection.ApplyPropertyValue(Inline.FontSizeProperty, dieziocho.Text);
            }
            else
                await this.ShowMessageAsync("Atención", "Seleccione una palabra, oración o párrafo. Por favor");
        }

        private async void veinte_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var selection = rchCaja.Selection;
            if (!rchCaja.Selection.IsEmpty)
            {
                selection.ApplyPropertyValue(Inline.FontSizeProperty, veinte.Text);
            }
            else
                await this.ShowMessageAsync("Atención", "Seleccione una palabra, oración o párrafo. Por favor");
        }

        private async void veinteCuatro_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var selection = rchCaja.Selection;
            if (!rchCaja.Selection.IsEmpty)
            {
                selection.ApplyPropertyValue(Inline.FontSizeProperty, veinteCuatro.Text);
            }
            else
                await this.ShowMessageAsync("Atención", "Seleccione una palabra, oración o párrafo. Por favor");
        }

        private async void veinteOcho_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var selection = rchCaja.Selection;
            if (!rchCaja.Selection.IsEmpty)
            {
                selection.ApplyPropertyValue(Inline.FontSizeProperty, veinteOcho.Text);
            }
            else
                await this.ShowMessageAsync("Atención", "Seleccione una palabra, oración o párrafo. Por favor");
        }

        private async void treintados_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var selection = rchCaja.Selection;
            if (!rchCaja.Selection.IsEmpty)
            {
                selection.ApplyPropertyValue(Inline.FontSizeProperty, treintados.Text);
            }
            else
                await this.ShowMessageAsync("Atención", "Seleccione una palabra, oración o párrafo. Por favor");
        }

        private async void txtLeft_Click(object sender, RoutedEventArgs e)
        {
      
            if (!rchCaja.Selection.IsEmpty)
            {
                rchCaja.Selection.ApplyPropertyValue(Block.TextAlignmentProperty, TextAlignment.Left);
            }
            else
                await this.ShowMessageAsync("Atención", "Seleccione una palabra, oración o párrafo. Por favor");
            
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!rchCaja.Selection.IsEmpty)
            {
                rchCaja.Selection.ApplyPropertyValue(Block.TextAlignmentProperty, TextAlignment.Right);
            }
            else
                await this.ShowMessageAsync("Atención", "Seleccione una palabra, oración o párrafo. Por favor");
        }

        private async void btnJustificar_Click(object sender, RoutedEventArgs e)
        {
            if (!rchCaja.Selection.IsEmpty)
            {
                rchCaja.Selection.ApplyPropertyValue(Block.TextAlignmentProperty, TextAlignment.Justify);
            }
            else
                await this.ShowMessageAsync("Atención", "Seleccione una palabra, oración o párrafo. Por favor");
        }

        private async void btnColor_Click(object sender, RoutedEventArgs e)
        {
            if (!rchCaja.Selection.IsEmpty)
            {
                ColorDialog colorDialog = new ColorDialog();
                colorDialog.Owner = this;
                colorDialog.ShowDialog();
                rchCaja.Selection.ApplyPropertyValue(Block.ForegroundProperty, new SolidColorBrush(colorDialog.SelectedColor));
            }
            else
                await this.ShowMessageAsync("Atención", "Seleccione una palabra, oración o párrafo. Por favor");
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog objDg = new System.Windows.Forms.SaveFileDialog();
            objDg.Filter = "Rich Text Format (*.rtf)|*.rtf|Archivos de texto (*.txt)|*.txt |All files (*.*)|*.*";
            var guardar = objDg.ShowDialog(); 
            if (guardar == System.Windows.Forms.DialogResult.OK)
            {
                FileStream fileStream = new FileStream(objDg.FileName, FileMode.Create);
                TextRange range = new TextRange(rchCaja.Document.ContentStart, rchCaja.Document.ContentEnd);
                range.Save(fileStream, DataFormats.Rtf);
            }
        }

        private void mnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void mnAbrir_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog objDg = new System.Windows.Forms.OpenFileDialog();
            objDg.Filter = "Rich Text Format (*.rtf)|*.rtf|Archivos de texto (*.txt)|*.txt |All files (*.*)|*.*";
            var abrir = objDg.ShowDialog();
            if (abrir == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    FileStream fileStream = new FileStream(objDg.FileName, FileMode.Open);
                    TextRange range = new TextRange(rchCaja.Document.ContentStart, rchCaja.Document.ContentEnd);
                    range.Load(fileStream, DataFormats.Rtf);
                }
                catch
                {
                    await this.ShowMessageAsync("Atención", "Error al cargar el archivo. Intentelo de nuevo");
                }

            }
        }

        private void mnCerrar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(mododark.FontWeight.Equals(FontWeights.Normal))
            {
                Bold_Checked(sender, e);
                ThemeManager.Current.ChangeTheme(this, "Dark.Orange");
            }
            else if(mododark.FontWeight.Equals(FontWeights.Bold))
            {
                Bold_Unchecked(sender, e);
                ThemeManager.Current.ChangeTheme(this, "Light.Orange");
            }
                
        }

        private void Bold_Checked(object sender, RoutedEventArgs e)
        {
            mododark.FontWeight = FontWeights.Bold;
        }

        private void Bold_Unchecked(object sender, RoutedEventArgs e)
        {
            mododark.FontWeight = FontWeights.Normal;
        }

        private void btnGuardar_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog dlg = new System.Windows.Forms.SaveFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            var abrir = dlg.ShowDialog();
            if (abrir == System.Windows.Forms.DialogResult.OK)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Create);
                TextRange range = new TextRange(rchCaja.Document.ContentStart, rchCaja.Document.ContentEnd);
                range.Save(fileStream, DataFormats.Rtf);
            }
        }
    }
}

