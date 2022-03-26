using APIParaConsumir.Data;
using APIParaConsumir.Models;
using APIParaConsumir.Models.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace APIParaConsumir.Services
{
    public class LibroService:ILibroService
    {
        
            private readonly BibliotecasContext _context;

            public LibroService(BibliotecasContext context)
            {
                _context = context;
            }
            public void Add(LibroRequest request)
            {
                Libro _libro = new Libro();
                _libro.Nombre = request.Nombre;
                _libro.Descripcion = request.Descripcion;
                _libro.IdBibliotecaria=request.IdBibliotecaria;
                _context.Add(_libro);
                _context.SaveChanges();
            }

            public void Delete(int id)
            {
                try
                {
                    Libro _libro = _context.Libros.Find(id);
                    _context.Remove(_libro);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }

            public void Edit(LibroRequest request)
            {
                try
                {
                    Libro _libro = _context.Libros.Find(request.Id);
                    _libro.Nombre = request.Nombre;
                    _libro.Descripcion = request.Descripcion;
                    _libro.IdBibliotecaria = request.IdBibliotecaria;
                    _context.Update(_libro);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }

            public IQueryable<Libro> GetAll()
            {
                return _context.Libros.Include(c => c.IdBibliotecariaNavigation).OrderByDescending(a => a.Id);
            }
        }
    }
