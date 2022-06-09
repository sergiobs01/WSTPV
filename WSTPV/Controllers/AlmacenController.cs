using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using WSTPV.Contexts;
using WSTPV.Entities;
using WSTPV.Results;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSTPV.Controllers
{
    [Route("api/[controller]")]
    public class AlmacenController : Controller
    {
        private readonly AppDbContext context;

        public AlmacenController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<AlmacenController>
        [HttpGet]
        public ActionResult Get()
        {
            return Json(context.Almacen.ToList());
        }

        // GET api/<AlmacenController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Json(context.Almacen.ToList().Where(l => l.id == id));
        }

        // POST api/<AlmacenController>
        [HttpPost]
        public ActionResult Post([FromBody] Almacen value)
        {
            AlmacenResult almacenResult = new AlmacenResult();
            try
            {
                context.Almacen.Add(value);
                context.SaveChanges();
                almacenResult.articulo = value.articulo;
                almacenResult.cantidad = value.cantidad;
                almacenResult.precio = value.precio;
                almacenResult.url = value.url;
                almacenResult.observaciones = value.observaciones;
                almacenResult.actualizado = false;
                almacenResult.borrado = false;
                almacenResult.creado = true;
                almacenResult.error = "";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(almacenResult);
            }
            catch (Exception e)
            {
                almacenResult.articulo = value.articulo;
                almacenResult.cantidad = value.cantidad;
                almacenResult.precio = value.precio;
                almacenResult.url = value.url;
                almacenResult.observaciones = value.observaciones;
                almacenResult.actualizado = false;
                almacenResult.borrado = false;
                almacenResult.creado = false;
                almacenResult.error = "Articulo ya existente";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(almacenResult);
            }
        }

        // PUT api/<AlmacenController>/5
        [HttpPut]
        public ActionResult Put([FromBody] Almacen value)
        {
            AlmacenResult almacenResult = new AlmacenResult();
            try
            {
                var almacen = context.Almacen.FirstOrDefault(l => l.id == value.id);
                almacen.articulo = value.articulo;
                almacen.cantidad = value.cantidad;
                almacenResult.precio = value.precio;
                almacenResult.url = value.url;
                almacen.observaciones = value.observaciones;
                context.Almacen.Update(almacen);
                context.SaveChanges();
                almacenResult.articulo = almacen.articulo;
                almacenResult.cantidad = almacen.cantidad;
                almacenResult.observaciones = almacen.observaciones;
                almacenResult.creado = false;
                almacenResult.actualizado = true;
                almacenResult.borrado = false;
                almacenResult.error = "";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(almacenResult);
            }
            catch (Exception e)
            {
                almacenResult.articulo = value.articulo;
                almacenResult.cantidad = value.cantidad;
                almacenResult.precio = value.precio;
                almacenResult.url = value.url;
                almacenResult.observaciones = value.observaciones;
                almacenResult.creado = false;
                almacenResult.actualizado = false;
                almacenResult.borrado = false;
                almacenResult.error = "Articulo no existente";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(almacenResult);
            }
        }

        // DELETE api/<AlmacenController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            AlmacenResult almacenResult = new AlmacenResult();
            try
            {
                var almacen = context.Almacen.FirstOrDefault(l => l.id == id);
                context.Almacen.Remove(almacen);
                context.SaveChanges();
                almacenResult.articulo = almacen.articulo;
                almacenResult.cantidad = almacen.cantidad;
                almacenResult.precio = almacen.precio;
                almacenResult.url = almacen.url;
                almacenResult.observaciones = almacen.observaciones;
                almacenResult.creado = false;
                almacenResult.actualizado = false;
                almacenResult.borrado = true;
                almacenResult.error = "";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(almacenResult);
            }
            catch (Exception e)
            {
                almacenResult.articulo = "";
                almacenResult.cantidad = 0;
                almacenResult.precio = 0;
                almacenResult.url = "";
                almacenResult.observaciones = "";
                almacenResult.creado = false;
                almacenResult.actualizado = false;
                almacenResult.borrado = false;
                almacenResult.error = "Articulo no encontrado";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(almacenResult);
            }
        }
    }
}
