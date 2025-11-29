using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Clases
{
   public class Raza
    {
        public int Id { get; set; }
        public string NombreRaza { get; set; }
        public List<Animal>? Animales { get; set; }= new List<Animal>();

    }
}
