#pragma checksum "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\Usuario.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "149aba6b6afb6e3f7eb774f4fffd5e4b3c4f00f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Configuracion_Usuario), @"mvc.1.0.view", @"/Views/Configuracion/Usuario.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Configuracion/Usuario.cshtml", typeof(AspNetCore.Views_Configuracion_Usuario))]
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
#line 3 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\Usuario.cshtml"
using GestorLaboratorios.Settings;

#line default
#line hidden
#line 4 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\Usuario.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"149aba6b6afb6e3f7eb774f4fffd5e4b3c4f00f9", @"/Views/Configuracion/Usuario.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38ea79a3eb4083282ec7125da77034d9406e7e46", @"/Views/_ViewImports.cshtml")]
    public class Views_Configuracion_Usuario : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GestorLaboratorios.ViewModels.Configuracion.UsuarioViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Configuracion", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CargarDetalleUsuario", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/editar.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("cursor:pointer;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Editar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(69, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(142, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(225, 472, true);
            WriteLiteral(@"
<script>
    /**
     * Muestra el mensaje de respuesta cuando se crea o actualiza un usuario
     * bRespuesta
     */
    function mensajeCrearActualizar(bRespuesta) {
        try {
            var sMensaje = (bRespuesta) ?""Se guardó la información correctamente"":""Error al actualizar la información"";
            var icon = (bRespuesta) ?""success"":""error"";
            mensaje(sMensaje, icon);

        } catch (err) {
            window.location.href = '");
            EndContext();
            BeginContext(698, 28, false);
#line 21 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\Usuario.cshtml"
                               Write(Url.Content("~/Login/Login"));

#line default
#line hidden
            EndContext();
            BeginContext(726, 30, true);
            WriteLiteral("\';\r\n        }\r\n    }\r\n\r\n\r\n    ");
            EndContext();
            BeginContext(757, 15, false);
#line 26 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\Usuario.cshtml"
Write(Model.JsFuncion);

#line default
#line hidden
            EndContext();
            BeginContext(772, 366, true);
            WriteLiteral(@"
</script>

<div id=""general"" class=""row"">
    <div class=""col-lg-12 col-md-12 col-sm-12"">
        <div class=""row"">
            <div class=""col-lg-6 col-md-6 col-sm-12"">
                <h3 class=""mt-5"">Usuarios /</h3>
            </div>
        </div>

        <div class=""row"">
            <div class=""col-lg-12 col-md-12 col-sm-12"">
                ");
            EndContext();
            BeginContext(1138, 224, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b025ec1cd1b14926aae751da3c7e466f", async() => {
                BeginContext(1255, 103, true);
                WriteLiteral("\r\n                    <input type=\"button\" class=\"btn btn-primary\" value=\"Agregar\" />\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-IdUserConver", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 39 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\Usuario.cshtml"
                                                                                                WriteLiteral(encrypter.Encrypt("0"));

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["IdUserConver"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-IdUserConver", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["IdUserConver"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1362, 124, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-12 col-md-12 col-sm-12\">\r\n");
            EndContext();
#line 47 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\Usuario.cshtml"
                 if (Model.ListadoUsuarios != null && Model.ListadoUsuarios.Any())
                {

#line default
#line hidden
            BeginContext(1589, 722, true);
            WriteLiteral(@"                    <table class=""table table-bordered table-striped"">
                        <thead>
                            <tr>
                                <td></td>
                                <td scope=""col"">Perfil</td>
                                <td scope=""col"">Nombres</td>
                                <td scope=""col"">Identificación</td>
                                <td scope=""col"">Código</td>
                                <td scope=""col"">Correo</td>
                                <td scope=""col"">Telefono</td>
                                <td scope=""col"">Activo</td>
                            </tr>
                        </thead>
                        <tbody>
");
            EndContext();
#line 63 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\Usuario.cshtml"
                             foreach (var usuario in Model.ListadoUsuarios)
                            {

#line default
#line hidden
            BeginContext(2419, 120, true);
            WriteLiteral("                                <tr>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(2539, 350, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5247306300db4ed3be521488b1af1d38", async() => {
                BeginContext(2725, 46, true);
                WriteLiteral("\r\n                                            ");
                EndContext();
                BeginContext(2771, 72, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "be760c9f987a48dcb4face003cb35b8e", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2843, 42, true);
                WriteLiteral("\r\n                                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-IdUserConver", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 68 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\Usuario.cshtml"
                                                       WriteLiteral(encrypter.Encrypt(usuario.IdUsuario.ToString()));

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["IdUserConver"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-IdUserConver", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["IdUserConver"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2889, 85, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>");
            EndContext();
            BeginContext(2975, 14, false);
#line 72 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\Usuario.cshtml"
                                   Write(usuario.Perfil);

#line default
#line hidden
            EndContext();
            BeginContext(2989, 47, true);
            WriteLiteral("</td>\r\n                                    <td>");
            EndContext();
            BeginContext(3037, 22, false);
#line 73 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\Usuario.cshtml"
                                   Write(usuario.NombreCompleto);

#line default
#line hidden
            EndContext();
            BeginContext(3059, 47, true);
            WriteLiteral("</td>\r\n                                    <td>");
            EndContext();
            BeginContext(3107, 22, false);
#line 74 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\Usuario.cshtml"
                                   Write(usuario.Identificacion);

#line default
#line hidden
            EndContext();
            BeginContext(3129, 47, true);
            WriteLiteral("</td>\r\n                                    <td>");
            EndContext();
            BeginContext(3177, 14, false);
#line 75 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\Usuario.cshtml"
                                   Write(usuario.Codigo);

#line default
#line hidden
            EndContext();
            BeginContext(3191, 47, true);
            WriteLiteral("</td>\r\n                                    <td>");
            EndContext();
            BeginContext(3239, 14, false);
#line 76 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\Usuario.cshtml"
                                   Write(usuario.Correo);

#line default
#line hidden
            EndContext();
            BeginContext(3253, 47, true);
            WriteLiteral("</td>\r\n                                    <td>");
            EndContext();
            BeginContext(3301, 16, false);
#line 77 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\Usuario.cshtml"
                                   Write(usuario.Telefono);

#line default
#line hidden
            EndContext();
            BeginContext(3317, 78, true);
            WriteLiteral("</td>\r\n                                    <td><input type=\"checkbox\" disabled");
            EndContext();
            BeginWriteAttribute("checked", " checked=\"", 3395, "\"", 3420, 1);
#line 78 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\Usuario.cshtml"
WriteAttributeValue("", 3405, usuario.Activo, 3405, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3421, 49, true);
            WriteLiteral(" /></td>\r\n                                </tr>\r\n");
            EndContext();
#line 80 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\Usuario.cshtml"
                            }

#line default
#line hidden
            BeginContext(3501, 64, true);
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n");
            EndContext();
#line 83 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\Usuario.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(3625, 47, true);
            WriteLiteral("                    <h1> No hay usuarios</h1>\r\n");
            EndContext();
#line 87 "C:\Users\user\Desktop\gestorlaboratorios\GestorLaboratorios\Views\Configuracion\Usuario.cshtml"
                }

#line default
#line hidden
            BeginContext(3691, 54, true);
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Encrypter encrypter { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GestorLaboratorios.ViewModels.Configuracion.UsuarioViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
