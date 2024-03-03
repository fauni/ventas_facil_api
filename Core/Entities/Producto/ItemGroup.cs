namespace Core.Entities.Producto
{
    public class ResponseItemGroup
    {
        public List<ItemGroup> value { get; set; }
    }

    public class ItemGroup
    {
        public string PriceDifferencesAccount { get; set; }
        public string StockInflationAdjustAccount { get; set; }
        public long? MinimumOrderQuantity { get; set; }
        public string OrderInterval { get; set; }
        public string ExchangeRateDifferencesAccount { get; set; }
        public string IncreasingAccount { get; set; }
        public string StockInflationOffsetAccount { get; set; }
        public string ProcurementMethod { get; set; }
        public string ComponentWarehouse { get; set; }
        public string PurchaseOffsetAccount { get; set; }
        public string InventorySystem { get; set; }
        public string WipMaterialVarianceAccount { get; set; }
        public string PlanningSystem { get; set; }
        public string PurchaseAccount { get; set; }
        public string ReturningAccount { get; set; }
        public string CostInflationAccount { get; set; }
        public string ExpensesAccount { get; set; }
        public string RevenuesAccount { get; set; }
        public string TransfersAccount { get; set; }
        public string LeadTime { get; set; }
        public long? OrderMultiple { get; set; }
        public string CostInflationOffsetAccount { get; set; }
        public string InventoryAccount { get; set; }
        public string DecreaseGlAccount { get; set; }
        public int? Number { get; set; }
        public string GoodsClearingAccount { get; set; }
        public string IncreaseGlAccount { get; set; }
        public string ForeignRevenuesAccount { get; set; }
        public string Alert { get; set; }
        public string WipMaterialAccount { get; set; }
        public string ShippedGoodsAccount { get; set; }
        public string ExemptRevenuesAccount { get; set; }
        public string DecreasingAccount { get; set; }
        public string VatInRevenueAccount { get; set; }
        public string VarianceAccount { get; set; }
        public string EuExpensesAccount { get; set; }
        public string ForeignExpensesAccount { get; set; }
        public string CycleCode { get; set; }
        public string CostAccount { get; set; }
        public string EuRevenuesAccount { get; set; }
        public string PaReturnAccount { get; set; }
        public string GroupName { get; set; }
        public string ExpenseClearingAct { get; set; }
        public string PurchaseCreditAcc { get; set; }
        public string EuPurchaseCreditAcc { get; set; }
        public string ForeignPurchaseCreditAcc { get; set; }
        public string SalesCreditAcc { get; set; }
        public string SalesCreditEuAcc { get; set; }
        public string ExemptedCredits { get; set; }
        public string SalesCreditForeignAcc { get; set; }
        public string ExpenseOffsetAccount { get; set; }
        public string NegativeInventoryAdjustmentAccount { get; set; }
        public string WhIncomingCenvatAccount { get; set; }
        public string WhOutgoingCenvatAccount { get; set; }
        public string StockInTransitAccount { get; set; }
        public string WipOffsetProfitAndLossAccount { get; set; }
        public string InventoryOffsetProfitAndLossAccount { get; set; }
        public string ToleranceDays { get; set; }
        public string DefaultUoMGroup { get; set; }
        public string DefaultInventoryUoM { get; set; }
        public string PurchaseBalanceAccount { get; set; }
        public string ItemClass { get; set; }
        public string RawMaterial { get; set; }
        public List<string> ItemGroupsWarehouseInfos { get; set; }
    }
}
