using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogCore.AccesoDatos.Data.Repository;
using BlogCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogCore.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class CategoriasController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public CategoriasController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]                          // validacion del token, para evitar hackeos al formulario.
        public IActionResult Create(Categoria categoria)    // recibe la categoria.
        {
            // primero validamos el modelo, los campos requeridos, la longuitud de caracteres, lo que el usuario haya escrito.
            // esto en el caso que sea valido todos los campos se cumplen se guardan en la base de datos, y retorna al index. Sino retorna la vista.
            if (ModelState.IsValid)                         
            {
                _contenedorTrabajo.Categoria.Add(categoria);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // vamos a buscar dentro de las categorias la que le estamos pasando por el id que viene del ajax (data). del boton Editar le pasamos la data.
            // luego validamos si la categoria es null, que devuelva un NotFound (error 504), sino que retorne la vista con la categoria.
            Categoria categoria = new Categoria();
            categoria = _contenedorTrabajo.Categoria.Get(id);

            if (categoria == null)
                return NotFound();

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]                          // validacion del token, para evitar hackeos al formulario.
        public IActionResult Edit(Categoria categoria)    // recibe la categoria.
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Categoria.Update(categoria);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        #region "Llamadas a la api"
        [HttpGet]
        public IActionResult GetAll()
        {
            // llamada a todo con el metodo GetAll desde el IRepository generico
            return Json(new { data = _contenedorTrabajo.Categoria.GetAll()});
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Categoria.Get(id);

            if (objFromDb == null)
                return Json(new { success = false, message = "Error, borrando categoria" });

            _contenedorTrabajo.Categoria.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Categoria borrada correctamente!" });
        }
        #endregion
    }
}
