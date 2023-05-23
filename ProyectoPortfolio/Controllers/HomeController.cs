using Microsoft.AspNetCore.Mvc;
using ProyectoPortfolio.Models;
using ProyectoPortfolio.Services;
using System.Diagnostics;

namespace ProyectoPortfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos repositorioProyectos;
        private readonly IServicioEmail servicioEmail;

        public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repositorioProyectos, IServicioEmail servicioEmail)
        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            this.servicioEmail = servicioEmail;
        }

        //renderiza una vista
        public IActionResult Index()
        {
            //la configuracion de este viewbag solo sera valido para el index, ya que solo esta
            //configurado nombrecompleto solo en index
            //El problema es que hay que tener cuidado de definir el nombre, ya que se nos puede
            //pasar ese dato
            //El viewbag es de tipo dinamico
            //ViewBag.NombreCompleto = "Kevin Castillo";
            //retorna una vista, lacual se ubica esa vista en el HOME dado por el nombre
            // HomeController y el nombre de la funcion Index
            //en view recibe de parametros el nombre de la vista y algun modelo a representar
            //return View("Index", "Roberto");
            var proyectos = repositorioProyectos.ObtenerProyectos().Take(2).ToList();
            var model = new HomeIndexViewModel()
            {
                Proyectos = proyectos
            };
            return View("Index", model);
        }

        public IActionResult Proyectos()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos();
            return View(proyectos);
        }

        //poner un get no es obligatorio, ya que se sobre entiende que se 
        //esta hablando de una peticion get
        //[HttpGet]
        public IActionResult Contacto()
        {
            return View();
        }

        public IActionResult Gracias()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contacto(ContactoViewModel contactoViewModel)
        {
            try
            {
                await servicioEmail.Enviar(contactoViewModel);
            }
            catch
            {
                throw new Exception();
            }
            return RedirectToAction("Gracias");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}