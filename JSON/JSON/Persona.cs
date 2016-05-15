using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    class Persona
    {

        private string nombre;
        private int edad;

        //En este ejemplo no vamos a poner un constructor
        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public int Edad
        {
            get
            {
                return edad;
            }

            set
            {
                edad = value;
            }
        }
    }
}
