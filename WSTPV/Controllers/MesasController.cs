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
    public class MesasController : Controller
    {
        private readonly AppDbContext context;

        public MesasController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<MesasController>
        [HttpGet]
        public ActionResult Get()
        {
            return Json(context.Mesas.ToList());
        }

        // GET api/<MesasController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Json(context.Mesas.ToList().Where(l => l.id == id));
        }

        // POST api/<MesasController>
        [HttpPost]
        public ActionResult Post([FromBody] Mesas value)
        {
            MesasResult mesasResult = new MesasResult();
            try
            {
                context.Mesas.Add(value);
                context.SaveChanges();
                mesasResult.nombre = value.nombre;
                mesasResult.actualizado = false;
                mesasResult.borrado = false;
                mesasResult.creado = true;
                mesasResult.error = "";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(mesasResult);
            }
            catch (Exception e)
            {
                mesasResult.nombre = value.nombre;
                mesasResult.actualizado = false;
                mesasResult.borrado = false;
                mesasResult.creado = false;
                mesasResult.error = "Mesa ya existente";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(mesasResult);
            }
        }

        // PUT api/<MesasController>/5
        [HttpPut]
        public ActionResult Put([FromBody] Mesas value)
        {
            MesasResult mesasResult = new MesasResult();
            try
            {
                var mesa = context.Mesas.FirstOrDefault(l => l.id == value.id);
                mesa.nombre= value.nombre;
                context.Mesas.Update(mesa);
                context.SaveChanges();
                mesasResult.nombre = mesa.nombre;
                mesasResult.creado = false;
                mesasResult.actualizado = true;
                mesasResult.borrado = false;
                mesasResult.error = "";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(mesasResult);
            }
            catch (Exception e)
            {
                mesasResult.nombre = value.nombre;
                mesasResult.creado = false;
                mesasResult.actualizado = false;
                mesasResult.borrado = false;
                mesasResult.error = "Mesa no existente";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(mesasResult);
            }
        }

        // DELETE api/<MesasController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            MesasResult mesasResult = new MesasResult();
            try
            {
                var mesa = context.Mesas.FirstOrDefault(l => l.id == id);
                context.Mesas.Remove(mesa);
                context.SaveChanges();
                mesasResult.nombre = mesa.nombre;
                mesasResult.creado = false;
                mesasResult.actualizado = false;
                mesasResult.borrado = true;
                mesasResult.error = "";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(mesasResult);
            }
            catch (Exception e)
            {
                mesasResult.nombre = "";
                mesasResult.creado = false;
                mesasResult.actualizado = false;
                mesasResult.borrado = false;
                mesasResult.error = "Mesa no encontrada";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(mesasResult);
            }
        }
    }
}
