using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WSTPV.Contexts;
using WSTPV.Entities;
using WSTPV.Results;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSTPV.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly AppDbContext context;

        public ClienteController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public ActionResult Get()
        {
            return Json(context.Cliente.ToList());
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Json(context.Cliente.ToList().Where(l => l.id == id));
        }

        // POST api/<ClienteController>
        [HttpPost]
        public ActionResult Post([FromBody] Cliente value)
        {
            ClienteResult clienteResult = new ClienteResult();
            try
            {
                context.Cliente.Add(value);
                context.SaveChanges();
                clienteResult.nombre = value.nombre;
                clienteResult.apellidos = value.apellidos;
                clienteResult.email = value.email;
                clienteResult.creado = true;
                clienteResult.actualizado = false;
                clienteResult.borrado = false;
                clienteResult.error = "";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(clienteResult);
            }
            catch (Exception e)
            {
                clienteResult.nombre = value.nombre;
                clienteResult.apellidos = value.apellidos;
                clienteResult.email = value.email;
                clienteResult.creado = false;
                clienteResult.actualizado = false;
                clienteResult.borrado = false;
                clienteResult.error = "Cliente ya existente";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(clienteResult);
            }
        }

        // PUT api/<ClienteController>
        [HttpPut]
        public ActionResult Put([FromBody] Cliente value)
        {
            ClienteResult clienteResult = new ClienteResult();
            try
            {
                var client = context.Cliente.FirstOrDefault(l => l.id == value.id);
                client.nombre = value.nombre;
                client.apellidos = value.apellidos;
                client.email = value.email;
                context.Cliente.Update(client);
                context.SaveChanges();
                clienteResult.nombre = value.nombre;
                clienteResult.apellidos = value.apellidos;
                clienteResult.email = value.email;
                clienteResult.creado = false;
                clienteResult.actualizado = true;
                clienteResult.borrado = false;
                clienteResult.error = "";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(clienteResult);
            }
            catch (Exception e)
            {
                clienteResult.nombre = value.nombre;
                clienteResult.apellidos = value.apellidos;
                clienteResult.email = value.email;
                clienteResult.creado = false;
                clienteResult.actualizado = false;
                clienteResult.borrado = false;
                clienteResult.error = "Cliente no encontrado";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(clienteResult);
            }
        }

        // DELETE api/<ClienteController>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            ClienteResult clienteResult = new ClienteResult();
            try
            {
                var client = context.Cliente.FirstOrDefault(l => l.id == id);
                context.Cliente.Remove(client);
                context.SaveChanges();
                clienteResult.nombre = client.nombre;
                clienteResult.apellidos = client.apellidos;
                clienteResult.email = client.email;
                clienteResult.creado = false;
                clienteResult.actualizado = false;
                clienteResult.borrado = true;
                clienteResult.error = "";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(clienteResult);
            }
            catch (Exception e)
            {
                clienteResult.nombre = "";
                clienteResult.apellidos = "";
                clienteResult.email = "";
                clienteResult.creado = false;
                clienteResult.actualizado = false;
                clienteResult.borrado = false;
                clienteResult.error = "Cliente no encontrado";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(clienteResult);
            }
        }
    }
}
