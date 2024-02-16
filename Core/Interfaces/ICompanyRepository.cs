using Core.Entities.Company;

namespace Core.Interfaces
{
    public interface ICompanyRepository
    {
        List<Company> GetCompanies();
        Company GetCompanyByIdAsync(int id);
        Task<Company> GetCompanyByNitAsync(int nint);
    }
}
