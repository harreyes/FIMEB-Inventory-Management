using GestorLaboratorios.Services;
using GestorLaboratorios.ViewModels.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GestorLaboratorios.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginRepositorio _loginRepositorio;
        public LoginController(LoginRepositorio loginRepositorio)
        {
            this._loginRepositorio = loginRepositorio;
        }

        /// <summary>
        /// Retorna la vista del login
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            try
            {
                var model = new LoginViewModel();
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Valida el ingreso de los usuarios que no son estudiantes
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns></returns>
        public IActionResult ValidarIngreso(LoginViewModel loginViewModel)
        {
            try
            {
                var dataUsuario = _loginRepositorio.ValidarIngreso(loginViewModel);
                if (dataUsuario != null)
                {
                    HttpContext.Session.SetString("id_usuario", dataUsuario.UprUsuario.ToString());
                    HttpContext.Session.SetString("nombre_usuario", $"{dataUsuario.UprUsuarioNavigation.UsuNombre} {dataUsuario.UprUsuarioNavigation.UsuApellido}");
                    HttpContext.Session.SetString("id_laboratorio", dataUsuario.UprLaboratorio.ToString());
                    HttpContext.Session.SetString("id_perfil", dataUsuario.UprUsuarioNavigation.UsuPerfilNavigation.PerId.ToString());
                    return RedirectToAction("Inicio", "Inicio");
                }
                else
                {
                    loginViewModel.JsFuncion = "mensajeError(false);";
                    //ModelState.AddModelError("Mensaje", "Correo o contraseña incorrectos");
                    return View("Login", loginViewModel);
                }
            }

            catch (Exception err)
            {
                return new RedirectResult("~/Login/Login");
            }
        }

        /// <summary>
        /// Se usa para validar el ingreso cuando se trata de un estudiante
        /// </summary>
        /// <param name="sCodigo"></param>
        /// <returns></returns>
        public object ValidarIngresoEstudiante(string sCodigo)
        {
            try
            {
                var dataUsuarioEstudiante = _loginRepositorio.ValidarIngresoEstudiante(sCodigo);
                if (dataUsuarioEstudiante != null)
                {
                    HttpContext.Session.SetString("id_usuario", dataUsuarioEstudiante.UsuId.ToString());
                    HttpContext.Session.SetString("nombre_usuario", $"{dataUsuarioEstudiante.UsuNombre} {dataUsuarioEstudiante.UsuApellido}");
                    HttpContext.Session.SetString("id_perfil", dataUsuarioEstudiante.UsuPerfil.ToString());
                    return new { ingreso = true };
                }
                return new { ingreso = false };
            }
            catch (Exception err)
            {
                return new { ingreso = false };
            }
        }

        /// <summary>
        /// Cierra la sesión
        /// </summary>
        /// <returns></returns>
        public IActionResult CerrarSesion()
        {
            try
            {
                HttpContext.Session.Clear();
                return new RedirectResult("~/Login/Login");
            }
            catch (Exception err)
            {
                return new RedirectResult("~/Login/Login");
            }
        }

    }
}
