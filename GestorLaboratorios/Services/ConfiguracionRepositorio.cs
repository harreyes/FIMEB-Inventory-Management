using GestorLaboratorios.Models;
using GestorLaboratorios.Settings;
using GestorLaboratorios.ViewModels.Configuracion;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestorLaboratorios.Services
{
    public class ConfiguracionRepositorio
    {
        private readonly IConfiguration _configuracion;
        private readonly DBGESTORContext _dbContext;
        Encrypter encrypter = new Encrypter();

        /// <summary>
        /// Es el constructor del repositorio, inicializa el contexto y la variable de configuración
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="configuracion"></param>
        public ConfiguracionRepositorio(DBGESTORContext dbContext, IConfiguration configuracion)
        {
            this._configuracion = configuracion;
            this._dbContext = dbContext;
        }

        /// <summary>
        /// Carga el listado de los tipos de elementos dependiendo el laboratorio
        /// </summary>
        /// <param name="IdLaboratorio"></param>
        /// <returns></returns>
        public List<TipoElementoViewModel> ListadoTipoElementoDetalle(int IdLaboratorio)
        {
            try
            {
                var listadoTipoElementoDetalle = this._dbContext.AdmTipoElemento
                    .Where(t => t.TelLaboratorio == IdLaboratorio)
                    .Select(t => new TipoElementoViewModel
                    {
                        IdLaboratorio = t.TelLaboratorio,
                        IdTipoElemento = t.TelId,
                        Descripcion = t.TelDescripcion,
                        Activo = t.TelActivo
                    })
                    .ToList();
                return listadoTipoElementoDetalle;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// Actualiza el tipo de elemento 
        /// </summary>
        /// <param name="IdTipoElemento"></param>
        /// <param name="Activo"></param>
        /// <param name="Descripcion"></param>
        /// <returns></returns>
        public bool ActualizarTipoElemento(int IdTipoElemento, int Activo, string Descripcion)
        {
            try
            {
                var tipoElemento = _dbContext.AdmTipoElemento.Where(t => t.TelId == IdTipoElemento).FirstOrDefault();
                tipoElemento.TelDescripcion = Descripcion;
                tipoElemento.TelActivo = Activo;
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        /// <summary>
        /// Inserta el nuevo tipo de elemento
        /// </summary>
        /// <param name="IdLaboratorio"></param>
        /// <param name="IdTipoElemento"></param>
        /// <param name="Activo"></param>
        /// <param name="Descripcion"></param>
        /// <returns></returns>
        public bool CrearTipoElemento(int IdLaboratorio, int IdTipoElemento, int Activo, string Descripcion)
        {
            try
            {
                var idMaxTipoElemento = (_dbContext.AdmTipoElemento.Any()) ? _dbContext.AdmTipoElemento.Max(t => t.TelId) : 0;
                var tipoElemento = new AdmTipoElemento
                {
                    TelId = idMaxTipoElemento + 1,
                    TelDescripcion = Descripcion,
                    TelActivo = Activo,
                    TelLaboratorio = IdLaboratorio
                };
                _dbContext.Add(tipoElemento);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        /// <summary>
        /// Carga el listado de los elementos para mostrar en la vista
        /// </summary>
        /// <param name="IdLaboratorio"></param>
        /// <returns></returns>
        public List<ElementoViewModel> ListadoDetalleElemento(int IdLaboratorio, int IdEstado)
        {
            try
            {
                var listadoElemento = _dbContext.AdmElemento
                    .Where(e => e.EleLaboratorio == IdLaboratorio && e.EleEstado == IdEstado)
                    .Select(e => new ElementoViewModel
                    {
                        IdElemento = e.EleId,
                        TipoElemento = e.EleTipoElementoNavigation.TelDescripcion,
                        IdEstadoElemento = e.EleEstado,
                        Placa = e.ElePlacaUan,
                        Serial = e.EleSerial,
                        Modelo = e.EleModelo,
                        Marca = e.EleMarca,
                        Observacion = e.EleObservaciones,
                        NombreUsuarioCreacion = $"{e.EleUsuarioCreacionNavigation.UsuNombre} {e.EleUsuarioCreacionNavigation.UsuApellido}".ToUpper(),
                        FechaCreacion = e.EleFechaCreacion,
                        Activo = (e.EleActivo == 1) ? true : false
                    })
                    .ToList();
                return listadoElemento;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// Carga la información del elemento
        /// </summary>
        /// <param name="IdElemento"></param>
        /// <returns></returns>
        public ElementoDetalleViewModel CargarDetalleElemento(int IdElemento)
        {
            try
            {
                var elemento = _dbContext.AdmElemento
                    .Where(e => e.EleId == IdElemento)
                    .Select(e => new ElementoDetalleViewModel
                    {
                        IdElemento = e.EleId,
                        IdEstado = e.EleEstado,
                        IdTipoElemento = e.EleTipoElemento,
                        Placa = e.ElePlacaUan,
                        Descripcion = e.EleDescripcion,
                        Serial = e.EleSerial,
                        Modelo = e.EleModelo,
                        Marca = e.EleMarca,
                        Observacion = e.EleObservaciones,
                        NombreUsuarioCreacion = $"{e.EleUsuarioCreacionNavigation.UsuNombre} {e.EleUsuarioCreacionNavigation.UsuApellido}".ToUpper(),
                        Activo = (e.EleActivo == 1) ? true : false
                    })
                    .FirstOrDefault();
                return elemento;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// Carga el combo del listado de Tipos de elementos dependiendo el laboratorio
        /// </summary>
        /// <param name="IdLaboratorio"></param>
        /// <returns></returns>
        public List<SelectListItem> ListadoTiposElementos(int IdLaboratorio)
        {
            try
            {
                var listadoTiposElementos = _dbContext.AdmTipoElemento
                    .Where(t => t.TelLaboratorio == IdLaboratorio && t.TelActivo == 1)
                    .Select(t => new SelectListItem
                    {
                        Value = t.TelId.ToString(),
                        Text = t.TelDescripcion
                    })
                    .ToList();
                return listadoTiposElementos;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// Carga el listado de los estados para cada elemento
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> ListadoEstadoElemento()
        {
            try
            {
                var listadoEstadosElementos = _dbContext.SysElementoEstado
                    .Select(e => new SelectListItem
                    {
                        Value = e.EesId.ToString(),
                        Text = e.EesDescripcion
                    })
                    .ToList();
                return listadoEstadosElementos;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// Actualiza la información del elemento
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ActualizarElemento(ElementoDetalleViewModel Model)
        {
            try
            {
                var elemento = _dbContext.AdmElemento
                    .Where(e => e.EleId == Model.IdElemento)
                    .FirstOrDefault();
                elemento.EleTipoElemento = Model.IdTipoElemento;
                elemento.EleDescripcion = Model.Descripcion;
                elemento.ElePlacaUan = Model.Placa;
                elemento.EleSerial = Model.Serial;
                elemento.EleModelo = Model.Modelo;
                elemento.EleMarca = Model.Marca;
                elemento.EleObservaciones = Model.Observacion;
                elemento.EleActivo = (Model.Activo) ? 1 : 0;
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// Crea el nuevo elemento en la base de datos
        /// </summary>
        /// <param name="Model"></param>
        /// <param name="IdLaboratorio"></param>
        /// <param name="IdUsuarioCreacion"></param>
        /// <returns></returns>
        public bool CrearElemento(ElementoDetalleViewModel Model, int IdLaboratorio, int IdUsuarioCreacion)
        {
            try
            {
                var idMaxElemento = (_dbContext.AdmElemento.Any()) ? _dbContext.AdmElemento.Max(e => e.EleId) : 0;
                var elementoNuevo = new AdmElemento
                {
                    EleId = idMaxElemento + 1,
                    EleLaboratorio = IdLaboratorio,
                    EleTipoElemento = Model.IdTipoElemento,
                    EleEstado = 1,
                    ElePlacaUan = Model.Placa,
                    EleDescripcion = Model.Descripcion,
                    EleSerial = Model.Serial,
                    EleModelo = Model.Modelo,
                    EleMarca = Model.Marca,
                    EleObservaciones = Model.Observacion,
                    EleUsuarioCreacion = IdUsuarioCreacion,
                    EleFechaCreacion = DateTime.Now,
                    EleActivo = 1
                };
                _dbContext.AdmElemento.Add(elementoNuevo);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// Carga el listado de todos los usuarios
        /// </summary>
        /// <returns></returns>
        public List<UsuarioViewModel> ListadoUsuarios()
        {
            try
            {
                var listadoUsuarios = _dbContext.AdmUsuario
                    .Select(u => new UsuarioViewModel
                    {
                        IdUsuario = u.UsuId,
                        Perfil = u.UsuPerfilNavigation.PerDescripcion,
                        NombreCompleto = $"{u.UsuNombre} {u.UsuApellido}".ToUpper(),
                        Identificacion = u.UsuIdentificacion,
                        Codigo = u.UsuCodigo,
                        Correo = u.UsuCorreo,
                        Telefono = u.UsuTelefono,
                        Activo = (u.UsuActivo == 1) ? true : false
                    })
                    .ToList();

                return listadoUsuarios;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// Carga el listado de perfiles para crear o editar un usuario
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> ListadoPerfiles()
        {
            try
            {
                var listadoPerfiles = _dbContext.AdmPerfil
                    .Where(p => p.PerActivo == 1)
                    .Select(p => new SelectListItem
                    {
                        Value = p.PerId.ToString(),
                        Text = p.PerDescripcion
                    })
                    .ToList();
                return listadoPerfiles;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// Carga la información del usuario para poder editarla
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <returns></returns>
        public UsuarioDetalleViewModel CargarDetalleUsuario(int IdUsuario)
        {
            try
            {
                var detalleUsuario = _dbContext.AdmUsuario
                    .Where(u => u.UsuId == IdUsuario)
                    .Select(u => new UsuarioDetalleViewModel
                    {
                        IdUsuario = u.UsuId,
                        IdPerfil = u.UsuPerfil,
                        Nombres = u.UsuNombre.ToUpper(),
                        Apellidos = u.UsuApellido.ToUpper(),
                        Identificacion = u.UsuIdentificacion,
                        Codigo = u.UsuCodigo,
                        Correo = u.UsuCorreo,
                        Telefono = u.UsuTelefono,
                        IdEstado = u.UsuEstado,
                        Activo = (u.UsuActivo == 1) ? true : false
                    })
                    .FirstOrDefault();
                return detalleUsuario;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// Carga el listado de estados para poder editar o crear un usuario
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> ListadoEstadosUsuarios()
        {
            try
            {
                var listadoEstadosUsuarios = _dbContext.SysEstadoUsuario
                    .Where(e => e.EusActivo == 1)
                    .Select(e => new SelectListItem
                    {
                        Value = e.EusId.ToString(),
                        Text = e.EusDescripcion
                    })
                    .ToList();
                return listadoEstadosUsuarios;
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        public bool InsertarUsuario(UsuarioDetalleViewModel usuarioDetalleViewModel, int IdLaboratorio)
        {
            try
            {
                var maxId = (_dbContext.AdmUsuario.Any()) ? _dbContext.AdmUsuario.Max(u => u.UsuId) : 0;
                var usuario = new AdmUsuario
                {
                    UsuId = maxId + 1,
                    UsuPerfil = usuarioDetalleViewModel.IdPerfil,
                    UsuNombre = usuarioDetalleViewModel.Nombres.Trim().ToUpper(),
                    UsuApellido = usuarioDetalleViewModel.Apellidos.Trim().ToUpper(),
                    UsuIdentificacion = usuarioDetalleViewModel.Identificacion,
                    UsuCodigo = usuarioDetalleViewModel.Codigo,
                    UsuCorreo = usuarioDetalleViewModel.Correo,
                    UsuContrasena = encrypter.Encrypt(usuarioDetalleViewModel.Correo.Substring(0, usuarioDetalleViewModel.Correo.IndexOf("@"))),
                    UsuTelefono = usuarioDetalleViewModel.Telefono,
                    UsuFoto = "",
                    UsuFechaCreacion = DateTime.Now,
                    UsuEstado = 1,
                    //UsuEstado = usuarioDetalleViewModel.IdEstado,
                    UsuActivo = 1
                };
                _dbContext.Add(usuario);

                var usuarioLaboratorio = new AdmUsuarioLaboratorio
                {
                    UprLaboratorio = IdLaboratorio,
                    UprUsuario = maxId + 1
                };
                _dbContext.Add(usuarioLaboratorio);

                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public bool ActualizarUsuario(UsuarioDetalleViewModel Model)
        {
            try
            {
                var usuario = _dbContext.AdmUsuario
                    .Where(u => u.UsuId == Model.IdUsuario)
                    .FirstOrDefault();

                usuario.UsuPerfil = Model.IdPerfil;
                usuario.UsuNombre = Model.Nombres;
                usuario.UsuApellido = Model.Apellidos;
                usuario.UsuIdentificacion = Model.Identificacion;
                usuario.UsuCodigo = Model.Codigo;
                usuario.UsuCorreo = Model.Correo;
                usuario.UsuTelefono = Model.Telefono;
                //usuario.UsuEstado = Model.IdEstado;
                usuario.UsuActivo = (Model.Activo) ? 1 : 0;

                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        public List<SelectListItem> ListadoUsuariosPrestamo()
        {
            try
            {
                var listadoUsuariosPrestamo = _dbContext.AdmUsuario
                    .Where(u => u.UsuPerfil == 3)
                    .Select(u => new SelectListItem
                    {
                        Value = u.UsuId.ToString(),
                        Text = $"{u.UsuNombre} {u.UsuApellido}".ToUpper()
                    }).ToList();

                return listadoUsuariosPrestamo;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public bool CrearPrestamo(ElementoPrestamoViewModel Model, int IdLaboratorio, string IdsElementos, bool Prestamo, int IdUsuarioLogueado)
        {
            try
            {
                var IdsElementosArreglo = IdsElementos.Split(",");
                var idMax = (_dbContext.AdmPrestamoReserva.Any()) ? _dbContext.AdmPrestamoReserva.Max(p => p.PreId) : 0;

                var elementos = _dbContext.AdmElemento
                    .Where(e => IdsElementosArreglo.Contains(encrypter.Encrypt(e.EleId.ToString())))
                    .ToList();

                if (Prestamo)
                {
                    elementos.ForEach(ele =>
                    {
                        ele.EleEstado = 2;
                    });
                }
                var fechaActual = DateTime.Now;
                var fechaPrestamo = new DateTime(Model.Fecha.Year, Model.Fecha.Month, Model.Fecha.Day, fechaActual.Hour-5, fechaActual.Minute, fechaActual.Second);

                var prestamo = new AdmPrestamoReserva
                {
                    PreId = idMax + 1,
                    PreLaboratorio = IdLaboratorio,
                    PreUsuario = (Model.IdUsuario != 0) ? Model.IdUsuario : IdUsuarioLogueado,
                    PreFechaCreacion = DateTime.Now,
                    PreFechaPrestamoReserva = fechaPrestamo,
                    PreProfesor = Model.Profesor,
                    PreMateria = Model.Materia,
                    PreTipo = (Prestamo) ? 1 : 2,
                    PreEstado = (Prestamo) ? 1 : 4,
                    AdmPrestamoReservaElemento = elementos.Select(e => new AdmPrestamoReservaElemento
                    {
                        PreReserva = idMax + 1,
                        PreElemento = e.EleId,
                        PreEntregado = 0
                    }).ToList()
                };

                _dbContext.Add(prestamo);

                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        public List<ElementoParteViewModel> ListadoParteElemento(int IdElemento)
        {
            try
            {
                var listadoParteElemento = _dbContext.AdmElementoParte
                    .Where(p => p.EpaElemento == IdElemento)
                    .Select(p => new ElementoParteViewModel
                    {
                        IdParteElemento = p.EpaId,
                        Descripcion = p.EpaDescripcion.ToUpper(),
                        Activo = (p.EpaActivo == 1) ? true : false
                    })
                    .ToList();

                return listadoParteElemento;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public bool CrearParteElemento(ElementoParteViewModel Model)
        {
            try
            {
                var idMax = (_dbContext.AdmElementoParte.Any()) ? _dbContext.AdmElementoParte.Max(p => p.EpaId) : 0;

                var parteElemento = new AdmElementoParte
                {
                    EpaId = idMax + 1,
                    EpaDescripcion = Model.Descripcion,
                    EpaActivo = 1,
                    EpaElemento = Model.IdElemento
                };

                _dbContext.Add(parteElemento);
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public bool ActualizarParteElemento(ElementoParteViewModel Model)
        {
            try
            {
                var parteElemento = _dbContext.AdmElementoParte
                    .Where(p => p.EpaId == Model.IdParteElemento)
                    .FirstOrDefault();

                parteElemento.EpaDescripcion = Model.Descripcion;
                parteElemento.EpaActivo = (Model.Activo) ? 1 : 0;

                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public bool CambiarEstadoElemento(int IdElemento, int IdEstado, int IdTipoMantenimiento, string ObservacionMantenimiento, string RepuestosMantenimiento, int IdUsuarioLogueado)
        {
            try
            {
                var elemento = _dbContext.AdmElemento
                    .Where(e => e.EleId == IdElemento)
                    .FirstOrDefault();
                elemento.EleEstado = IdEstado;

                //Es cuando va para mantenimiento
                if (IdEstado == 3)
                {
                    int idMax = (_dbContext.AdmMantenimiento.Any()) ? _dbContext.AdmMantenimiento.Max(e => e.ManId) : 0;

                    var mantenimiento = new AdmMantenimiento
                    {
                        ManId = idMax + 1,
                        ManElemento = IdElemento,
                        ManTipoMantenimiento = IdTipoMantenimiento,
                        ManUsuarioCreacion = IdUsuarioLogueado,
                        ManFechaInicio = DateTime.Now,
                        ManFinalizado = 0
                    };

                    _dbContext.Add(mantenimiento);
                }

                //Es cuando viene de mantenimiento y va a disponible, pide la observación y los repuestos
                if (IdEstado == 1)
                {
                    var elementoMantenimiento = _dbContext.AdmMantenimiento
                        .Where(em => em.ManElemento == IdElemento && em.ManFechaFin == null)
                        .FirstOrDefault();

                    elementoMantenimiento.ManDescripcion = ObservacionMantenimiento ?? "Sin observación";
                    elementoMantenimiento.ManRepuestos = RepuestosMantenimiento ?? "Sin repuestos";
                    elementoMantenimiento.ManFechaFin = DateTime.Now;
                    elementoMantenimiento.ManFinalizado = 1;
                }

                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public List<SelectListItem> CargarListaTipoMantenimiento()
        {
            try
            {
                var listaTipoMantenimiento = _dbContext.SysTipoMantenimiento
                    .Where(t => t.TmaActivo == 1)
                    .Select(t => new SelectListItem
                    {
                        Value = t.TmaId.ToString(),
                        Text = t.TmaDescripcion
                    })
                    .ToList();
                return listaTipoMantenimiento;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
