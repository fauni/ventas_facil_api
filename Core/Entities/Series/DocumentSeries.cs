using Core.Entities.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Series
{
    public class ResponseDocumentSeries
    {
        public List<DocumentSeries> value { get; set; }
    }
    public class DocumentSeries
    {
        public int Document { get; set; }
        public string DocumentSubType { get; set; }
        public long InitialNumber { get; set; }
        public long LastNumber { get; set; }
        public long NextNumber { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public string Remarks { get; set; }
        public string GroupCode { get; set; }
        public string Locked { get; set; }
        public string PeriodIndicator { get; set; }
        public string Name { get; set; }
        public long Series { get; set; }
        public string IsDigitalSeries { get; set; }
        public string DigitNumber { get; set; }
        public string SeriesType { get; set; }
        public string IsManual { get; set; }
        public string Bplid { get; set; }
        public string AtDocumentType { get; set; }
        public string IsElectronicCommEnabled { get; set; }
        public string CostAccountOnly { get; set; }
        public string InvoiceType { get; set; }
        public string InvoiceTypeOfNegativeInvoice { get; set; }
        public string PortugalSeriesAction { get; set; }
        public string PortugalSeriesStatus { get; set; }
        public string PortugalSeriesPhase { get; set; }
    }
}
