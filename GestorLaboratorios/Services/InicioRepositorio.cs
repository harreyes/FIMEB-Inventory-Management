using GestorLaboratorios.Models;
using GestorLaboratorios.Settings;
using GestorLaboratorios.ViewModels.Inicio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestorLaboratorios.Services
{
    public class InicioRepositorio : Controller
    {
        private readonly IConfiguration _configuracion;
        private readonly DBGESTORContext _dbContext;
        Encrypter encrypter = new Encrypter();

        public InicioRepositorio(DBGESTORContext dBGESTORContext, IConfiguration configuration)
        {
            this._dbContext = dBGESTORContext;
            this._configuracion = configuration;
        }

        /// <summary>
        /// Carga el listado de los prestamos y reservas en la pantalla de inicio
        /// </summary>
        /// <param name="IdLaboratorio"></param>
        /// <returns></returns>
        public List<InicioViewModel> ListadoPrestamo(int IdLaboratorio)
        {
            try
            {
                var listadoPrestamo = _dbContext.AdmPrestamoReserva
                    .Where(p => p.PreLaboratorio == IdLaboratorio && p.PreFechaPrestamoReserva.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                    .OrderByDescending(p => p.PreId)
                    .Select(p => new InicioViewModel
                    {
                        IdPrestamo = p.PreId,
                        Usuario = $"{p.PreUsuarioNavigation.UsuNombre} {p.PreUsuarioNavigation.UsuApellido}".ToUpper(),
                        IdTipoSolicitud = p.PreTipoNavigation.TprId,
                        TipoSolicitud = p.PreTipoNavigation.TprDescripcion.ToUpper(),
                        Fecha = p.PreFechaPrestamoReserva,
                        Profesor = p.PreProfesor.ToUpper(),
                        Materia = p.PreMateria.ToUpper(),
                        IdEstado = p.PreEstado,
                        Estado = p.PreEstadoNavigation.EprDescripcion
                    })
                    .ToList();

                return listadoPrestamo;
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        public List<ElementosPrestamoViewModel> ListadoElementosPrestamo(int IdPrestamo)
        {
            try
            {
                var listadoElementosPrestamo = _dbContext.AdmPrestamoReservaElemento
                    .Where(p => p.PreReserva == IdPrestamo)
                    .Select(p => new ElementosPrestamoViewModel
                    {
                        IdElemento = p.PreElemento,
                        PlacaElemento = p.PreElementoNavigation.ElePlacaUan,
                        SerialElemento = p.PreElementoNavigation.EleSerial,
                        ModeloElemento = p.PreElementoNavigation.EleModelo,
                        MarcaElemento = p.PreElementoNavigation.EleMarca,
                        Entregado = p.PreEntregado
                    })
                    .ToList();

                return listadoElementosPrestamo;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public bool CambioEstadoReservaPrestamo(int IdReserva, int IdEstado)
        {
            try
            {
                var reservaPrestamo = _dbContext.AdmPrestamoReserva
                    .Where(p => p.PreId == IdReserva)
                    .FirstOrDefault();
                reservaPrestamo.PreEstado = IdEstado;
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public bool EntregarElemento(int IdReservaPrestamo, string[] IdsELementos)
        {
            try
            {
                var elementosPrestamo = _dbContext.AdmPrestamoReservaElemento
                    .Where(e => e.PreReserva == IdReservaPrestamo && IdsELementos.Contains(encrypter.Encrypt(e.PreElemento.ToString())))
                    .ToList();

                foreach (var eleReservaPrestamo in elementosPrestamo)
                {
                    eleReservaPrestamo.PreEntregado = 1;
                }

                var elementos = _dbContext.AdmElemento
                    .Where(e => IdsELementos.Contains(encrypter.Encrypt(e.EleId.ToString())))
                    .ToList();

                foreach (var ele in elementos)
                {
                    ele.EleEstado = 1;
                }

                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        public bool CambiarEstadoReservaPrestamo(int IdPrestamoReserva, int IdEstado, bool Prestamo)
        {
            try
            {
                var prestamoReserva = _dbContext.AdmPrestamoReserva
                    .Where(p => p.PreId == IdPrestamoReserva)
                    .FirstOrDefault();

                prestamoReserva.PreEstado = IdEstado;

                if (!Prestamo && IdEstado == 1)
                {
                    var elementosReserva = _dbContext.AdmPrestamoReservaElemento
                                    .Where(e => e.PreReserva == IdPrestamoReserva)
                                    .Select(e => e.PreElemento)
                                    .ToList();

                    var elementos = _dbContext.AdmElemento
                                    .Where(e => elementosReserva.Contains(e.EleId))
                                    .ToList();

                    elementos.ForEach(ele =>
                    {
                        ele.EleEstado = 2;
                    });

                }

                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

    }
}
