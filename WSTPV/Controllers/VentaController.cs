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
    [ApiController]
    public class VentaController : Controller
    {
        private readonly AppDbContext context;

        public VentaController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<VentaController>
        [HttpGet]
        public ActionResult Get()
        {
            return Json(context.Venta.ToList());
        }

        // GET api/<VentaController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Json(context.Venta.ToList().Where(l => l.id == id));
        }

        // POST api/<VentaController>
        [HttpPost]
        public ActionResult Post([FromBody] Venta value)
        {
            VentaResult ventaResult = new VentaResult();
            try
            {
                value.dia_venta = DateTime.Now.ToString();
                context.Venta.Add(value);
                context.SaveChanges();
                ventaResult.usuario = value.usuario;
                ventaResult.cliente_id = value.cliente_id;
                ventaResult.articulo_id = value.articulo_id;
                ventaResult.mesa_id = value.mesa_id;
                ventaResult.dia_venta = value.dia_venta;
                ventaResult.cantidad = value.cantidad;
                ventaResult.observaciones = value.observaciones;
                ventaResult.creado = true;
                ventaResult.actualizado = false;
                ventaResult.borrado = false;
                ventaResult.error = "";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(ventaResult);
            }
            catch (Exception e)
            {
                ventaResult.usuario = value.usuario;
                ventaResult.cliente_id = value.cliente_id;
                ventaResult.articulo_id = value.articulo_id;
                ventaResult.mesa_id = value.mesa_id;
                ventaResult.dia_venta = value.dia_venta;
                ventaResult.cantidad = value.cantidad;
                ventaResult.observaciones = value.observaciones;
                ventaResult.creado = false;
                ventaResult.actualizado = false;
                ventaResult.borrado = false;
                ventaResult.error = "ERROR";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(ventaResult);
            }
        }

        // PUT api/<VentaController>/5
        [HttpPut]
        public ActionResult Put([FromBody] Venta value)
        {
            VentaResult ventaResult = new VentaResult();
            try
            {
                var venta = context.Venta.FirstOrDefault(l => l.id == value.id);
                venta.cliente_id = value.cliente_id;
                venta.articulo_id = value.articulo_id;
                venta.mesa_id = value.mesa_id;
                venta.observaciones = value.observaciones;
                venta.cantidad = value.cantidad;
                context.Venta.Update(venta);
                context.SaveChanges();
                ventaResult.usuario = venta.usuario;
                ventaResult.cliente_id = venta.cliente_id;
                ventaResult.articulo_id = venta.articulo_id;
                ventaResult.mesa_id = venta.mesa_id;
                ventaResult.cantidad = venta.cantidad;
                ventaResult.dia_venta = venta.dia_venta;
                ventaResult.observaciones = venta.observaciones;
                ventaResult.creado = false;
                ventaResult.actualizado = true;
                ventaResult.borrado = false;
                ventaResult.error = "";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(ventaResult);
            }
            catch (Exception e)
            {
                ventaResult.usuario = value.usuario;
                ventaResult.cliente_id = value.cliente_id;
                ventaResult.articulo_id = value.articulo_id;
                ventaResult.mesa_id = value.mesa_id;
                ventaResult.cantidad = value.cantidad;
                ventaResult.dia_venta = value.dia_venta;
                ventaResult.observaciones = value.observaciones;
                ventaResult.creado = false;
                ventaResult.actualizado = false;
                ventaResult.borrado = false;
                ventaResult.error = "Venta no encontrada";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(ventaResult);
            }
        }

        // DELETE api/<VentaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            VentaResult ventaResult = new VentaResult();
            try
            {
                var venta = context.Venta.FirstOrDefault(l => l.id == id);
                context.Venta.Remove(venta);
                context.SaveChanges();
                ventaResult.usuario = venta.usuario;
                ventaResult.cliente_id = venta.cliente_id;
                ventaResult.articulo_id = venta.articulo_id;
                ventaResult.mesa_id = venta.mesa_id;
                ventaResult.dia_venta = venta.dia_venta;
                ventaResult.cantidad = venta.cantidad;
                ventaResult.observaciones = venta.observaciones;
                ventaResult.creado = false;
                ventaResult.actualizado = false;
                ventaResult.borrado = true;
                ventaResult.error = "";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(ventaResult);
            }
            catch (Exception e)
            {
                ventaResult.usuario = "";
                ventaResult.cliente_id = 0;
                ventaResult.articulo_id = 0;
                ventaResult.mesa_id = 0;
                ventaResult.dia_venta = "";
                ventaResult.cantidad = 0;
                ventaResult.observaciones = "";
                ventaResult.creado = false;
                ventaResult.actualizado = false;
                ventaResult.borrado = false;
                ventaResult.error = "Venta no encontrada";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(ventaResult);
            }
        }
    }
}
