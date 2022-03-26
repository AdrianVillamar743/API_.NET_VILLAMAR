using APIParaConsumir.Models.Request;
using APIParaConsumir.Response;
using APIParaConsumir.Services;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIParaConsumir.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliotecaController : ControllerBase
    {
        private readonly IBibliotecaService _bibliotecaService;

        public BibliotecaController(IBibliotecaService bibliotecaService)

        {
            _bibliotecaService = bibliotecaService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                _respuesta.Data = _bibliotecaService.GetAll();
                _respuesta.exito = 1;
            }
            catch (Exception ex)
            {

                _respuesta.Mensaje = ex.Message;
            }
            return Ok(_respuesta);
        }

        [HttpPost]
        public IActionResult Add(BibliotecaRequest request)
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                _bibliotecaService.Add(request);
                _respuesta.exito = 1;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;

            }
            return Ok(_respuesta);
        }

        [HttpPut]
        public IActionResult Edit(BibliotecaRequest request)
        {
            Respuesta _respuesta = new Respuesta();
            try
            {
                _bibliotecaService.Edit(request);
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
                _bibliotecaService.Delete(id);
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


