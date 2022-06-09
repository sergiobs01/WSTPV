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
    public class DescuentoController : Controller
    {
        private readonly AppDbContext context;

        public DescuentoController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<Descuento>
        [HttpGet]
        public ActionResult Get()
        {
            return Json(context.Descuento.ToList());
        }

        // GET api/<Descuento>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Json(context.Descuento.ToList().Where(l => l.cliente_id == id));
        }

        // POST api/<Descuento>
        [HttpPost]
        public ActionResult Post([FromBody] Descuento value)
        {
            DescuentoResult descuentoResult = new DescuentoResult();
            if (value.cliente_id != 0)
            {
                if (value.cantidad != 0)
                {
                    context.Descuento.Add(value);
                    context.SaveChanges();
                    descuentoResult.cliente_id = value.cliente_id;
                    descuentoResult.cantidad = value.cantidad;
                    descuentoResult.creado = true;
                    descuentoResult.actualizado = false;
                    descuentoResult.borrado = false;
                    descuentoResult.error = "";
                    return Json(descuentoResult);
                }
                else
                {
                    descuentoResult.cliente_id = value.cliente_id;
                    descuentoResult.cantidad = value.cantidad;
                    descuentoResult.creado = false;
                    descuentoResult.actualizado = false;
                    descuentoResult.borrado = false;
                    descuentoResult.error = "El descuento tiene que ser mayor a 0";
                    return Json(descuentoResult);
                }
            }
            else
            {
                descuentoResult.cliente_id = value.cliente_id;
                descuentoResult.cantidad = value.cantidad;
                descuentoResult.creado = false;
                descuentoResult.actualizado = false;
                descuentoResult.borrado = false;
                descuentoResult.error = "El id de cliente no corresponde a un cliente existente";
                return Json(descuentoResult);
            }
        }

        // PUT api/<Descuento>/5
        [HttpPut]
        public ActionResult Put([FromBody] Descuento value)
        {
            DescuentoResult descuentoResult = new DescuentoResult();
            try
            {
                var descuento = context.Descuento.FirstOrDefault(l => l.id == value.id);
                descuento.cantidad = value.cantidad;
                context.Descuento.Update(descuento);
                context.SaveChanges();
                descuentoResult.cliente_id = descuento.cliente_id;
                descuentoResult.cantidad = descuento.cantidad;
                descuentoResult.creado = false;
                descuentoResult.actualizado = true;
                descuentoResult.borrado = false;
                descuentoResult.error = "";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(descuentoResult);
            }
            catch (Exception e)
            {
                descuentoResult.cliente_id = 0;
                descuentoResult.cantidad = value.cantidad;
                descuentoResult.creado = false;
                descuentoResult.actualizado = false;
                descuentoResult.borrado = false;
                descuentoResult.error = "ERROR";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(descuentoResult);
            }
        }

        // DELETE api/<Descuento>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            DescuentoResult descuentoResult = new DescuentoResult();
            try
            {
                var descuento = context.Descuento.FirstOrDefault(l => l.id == id);
                context.Descuento.Remove(descuento);
                context.SaveChanges();
                descuentoResult.cliente_id = descuento.cliente_id;
                descuentoResult.cantidad = descuento.cantidad;
                descuentoResult.creado = false;
                descuentoResult.actualizado = false;
                descuentoResult.borrado = true;
                descuentoResult.error = "";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(descuentoResult);
            }
            catch (Exception e)
            {
                descuentoResult.cliente_id = 0;
                descuentoResult.cantidad = 0;
                descuentoResult.creado = false;
                descuentoResult.actualizado = false;
                descuentoResult.borrado = true;
                descuentoResult.error = "Descuento no encontrado";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(descuentoResult);
            }
        }
    }
}
