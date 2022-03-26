using APIParaConsumir.Models;
using APIParaConsumir.Models.Request;
using System.Linq;

namespace APIParaConsumir.Services
{
    public interface IBibliotecaService
    {
        public IQueryable<Biblioteca> GetAll();
        public void Add(BibliotecaRequest request);
        public void Edit(BibliotecaRequest request);
        public void Delete(int id);
    }
}
