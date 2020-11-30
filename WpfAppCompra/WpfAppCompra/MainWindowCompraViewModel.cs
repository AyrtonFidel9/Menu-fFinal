using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;

namespace WpfAppCompra
{
    class MainWindowCompraViewModel : IDataErrorInfo
    {

        #region IDataErrorInfo Members 

        private int age;
        private string nombre;
        private string cedula;
        private string pago;
        private bool _nombre;
        private bool _cedula;
        private bool _pago;


        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Nombre { get => nombre; set => nombre = value; }

        public string Error
        {
            get
            {
                return null;
            }
        }

        public string Cedula { get => cedula; set => cedula = value; }
        public string Pago { get => pago; set => pago = value; }
        public bool Nombre1 { get => _nombre; set => _nombre = value; }
        public bool Cedula1 { get => _cedula; set => _cedula = value; }
        public bool Pago1 { get => _pago; set => _pago = value; }

        public string this[string name]
        {
            get
            {
                string result = null;

                //if (name == "Age")
                //{
                //    if (this.age < 0 || this.age > 150)
                //    {
                //        result = "Age must not be less than 0 or greater than 150.";
                //    }
                //}
                if(name == "Nombre")
                {

                    if (string.IsNullOrEmpty(nombre))
                    {

                        result = "Campo obligatorio, ingrese un nombre.";
                        this._nombre = false;
                    }
                    else
                        this._nombre = true;
                    try
                    {
                        if(nombre.Length != 0)
                        {
                            for (int i = 0; i < nombre.Length; i++)
                            {
                                if ((int)nombre[i] >= 48 && (int)nombre[i] <= 57)
                                {
                                    result = "No se admite valores numéricos en un nombre";
                                    this._nombre = false;
                                }
                                else
                                    this._nombre = true;
                            }
                        }
                       
                    }
                    catch
                    {
                    }
                   //MessageBox.Show("nombre: "+_nombre.ToString());

                }
                if(name == "Cedula")
                {
                    if (string.IsNullOrEmpty(cedula))
                    {
                        result = "Campo obligatorio, ingrese un nombre.";
                        this._cedula = false;
                    }
                    else
                    {
                        this._cedula = true;
                        try
                        {
                            if(cedula.Length > 10)
                            {
                                result = "El número de cédula no debe superar los 10 dígitos";
                                this._cedula = false;
                            }
                            else
                                _cedula = true;
                            for (int i = 0; i < cedula.Length; i++)
                            {
                                if (!((int)cedula[i] >= 48 && (int)cedula[i] <= 57))
                                {
                                    result = "No se admiten caracteres en un número de cédula";
                                    this._cedula = false;
                                }
                                else
                                    this._cedula = true;
                            }

                        }
                        catch
                        {
                        }

                    }
                    //MessageBox.Show("cedula: "+_cedula.ToString());
                }
                if (name == "Pago")
                {
                    if (string.IsNullOrEmpty(pago))
                    {
                        result = "Campo obligatorio, ingrese una forma de pago.";
                        _pago = false;
                    }
                    else
                        _pago = true;
                    //MessageBox.Show("pago: "+_pago.ToString());
                }
                return result;
            }
        }


        #endregion
    }
}
