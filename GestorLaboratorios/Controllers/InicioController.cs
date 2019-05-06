using GestorLaboratorios.Services;
using GestorLaboratorios.Settings;
using GestorLaboratorios.ViewModels.Inicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace GestorLaboratorios.Controllers
{
    [ServiceFilter(typeof(VerifyUserAttribute))]
    public class InicioController : Controller
    {
        private readonly ConfiguracionRepositorio _configuracionRepositorio;
        private readonly InicioRepositorio _inicioRepositorio;
        private readonly IConfiguration _configuracion;
        Encrypter encrypter = new Encrypter();

        public InicioController(InicioRepositorio inicioRepositorio, ConfiguracionRepositorio configuracionRepositorio, IConfiguration configuration)
        {
            this._inicioRepositorio = inicioRepositorio;
            this._configuracionRepositorio = configuracionRepositorio;
            this._configuracion = configuration;
        }

        public IActionResult Inicio()
        {
            try
            {
                int idLaboratorio = int.Parse(HttpContext.Session.GetString("id_laboratorio"));

                var model = new InicioViewModel();

                if (TempData["funcionCambioEstadoReservaPrestamo"] is string respuestaCambioEstado)
                {
                    model.JsFuncion = respuestaCambioEstado;
                }

                model.ListadoPrestamo = _inicioRepositorio.ListadoPrestamo(idLaboratorio);
                return View(model);
            }
            catch (Exception)
            {
                return new RedirectResult("~/Login/Login");
            }
        }

        public IActionResult InicioEstudiante()
        {
            try
            {
                var model = new InicioEstudianteViewModel();

                model.ListadoDetalleElemento = _configuracionRepositorio.ListadoDetalleElemento(1, 1);

                if (TempData["mensajeCreacionReserva"] is string mensajeCreacionReserva)
                {
                    model.JsFuncion = mensajeCreacionReserva;
                }

                return View(model);
            }
            catch (Exception err)
            {
                return new RedirectResult("~/Login/Login");
            }
        }

        public IActionResult ElementosPrestamo(string IdPresEncrip, string IdEstadoEncrip)
        {
            try
            {
                int idPrestamo = int.Parse(encrypter.Decrypt(IdPresEncrip));
                int idEstado = int.Parse(encrypter.Decrypt(IdEstadoEncrip));
                var model = new ElementosPrestamoViewModel();
                model.IdReservaPrestamo = idPrestamo;
                model.ListadoPrestamoElementos = _inicioRepositorio.ListadoElementosPrestamo(idPrestamo);
                model.IdEstadoReservaPrestamo = idEstado;
                //model.ListadoPrestamoElementos.
                if (TempData["funcionEntregarElemento"] is string funcionEntregarElemento)
                {
                    model.JsFuncion = funcionEntregarElemento;
                }

                //model.ListadoPrestamoElementos.coun

                return View(model);
            }
            catch (Exception err)
            {
                return new RedirectResult("~/Login/Login");
            }
        }

        public bool EntregarElemento(int IdReservaPrestamo, string[] IdsELementos)
        {
            try
            {
                bool bRespuesta = _inicioRepositorio.EntregarElemento(IdReservaPrestamo, IdsELementos);

                string sMensaje = (bRespuesta) ? "Se entregaron correctamente los elementos" : "Error al entregar los elementos";
                string sIcono = (bRespuesta) ? "success" : "error";

                TempData["funcionEntregarElemento"] = $"mensaje('{sMensaje}','{sIcono}')";
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        //public IActionResult CambioEstadoReservaPrestamo(string IdReservaPrestamoEncrip, string IdEstadoEncrip)
        //{
        //    try
        //    {
        //        int idReservaPrestamo = int.Parse(encrypter.Decrypt(IdReservaPrestamoEncrip));
        //        int idEstado = int.Parse(encrypter.Decrypt(IdEstadoEncrip));

        //        bool respuestaCambioEstado = _inicioRepositorio.CambioEstadoReservaPrestamo(idReservaPrestamo, idEstado);
        //        string sMensaje = (respuestaCambioEstado) ?:;

        //        TempData["respuestaCambioEstado"] = $"mensajeCambioEstado({respuestaCambioEstado.ToString().ToLower()});";
        //        return new RedirectToActionResult("Inicio", "Inicio", null);
        //    }
        //    catch (Exception err)
        //    {
        //        return StatusCode((int)HttpStatusCode.InternalServerError, err.ToString());
        //    }
        //}

        public bool CambiarEstadoReservaPrestamo(int IdPrestamoReserva, int IdEstado, bool Prestamo)
        {
            try
            {
                bool respuesta = _inicioRepositorio.CambiarEstadoReservaPrestamo(IdPrestamoReserva, IdEstado, Prestamo);

                string sMensaje = (respuesta) ? "Se cambió el estado correctamente" : "Error al cambiar el estado";
                string sIcono = (respuesta) ? "success" : "error";
                TempData["funcionCambioEstadoReservaPrestamo"] = $"mensaje('{sMensaje}','{sIcono}');";
                return respuesta;
            }
            catch (Exception err)
            {
                return false;
            }
        }

    }
}
