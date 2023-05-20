using ProyectoPortfolio.Models;

namespace ProyectoPortfolio.Services
{
    public interface IRepositorioProyectos
    {
        List<ProyectDTO> ObtenerProyectos();
    }

    public class RepositorioProyectos : IRepositorioProyectos
    {
        public List<ProyectDTO> ObtenerProyectos()
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
                    Link ="https://proyectofinalbackend-production-c2fa.up.railway.app/",
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
    }
}
