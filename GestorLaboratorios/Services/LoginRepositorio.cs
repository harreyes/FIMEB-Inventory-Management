using GestorLaboratorios.Models;
using GestorLaboratorios.Settings;
using GestorLaboratorios.ViewModels.Login;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace GestorLaboratorios.Services
{
    public class LoginRepositorio
    {
        private readonly DBGESTORContext _dbContext;
        public IConfiguration _configuracion;
        Encrypter encrypter = new Encrypter();
        public LoginRepositorio(DBGESTORContext dBGESTORContext, IConfiguration configuration)
        {
            this._dbContext = dBGESTORContext;
            this._configuracion = configuration;
        }

        /// <summary>
        /// Metodo para ingresar, comprueba que coincida correo y cotraseña
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns></returns>
        public AdmUsuarioLaboratorio ValidarIngreso(LoginViewModel loginViewModel)
        {
            try
            {
                var Usuario = _dbContext.AdmUsuarioLaboratorio
                                .Where(u => u.UprUsuarioNavigation.UsuCorreo == loginViewModel.sCorreo
                                    && u.UprUsuarioNavigation.UsuContrasena == encrypter.Encrypt(loginViewModel.sContrasena)
                                    && u.UprUsuarioNavigation.UsuActivo == 1)
                                .Include(u => u.UprUsuarioNavigation.UsuPerfilNavigation);
                if (Usuario.Any())
                {
                    return Usuario.FirstOrDefault();
                }
                return null;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// Valida el ingreso del estudiante, solo valida el código
        /// </summary>
        /// <param name="sCodigo"></param>
        /// <returns></returns>
        public AdmUsuario ValidarIngresoEstudiante(string sCodigo)
        {
            try
            {
                var usuarioEstudiante = _dbContext.AdmUsuario
                                        .Where(u => u.UsuCodigo == sCodigo && u.UsuPerfil == 3 && u.UsuActivo == 1);
                return usuarioEstudiante.Any() ? usuarioEstudiante.FirstOrDefault() : null;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

    }
}

