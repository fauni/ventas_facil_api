using Core.Entities.Company;
using Core.Interfaces;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class CompanyRepository : ICompanyRepository
    {
        ICompanyData _companyData;

        public CompanyRepository(ICompanyData companyData)
        {
            _companyData = companyData;
        }
        public List<Company> GetCompanies()
        {
            var companies = _companyData.GetAllCompanies();
            return companies;
        }

        public Company GetCompanyByIdAsync(int id)
        {
            var company = _companyData.GetCompaniesById(id);
            return company;
        }

        public Task<Company> GetCompanyByNitAsync(int nint)
        {
            throw new NotImplementedException();
        }
    }
}
