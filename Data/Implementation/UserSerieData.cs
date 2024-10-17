using Core.Entities;
using Core.Entities.Producto;
using Core.Entities.Series;
using Data.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Net.Http.Headers;

namespace Data.Implementation
{
    public class UserSerieData : IUserSerieData
    {
        IConfiguration _configuration;

        public UserSerieData(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DocumentSeries GetSerieById(int id)
        {
            DocumentSeries serie = new DocumentSeries();
            try
            {
                string string_connection = _configuration.GetConnectionString("DatabaseConnectionSAP");
                StoreProcedure consulta = new StoreProcedure($"SELECT Series, SeriesName FROM NNM1 T0 where Series = {id};");

                DataTable dt = consulta.EjecutarConsulta(string_connection);
                if (string.IsNullOrEmpty(consulta.Error)) { 
                    foreach (DataRow row in dt.Rows)
                    {
                        DocumentSeries s = new DocumentSeries();
                        s.Series = Convert.ToInt32(row["Series"]);
                        s.Name = Convert.ToString(row["SeriesName"]);
                        serie = s;
                    }
                }
                return serie;

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<UserSerie> GetSeriesByUser(string idUsuario)
        {
            List<UserSerie> result = new List<UserSerie>();
            try
            {
                string string_connection = _configuration.GetConnectionString("DatabaseConnection");
                StoreProcedure consulta = new StoreProcedure(
                    @$"select Id,IdUsuario,IdSerie from UserSeries where IdUsuario = '{idUsuario}'"
                );

                DataTable dt = consulta.EjecutarConsulta(string_connection);
                if (string.IsNullOrEmpty(consulta.Error))
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        UserSerie u = new UserSerie();
                        u.Id= Convert.ToInt32(row["Id"]);
                        u.IdUsuario = row["IdUsuario"].ToString();
                        u.IdSerie = Convert.ToInt32(row["IdSerie"]);
                        u.NombreSerie = GetSerieById(Convert.ToInt32(row["IdSerie"])).Name ?? "";
                        result.Add(u);
                    }
                }
                else
                {
                    throw new Exception(consulta.Error);
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener los datos: {ex.Message}");
            }
            return result;
        }
    }
}
