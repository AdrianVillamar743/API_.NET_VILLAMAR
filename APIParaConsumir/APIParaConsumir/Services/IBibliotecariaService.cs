using APIParaConsumir.Models;
using APIParaConsumir.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
namespace APIParaConsumir.Services
{
    public interface IBibliotecariaService
    {
        public IQueryable<Bibliotecaria> GetAll();
       public void Add(BibliotecariaRequest request);
        public void Edit(BibliotecariaRequest request);
        public void Delete(int id);

    }
}
