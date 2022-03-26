using APIParaConsumir.Data;
using APIParaConsumir.Models.Request;
using APIParaConsumir.Response;
using APIParaConsumir.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace APIParaConsumir.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliotecariaController : ControllerBase
    {
        private readonly IBibliotecariaService _bibliotecariaService;
        private readonly BibliotecasContext _bibliotecasContext;
        public BibliotecariaController(IBibliotecariaService bibliotecariaService, BibliotecasContext bibliotecasContext)

        {
            _bibliotecariaService = bibliotecariaService;
            _bibliotecasContext = bibliotecasContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                _respuesta.Data = _bibliotecariaService.GetAll();
                _respuesta.exito = 1;
            }
            catch (Exception ex)
            {

                _respuesta.Mensaje = ex.Message;
            }
            return Ok(_respuesta);
        }
        
        [HttpPost]
        public IActionResult Add(BibliotecariaRequest request)
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                _bibliotecariaService.Add(request);
                _respuesta.exito=1;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                
            }
            return Ok(_respuesta);
        }


        [HttpPut]
        public IActionResult Edit(BibliotecariaRequest request)
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                _bibliotecariaService.Edit(request);
                _respuesta.exito = 1;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;

            }
            return Ok(_respuesta);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                _bibliotecariaService.Delete(id);
                _respuesta.exito = 1;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;

            }
            return Ok(_respuesta);
        }

    }
}
