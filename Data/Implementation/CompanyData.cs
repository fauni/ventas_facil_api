using Core.Entities.Company;
using Data.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Data.Implementation
{
    public class CompanyData : ICompanyData
    {
        IConfiguration _configuration;

        public CompanyData(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Company> GetAllCompanies()
        {
            List<Company> result = new List<Company>();
            try
            {
                string string_connection = _configuration.GetConnectionString("DatabaseConnection");
                StoreProcedure consulta = new StoreProcedure("select * from Company");
                DataTable dt = consulta.EjecutarConsulta(string_connection);
                if (string.IsNullOrEmpty(consulta.Error))
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        Company c = new Company();
                        c.Id = Convert.ToInt32(item["Id"]);
                        c.RazonSocial = item["RazonSocial"].ToString();
                        c.Nit = item["Nit"].ToString();
                        c.CompanyDB = item["CompanyDB"].ToString();
                        c.UserName = item["UserName"].ToString();
                        c.Password = item["Password"].ToString();
                        c.NumMaximoUser = Convert.ToInt32(item["NumMaximoUser"]);
                        result.Add(c);
                    }
                }
                else
                {
                    throw new Exception(consulta.Error);
                }

            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public Company GetCompaniesById(int id)
        {
            Company result = new Company();
            try
            {
                string string_connection = _configuration.GetConnectionString("DatabaseConnection");
                StoreProcedure consulta = new StoreProcedure($"select * from Company where Id = {id}");
                DataTable dt = consulta.EjecutarConsulta(string_connection);
                if (string.IsNullOrEmpty(consulta.Error))
                {
                    DataRow item = dt.Rows[0];
                    Company c = new Company();
                    c.Id = Convert.ToInt32(item["Id"]);
                    c.RazonSocial = item["RazonSocial"].ToString();
                    c.Nit = item["Nit"].ToString();
                    c.ServerName = item["ServerName"].ToString();
                    c.CompanyDB = item["CompanyDB"].ToString();
                    c.UserName = item["UserName"].ToString();
                    c.Password = item["Password"].ToString();
                    c.NumMaximoUser = Convert.ToInt32(item["NumMaximoUser"]);
                    c.Enable = Convert.ToInt32(item["Enable"]);
                    result = c;
                }
                else
                {
                    throw new Exception(consulta.Error);
                }

            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
