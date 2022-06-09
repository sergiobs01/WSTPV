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
    public class LoginController : Controller
    {
        private readonly AppDbContext context;
        public LoginController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get([FromQuery] Logins value)
        {
            var logins = context.Logins.ToList();
            LoginResult loginResult = new LoginResult();
            try
            {
                if (value.usuario == "ADMIN" && value.contrasena == "SERGIO")
                {
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return Json(logins);
                }
                else
                {
                    var login = context.Logins.FirstOrDefault(l => l.usuario == value.usuario);
                    if (value.contrasena == login.contrasena)
                    {
                        loginResult.usuario = login.usuario;
                        loginResult.contrasena = login.contrasena;
                        loginResult.nombre = login.nombre;
                        loginResult.creado = false;
                        loginResult.actualizado = false;
                        loginResult.logeado = true;
                        loginResult.borrado = false;
                        loginResult.error = "";
                        Response.StatusCode = (int)HttpStatusCode.OK;
                        return Json(loginResult);
                    }
                    else
                    {
                        loginResult.usuario = value.usuario;
                        loginResult.contrasena = value.contrasena;
                        loginResult.nombre = value.nombre;
                        loginResult.creado = false;
                        loginResult.actualizado = false;
                        loginResult.logeado = false;
                        loginResult.borrado = false;
                        loginResult.error = "Contraseña incorrecta";
                        Response.StatusCode = (int)HttpStatusCode.OK;
                        return Json(loginResult);
                    }
                }
            }
            catch (Exception e)
            {
                loginResult.usuario = value.usuario;
                loginResult.contrasena = value.contrasena;
                loginResult.nombre = value.nombre;
                loginResult.creado = false;
                loginResult.actualizado = false;
                loginResult.logeado = false;
                loginResult.borrado = false;
                loginResult.error = "Usuario no encontrado";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(loginResult);
            }
        }

        // GET api/<controller>/5
        /*[HttpGet("{id}")]
        public Login Get(String user)
        {
            var login = context.Login.FirstOrDefault(l=>l.usuario==user);
            return login;
        }*/

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] Logins value)
        {
            LoginResult loginResult = new LoginResult();
            try
            {
                context.Logins.Add(value);
                context.SaveChanges();
                loginResult.usuario = value.usuario;
                loginResult.contrasena = value.contrasena;
                loginResult.nombre = value.nombre;
                loginResult.creado = true;
                loginResult.actualizado = false;
                loginResult.logeado = false;
                loginResult.borrado = false;
                loginResult.error = "";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(loginResult);
            }
            catch (Exception e)
            {
                loginResult.usuario = value.usuario;
                loginResult.contrasena = value.contrasena;
                loginResult.nombre = value.nombre;
                loginResult.creado = false;
                loginResult.actualizado = false;
                loginResult.logeado = false;
                loginResult.borrado = false;
                loginResult.error = "Usuario ya existente";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(loginResult);
            }
        }

        // PUT api/<controller>/nonumber
        [HttpPut]
        public ActionResult Put([FromBody] Logins value)
        {
            LoginResult loginResult = new LoginResult();
            try
            {
                if (value.contrasena != "")
                {
                    var login = context.Logins.FirstOrDefault(l => l.usuario == value.usuario);
                    login.contrasena = value.contrasena;
                    if(value.nombre != null)
                    {
                        login.nombre = value.nombre;
                    }
                    if (value.ultimo_login != null)
                    {
                        login.ultimo_login = value.ultimo_login;
                    }
                    context.Logins.Update(login);
                    context.SaveChanges();
                    loginResult.usuario = value.usuario;
                    loginResult.contrasena = value.contrasena;
                    loginResult.nombre = value.nombre;
                    loginResult.creado = false;
                    loginResult.actualizado = true;
                    loginResult.logeado = false;
                    loginResult.borrado = false;
                    loginResult.error = "";
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return Json(loginResult);
                }
                loginResult.usuario = value.usuario;
                loginResult.contrasena = value.contrasena;
                loginResult.nombre = value.nombre;
                loginResult.creado = false;
                loginResult.actualizado = false;
                loginResult.logeado = false;
                loginResult.borrado = false;
                loginResult.error = "La contraseña no puede estar vacía";
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(loginResult);
            }
            catch (Exception e)
            {
                loginResult.usuario = value.usuario;
                loginResult.contrasena = value.contrasena;
                loginResult.nombre = value.nombre;
                loginResult.creado = false;
                loginResult.actualizado = false;
                loginResult.logeado = false;
                loginResult.borrado = false;
                loginResult.error = "ERROR";
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(loginResult);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public ActionResult Delete([FromBody] Logins value)
        {
            LoginResult loginResult = new LoginResult();
            try
            {
                var login = context.Logins.FirstOrDefault(l => l.usuario == value.usuario);
                if (value.contrasena != null && login.contrasena == value.contrasena)
                {
                    context.Logins.Remove(login);
                    context.SaveChanges();
                    loginResult.usuario = value.usuario;
                    loginResult.contrasena = value.contrasena;
                    loginResult.nombre = value.nombre;
                    loginResult.creado = false;
                    loginResult.actualizado = false;
                    loginResult.logeado = false;
                    loginResult.borrado = true;
                    loginResult.error = "";
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return Json(loginResult);
                }
                else
                {
                    loginResult.usuario = value.usuario;
                    loginResult.contrasena = value.contrasena;
                    loginResult.nombre = value.nombre;
                    loginResult.creado = false;
                    loginResult.actualizado = false;
                    loginResult.logeado = false;
                    loginResult.borrado = false;
                    loginResult.error = "Contraseña incorrecta";
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return Json(loginResult);
                }
            }
            catch (Exception e)
            {
                loginResult.usuario = value.usuario;
                loginResult.contrasena = value.contrasena;
                loginResult.nombre = value.nombre;
                loginResult.creado = false;
                loginResult.actualizado = false;
                loginResult.logeado = false;
                loginResult.borrado = false;
                loginResult.error = "ERROR";
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(loginResult);
            }
        }
    }
}
