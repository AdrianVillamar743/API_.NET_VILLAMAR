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
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;
        private readonly BibliotecasContext _bibliotecasContext;

        public LibroController(ILibroService libroService, BibliotecasContext bibliotecasContext)
        {
            _libroService = libroService;
            _bibliotecasContext = bibliotecasContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                _respuesta.Data = _libroService.GetAll();
                _respuesta.exito = 1;
            }
            catch (Exception ex)
            {

                _respuesta.Mensaje = ex.Message;
            }
            return Ok(_respuesta);
        }

        [HttpPost]
        public IActionResult Add(LibroRequest request)
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                _libroService.Add(request);
                _respuesta.exito = 1;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;

            }
            return Ok(_respuesta);
        }


        [HttpPut]
        public IActionResult Edit(LibroRequest request)
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                _libroService.Edit(request);
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
                _libroService.Delete(id);
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
