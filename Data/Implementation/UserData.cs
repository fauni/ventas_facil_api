using Core.Entities;
using Core.Entities.Errors;
using Data.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public class UserData: IUserData
    {
        IConfiguration _configuration;
        public UserData(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public User Login(string username, string password, int id_company, out CodeErrorException Error)
        {
            User result = new User();
            try
            {
                string string_connection = _configuration.GetConnectionString("DatabaseConnection");
                string sql = $"select * from Users where UserName = '{username}' and PasswordHash = '{password}' and IdCompany = {id_company};";
                StoreProcedure consulta = new StoreProcedure(sql);
                DataTable dt = consulta.EjecutarConsulta(string_connection);
                if (string.IsNullOrEmpty(consulta.Error))
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataRow item = dt.Rows[0];
                        User u = new User();
                        u.Id = (item["Id"]).ToString();
                        u.Nombre = (item["Nombre"]).ToString();
                        u.Apellido = (item["Apellido"]).ToString();
                        u.UserName = (item["UserName"]).ToString();
                        u.Email = (item["Email"]).ToString();
                        u.EmailConfirmed = Convert.ToBoolean(item["EmailConfirmed"]);
                        u.PasswordHash = item["PasswordHash"].ToString();
                        u.ApiToken = item["ApiToken"].ToString();
                        u.PhoneNumber = item["PhoneNumber"].ToString();
                        u.PhoneNumberConfirmed = Convert.ToBoolean(item["PhoneNumberConfirmed"]);
                        u.TwoFactorEnabled = Convert.ToBoolean(item["TwoFactorEnabled"]);
                        u.LockoutEnd = item["LockoutEnd"] == DBNull.Value ? null : Convert.ToDateTime(item["LockoutEnd"]);
                        u.LockoutEnabled = Convert.ToBoolean(item["LockoutEnabled"]);
                        u.AccessFailedCount = Convert.ToInt32(item["AccessFailedCount"]);
                        u.IdCompany = Convert.ToInt32(item["IdCompany"]);
                        u.IdEmpleadoSap = Convert.ToInt32(item["IdEmpleadoSap"]);
                        u.Imagen = item["Imagen"].ToString();
                        u.Almacen = item["Almacen"].ToString();
                        result = u;
                    }
                    else
                    {
                        var codeError = new CodeErrorException(401, message: consulta.Error);
                        Error = codeError;
                        return result;
                    }
                }
                else
                {
                    throw new Exception(consulta.Error);
                }
                Error = null;
                return result;
            }
            catch (Exception ex)
            {
                var codeError = new CodeErrorException(500, ex.Message, ex.StackTrace);
                Error = codeError;
                return result;
            }
        }
    }
}
