﻿using Core.Entities.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Ventas
{
    public class ResponseOrder
    {
        public List<Order> value { get; set; }
    }
    public class Order
    {
        public int? DocEntry { get; set; }
        public int? DocNum { get; set; }
        public string DocType { get; set; }
        public string HandWritten { get; set; }
        public string Printed { get; set; }
        public DateTimeOffset? DocDate { get; set; }
        public DateTimeOffset? DocDueDate { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string Address { get; set; }
        public string NumAtCard { get; set; }
        public double? DocTotal { get; set; }
        public string AttachmentEntry { get; set; }
        public string DocCurrency { get; set; }
        public double? DocRate { get; set; }
        public double? Reference1 { get; set; }
        public string Reference2 { get; set; }
        public string Comments { get; set; }
        public string JournalMemo { get; set; }
        public double? PaymentGroupCode { get; set; }
        public DateTimeOffset? DocTime { get; set; }
        public int? SalesPersonCode { get; set; }
        public double? TransportationCode { get; set; }
        public string Confirmed { get; set; }
        public string ImportFileNum { get; set; }
        public string SummeryType { get; set; }
        public int? ContactPersonCode { get; set; }
        public string ShowScn { get; set; }
        public double? Series { get; set; }
        public DateTimeOffset? TaxDate { get; set; }
        public string PartialSupply { get; set; }
        public string DocstringCode { get; set; }
        public string ShipToCode { get; set; }
        public string Indicator { get; set; }
        public string FederalTaxId { get; set; }
        public double? DiscountPercent { get; set; }
        public string PaymentReference { get; set; }
        public DateTimeOffset? CreationDate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public double? FinancialPeriod { get; set; }
        public double? UserSign { get; set; }
        public string TransNum { get; set; }
        public double? VatSum { get; set; }
        public double? VatSumSys { get; set; }
        public double? VatSumFc { get; set; }
        public string NetProcedure { get; set; }
        public double? DocTotalFc { get; set; }
        public double? DocTotalSys { get; set; }
        public string Form1099 { get; set; }
        public string Box1099 { get; set; }
        public string RevisionPo { get; set; }
        public DateTimeOffset? RequriedDate { get; set; }
        public DateTimeOffset? CancelDate { get; set; }
        public string BlockDunning { get; set; }
        public string Submitted { get; set; }
        public double? Segment { get; set; }
        public string PickStatus { get; set; }
        public string Pick { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentBlock { get; set; }
        public string PaymentBlockEntry { get; set; }
        public string CentralBankIndicator { get; set; }
        public string MaximumCashDiscount { get; set; }
        public string Reserve { get; set; }
        public string Project { get; set; }
        public string ExemptionValidityDateFrom { get; set; }
        public string ExemptionValidityDateTo { get; set; }
        public string WareHouseUpdateType { get; set; }
        public string Rounding { get; set; }
        public string ExternalCorrectedDocNum { get; set; }
        public string InternalCorrectedDocNum { get; set; }
        public string NextCorrectingDocument { get; set; }
        public string DeferredTax { get; set; }
        public string TaxExemptionLetterNum { get; set; }
        public double? WtApplied { get; set; }
        public double? WtAppliedFc { get; set; }
        public string BillOfExchangeReserved { get; set; }
        public string AgentCode { get; set; }
        public double? WtAppliedSc { get; set; }
        public double? TotalEqualizationTax { get; set; }
        public double? TotalEqualizationTaxFc { get; set; }
        public double? TotalEqualizationTaxSc { get; set; }
        public double? NumberOfInstallments { get; set; }
        public string ApplyTaxOnFirstInstallment { get; set; }
        public double? WtNonSubjectAmount { get; set; }
        public double? WtNonSubjectAmountSc { get; set; }
        public double? WtNonSubjectAmountFc { get; set; }
        public double? WtExemptedAmount { get; set; }
        public double? WtExemptedAmountSc { get; set; }
        public double? WtExemptedAmountFc { get; set; }
        public double? BaseAmount { get; set; }
        public double? BaseAmountSc { get; set; }
        public double? BaseAmountFc { get; set; }
        public double? WtAmount { get; set; }
        public double? WtAmountSc { get; set; }
        public double? WtAmountFc { get; set; }
        public string VatDate { get; set; }
        public string DocumentsOwner { get; set; }
        public string FolioPrefixString { get; set; }
        public string FolioNumber { get; set; }
        public string DocumentSubType { get; set; }
        public string BpChannelCode { get; set; }
        public string BpChannelContact { get; set; }
        public string Address2 { get; set; }
        public string DocumentStatus { get; set; }
        public string PeriodIndicator { get; set; }
        public string PayToCode { get; set; }
        public string ManualNumber { get; set; }
        public string UseShpdGoodsAct { get; set; }
        public string IsPayToBank { get; set; }
        public string PayToBankCountry { get; set; }
        public string PayToBankCode { get; set; }
        public string PayToBankAccountNo { get; set; }
        public string PayToBankBranch { get; set; }
        public string BplIdAssignedToInvoice { get; set; }
        public double? DownPayment { get; set; }
        public string ReserveInvoice { get; set; }
        public double? LanguageCode { get; set; }
        public string TrackingNumber { get; set; }
        public string PickRemark { get; set; }
        public string ClosingDate { get; set; }
        public string SequenceCode { get; set; }
        public string SequenceSerial { get; set; }
        public string SeriesString { get; set; }
        public string SubSeriesString { get; set; }
        public double? SequenceModel { get; set; }
        public string UseCorrectionVatGroup { get; set; }
        public double? TotalDiscount { get; set; }
        public double? DownPaymentAmount { get; set; }
        public double? DownPaymentPercentage { get; set; }
        public string DownPaymentType { get; set; }
        public double? DownPaymentAmountSc { get; set; }
        public double? DownPaymentAmountFc { get; set; }
        public double? VatPercent { get; set; }
        public double? ServiceGrossProfitPercent { get; set; }
        public string OpeningRemarks { get; set; }
        public string ClosingRemarks { get; set; }
        public double? RoundingDiffAmount { get; set; }
        public double? RoundingDiffAmountFc { get; set; }
        public double? RoundingDiffAmountSc { get; set; }
        public string Cancelled { get; set; }
        public string SignatureInputMessage { get; set; }
        public string SignatureDigest { get; set; }
        public string CertificationNumber { get; set; }
        public string PrivateKeyVersion { get; set; }
        public string ControlAccount { get; set; }
        public string InsuranceOperation347 { get; set; }
        public string ArchiveNonremovableSalesQuotation { get; set; }
        public string GtsChecker { get; set; }
        public string GtsPayee { get; set; }
        public double? ExtraMonth { get; set; }
        public double? ExtraDays { get; set; }
        public double? CashDiscountDateOffset { get; set; }
        public string StartFrom { get; set; }
        public string NtsApproved { get; set; }
        public string ETaxWebSite { get; set; }
        public string ETaxNumber { get; set; }
        public string NtsApprovedNumber { get; set; }
        public string EDocGenerationType { get; set; }
        public string EDocSeries { get; set; }
        public string EDocNum { get; set; }
        public string EDocExportFormat { get; set; }
        public string EDocStatus { get; set; }
        public string EDocErrorCode { get; set; }
        public string EDocErrorMessage { get; set; }
        public string DownPaymentStatus { get; set; }
        public string GroupSeries { get; set; }
        public string GroupNumber { get; set; }
        public string GroupHandWritten { get; set; }
        public string ReopenOriginalDocument { get; set; }
        public string ReopenManuallyClosedOrCanceledDocument { get; set; }
        public string CreateOnlineQuotation { get; set; }
        public string PosEquipmentNumber { get; set; }
        public string PosManufacturerSerialNumber { get; set; }
        public string PosCashierNumber { get; set; }
        public string ApplyCurrentVatRatesForDownPaymentsToDraw { get; set; }
        public string ClosingOption { get; set; }
        public string SpecifiedClosingDate { get; set; }
        public string OpenForLandedCosts { get; set; }
        public string AuthorizationStatus { get; set; }
        public double? TotalDiscountFc { get; set; }
        public double? TotalDiscountSc { get; set; }
        public string RelevantToGts { get; set; }
        public string BplName { get; set; }
        public string VatRegNum { get; set; }
        public string AnnualInvoiceDeclarationReference { get; set; }
        public string Supplier { get; set; }
        public string Releaser { get; set; }
        public string Receiver { get; set; }
        public string BlanketAgreementNumber { get; set; }
        public string IsAlteration { get; set; }
        public string CancelStatus { get; set; }
        public string AssetValueDate { get; set; }
        public string DocumentDelivery { get; set; }
        public string AuthorizationCode { get; set; }
        public string StartDeliveryDate { get; set; }
        public string StartDeliveryTime { get; set; }
        public string EndDeliveryDate { get; set; }
        public string EndDeliveryTime { get; set; }
        public string VehiclePlate { get; set; }
        public string AtDocumentType { get; set; }
        public string ElecCommStatus { get; set; }
        public string ElecCommMessage { get; set; }
        public string ReuseDocumentNum { get; set; }
        public string ReuseNotaFiscalNum { get; set; }
        public string PrintSepaDirect { get; set; }
        public string FiscalDocNum { get; set; }
        public string PosDailySummaryNo { get; set; }
        public string PosReceiptNo { get; set; }
        public string PointOfIssueCode { get; set; }
        public string Letter { get; set; }
        public string FolioNumberFrom { get; set; }
        public string FolioNumberTo { get; set; }
        public string InterimType { get; set; }
        public double? RelatedType { get; set; }
        public string RelatedEntry { get; set; }
        public string SapPassport { get; set; }
        public string DocumentTaxId { get; set; }
        public string DateOfReportingControlStatementVat { get; set; }
        public string ReportingSectionControlStatementVat { get; set; }
        public string ExcludeFromTaxReportControlStatementVat { get; set; }
        public string PosCashRegister { get; set; }
        public DateTimeOffset? UpdateTime { get; set; }
        public string CreateQrCodeFrom { get; set; }
        public string PriceMode { get; set; }
        public string ShipFrom { get; set; }
        public string CommissionTrade { get; set; }
        public string CommissionTradeReturn { get; set; }
        public string UseBillToAddrToDetermineTax { get; set; }
        public string Cig { get; set; }
        public string Cup { get; set; }
        public string FatherCard { get; set; }
        public string FatherType { get; set; }
        public string ShipState { get; set; }
        public string ShipPlace { get; set; }
        public string CustOffice { get; set; }
        public string Fci { get; set; }
        public string AddLegIn { get; set; }
        public string LegTextF { get; set; }
        public string DanfeLgTxt { get; set; }
        public string IndFinal { get; set; }
        public double? DataVersion { get; set; }
        public string LastPageFolioNumber { get; set; }
        public string InventoryStatus { get; set; }
        public string PlasticPackagingTaxRelevant { get; set; }
        public List<string> DocumentApprovalRequests { get; set; }
        public List<DocumentLineOrder> DocumentLines { get; set; }
        public List<string> ElectronicProtocols { get; set; }
        public List<string> DocumentAdditionalExpenses { get; set; }
        public List<string> WithholdingTaxDataWtxCollection { get; set; }
        public List<string> WithholdingTaxDataCollection { get; set; }
        public List<string> DocumentSpecialLines { get; set; }
        public TaxExtension TaxExtension { get; set; }
        public Dictionary<string, string> AddressExtension { get; set; }
        public List<string> DocumentReferences { get; set; }
    }

    public partial class DocumentLineOrder
    {
        public double? LineNum { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public double? Quantity { get; set; }
        public DateTimeOffset? ShipDate { get; set; }
        public double? Price { get; set; }
        public double? PriceAfterVat { get; set; }
        public string Currency { get; set; }
        public double? Rate { get; set; }
        public double? DiscountPercent { get; set; }
        public string VendorNum { get; set; }
        public string SerialNum { get; set; }
        public string WarehouseCode { get; set; }
        public double? SalesPersonCode { get; set; }
        public double? CommisionPercent { get; set; }
        public string TreeType { get; set; }
        public string AccountCode { get; set; }
        public string UseBaseUnits { get; set; }
        public string SupplierCatNum { get; set; }
        public string CostingCode { get; set; }
        public string ProjectCode { get; set; }
        public string BarCode { get; set; }
        public string VatGroup { get; set; }
        public double? Height1 { get; set; }
        public string Hight1Unit { get; set; }
        public double? Height2 { get; set; }
        public string Height2Unit { get; set; }
        public double? Lengh1 { get; set; }
        public string Lengh1Unit { get; set; }
        public double? Lengh2 { get; set; }
        public string Lengh2Unit { get; set; }
        public double? Weight1 { get; set; }
        public string Weight1Unit { get; set; }
        public double? Weight2 { get; set; }
        public string Weight2Unit { get; set; }
        public double? Factor1 { get; set; }
        public double? Factor2 { get; set; }
        public double? Factor3 { get; set; }
        public double? Factor4 { get; set; }
        public double? BaseType { get; set; }
        public string BaseEntry { get; set; }
        public string BaseLine { get; set; }
        public double? Volume { get; set; }
        public double? VolumeUnit { get; set; }
        public double? Width1 { get; set; }
        public string Width1Unit { get; set; }
        public double? Width2 { get; set; }
        public string Width2Unit { get; set; }
        public string Address { get; set; }
        public string TaxCode { get; set; }
        public string TaxType { get; set; }
        public string TaxLiable { get; set; }
        public string PickStatus { get; set; }
        public double? PickQuantity { get; set; }
        public string PickListIdNumber { get; set; }
        public string OriginalItem { get; set; }
        public string BackOrder { get; set; }
        public string FreeText { get; set; }
        public double? ShippingMethod { get; set; }
        public string PoTargetNum { get; set; }
        public string PoTargetEntry { get; set; }
        public string PoTargetRowNum { get; set; }
        public string CorrectionInvoiceItem { get; set; }
        public double? CorrInvAmountToStock { get; set; }
        public double? CorrInvAmountToDiffAcct { get; set; }
        public double? AppliedTax { get; set; }
        public double? AppliedTaxFc { get; set; }
        public double? AppliedTaxSc { get; set; }
        public string WtLiable { get; set; }
        public string DeferredTax { get; set; }
        public double? EqualizationTaxPercent { get; set; }
        public double? TotalEqualizationTax { get; set; }
        public double? TotalEqualizationTaxFc { get; set; }
        public double? TotalEqualizationTaxSc { get; set; }
        public double? NetTaxAmount { get; set; }
        public double? NetTaxAmountFc { get; set; }
        public double? NetTaxAmountSc { get; set; }
        public string MeasureUnit { get; set; }
        public double? UnitsOfMeasurment { get; set; }
        public double? LineTotal { get; set; }
        public double? TaxPercentagePerRow { get; set; }
        public double? TaxTotal { get; set; }
        public string ConsumerSalesForecast { get; set; }
        public double? ExciseAmount { get; set; }
        public double? TaxPerUnit { get; set; }
        public double? TotalInclTax { get; set; }
        public string CountryOrg { get; set; }
        public string Sww { get; set; }
        public string TransactionType { get; set; }
        public string DistributeExpense { get; set; }
        public double? RowTotalFc { get; set; }
        public double? RowTotalSc { get; set; }
        public double? LastBuyInmPrice { get; set; }
        public double? LastBuyDistributeSumFc { get; set; }
        public double? LastBuyDistributeSumSc { get; set; }
        public double? LastBuyDistributeSum { get; set; }
        public double? StockDistributesumForeign { get; set; }
        public double? StockDistributesumSystem { get; set; }
        public double? StockDistributesum { get; set; }
        public double? StockInmPrice { get; set; }
        public string PickStatusEx { get; set; }
        public double? TaxBeforeDpm { get; set; }
        public double? TaxBeforeDpmfc { get; set; }
        public double? TaxBeforeDpmsc { get; set; }
        public string CfopCode { get; set; }
        public string CstCode { get; set; }
        public string Usage { get; set; }
        public string TaxOnly { get; set; }
        public double? VisualOrder { get; set; }
        public double? BaseOpenQuantity { get; set; }
        public double? UnitPrice { get; set; }
        public string LineStatus { get; set; }
        public double? PackageQuantity { get; set; }
        public string Text { get; set; }
        public string LineType { get; set; }
        public string CogsCostingCode { get; set; }
        public string CogsAccountCode { get; set; }
        public string ChangeAssemlyBoMWarehouse { get; set; }
        public double? GrossBuyPrice { get; set; }
        public double? GrossBase { get; set; }
        public double? GrossProfitTotalBasePrice { get; set; }
        public string CostingCode2 { get; set; }
        public string CostingCode3 { get; set; }
        public string CostingCode4 { get; set; }
        public string CostingCode5 { get; set; }
        public string ItemDetails { get; set; }
        public string LocationCode { get; set; }
        public string ActualDeliveryDate { get; set; }
        public double? RemainingOpenQuantity { get; set; }
        public double? OpenAmount { get; set; }
        public double? OpenAmountFc { get; set; }
        public double? OpenAmountSc { get; set; }
        public string ExLineNo { get; set; }
        public string RequiredDate { get; set; }
        public double? RequiredQuantity { get; set; }
        public string CogsCostingCode2 { get; set; }
        public string CogsCostingCode3 { get; set; }
        public string CogsCostingCode4 { get; set; }
        public string CogsCostingCode5 { get; set; }
        public string CsTforIpi { get; set; }
        public string CsTforPis { get; set; }
        public string CsTforCofins { get; set; }
        public string CreditOriginCode { get; set; }
        public string WithoutInventoryMovement { get; set; }
        public string AgreementNo { get; set; }
        public string AgreementRowNumber { get; set; }
        public string ActualBaseEntry { get; set; }
        public string ActualBaseLine { get; set; }
        public double? DocEntry { get; set; }
        public double? Surpluses { get; set; }
        public double? DefectAndBreakup { get; set; }
        public double? Shortages { get; set; }
        public string ConsiderQuantity { get; set; }
        public string PartialRetirement { get; set; }
        public double? RetirementQuantity { get; set; }
        public double? RetirementApc { get; set; }
        public string ThirdParty { get; set; }
        public string PoNum { get; set; }
        public string PoItmNum { get; set; }
        public string ExpenseType { get; set; }
        public string ReceiptNumber { get; set; }
        public string ExpenseOperationType { get; set; }
        public string FederalTaxId { get; set; }
        public double? GrossProfit { get; set; }
        public double? GrossProfitFc { get; set; }
        public double? GrossProfitSc { get; set; }
        public string PriceSource { get; set; }
        public string StgSeqNum { get; set; }
        public string StgEntry { get; set; }
        public string StgDesc { get; set; }
        public double? UoMEntry { get; set; }
        public string UoMCode { get; set; }
        public double? InventoryQuantity { get; set; }
        public double? RemainingOpenInventoryQuantity { get; set; }
        public string ParentLineNum { get; set; }
        public double? Incoterms { get; set; }
        public double? TransportMode { get; set; }
        public string NatureOfTransaction { get; set; }
        public string DestinationCountryForImport { get; set; }
        public string DestinationRegionForImport { get; set; }
        public string OriginCountryForExport { get; set; }
        public string OriginRegionForExport { get; set; }
        public string ItemType { get; set; }
        public string ChangeInventoryQuantityIndependently { get; set; }
        public string FreeOfChargeBp { get; set; }
        public string SacEntry { get; set; }
        public string HsnEntry { get; set; }
        public double? GrossPrice { get; set; }
        public double? GrossTotal { get; set; }
        public double? GrossTotalFc { get; set; }
        public double? GrossTotalSc { get; set; }
        public double? NcmCode { get; set; }
        public string NveCode { get; set; }
        public string IndEscala { get; set; }
        public double? CtrSealQty { get; set; }
        public string CnjpMan { get; set; }
        public string CestCode { get; set; }
        public string UfFiscalBenefitCode { get; set; }
        public string ReverseCharge { get; set; }
        public string ShipToCode { get; set; }
        public string ShipToDescription { get; set; }
        public string OwnerCode { get; set; }
        public double? ExternalCalcTaxRate { get; set; }
        public double? ExternalCalcTaxAmount { get; set; }
        public double? ExternalCalcTaxAmountFc { get; set; }
        public double? ExternalCalcTaxAmountSc { get; set; }
        public string StandardItemIdentification { get; set; }
        public string CommodityClassification { get; set; }
        public string UnencumberedReason { get; set; }
        public string CuSplit { get; set; }
        public double? ListNum { get; set; }
        public List<LineTaxJurisdiction> LineTaxJurisdictions { get; set; }
        public List<string> DocumentLineAdditionalExpenses { get; set; }
        public List<string> WithholdingTaxLines { get; set; }
        public List<string> SerialNumbers { get; set; }
        public List<string> BatchNumbers { get; set; }
        public List<string> DocumentLinesBinAllocations { get; set; }
    }

    public partial class LineTaxJurisdiction
    {
        public string JurisdictionCode { get; set; }
        public double? JurisdictionType { get; set; }
        public double? TaxAmount { get; set; }
        public double? TaxAmountSc { get; set; }
        public double? TaxAmountFc { get; set; }
        public double? TaxRate { get; set; }
        public double? DocEntry { get; set; }
        public double? LineNumber { get; set; }
        public double? RowSequence { get; set; }
        public double? ExternalCalcTaxRate { get; set; }
        public double? ExternalCalcTaxAmount { get; set; }
        public double? ExternalCalcTaxAmountFc { get; set; }
        public double? ExternalCalcTaxAmountSc { get; set; }
    }

    public partial class TaxExtension
    {
        public string TaxId0 { get; set; }
        public string TaxId1 { get; set; }
        public string TaxId2 { get; set; }
        public string TaxId3 { get; set; }
        public string TaxId4 { get; set; }
        public string TaxId5 { get; set; }
        public string TaxId6 { get; set; }
        public string TaxId7 { get; set; }
        public string TaxId8 { get; set; }
        public string TaxId9 { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string Incoterms { get; set; }
        public string Vehicle { get; set; }
        public string VehicleState { get; set; }
        public string NfRef { get; set; }
        public string Carrier { get; set; }
        public string PackQuantity { get; set; }
        public string PackDescription { get; set; }
        public string Brand { get; set; }
        public string ShipUnitNo { get; set; }
        public double? NetWeight { get; set; }
        public double? GrossWeight { get; set; }
        public string StreetS { get; set; }
        public string BlockS { get; set; }
        public string BuildingS { get; set; }
        public string CityS { get; set; }
        public string ZipCodeS { get; set; }
        public string CountyS { get; set; }
        public string StateS { get; set; }
        public string CountryS { get; set; }
        public string StreetB { get; set; }
        public string BlockB { get; set; }
        public string BuildingB { get; set; }
        public string CityB { get; set; }
        public string ZipCodeB { get; set; }
        public string CountyB { get; set; }
        public string StateB { get; set; }
        public string CountryB { get; set; }
        public string ImportOrExport { get; set; }
        public string MainUsage { get; set; }
        public string GlobalLocationNumberS { get; set; }
        public string GlobalLocationNumberB { get; set; }
        public string TaxId12 { get; set; }
        public string TaxId13 { get; set; }
        public string BillOfEntryNo { get; set; }
        public string BillOfEntryDate { get; set; }
        public string OriginalBillOfEntryNo { get; set; }
        public string OriginalBillOfEntryDate { get; set; }
        public string ImportOrExportType { get; set; }
        public string PortCode { get; set; }
        public double? DocEntry { get; set; }
        public double? BoEValue { get; set; }
        public string ClaimRefund { get; set; }
        public string DifferentialOfTaxRate { get; set; }
        public string IsIgstAccount { get; set; }
        public string TaxId14 { get; set; }
    }
}
