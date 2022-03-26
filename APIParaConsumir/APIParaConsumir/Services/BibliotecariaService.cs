using APIParaConsumir.Data;
using APIParaConsumir.Models;
using APIParaConsumir.Models.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace APIParaConsumir.Services
{
    public class BibliotecariaService : IBibliotecariaService
    {
        private readonly BibliotecasContext _context;

        public BibliotecariaService(BibliotecasContext context)
        {
            _context = context;
        }
        public void Add(BibliotecariaRequest request)
        {
            Bibliotecaria _bibliotecaria = new Bibliotecaria();
            _bibliotecaria.Nombre = request.Nombre;
            _bibliotecaria.Apellido = request.Apellido;
            _bibliotecaria.IdBiblioteca = request.IdBiblioteca;
            _context.Add(_bibliotecaria);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            try
            {
                Bibliotecaria _bibliotecaria = _context.Bibliotecaria.Find(id);
                _context.Remove(_bibliotecaria);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Edit(BibliotecariaRequest request)
        {
            try
            {
                Bibliotecaria _bibliotecaria = _context.Bibliotecaria.Find(request.IdBibliotecaria);
                _bibliotecaria.Nombre = request.Nombre;
                _bibliotecaria.Apellido = request.Apellido;
                _bibliotecaria.IdBiblioteca = request.IdBiblioteca;
                _context.Update(_bibliotecaria);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<Bibliotecaria> GetAll()
        {
            return _context.Bibliotecaria.Include(c => c.IdBibliotecaNavigation).OrderByDescending(a=>a.IdBibliotecaria);
        }
    }
}
