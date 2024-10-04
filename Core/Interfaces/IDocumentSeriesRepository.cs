using Core.Entities.Errors;
using Core.Entities.Series;
using Core.Entities.SocioNegocio;

namespace Core.Interfaces
{
    public interface IDocumentSeriesRepository
    {
        Task<(List<DocumentSeries> Result, CodeErrorException Error)> GetForDocumentCode(String sessionID, int documentCode);

    }
}
