﻿namespace Core.Entities.Producto
{
    public class ResponseItem
    {
        public List<Item> value { get; set; }
    }
    public partial class Item
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ForeignName { get; set; }
        public double? ItemsGroupCode { get; set; }
        public double? CustomsGroupCode { get; set; }
        public string SalesVatGroup { get; set; }
        public string BarCode { get; set; }
        public string VatLiable { get; set; }
        public string PurchaseItem { get; set; }
        public string SalesItem { get; set; }
        public string InventoryItem { get; set; }
        public string IncomeAccount { get; set; }
        public string ExemptIncomeAccount { get; set; }
        public string ExpanseAccount { get; set; }
        public string Mainsupplier { get; set; }
        public string SupplierCatalogNo { get; set; }
        public double? DesiredInventory { get; set; }
        public double? MinInventory { get; set; }
        public string Picture { get; set; }
        public string UserText { get; set; }
        public string SerialNum { get; set; }
        public double? CommissionPercent { get; set; }
        public double? CommissionSum { get; set; }
        public double? CommissionGroup { get; set; }
        public string TreeType { get; set; }
        public string AssetItem { get; set; }
        public string DataExportCode { get; set; }
        public double? Manufacturer { get; set; }
        public double? QuantityOnStock { get; set; }
        public double? QuantityOrderedFromVendors { get; set; }
        public double? QuantityOrderedByCustomers { get; set; }
        public string ManageSerialNumbers { get; set; }
        public string ManageBatchNumbers { get; set; }
        public string Valid { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string ValidRemarks { get; set; }
        public string Frozen { get; set; }
        public string FrozenFrom { get; set; }
        public string FrozenTo { get; set; }
        public string FrozenRemarks { get; set; }
        public string SalesUnit { get; set; }
        public double? SalesItemsPerUnit { get; set; }
        public string SalesPackagingUnit { get; set; }
        public double? SalesQtyPerPackUnit { get; set; }
        public double? SalesUnitLength { get; set; }
        public string SalesLengthUnit { get; set; }
        public double? SalesUnitWidth { get; set; }
        public string SalesWidthUnit { get; set; }
        public double? SalesUnitHeight { get; set; }
        public string SalesHeightUnit { get; set; }
        public double? SalesUnitVolume { get; set; }
        public double? SalesVolumeUnit { get; set; }
        public double? SalesUnitWeight { get; set; }
        public string SalesWeightUnit { get; set; }
        public string PurchaseUnit { get; set; }
        public double? PurchaseItemsPerUnit { get; set; }
        public string PurchasePackagingUnit { get; set; }
        public double? PurchaseQtyPerPackUnit { get; set; }
        public double? PurchaseUnitLength { get; set; }
        public string PurchaseLengthUnit { get; set; }
        public double? PurchaseUnitWidth { get; set; }
        public string PurchaseWidthUnit { get; set; }
        public double? PurchaseUnitHeight { get; set; }
        public string PurchaseHeightUnit { get; set; }
        public double? PurchaseUnitVolume { get; set; }
        public double? PurchaseVolumeUnit { get; set; }
        public double? PurchaseUnitWeight { get; set; }
        public string PurchaseWeightUnit { get; set; }
        public string PurchaseVatGroup { get; set; }
        public double? SalesFactor1 { get; set; }
        public double? SalesFactor2 { get; set; }
        public double? SalesFactor3 { get; set; }
        public double? SalesFactor4 { get; set; }
        public double? PurchaseFactor1 { get; set; }
        public double? PurchaseFactor2 { get; set; }
        public double? PurchaseFactor3 { get; set; }
        public double? PurchaseFactor4 { get; set; }
        public double? MovingAveragePrice { get; set; }
        public string ForeignRevenuesAccount { get; set; }
        public string EcRevenuesAccount { get; set; }
        public string ForeignExpensesAccount { get; set; }
        public string EcExpensesAccount { get; set; }
        public double? AvgStdPrice { get; set; }
        public string DefaultWarehouse { get; set; }
        public string ShipType { get; set; }
        public string GlMethod { get; set; }
        public string TaxType { get; set; }
        public double? MaxInventory { get; set; }
        public string ManageStockByWarehouse { get; set; }
        public string PurchaseHeightUnit1 { get; set; }
        public double? PurchaseUnitHeight1 { get; set; }
        public string PurchaseLengthUnit1 { get; set; }
        public double? PurchaseUnitLength1 { get; set; }
        public string PurchaseWeightUnit1 { get; set; }
        public double? PurchaseUnitWeight1 { get; set; }
        public string PurchaseWidthUnit1 { get; set; }
        public double? PurchaseUnitWidth1 { get; set; }
        public string SalesHeightUnit1 { get; set; }
        public double? SalesUnitHeight1 { get; set; }
        public string SalesLengthUnit1 { get; set; }
        public double? SalesUnitLength1 { get; set; }
        public string SalesWeightUnit1 { get; set; }
        public double? SalesUnitWeight1 { get; set; }
        public string SalesWidthUnit1 { get; set; }
        public double? SalesUnitWidth1 { get; set; }
        public string ForceSelectionOfSerialNumber { get; set; }
        public string ManageSerialNumbersOnReleaseOnly { get; set; }
        public string WtLiable { get; set; }
        public string CostAccountingMethod { get; set; }
        public string Sww { get; set; }
        public string WarrantyTemplate { get; set; }
        public string IndirectTax { get; set; }
        public string ArTaxCode { get; set; }
        public string ApTaxCode { get; set; }
        public string BaseUnitName { get; set; }
        public string ItemCountryOrg { get; set; }
        public string IssueMethod { get; set; }
        public string SriAndBatchManageMethod { get; set; }
        public string IsPhantom { get; set; }
        public string InventoryUom { get; set; }
        public string PlanningSystem { get; set; }
        public string ProcurementMethod { get; set; }
        public string ComponentWarehouse { get; set; }
        public string OrderIntervals { get; set; }
        public double? OrderMultiple { get; set; }
        public string LeadTime { get; set; }
        public double? MinOrderQuantity { get; set; }
        public string ItemType { get; set; }
        public string ItemClass { get; set; }
        public double? OutgoingServiceCode { get; set; }
        public double? IncomingServiceCode { get; set; }
        public double? ServiceGroup { get; set; }
        public double? NcmCode { get; set; }
        public string MaterialType { get; set; }
        public double? MaterialGroup { get; set; }
        public double? ProductSource { get; set; }
        public string Properties1 { get; set; }
        public string Properties2 { get; set; }
        public string Properties3 { get; set; }
        public string Properties4 { get; set; }
        public string Properties5 { get; set; }
        public string Properties6 { get; set; }
        public string Properties7 { get; set; }
        public string Properties8 { get; set; }
        public string Properties9 { get; set; }
        public string Properties10 { get; set; }
        public string Properties11 { get; set; }
        public string Properties12 { get; set; }
        public string Properties13 { get; set; }
        public string Properties14 { get; set; }
        public string Properties15 { get; set; }
        public string Properties16 { get; set; }
        public string Properties17 { get; set; }
        public string Properties18 { get; set; }
        public string Properties19 { get; set; }
        public string Properties20 { get; set; }
        public string Properties21 { get; set; }
        public string Properties22 { get; set; }
        public string Properties23 { get; set; }
        public string Properties24 { get; set; }
        public string Properties25 { get; set; }
        public string Properties26 { get; set; }
        public string Properties27 { get; set; }
        public string Properties28 { get; set; }
        public string Properties29 { get; set; }
        public string Properties30 { get; set; }
        public string Properties31 { get; set; }
        public string Properties32 { get; set; }
        public string Properties33 { get; set; }
        public string Properties34 { get; set; }
        public string Properties35 { get; set; }
        public string Properties36 { get; set; }
        public string Properties37 { get; set; }
        public string Properties38 { get; set; }
        public string Properties39 { get; set; }
        public string Properties40 { get; set; }
        public string Properties41 { get; set; }
        public string Properties42 { get; set; }
        public string Properties43 { get; set; }
        public string Properties44 { get; set; }
        public string Properties45 { get; set; }
        public string Properties46 { get; set; }
        public string Properties47 { get; set; }
        public string Properties48 { get; set; }
        public string Properties49 { get; set; }
        public string Properties50 { get; set; }
        public string Properties51 { get; set; }
        public string Properties52 { get; set; }
        public string Properties53 { get; set; }
        public string Properties54 { get; set; }
        public string Properties55 { get; set; }
        public string Properties56 { get; set; }
        public string Properties57 { get; set; }
        public string Properties58 { get; set; }
        public string Properties59 { get; set; }
        public string Properties60 { get; set; }
        public string Properties61 { get; set; }
        public string Properties62 { get; set; }
        public string Properties63 { get; set; }
        public string Properties64 { get; set; }
        public string AutoCreateSerialNumbersOnRelease { get; set; }
        public double? DnfEntry { get; set; }
        public string GtsItemSpec { get; set; }
        public string GtsItemTaxCategory { get; set; }
        public double? FuelId { get; set; }
        public string BeverageTableCode { get; set; }
        public string BeverageGroupCode { get; set; }
        public double? BeverageCommercialBrandCode { get; set; }
        public double? Series { get; set; }
        public string ToleranceDays { get; set; }
        public string TypeOfAdvancedRules { get; set; }
        public string IssuePrimarilyBy { get; set; }
        public string NoDiscounts { get; set; }
        public string AssetClass { get; set; }
        public string AssetGroup { get; set; }
        public string InventoryNumber { get; set; }
        public string Technician { get; set; }
        public string Employee { get; set; }
        public string Location { get; set; }
        public string AssetStatus { get; set; }
        public string CapitalizationDate { get; set; }
        public string StatisticalAsset { get; set; }
        public string Cession { get; set; }
        public string DeactivateAfterUsefulLife { get; set; }
        public string ManageByQuantity { get; set; }
        public double? UoMGroupEntry { get; set; }
        public double? InventoryUoMEntry { get; set; }
        public string DefaultSalesUoMEntry { get; set; }
        public string DefaultPurchasingUoMEntry { get; set; }
        public string DepreciationGroup { get; set; }
        public string AssetSerialNumber { get; set; }
        public double? InventoryWeight { get; set; }
        public string InventoryWeightUnit { get; set; }
        public double? InventoryWeight1 { get; set; }
        public string InventoryWeightUnit1 { get; set; }
        public string DefaultCountingUnit { get; set; }
        public double? CountingItemsPerUnit { get; set; }
        public string DefaultCountingUoMEntry { get; set; }
        public string Excisable { get; set; }
        public double? ChapterId { get; set; }
        public string ScsCode { get; set; }
        public string SpProdType { get; set; }
        public double? ProdStdCost { get; set; }
        public string InCostRollup { get; set; }
        public string VirtualAssetItem { get; set; }
        public string EnforceAssetSerialNumbers { get; set; }
        public string AttachmentEntry { get; set; }
        public string LinkedResource { get; set; }
        public string UpdateDate { get; set; }
        public string UpdateTime { get; set; }
        public string GstRelevnt { get; set; }
        public double? SacEntry { get; set; }
        public string GstTaxCategory { get; set; }
        public double? ServiceCategoryEntry { get; set; }
        public double? CapitalGoodsOnHoldPercent { get; set; }
        public double? CapitalGoodsOnHoldLimit { get; set; }
        public double? AssessableValue { get; set; }
        public double? AssVal4Wtr { get; set; }
        public string SoiExcisable { get; set; }
        public string Tnved { get; set; }
        public string ImportedItem { get; set; }
        public double? PricingUnit { get; set; }
        public DateTimeOffset? CreateDate { get; set; }
        public DateTimeOffset? CreateTime { get; set; }
        public string NveCode { get; set; }
        public string CtrSealQty { get; set; }
        public double? CestCode { get; set; }
        public string LegalText { get; set; }
        public double? DataVersion { get; set; }
        public string CreateQrCodeFrom { get; set; }
        public string TraceableItem { get; set; }
        public string CommodityClassification { get; set; }
        public List<ItemPrice> ItemPrices { get; set; }
        public List<ItemWarehouseInfoCollection> ItemWarehouseInfoCollection { get; set; }
        public List<string> ItemPreferredVendors { get; set; }
        public List<string> ItemLocalizationInfos { get; set; }
        public List<string> ItemProjects { get; set; }
        public List<string> ItemDistributionRules { get; set; }
        public List<string> ItemAttributeGroups { get; set; }
        public List<string> ItemDepreciationParameters { get; set; }
        public List<string> ItemPeriodControls { get; set; }
        public List<string> ItemUnitOfMeasurementCollection { get; set; }
        public List<string> ItemBarCodeCollection { get; set; }
        public ItemIntrastatExtension ItemIntrastatExtension { get; set; }
    }

    public partial class ItemIntrastatExtension
    {
    }

    public partial class ItemPrice
    {
        public int? PriceList { get; set; }
        public double? Price { get; set; }
        public string Currency { get; set; }
        public double? AdditionalPrice1 { get; set; }
        public string AdditionalCurrency1 { get; set; }
        public double? AdditionalPrice2 { get; set; }
        public string AdditionalCurrency2 { get; set; }
        public double? BasePriceList { get; set; }
        public double? Factor { get; set; }
        public List<string> UoMPrices { get; set; }
    }

    public partial class ItemWarehouseInfoCollection
    {
        public double? MinimalStock { get; set; }
        public double? MaximalStock { get; set; }
        public double? MinimalOrder { get; set; }
        public double? StandardAveragePrice { get; set; }
        public string Locked { get; set; }
        public string InventoryAccount { get; set; }
        public string CostAccount { get; set; }
        public string TransferAccount { get; set; }
        public string RevenuesAccount { get; set; }
        public string VarienceAccount { get; set; }
        public string DecreasingAccount { get; set; }
        public string IncreasingAccount { get; set; }
        public string ReturningAccount { get; set; }
        public string ExpensesAccount { get; set; }
        public string EuRevenuesAccount { get; set; }
        public string EuExpensesAccount { get; set; }
        public string ForeignRevenueAcc { get; set; }
        public string ForeignExpensAcc { get; set; }
        public string ExemptIncomeAcc { get; set; }
        public string PriceDifferenceAcc { get; set; }
        public string WarehouseCode { get; set; }
        public double? InStock { get; set; }
        public double? Committed { get; set; }
        public double? Ordered { get; set; }
        public double? CountedQuantity { get; set; }
        public string WasCounted { get; set; }
        public double? UserSignature { get; set; }
        public double? Counted { get; set; }
        public string ExpenseClearingAct { get; set; }
        public string PurchaseCreditAcc { get; set; }
        public string EuPurchaseCreditAcc { get; set; }
        public string ForeignPurchaseCreditAcc { get; set; }
        public string SalesCreditAcc { get; set; }
        public string SalesCreditEuAcc { get; set; }
        public string ExemptedCredits { get; set; }
        public string SalesCreditForeignAcc { get; set; }
        public string ExpenseOffsettingAccount { get; set; }
        public string WipAccount { get; set; }
        public string ExchangeRateDifferencesAcct { get; set; }
        public string GoodsClearingAcct { get; set; }
        public string NegativeInventoryAdjustmentAccount { get; set; }
        public string CostInflationOffsetAccount { get; set; }
        public string GlDecreaseAcct { get; set; }
        public string GlIncreaseAcct { get; set; }
        public string PaReturnAcct { get; set; }
        public string PurchaseAcct { get; set; }
        public string PurchaseOffsetAcct { get; set; }
        public string ShippedGoodsAccount { get; set; }
        public string StockInflationOffsetAccount { get; set; }
        public string StockInflationAdjustAccount { get; set; }
        public string VatInRevenueAccount { get; set; }
        public string WipVarianceAccount { get; set; }
        public string CostInflationAccount { get; set; }
        public string WhIncomingCenvatAccount { get; set; }
        public string WhOutgoingCenvatAccount { get; set; }
        public string StockInTransitAccount { get; set; }
        public string WipOffsetProfitAndLossAccount { get; set; }
        public string InventoryOffsetProfitAndLossAccount { get; set; }
        public string DefaultBin { get; set; }
        public string DefaultBinEnforced { get; set; }
        public string PurchaseBalanceAccount { get; set; }
        public string ItemCode { get; set; }
        public string IndEscala { get; set; }
        public string CnjpMan { get; set; }
        public List<string> ItemCycleCounts { get; set; }
    }
}
