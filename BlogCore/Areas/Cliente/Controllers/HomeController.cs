using BlogCore.AccesoDatos.Data.Repository.IRepository;
using BlogCore.Models;
using BlogCore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing.Printing;

namespace BlogCore.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    public class HomeController : Controller
    {

        private readonly IContenedorTrabajo _contenedorTrabajo;

        public HomeController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        //P�gina de inicio sin paginaci�n
        //public IActionResult Index()
        //{
        //    HomeVM homeVM = new HomeVM()
        //    {
        //        slider = _contenedorTrabajo.Slider.GetAll(),
        //        listArticulo = _contenedorTrabajo.Articulo.GetAll()
        //    };

        //    ViewBag.IsHome = true;

        //    return View(homeVM);
        //}

        //Pagina de inicio con paginaci�n
        public IActionResult Index(int page = 1, int pageSize = 6)
        {
            var articulos = _contenedorTrabajo.Articulo.AsQueryable();
            var paginatedEntries = articulos.Skip((page - 1) * pageSize).Take(pageSize);

            HomeVM homeVM = new HomeVM()
            {
                slider = _contenedorTrabajo.Slider.GetAll(),
                listArticulo = paginatedEntries.ToList(),
                PageIndex = page,
                TotalPages = (int)Math.Ceiling(articulos.Count() / (double)pageSize)
            };

            ViewBag.IsHome = true;

            return View(homeVM);
        }


        public IActionResult ResultadoBusqueda(string stringSearch, int page = 1, int pageSize = 6)
        {
            var articulos = _contenedorTrabajo.Articulo.AsQueryable();

            //Verifico que exista lo buscado
            if (!string.IsNullOrEmpty(stringSearch))
            {
                articulos = articulos.Where(e => e.Nombre.ToUpper().Contains(stringSearch.ToUpper()));
            }

            //Pagino resultados
            var paginatedEntries = articulos.Skip((page - 1) * pageSize).Take(pageSize);

            //Creo modelo para la vista
            var model = new ListaPaginada<Articulo>(paginatedEntries.ToList(), articulos.Count(), page, pageSize, stringSearch);
            return View(model);
        }

        public IActionResult Detalle(int id)
        {
            var articuloDB = _contenedorTrabajo.Articulo.Get(id);
            return View(articuloDB);
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
