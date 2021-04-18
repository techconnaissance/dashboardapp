using System;
using System.Collections.Generic;
using Dashboard.Model;

namespace Business
{
    public interface IDashboardService
    {
        List<Price> GetPrice();

        List<Price> GetPrice(int commodityId, int modelId, DateTime? fromDate, DateTime? toDate);
        List<DailyPosition> GetPosition(int commodityId, int modelId, DateTime? fromDate, DateTime? toDate);
        List<int> GetYears();
        List<Commodity> GetCommodities();
        List<Model> GetModels();
        Metrics OtherMetrics(int commodityId, int modelId, DateTime? fromDate, DateTime? toDate);
        List<PriceView> GetPrices(int? commodityId, int? modelId, DateTime? fromDate, DateTime? toDate);
        MasterData GetMasterData();
        List<TranscationView> GetTransactionView(int? commodityId, int? modelId, DateTime? fromDate, DateTime? toDate);
    }
}
