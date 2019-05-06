using GestorLaboratorios.Services;
using GestorLaboratorios.Settings;
using GestorLaboratorios.ViewModels.Pdf;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using System;

namespace GestorLaboratorios.Controllers
{
    public class PdfController : Controller
    {
        private readonly PdfRepositorio _pdfRepositorio;
        Encrypter encrypter = new Encrypter();

        public PdfController(PdfRepositorio pdfRepositorio)
        {
            _pdfRepositorio = pdfRepositorio;
        }

        public ViewAsPdf HojaDeVidaElemento(string IdEle)
        {
            try
            {
                int idElemento = int.Parse(encrypter.Decrypt(IdEle));
                var model = _pdfRepositorio.InformacionElemento(idElemento);

                var view = new ViewAsPdf(model)
                {
                    PageSize = Rotativa.AspNetCore.Options.Size.A4,
                    PageMargins = { Left = 10, Bottom = 10, Right = 10, Top = 10 },
                    PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
                };

                return view;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public ViewAsPdf ListadoElementos()
        {
            try
            {
                var model = new ListadoElementosViewModel
                {
                    ListadoElementos = _pdfRepositorio.ListadoElementos()
                };

                var view = new ViewAsPdf(model)
                {
                    PageSize = Rotativa.AspNetCore.Options.Size.A4,
                    PageMargins = { Left = 10, Bottom = 10, Right = 10, Top = 10 },
                    PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
                };

                return view;
            }
            catch (Exception err)
            {
                throw err;
            }
        }


    }
}
