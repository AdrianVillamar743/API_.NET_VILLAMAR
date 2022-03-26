# API_.NET_VILLAMAR
 API Rest creada utilizando .net y SQL server.
En esta ocasión crearemos un CRUD  API .NET Core con tablas relacionadas.
Utilizaremos el gestor de Base de Datos SQL server y el editor de texto Visual Studio.

1.- Abriremos Visual Studio para crear la API que consumiremos.

2.- Crearemos un nuevo proyecto seleccionando ASP.NET Core Web API

3.- Seleccionamos la plataforma que es core 5.0 

4.- Le damos click a crear

5.- Una vez el proyecto ha sido creado abriremos la consola de administrador de paquetes mediante la pestaña tools y luego Nuget Package Manager->Package Manager Console.

6.- Instalaremos por comando los paquetes a utilizarse.

7.- Utilizaremos el siguiente comando 

Install-Package Microsoft.EntityFrameworkCore.Tools

8.- Claro si deseas instalarlo desde la interfaz gráfica no hay problema.
Siempre que tengas instalado el paquete a usarse.

9.- Instalaremos el paquete de 
Microsoft.EntityFrameworkCore.SqlServer

10.- Cabe recalcar que las versiones de los paquetes deben ser 5.0


11.- Utilizaremos la consola del proyecto para generar la conexion con el siguiente comando

Scaffold-DbContext "Data source=LAPTOP-M2BTP9V4; Initial Catalog=Bibliotecas; user id=adrian password=villamar;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

12.- Crearemos una nueva carpeta llamada Data

13.- Moveremos nuestro Biblioteca Context importaremos los modelos, y cambiaremos el namespace por namespace APIParaConsumir.Data

14.- En el archivo appsetting.json modificaremos agregando lo siguiente 

  "ConnectionStrings": { "DefaultConnection": "Data source=LAPTOP-M2BTP9V4; Initial Catalog=Bibliotecas; user id=adrian password= villamar;Trusted_Connection=True;" }, 


15.- Dentro del archivo startup.cs utilizaremos lo siguiente en la funcion ConfigureServices.

  services.AddDbContext<BibliotecasContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });


Donde BibliotecasContext es el contexto que movimos a la carpeta Data por lo cual importaremos los archivos de la carpeta y las herramientas
using APIParaConsumir.Data;
using Microsoft.EntityFrameworkCore;

16.- Para probar el funcionamiento le damos a play

17.- Crearemos un nuevo controlador. API Controller Empty con el nombre BibliotecaController

18.- De la forma del paso 16 y 17 crearemos Libro y Bibliotecaria controller.

19.- En la carpeta Models agregaremos una nueva carpeta llamada Request

20.- Dentro de esta carpeta crearemos clases vacias llamadas LibroRequest,BibliotecaRequest,BibliotecariaRequest

21.- Dentro de cada una de ellas  procederemos a crear los campos con getter y setter por ejemplo

namespace APIParaConsumir.Models.Request
{
    public class BibliotecaRequest
    {
        public int IdBiblioteca { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
    }
}



//////////////

namespace APIParaConsumir.Models.Request
{
    public class BibliotecariaRequest
    {
        public int IdBibliotecaria { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdBiblioteca { get; set; }
    }
}

22.- Dentro del proyecto daremos click derecho nueva carpeta llamada services y crearemos una nueva clase de tipo interfaz para Bibliotecaria

IBibliotecariaService

23.- Dentro de la interfaz definiremos los métodos que deberán estar implementados en la clase en este caso empezaremos por el listar y 
agregar.

   public IQueryable<Bibliotecaria> GetAll();
       public void Add(BibliotecariaRequest request);    
       
24.- Crearemos una nueva clase dentro de la carpeta llamada services con el nombre BibliotecariaService
Heredamos la interfaz e implementamos sus métodos.


25.- Crearemos un constructor para el servicio con el contexto de biblioteca  referenciando a su constructor de conexión

        private readonly BibliotecasContext _context;

        public BibliotecariaService(BibliotecasContext context)
        {
            _context = context;
        }

26.- Y modificamos la funcion getAll para incluir la relacion de la biblioteca quedando asi
  public IQueryable<Bibliotecaria> GetAll()
        {
            return _context.Bibliotecaria.Include(c => c.IdBibliotecaNavigation).OrderByDescending(a=>a.IdBibliotecaria);
        }

27.- Procederemos a modificar el controller quedando de la siguiente forma.

using APIParaConsumir.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIParaConsumir.Controllers
{
    public class BibliotecariaController : Controller
    {
        private readonly IBibliotecariaService _bibliotecariaService;

        public BibliotecariaController(IBibliotecariaService bibliotecariaService)

        {
            _bibliotecariaService = bibliotecariaService;
        }

        public IActionResult GetAll()
        {

        }

    }
}

28.- Pero la funcion del controlador GetAll() necesita una respuesta por lo que dentro del proyecto crearemos una nueva carpeta llamada Response
Dentro de Response crearemos una clase llamada Respuesta con el siguiente codigo
namespace APIParaConsumir.Response
{
    public class Respuesta
    {
        public int exito { get; set; }
        public string Mensaje { get; set; }

        public object Data { get; set; }

        public Respuesta()
        {
            this.exito = 0;
        }
    }
}


29.- Y modificaremos el bibliotecariaController
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

        public BibliotecariaController(IBibliotecariaService bibliotecariaService)

        {
            _bibliotecariaService = bibliotecariaService;
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
    }
}


30.- Como dato importante debemos instanciar el servidio creado dentro del startup.cs en la función ConfigureServices.

services.AddScoped<IBibliotecariaService, BibliotecariaService>();

31.- Debemos indicar el formato de salida por lo que utilizaremos tambien el paquete de 
Microsoft.AspNetCore.Mvc.NewtonsoftJson

32.-  Indicamos el formato de Salida de json

   services.AddControllersWithViews().AddNewtonsoftJson(
                options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                }
                );


Ello para la función listar el resto de funciones del CRUD  del api estarán dentro del código.

