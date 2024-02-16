using Core.Entities.Company;

namespace Data.Interfaces
{
    public interface ICompanyData
    {
        public List<Company> GetAllCompanies();

        public Company GetCompaniesById(int id);
    }
}
