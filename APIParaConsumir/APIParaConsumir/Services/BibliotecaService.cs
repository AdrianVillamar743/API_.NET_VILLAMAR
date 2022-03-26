using APIParaConsumir.Data;
using APIParaConsumir.Models;
using APIParaConsumir.Models.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace APIParaConsumir.Services
{
    public class BibliotecaService : IBibliotecaService
    {
        private readonly BibliotecasContext _context;
      
        public BibliotecaService(BibliotecasContext context)
        {
            _context = context;
        }

        public void Add(BibliotecaRequest request)
        {
            Biblioteca _biblioteca = new Biblioteca();
            _biblioteca.Nombre = request.Nombre;
            _biblioteca.Direccion = request.Direccion;       
            _context.Add(_biblioteca);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            try
            {
                Biblioteca _biblioteca = _context.Bibliotecas.Find(id);
                _context.Remove(_biblioteca);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Edit(BibliotecaRequest request)
        {
            try
            {
                Biblioteca _biblioteca = _context.Bibliotecas.Find(request.IdBiblioteca);
                _biblioteca.Nombre = request.Nombre;
                _biblioteca.Direccion=request.Direccion;

                _context.Update(_biblioteca);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public IQueryable<Biblioteca> GetAll()
        {
            return _context.Bibliotecas.OrderByDescending(c => c.IdBiblioteca);
        }
    }
}
