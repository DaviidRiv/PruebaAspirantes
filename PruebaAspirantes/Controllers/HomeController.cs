using Microsoft.AspNetCore.Mvc;
using PruebaAspirantes.Models;
using System.Diagnostics;
using PruebaAspirantes.Services;

namespace PruebaAspirantes.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService_API _servicioAPI;

        public HomeController(IService_API servicioAPI)
        {
            _servicioAPI = servicioAPI;
        }

        public async Task<IActionResult> Index()
        {
            List<ModelAspirantes> lista = await _servicioAPI.Lista();
            return View(lista);
        }

        //VA A CONTROLAR LAS FUNCIONES DE GUARDAR O EDITAR
        public async Task<IActionResult> Aspirante(int Id)
        {

            ModelAspirantes modelo_producto = new ModelAspirantes();

            ViewBag.Accion = "Nuevo Aspirante";

            if (Id != 0)
            {
                ViewBag.Accion = "Editar Aspirante";
                modelo_producto = await _servicioAPI.Obtener(Id);
            }

            return View(modelo_producto);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarCambios(ModelAspirantes ob_producto)
        {

            bool respuesta;

            if (ob_producto.Id == 0)
            {
                respuesta = await _servicioAPI.Guardar(ob_producto);
            }
            else
            {
                respuesta = await _servicioAPI.Editar(ob_producto);
            }


            if (respuesta)
                return RedirectToAction("Index");
            else
                return NoContent();

        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int Id)
        {

            var respuesta = await _servicioAPI.Eliminar(Id);

            if (respuesta)
                return RedirectToAction("Index");
            else
                return NoContent();
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