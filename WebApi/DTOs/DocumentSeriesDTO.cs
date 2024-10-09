using Core.Entities.Series;

namespace WebApi.DTOs
{
    public class DocumentSeriesDTO
    {
        public int CodigoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public long NumeroInicial { get; set; }
        public long UltimoNumero { get; set; }
        public long SiguienteNumero { get; set; }
        public string Nombre { get; set; }
        public int? Series { get; set; }
        public string TipoDeSerie { get; set; }
    }

    public class MapeoDocumentSeriesDTO
    {
        public static DocumentSeriesDTO MapToDTO(DocumentSeries data)
        {
            return new DocumentSeriesDTO()
            {
                CodigoDocumento = data.Document,
                TipoDocumento = data.DocumentSubType,
                NumeroInicial = data.InitialNumber,
                UltimoNumero = data.LastNumber,
                SiguienteNumero = data.NextNumber,
                Nombre = data.Name,
                Series = data.Series,
                TipoDeSerie = data.SeriesType
            };
        }
    }
}
