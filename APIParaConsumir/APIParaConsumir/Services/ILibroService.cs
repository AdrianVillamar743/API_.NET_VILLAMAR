using APIParaConsumir.Models;
using APIParaConsumir.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace APIParaConsumir.Services
{
    public interface ILibroService
    {
        public IQueryable<Libro> GetAll();
        public void Add(LibroRequest request);
        public void Edit(LibroRequest request);
        public void Delete(int id);

    }
}
