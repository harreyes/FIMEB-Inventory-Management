using GestorLaboratorios.Models;
using GestorLaboratorios.Settings;
using GestorLaboratorios.ViewModels.Pdf;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestorLaboratorios.Services
{

    public class PdfRepositorio
    {
        private readonly IConfiguration _configuracion;
        private readonly DBGESTORContext _dbContext;
        Encrypter encrypter = new Encrypter();


        public PdfRepositorio(IConfiguration configuracion, DBGESTORContext dbContext)
        {
            _dbContext = dbContext;
            _configuracion = configuracion;
        }

        public HojaDeVidaElementoViewModel InformacionElemento(int IdElemento)
        {
            try
            {
                var listadoMantenimiento = _dbContext.AdmMantenimiento
                            .Where(e => e.ManElemento == IdElemento)
                            .Select(e => new HojaDeVidaElementoViewModel
                            {
                                Fecha = e.ManFechaInicio,
                                Usuario = $"{e.ManUsuarioCreacionNavigation.UsuNombre} {e.ManUsuarioCreacionNavigation.UsuApellido}",
                                TipoMantenimiento = e.ManTipoMantenimientoNavigation.TmaDescripcion.ToUpper(),
                                Repuestos = e.ManRepuestos,
                                Observacion = e.ManDescripcion
                            })
                            .OrderByDescending(e => e.Fecha)
                            .ToList();

                var model = new HojaDeVidaElementoViewModel
                {
                    ListadoMantenimiento = listadoMantenimiento
                };
                return model;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public List<ListadoElementosViewModel> ListadoElementos()
        {
            try
            {
                var listadoElementos = _dbContext.AdmElemento
                                        .Select(e => new ListadoElementosViewModel
                                        {
                                            Serial = e.EleSerial,
                                            Modelo = e.EleModelo,
                                            Descripcion = e.EleDescripcion,
                                            PlacaUan = e.ElePlacaUan,
                                            Partes = string.Join(", ", _dbContext.AdmElementoParte
                                                        .Where(p => p.EpaElemento == e.EleId)
                                                        .Select(p => p.EpaDescripcion)
                                                        .ToArray()),
                                            Marca = e.EleMarca,
                                            Cantidad = _dbContext.AdmElemento.Where(ele => ele.EleTipoElemento == e.EleTipoElemento).Count(),
                                            Observacion = e.EleObservaciones,

                                            IdEstadoElemento = e.EleEstado,
                                            TipoElemento = e.EleTipoElementoNavigation.TelDescripcion,
                                            UsuarioCreacion = $"{e.EleUsuarioCreacionNavigation.UsuNombre} {e.EleUsuarioCreacionNavigation.UsuApellido}",
                                            FechaCreacion = e.EleFechaCreacion,
                                            Activo = (e.EleActivo == 1) ? "SI" : "NO"
                                        })
                                        .ToList();
                return listadoElementos;
            }
            catch (Exception err)
            {
                throw err;
            }
        }


    }
}
