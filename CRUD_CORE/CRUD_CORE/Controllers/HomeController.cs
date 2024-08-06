using CRUD_CORE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository.Dao;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_CORE.Controllers
{
    public class HomeController : Controller
    {
        IVehiculo _service;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _service = new VehiculoService(String.Empty);
        }

        [HttpGet]
        public ActionResult consultarVehiculo(int id = 0)
        {
            ViewBag.Vehiculos = _service.Consultar(id);
            return View();
        }

        [HttpPost]
        public JsonResult consultarIdVehiculo(int id)
        {
            var vehiculos = _service.Consultar(id);
            var vehiculo = vehiculos.Count > 0 ? vehiculos[0] : null;
            return Json(vehiculo);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Insertar([FromBody] Vehiculo value)
        {
            Respuesta res;
            if (ModelState.IsValid)
            {
                if(value.id == 0)
                {
                    value.fecha_registro = DateTime.Now;
                    res = _service.Insertar(value);
                }
                else
                {
                    res = _service.Actualizar(value);
                }                
                return Json(res);
            }
            else
            {
                return Json(new Respuesta { Exitoso = false, Mensaje = "Datos inválidos." });
            }
        }
        
    }
}
