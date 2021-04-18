using System;
using System.Collections.Generic;
using System.Linq;
using Dashboard.Data;
using Dashboard.Model;

namespace Business
{
    public class DashboardService : IDashboardService
    {
        private IDashboardFactory _factory;
        public DashboardService(IDashboardFactory factory)
        {
            this._factory = factory;
        }


        #region MasterData
        public List<int> GetYears()
        {
            return _factory.GetAll<DailyPosition>().Select(p => p.Date.Year).Distinct().OrderBy(p => p).ToList();
        }

        public List<Commodity> GetCommodities()
        {
            return _factory.GetAll<Commodity>().ToList();
        }

        public List<Model> GetModels()
        {
            return _factory.GetAll<Model>().ToList();
        }

        public MasterData GetMasterData()
        {
            MasterData data = new MasterData();
            data.Commodities = _factory.GetAll<Commodity>().ToList();
            data.Models = _factory.GetAll<Model>().ToList();
            data.Years = _factory.GetAll<DailyPosition>().Select(p => p.Date.Year).Distinct().OrderByDescending(p => p).ToList();

            return data;
        }
        #endregion

        public List<Price> GetPrice()
        {
           return _factory.GetAll<Price>().ToList();
        }

        public List<Price> GetPrice(int commodityId, int modelId, DateTime? fromDate, DateTime? toDate)
        {
            
            var query = _factory.GetAll<Price>();

            query = query.Where(p => p.CommodityId == commodityId && p.ModelId == modelId);
            if (fromDate != null)
                query = query.Where(p => p.Date >= fromDate);

            if(toDate != null)
            {
                query = query.Where(p => p.Date <= toDate);
            }

            var result = query.ToList();

            return result;
        }

        public List<DailyPosition> GetPosition(int commodityId, int modelId, DateTime? fromDate, DateTime? toDate)
        {

            var query = _factory.GetAll<DailyPosition>();

            query = query.Where(p => p.CommodityId == commodityId && p.ModelId == modelId);
            if (fromDate != null)
                query = query.Where(p => p.Date >= fromDate);

            if (toDate != null)
            {
                query = query.Where(p => p.Date <= toDate);
            }

            var result = query.ToList();

            return result;
        }

        

        public Metrics OtherMetrics(int commodityId, int modelId, DateTime? fromDate, DateTime? toDate)
        {
            Metrics metrics = new Metrics();

            var query = _factory.GetAll<DailyPosition>();

            var result = query.Where(p => p.CommodityId == commodityId && p.ModelId == modelId).OrderByDescending(p=> p.Date).FirstOrDefault();

            if(result != null)
            {
                metrics.CurrentPosition = result.Position;
            }

            metrics.PnLYTD = Math.Round(query.Where(p => p.Date >= fromDate && p.Date <= toDate).Sum(p => p.PNL), 2);
            metrics.PnLLTD = metrics.PnLYTD;

            var comRes =_factory.Get<ValueAtRisk>(p => p.ModelId == modelId && p.CommodityId == commodityId).FirstOrDefault();
            if (comRes != null)
                metrics.Var = comRes.Value;

            return metrics;
        }


        public List<PriceView> GetPrices(int? commodityId, int? modelId, DateTime? fromDate, DateTime? toDate)
        {
            var query = _factory.GetAll<PriceView>();

            if(commodityId != null)
            {
                query = query.Where(p => p.CommodityId == commodityId);
            }

            if (modelId != null)
            {
                query = query.Where(p => p.ModelId == modelId);
            }

            if (fromDate != null)
                query = query.Where(p => p.Date >= fromDate);

            if (toDate != null)
            {
                query = query.Where(p => p.Date <= toDate);
            }

            return query.ToList();
        }

        public List<TranscationView> GetTransactionView(int? commodityId, int? modelId, DateTime? fromDate, DateTime? toDate)
        {
            var query = _factory.GetAll<TranscationView>();

            if (commodityId != null)
            {
                query = query.Where(p => p.CommodityId == commodityId);
            }

            if (modelId != null)
            {
                query = query.Where(p => p.ModelId == modelId);
            }

            if (fromDate != null)
                query = query.Where(p => p.Date >= fromDate);

            if (toDate != null)
            {
                query = query.Where(p => p.Date <= toDate);
            }

            return query.OrderByDescending(p=> p.Date).ToList();
        }
    }
}
