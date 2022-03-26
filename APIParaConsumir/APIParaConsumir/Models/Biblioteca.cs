using System;
using System.Collections.Generic;

#nullable disable

namespace APIParaConsumir.Models
{
    public partial class Biblioteca
    {
        public Biblioteca()
        {
            Bibliotecaria = new HashSet<Bibliotecaria>();
        }

        public int IdBiblioteca { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Bibliotecaria> Bibliotecaria { get; set; }
    }
}
