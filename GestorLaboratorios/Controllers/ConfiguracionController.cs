using GestorLaboratorios.Services;
using GestorLaboratorios.Settings;
using GestorLaboratorios.ViewModels.Configuracion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace GestorLaboratorios.Controllers
{
    [ServiceFilter(typeof(VerifyUserAttribute))]
    public class ConfiguracionController : Controller
    {
        private readonly ConfiguracionRepositorio _configuracionRepositorio;
        private readonly PdfRepositorio _pdfRepositorio;
        private readonly IConfiguration _configuracion;
        Encrypter encrypter = new Encrypter();

        ICompositeViewEngine _viewEngine;


        /// <summary>
        /// Constructor del controlador
        /// </summary>
        /// <param name="configuracionRepositorio"></param>
        /// <param name="configuration"></param>
        public ConfiguracionController(ConfiguracionRepositorio configuracionRepositorio, PdfRepositorio pdfRepositorio, IConfiguration configuration, ICompositeViewEngine viewEngine)
        {
            this._configuracionRepositorio = configuracionRepositorio;
            this._pdfRepositorio = pdfRepositorio;
            this._configuracion = configuration;
            this._viewEngine = viewEngine;
        }

        #region TipoElemento
        /// <summary>
        /// Retorna la vista de tipo elemento con la data cargada
        /// </summary>
        /// <returns></returns>
        public IActionResult TipoElemento()
        {
            try
            {
                int idLaboratorio = int.Parse(HttpContext.Session.GetString("id_laboratorio"));
                var listadoTiposElementos = _configuracionRepositorio.ListadoTipoElementoDetalle(idLaboratorio);
                var model = new TipoElementoViewModel
                {
                    ListadoTipoElemento = listadoTiposElementos
                };
                return View(model);
            }
            catch (Exception err)
            {
                return new RedirectResult("~/Login/Login");
            }
        }

        /// <summary>
        /// Se usa para crear o actualizar un tipoElemento
        /// </summary>
        /// <param name="IdTipoElemento"></param>
        /// <param name="Activo"></param>
        /// <param name="Descripcion"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CrearActualizarTipoElemento(int IdTipoElemento, int Activo, string Descripcion)
        {
            try
            {
                var bCrear = (IdTipoElemento == 0) ? true : false;

                var idLaboratorio = int.Parse(HttpContext.Session.GetString("id_laboratorio"));

                var bRespuesta = (bCrear) ?
                    _configuracionRepositorio.CrearTipoElemento(idLaboratorio, IdTipoElemento, 1, Descripcion) :
                    _configuracionRepositorio.ActualizarTipoElemento(IdTipoElemento, Activo, Descripcion);

                var listadoTiposElementosDetalles = _configuracionRepositorio.ListadoTipoElementoDetalle(idLaboratorio);
                var model = new TipoElementoViewModel
                {
                    ListadoTipoElemento = listadoTiposElementosDetalles
                };

                //si falla al insertar o al actualizar genera una exepción para que retorne el StatusCode, se usó así para 
                //no tener que volver a poner el código del status code
                return (bRespuesta) ? PartialView("TipoElemento", model) : throw new Exception();
            }
            catch (Exception err)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, err.ToString());
            }
        }
        #endregion

        #region Elemento
        /// <summary>
        /// Retorna la vista de elemento con la data cargada
        /// </summary>
        /// <returns></returns>
        public IActionResult Elemento(int IdEstadoElemento = 0)
        {
            try
            {
                int idLaboratorio = int.Parse(HttpContext.Session.GetString("id_laboratorio"));
                var listadoEstadoElemento = _configuracionRepositorio.ListadoEstadoElemento();

                IdEstadoElemento = (IdEstadoElemento == 0) ? int.Parse(listadoEstadoElemento[0].Value) : IdEstadoElemento;

                var listadoDetalleElemento = _configuracionRepositorio.ListadoDetalleElemento(idLaboratorio, IdEstadoElemento);
                var model = new ElementoViewModel
                {
                    IdEstadoElemento = IdEstadoElemento,
                    ListadoEstadoElemento = listadoEstadoElemento,
                    ListadoDetalleElemento = listadoDetalleElemento
                };
                //Representa el mensaje cuando se actualiza o se crea un elemento
                var tempData = TempData["mensajeRespuestaCrearActualizar"];
                if (TempData["mensajeRespuestaCrearActualizar"] is string mensaje)
                {
                    model.JsFunction = mensaje;
                }

                if (TempData["mensajeCreacionPrestamo"] is string mensajeCreacionPrestamo)
                {
                    model.JsFunction = mensajeCreacionPrestamo;
                }

                return View(model);
            }
            catch (Exception err)
            {
                return new RedirectResult("~/Login/Login");
            }
        }

        /// <summary>
        /// Carga el detalle de los elementos, si es para crear el elemento cargar el modelo vacio
        /// </summary>
        /// <param name="IdElemento"></param>
        /// <returns></returns>
        public IActionResult CargarDetalleElemento(string IdEleConver)
        {
            try
            {
                int IdElemento = int.Parse(encrypter.Decrypt(IdEleConver));
                int idLaboratorio = int.Parse(HttpContext.Session.GetString("id_laboratorio"));
                var modelo = new ElementoDetalleViewModel();
                if (IdElemento != 0)
                {
                    modelo = _configuracionRepositorio.CargarDetalleElemento(IdElemento);
                }
                modelo.IdElemento = IdElemento;
                modelo.ListadoTipoElemento = _configuracionRepositorio.ListadoTiposElementos(idLaboratorio);

                return View("ElementoDetalle", modelo);
            }
            catch (Exception err)
            {
                return new RedirectResult("~/Login/Login");
            }
        }

        /// <summary>
        /// Se usa para crear o actualizar la información del elemento
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public IActionResult CrearActualizarElemento(ElementoDetalleViewModel Model)
        {
            try
            {
                int idLaboratorio = int.Parse(HttpContext.Session.GetString("id_laboratorio"));
                int idUsuario = int.Parse(HttpContext.Session.GetString("id_usuario"));

                var bRespuesta = (Model.IdElemento == 0) ? _configuracionRepositorio.CrearElemento(Model, idLaboratorio, idUsuario)
                    : _configuracionRepositorio.ActualizarElemento(Model);

                var bRespuestaJs = (bRespuesta) ? "true" : "false";
                TempData["mensajeRespuestaCrearActualizar"] = $"mensajeRespuestaCrearActualizar({bRespuestaJs})";
                return RedirectToAction("Elemento", "Configuracion");

                //return View("Elemento");
            }
            catch (Exception err)
            {
                return new RedirectResult("~/Login/Login");
            }
        }

        public IActionResult CargarVistaPrestamo()
        {
            try
            {
                var listadoUsuarios = _configuracionRepositorio.ListadoUsuariosPrestamo();

                var model = new ElementoPrestamoViewModel
                {
                    Fecha = DateTime.Now,
                    ListadoUsuarios = listadoUsuarios
                };

                return PartialView("ElementoPrestamo", model);
            }
            catch (Exception err)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, err.ToString());
            }
        }
        #endregion

        #region Usuario

        /// <summary>
        /// Retorna la vista de usuarios con el modelo seteado
        /// </summary>
        /// <returns></returns>
        public IActionResult Usuario()
        {
            try
            {
                //int idPerfil = int.Parse(HttpContext.Session.GetString("id_perfil"));

                var listadoUsuarios = _configuracionRepositorio.ListadoUsuarios();

                var model = new UsuarioViewModel
                {
                    ListadoUsuarios = listadoUsuarios
                };

                if (TempData["mensajeCrearActualizar"] is string mensaje)
                {
                    model.JsFuncion = mensaje;
                }
                return View(model);
            }
            catch (Exception err)
            {
                return new RedirectResult("~/Login/Login");
            }
        }

        /// <summary>
        /// Carga la información del usuario al momento de editar
        /// </summary>
        /// <param name="IdUserConver"></param>
        /// <returns></returns>
        public IActionResult CargarDetalleUsuario(string IdUserConver)
        {
            try
            {
                int idUsuario = int.Parse(encrypter.Decrypt(IdUserConver));

                var model = new UsuarioDetalleViewModel();
                model = (idUsuario != 0) ? _configuracionRepositorio.CargarDetalleUsuario(idUsuario) : model;
                model.ListadoPerfiles = _configuracionRepositorio.ListadoPerfiles();
                model.ListadoEstados = _configuracionRepositorio.ListadoEstadosUsuarios();
                model.IdUsuario = idUsuario;
                return View("UsuarioDetalle", model);
            }
            catch (Exception err)
            {
                return new RedirectResult("~/Login/Login");
            }
        }


        public IActionResult CrearActualizarUsuario(UsuarioDetalleViewModel UsuarioDetalleModel)
        {
            try
            {
                int idLaboratorio = int.Parse(HttpContext.Session.GetString("id_laboratorio"));

                bool bRespuesta = (UsuarioDetalleModel.IdUsuario == 0)
                    ? _configuracionRepositorio.InsertarUsuario(UsuarioDetalleModel, idLaboratorio)
                    : _configuracionRepositorio.ActualizarUsuario(UsuarioDetalleModel);

                string sMensaje = $"mensajeCrearActualizar({((bRespuesta) ? "true" : "false")})";
                TempData["mensajeCrearActualizar"] = sMensaje;
                return new RedirectToActionResult("Usuario", "Configuracion", null);
            }
            catch (Exception err)
            {
                return new RedirectResult("~/Login/Login");
            }
        }


        #endregion
        [HttpPost]
        public bool CrearPrestamo(ElementoPrestamoViewModel Model, string IdsElementos, bool Prestamo)
        {
            try
            {
                int idLaboratorio = (Prestamo) ? int.Parse(HttpContext.Session.GetString("id_laboratorio")) : 1;
                int idUsuarioLogueado = int.Parse(HttpContext.Session.GetString("id_usuario"));
                bool bRespuesta = _configuracionRepositorio.CrearPrestamo(Model, idLaboratorio, IdsElementos, Prestamo, idUsuarioLogueado);

                if (Prestamo)
                {
                    TempData["mensajeCreacionPrestamo"] = $"mensajeCreacionPrestamo({bRespuesta.ToString().ToLower()});";
                }
                else
                {
                    string mensaje = (bRespuesta) ? "Se creó correctamente la reserva" : "Error al crear la reserva";
                    string icono = (bRespuesta) ? "success" : "error";
                    TempData["mensajeCreacionReserva"] = $"mensaje('{mensaje}','{icono}');";
                }

                return bRespuesta;
            }
            catch (Exception err)
            {
                return false;
            }
        }


        public IActionResult ElementoParte(string IdEleEncryp)
        {
            try
            {
                int idElemento = int.Parse(encrypter.Decrypt(IdEleEncryp));

                var listadoParteElemento = _configuracionRepositorio.ListadoParteElemento(idElemento);

                var model = new ElementoParteViewModel
                {
                    ListadoParteElemento = listadoParteElemento,
                    IdElemento = idElemento
                };

                return View(model);
            }
            catch (Exception err)
            {
                return new RedirectResult("~/Login/Login");
            }
        }


        public IActionResult CrearActualizarParteElemento(ElementoParteViewModel Model)
        {
            try
            {
                bool respuesta = (Model.IdParteElemento == 0)
                    ? _configuracionRepositorio.CrearParteElemento(Model)
                    : _configuracionRepositorio.ActualizarParteElemento(Model);

                var listadoParteElemento = _configuracionRepositorio.ListadoParteElemento(Model.IdElemento);

                var model = new ElementoParteViewModel
                {
                    ListadoParteElemento = listadoParteElemento,
                    IdElemento = Model.IdElemento
                };

                return (respuesta)
                    ? PartialView("ElementoParte", model)
                    : throw new Exception();
            }
            catch (Exception err)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, err.ToString());
            }
        }

        public IActionResult CambiarEstadoElemento(int IdEstadoCombo, int IdElemento, int IdEstadoDestino, int IdTipoMantenimiento, string ObservacionMantenimiento = "", string RepuestosMantenimiento = "")
        {
            try
            {
                int idUsuarioLogueado = int.Parse(HttpContext.Session.GetString("id_usuario"));
                bool bRespuesta = _configuracionRepositorio.CambiarEstadoElemento(IdElemento, IdEstadoDestino, IdTipoMantenimiento, ObservacionMantenimiento, RepuestosMantenimiento, idUsuarioLogueado);

                string mensajeRespuesta = (bRespuesta) ? "Se cambió correctamente el estado del elemento" : "Error al cambiar el estado del elemento";
                string iconoRespuesta = (bRespuesta) ? "success" : "error";

                int idLaboratorio = int.Parse(HttpContext.Session.GetString("id_laboratorio"));
                var listadoEstadoElemento = _configuracionRepositorio.ListadoEstadoElemento();

                var listadoDetalleElemento = _configuracionRepositorio.ListadoDetalleElemento(idLaboratorio, IdEstadoCombo);
                var model = new ElementoViewModel
                {
                    IdEstadoElemento = IdEstadoCombo,
                    ListadoEstadoElemento = listadoEstadoElemento,
                    ListadoDetalleElemento = listadoDetalleElemento,
                    JsFunction = $"mensaje('{mensajeRespuesta}','{iconoRespuesta}');"
                };

                return PartialView("Elemento", model);
            }
            catch (Exception err)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, err.ToString());
            }
        }

        public List<SelectListItem> CargarListaTipoMantenimiento()
        {
            try
            {
                return _configuracionRepositorio.CargarListaTipoMantenimiento();
            }
            catch (Exception err)
            {
                return null;
            }
        }


        public IActionResult ExportarExcel(int IdEstado = 0)
        {
            try
            {

                var listadoElementosFiltrado = _pdfRepositorio.ListadoElementos();
                listadoElementosFiltrado = (IdEstado == 0) ? listadoElementosFiltrado : listadoElementosFiltrado
                                                .Where(e => e.IdEstadoElemento == IdEstado).ToList();

                var listadoElementosFinal = listadoElementosFiltrado
                                    .Select(e => new ElementoExcelViewModel
                                    {
                                        PLaca = e.PlacaUan,
                                        TipoElemento = e.TipoElemento,
                                        Serial = e.Serial,
                                        Modelo = e.Modelo,
                                        Marca = e.Marca,
                                        Observaciones = e.Observacion,
                                        UsuarioCreacion = e.UsuarioCreacion,
                                        FechaCreacion = e.FechaCreacion,
                                        Activo = e.Activo
                                    })
                                    .ToList();

                var stream = new MemoryStream();

                using (var paquete = new ExcelPackage(stream))
                {
                    var hojaTrabajo = paquete.Workbook.Worksheets.Add("Elementos");
                    hojaTrabajo.Cells.LoadFromCollection(listadoElementosFinal, true);
                    hojaTrabajo.Cells["A1:I1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    hojaTrabajo.Cells["A1:I1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    hojaTrabajo.Column(8).Style.Numberformat.Format = "dd-mm-yyyy hh:mm";
                    hojaTrabajo.Cells[hojaTrabajo.Dimension.Address].AutoFitColumns();
                    hojaTrabajo.Cells[hojaTrabajo.Dimension.Address].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    stream = new MemoryStream(paquete.GetAsByteArray());
                }
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Inventario.xlsx");
            }
            catch (Exception err)
            {

                throw err;
            }
        }



    }
}
