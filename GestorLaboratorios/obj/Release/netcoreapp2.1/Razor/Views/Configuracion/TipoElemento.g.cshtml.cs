#pragma checksum "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\TipoElemento.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e1dc48f66bf4df8a9b59abb741831e958c782ccd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Configuracion_TipoElemento), @"mvc.1.0.view", @"/Views/Configuracion/TipoElemento.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Configuracion/TipoElemento.cshtml", typeof(AspNetCore.Views_Configuracion_TipoElemento))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 3 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\_ViewImports.cshtml"
using GestorLaboratorios;

#line default
#line hidden
#line 4 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\_ViewImports.cshtml"
using GestorLaboratorios.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1dc48f66bf4df8a9b59abb741831e958c782ccd", @"/Views/Configuracion/TipoElemento.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38ea79a3eb4083282ec7125da77034d9406e7e46", @"/Views/_ViewImports.cshtml")]
    public class Views_Configuracion_TipoElemento : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GestorLaboratorios.ViewModels.Configuracion.TipoElementoViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/editar.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("cursor:pointer;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(74, 2636, true);
            WriteLiteral(@"
<script type=""text/javascript"">

    /**
     * Muestra el div de editar y crear
     * */
    function mostrarDivCrear() {
        try {
            $(""#idTipoElementoOculto"").val(0);
            var textoBoton = ($(""#idTipoElementoOculto"").val() == ""0"") ? ""Insertar"" : ""Actualizar"";
            $(""#btnGuardar"").html(textoBoton);
            $(""#descripcion"").val("""");
            $(""#ckbActivo, #lblActivo"").css(""display"", ""none"");
            $(""#divCrearEditar"").css(""display"", ""block"");
        } catch (err) {
            mensaje(""Error al mostrar la información"",""error"");
            console.log(err);
        }
    }

    /**
    * Muestra el div de editar y crear
    * */
    function mostrarDivEditar(idTipoElemento, descripcion, activo) {
        try {
            $(""#idTipoElementoOculto"").val(idTipoElemento);
            var textoBoton = ($(""#idTipoElementoOculto"").val() == 0) ? ""Insertar"" : ""Actualizar"";
            $(""#btnGuardar"").html(textoBoton);
            $(""#descrip");
            WriteLiteral(@"cion"").val(descripcion);
            $(""#ckbActivo"")[0].checked = (activo == 1) ? true : false;
            $(""#divCrearEditar, #ckbActivo, #lblActivo"").css(""display"", ""block"");
        } catch (err) {
            mensaje(""Error al mostrar la información"", ""error"");
            console.log(err);
        }
    }

    /**
     * Se usa para ocultar el div de editar y crear y limpiar los campos
     * */
    function cancelar() {
        try {
            $(""#divCrearEditar"").css(""display"", ""none"");
            $(""#descripcion"").val("""");
            $(""#ckbActivo"")[0].checked = false;
        } catch (err) {
            mensaje(""Error al cargar la información"", ""error"");
            console.log(err);
        }
    }

    /**
     * Actualiza o guarda el tipo de elemento
     * */
    function guardar() {
        try {
            var descripcion = $(""#descripcion"").val();
            if (descripcion != """") {
                var idTipoElemento = $(""#idTipoElementoOculto"").val();

 ");
            WriteLiteral(@"               var activo = ($(""#ckbActivo"")[0].checked) ? 1 : 0;

                var parteMensajeOk = ($(""#idTipoElementoOculto"").val() == 0) ? 'creó' : ""actualizó"";
                var mensajeOk = `Se ${parteMensajeOk} correctamente el tipo de elemento`;

                var parteMensajeKo = ($(""#idTipoElementoOculto"").val() == 0) ? 'crear' : ""actualizar"";
                var mensajeKo = `Error al ${parteMensajeKo} el tipo de elemento`;

                Pace.track(() => {
                    $.ajax({
                        type: ""POST"",
                        url: '");
            EndContext();
            BeginContext(2711, 58, false);
#line 73 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\TipoElemento.cshtml"
                         Write(Url.Content("~/Configuracion/CrearActualizarTipoElemento"));

#line default
#line hidden
            EndContext();
            BeginContext(2769, 2491, true);
            WriteLiteral(@"',
                        data: { IdTipoElemento: idTipoElemento, Activo: activo, Descripcion: descripcion },
                        success: (vista) => {
                            $(""#general"").html(vista);
                            mensaje(mensajeOk, ""success"");
                        },
                        error: (err) => {
                            //if(err.statusCode)
                            console.log(err.message);
                            mensaje(mensajeKo, ""error"");
                        }
                    });
                });
            } else {
                mensaje(""Tiene que llenar la descripción"", ""error"");
            }
        } catch (err) {
            mensaje(""Error al guardar la información"", ""error"");
            console.log(err);
        }
    }

</script>


<div id=""general"">
    <div class=""row"">
        <div class=""col-lg-12 col-md-12 col-sm-12"">
            <div class=""row"">
                <div class=""col-lg-6 col-md-6 col-");
            WriteLiteral(@"sm-12"">
                    <h3 class=""mt-5"">Tipos Elementos /</h3>
                </div>
            </div>

            <div id=""divCrearEditar"" class=""row"" style=""padding:1%; display:none;"">

                <div class=""col-lg-1 col-md-1 col-sm-12"" style=""text-align:left;"">
                    <label>Descripción</label>
                </div>
                <div class=""col-lg-5 col-md-5 col-sm-12"">
                    <input id=""descripcion"" class=""form-control"" required />
                </div>

                <div class=""col-lg-1 col-md-1 col-sm-12"">
                    <label id=""lblActivo"" for=""ckbActivo"">Activo</label>
                    <input id=""ckbActivo"" name=""ckbActivo"" type=""checkbox"" />
                </div>

                <div class=""col-lg-1 col-md-1 col-sm-12"">
                    <button id=""btnGuardar"" class=""btn btn-success"" onclick=""guardar();""></button>
                </div>

                <div class=""col-lg-1 col-md-1 col-sm-12"">
                    ");
            WriteLiteral(@"<button class=""btn btn-danger"" onclick=""cancelar();"">Cancelar</button>
                </div>
            </div>

            <div class=""row"">
                <div class=""col-lg-2 col-md-2 col-sm-12"">
                    <button class=""btn btn-primary"" onclick=""mostrarDivCrear();"">Agregar</button>
                </div>
            </div>
            <div class=""row"">
                <div class=""col-lg-12 col-md-12 col-sm-12"">
");
            EndContext();
#line 137 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\TipoElemento.cshtml"
                     if (Model.ListadoTipoElemento != null && Model.ListadoTipoElemento.Any())
                    {

#line default
#line hidden
            BeginContext(5379, 498, true);
            WriteLiteral(@"                        <table class=""table table-bordered table-striped"" style=""width:100%;"">
                            <thead class=""thead-dark"">
                                <tr>
                                    <td scope=""col""></td>
                                    <td scope=""col"">Descripción</td>
                                    <td scope=""col"">Activo</td>
                                </tr>
                            </thead>
                            <tbody>
");
            EndContext();
#line 148 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\TipoElemento.cshtml"
                                 foreach (var item in Model.ListadoTipoElemento)
                                {

#line default
#line hidden
            BeginContext(5994, 87, true);
            WriteLiteral("                                    <tr>\r\n                                        <td> ");
            EndContext();
            BeginContext(6081, 142, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "561b896bc4934b859faa1961772186fa", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "onclick", 8, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 6145, "mostrarDivEditar(", 6145, 17, true);
#line 151 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\TipoElemento.cshtml"
AddHtmlAttributeValue("", 6162, item.IdTipoElemento, 6162, 20, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 6182, ",", 6182, 1, true);
            AddHtmlAttributeValue(" ", 6183, "\'", 6184, 2, true);
#line 151 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\TipoElemento.cshtml"
AddHtmlAttributeValue("", 6185, item.Descripcion, 6185, 17, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 6202, "\',", 6202, 2, true);
#line 151 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\TipoElemento.cshtml"
AddHtmlAttributeValue(" ", 6204, item.Activo, 6205, 12, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 6217, ");", 6217, 2, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6223, 53, true);
            WriteLiteral(" </td>\r\n                                        <td> ");
            EndContext();
            BeginContext(6277, 16, false);
#line 152 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\TipoElemento.cshtml"
                                        Write(item.Descripcion);

#line default
#line hidden
            EndContext();
            BeginContext(6293, 82, true);
            WriteLiteral("</td>\r\n                                        <td><input type=\"checkbox\" disabled");
            EndContext();
            BeginWriteAttribute("checked", " checked=\"", 6375, "\"", 6413, 1);
#line 153 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\TipoElemento.cshtml"
WriteAttributeValue("", 6385, item.Activo==1?true:false, 6385, 28, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6414, 53, true);
            WriteLiteral(" /></td>\r\n                                    </tr>\r\n");
            EndContext();
#line 155 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\TipoElemento.cshtml"
                                }

#line default
#line hidden
            BeginContext(6502, 74, true);
            WriteLiteral("                            </tbody>\r\n\r\n                        </table>\r\n");
            EndContext();
#line 159 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\TipoElemento.cshtml"
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(6648, 61, true);
            WriteLiteral("                        <h1> No hay tipos de elementos</h1>\r\n");
            EndContext();
#line 163 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\TipoElemento.cshtml"
                    }

#line default
#line hidden
            BeginContext(6732, 74, true);
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n");
            EndContext();
            BeginContext(6891, 63, true);
            WriteLiteral("    <input id=\"idTipoElementoOculto\" type=\"hidden\" />\r\n</div>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GestorLaboratorios.ViewModels.Configuracion.TipoElementoViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
