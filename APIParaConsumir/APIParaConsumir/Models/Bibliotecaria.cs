using System;
using System.Collections.Generic;

#nullable disable

namespace APIParaConsumir.Models
{
    public partial class Bibliotecaria
    {
        public Bibliotecaria()
        {
            Libros = new HashSet<Libro>();
        }

        public int IdBibliotecaria { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? IdBiblioteca { get; set; }

        public virtual Biblioteca IdBibliotecaNavigation { get; set; }
        public virtual ICollection<Libro> Libros { get; set; }
    }
}
