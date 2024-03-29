#pragma checksum "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\ElementoParte.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7d35ff8a42865ce7a34e51d7be1f7da610439f8f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Configuracion_ElementoParte), @"mvc.1.0.view", @"/Views/Configuracion/ElementoParte.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Configuracion/ElementoParte.cshtml", typeof(AspNetCore.Views_Configuracion_ElementoParte))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d35ff8a42865ce7a34e51d7be1f7da610439f8f", @"/Views/Configuracion/ElementoParte.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38ea79a3eb4083282ec7125da77034d9406e7e46", @"/Views/_ViewImports.cshtml")]
    public class Views_Configuracion_ElementoParte : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GestorLaboratorios.ViewModels.Configuracion.ElementoParteViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Configuracion", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Elemento", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("cursor:pointer"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/editar.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(76, 974, true);
            WriteLiteral(@"

<script>

    /**
    * Muestra el div de editar y crear
    * */
    function mostrarDivCrearEditar(idParteElemento =0, descripcion="""", activo=false) {
        try {
            $(""#idParteElemento"").val(idParteElemento);
            $(""#descripcion"").val(descripcion);
            $(""#activo"").attr(""checked"",activo);
            $(""#divActivo"").css(""display"", (idParteElemento == 0) ? ""none"" :""block"");
            $(""#divCrearEditar"").css(""display"", ""block"");
        } catch (err) {
            mensaje(""Error al mostrar la información"", ""error"");
            console.log(err);
        }
    }


    function guardarParteElemento() {
        try {
            var idParteElemento = $(""#idParteElemento"").val();
            var activo = $(""#activo"").attr(""checked"");
            var descripcion = $(""#descripcion"").val();

            Pace.track(() => {
                $.ajax({
                    type:""POST"",
                    url: '");
            EndContext();
            BeginContext(1051, 59, false);
#line 32 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\ElementoParte.cshtml"
                     Write(Url.Content("~/Configuracion/CrearActualizarParteElemento"));

#line default
#line hidden
            EndContext();
            BeginContext(1110, 43, true);
            WriteLiteral("\',\r\n                    data: { IdElemento:");
            EndContext();
            BeginContext(1154, 16, false);
#line 33 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\ElementoParte.cshtml"
                                  Write(Model.IdElemento);

#line default
#line hidden
            EndContext();
            BeginContext(1170, 528, true);
            WriteLiteral(@", IdParteElemento: idParteElemento, Descripcion: descripcion, Activo: activo },
                    success: (data) => {
                        mensaje(""Se guardó correctamente la información"", ""success"");
                        $(""#general"").html(data);
                    },
                    error: (err) => {
                        mensaje(""Error al guardar la información"", ""error"");
                    }

                });
            });

        } catch (err) {
            window.location.href = '");
            EndContext();
            BeginContext(1699, 28, false);
#line 46 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\ElementoParte.cshtml"
                               Write(Url.Content("~/Login/Login"));

#line default
#line hidden
            EndContext();
            BeginContext(1727, 1672, true);
            WriteLiteral(@"';
        }
    }


</script>

<div id=""general"" class=""row"">
    <div class=""col-lg-12 col-md-12 col-sm-12"">
        <div class=""row"">
            <div class=""col-lg-6 col-md-6 col-sm-12"">
                <h3 class=""mt-5"">Partes Elementos /</h3>
            </div>
        </div>

        <div id=""divCrearEditar"" style=""display:none; padding:2% 0;"" class=""row"">
            <div class=""col-lg-12 col-md-12 col-sm-12"">
                <div class=""form-row"">
                    <div class=""col-lg-1 col-md-1 col-sm-12"">
                        <label>Descripción</label>
                    </div>
                    <div class=""col-lg-3 col-md-3 col-sm-12"">
                        <input id=""descripcion"" class=""form-control"" />
                    </div>
                    <div id=""divActivo"" class=""col-lg-4 col-md-4 col-sm-12"">
                        <label>Activo</label>
                        <input id=""activo"" type=""checkbox"" />
                    </div>
                    <di");
            WriteLiteral(@"v class=""col-lg-4 col-md-4 col-sm-12"">
                        <button class=""btn btn-success"" onclick=""guardarParteElemento();"">Guardar</button>
                        <button class=""btn btn-danger"" onclick='$(""#divCrearEditar"").css(""display"",""none"")'>Cancelar</button>
                    </div>
                </div>
                <input type=""hidden"" id=""idParteElemento"" />
            </div>
        </div>

        <div class=""row"" style=""padding:2% 0;"">
            <div class=""col-lg-2 col-md-2 col-sm-12"">
                <button class=""btn btn-primary"" onclick=""mostrarDivCrearEditar();"">Agregar</button>
                ");
            EndContext();
            BeginContext(3399, 159, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aff568025f864a519adab16fbd7672de", async() => {
                BeginContext(3455, 99, true);
                WriteLiteral("\r\n                    <input type=\"button\" class=\"btn btn-danger\" value=\"Volver\">\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3558, 124, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-12 col-md-12 col-sm-12\">\r\n");
            EndContext();
#line 94 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\ElementoParte.cshtml"
                 if (Model.ListadoParteElemento != null && Model.ListadoParteElemento.Any())
                {

#line default
#line hidden
            BeginContext(3795, 396, true);
            WriteLiteral(@"                    <table class=""table table-sm table-bordered table-striped"">
                        <thead>
                            <tr>
                                <th></th>
                                <th>Descripción</th>
                                <th>Activo</th>
                            </tr>
                        </thead>
                        <tbody>
");
            EndContext();
#line 105 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\ElementoParte.cshtml"
                             foreach (var parte in Model.ListadoParteElemento)
                            {

#line default
#line hidden
            BeginContext(4302, 120, true);
            WriteLiteral("                                <tr>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(4422, 168, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c95d7c5f991f4b7d90d30c17f867d121", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "onclick", 7, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 4485, "mostrarDivCrearEditar(", 4485, 22, true);
#line 109 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\ElementoParte.cshtml"
AddHtmlAttributeValue("", 4507, parte.IdParteElemento, 4507, 22, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 4529, ",\'", 4529, 2, true);
#line 109 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\ElementoParte.cshtml"
AddHtmlAttributeValue("", 4531, parte.Descripcion, 4531, 18, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 4549, "\',", 4549, 2, true);
#line 109 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\ElementoParte.cshtml"
AddHtmlAttributeValue("", 4551, parte.Activo.ToString().ToLower(), 4551, 34, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 4585, ")", 4585, 1, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4590, 85, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>");
            EndContext();
            BeginContext(4676, 17, false);
#line 111 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\ElementoParte.cshtml"
                                   Write(parte.Descripcion);

#line default
#line hidden
            EndContext();
            BeginContext(4693, 69, true);
            WriteLiteral("</td>\r\n                                    <td><input type=\"checkbox\"");
            EndContext();
            BeginWriteAttribute("checked", " checked=", 4762, "", 4784, 1);
#line 112 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\ElementoParte.cshtml"
WriteAttributeValue("", 4771, parte.Activo, 4771, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4784, 58, true);
            WriteLiteral(" disabled /></td>\r\n                                </tr>\r\n");
            EndContext();
#line 114 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\ElementoParte.cshtml"
                            }

#line default
#line hidden
            BeginContext(4873, 66, true);
            WriteLiteral("\r\n                        </tbody>\r\n                    </table>\r\n");
            EndContext();
#line 118 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\ElementoParte.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(4999, 74, true);
            WriteLiteral("                    <h1>No hay partes para el elemento seleccionado</h1>\r\n");
            EndContext();
#line 122 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\ElementoParte.cshtml"
                }

#line default
#line hidden
            BeginContext(5092, 56, true);
            WriteLiteral("            </div>\r\n        </div>\r\n\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GestorLaboratorios.ViewModels.Configuracion.ElementoParteViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
