using Microsoft.AspNetCore.Mvc;
using ProyectoPortfolio.Models;
using System.Diagnostics;

namespace ProyectoPortfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
            var proyectos = ObtenerProyectos().Take(2).ToList();
            var model = new HomeIndexViewModel()
            {
                Proyectos = proyectos
            };
            return View("Index", model);
        }

        private List<ProyectDTO> ObtenerProyectos()
        {
            return new List<ProyectDTO>
            {
                new ProyectDTO
                {
                    Titulo =  "Game-Place",
                    Descripcion = "Este proyecto se trata de una tienda online de videojuegos donde se puede comprar a traves de un stock una cantidad de juegos especificos de una base de datos subida en Firebase, ademas del uso de contexto para carritos y routing",
                    ImagenURL = "/images/proyectos/proyectoGamePlaceReact.png",
                    Link ="https://github.com/nicocastx/Game-Place",
                },
                new ProyectDTO
                {
                    Titulo =  "Instrumenty",
                    Descripcion = "Proyecto orientado al backend en donde desarrollo una aplicacion orientada al back-end",
                    ImagenURL = "/images/proyectos/proyectoInstrumentyBackend.png",
                    Link ="https://github.com/nicocastx/Game-Place",
                },
                new ProyectDTO
                {
                    Titulo =  "Criptowin",
                    Descripcion = "Criptowin es un proyecto realizado para demostrar mis conocimiento" +
                    "adquiridos durante el cursado de Desarrollo Web en Coderhouse",
                    ImagenURL = "/images/proyectos/proyectoCriptoWinDW.png",
                    Link = "https://criptowin-4ctdw1k5j-nicocastx.vercel.app/"
                },
                new ProyectDTO
                {
                    Titulo =  "SteamSim",
                    Descripcion = "SteamSim es mi proyecto desarrollado para el curso de Javascript en la Academia de Coderhouse ",
                    ImagenURL = "/images/proyectos/proyectoSteamSimJS.png",
                    Link ="https://steam-sim-coder-a0cy0c1h6-nicocastx.vercel.app/",
                },
            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}