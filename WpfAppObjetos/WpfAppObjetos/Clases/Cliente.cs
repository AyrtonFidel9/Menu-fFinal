using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppObjetos.Clases
{
    class Cliente
    {
        private string nombre;
        private string apellido;
        private string cedula;
        private string telefono;
        private string direccion;
        private string email;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Email { get => email; set => email = value; }

    }
}
