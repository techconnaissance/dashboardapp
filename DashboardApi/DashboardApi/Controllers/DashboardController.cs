using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DashboardApi.Controllers
{
    public class DashboardController : BaseController
    {
        IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            this._dashboardService = dashboardService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("price")]
        public IActionResult GetAllPrice(int commodityId,int modelId, DateTime? fromDate, DateTime? toDate)
        {
            return new JsonResult(this._dashboardService.GetPrice(commodityId, modelId,fromDate, toDate));
        }

        [HttpGet]
        [Route("position")]
        public IActionResult GetAllPosition(int commodityId, int modelId, DateTime? fromDate, DateTime? toDate)
        {
            return new JsonResult(this._dashboardService.GetPosition(commodityId, modelId, fromDate, toDate));
        }

        [HttpGet]
        [Route("year")]
        public IActionResult GetAllYear()
        {
            return new JsonResult(this._dashboardService.GetYears());
        }

        [HttpGet]
        [Route("commodities")]
        public IActionResult GetAllCommodities()
        {
            return new JsonResult(this._dashboardService.GetCommodities());
        }

        [HttpGet]
        [Route("models")]
        public IActionResult GetAllModels()
        {
            return new JsonResult(this._dashboardService.GetModels());
        }

        [HttpGet]
        [Route("metrics")]
        public IActionResult GetOtherMetrics(int commodityId, int modelId, DateTime? fromDate, DateTime? toDate)
        {
            return new JsonResult(this._dashboardService.OtherMetrics(commodityId, modelId, fromDate, toDate));
        }

        [HttpGet]
        [Route("priceview")]
        public IActionResult GetPriceView(int? commodityId, int? modelId, DateTime? fromDate, DateTime? toDate)
        {
            return new JsonResult(this._dashboardService.GetPrices(commodityId, modelId, fromDate, toDate));
        }

        [HttpGet]
        [Route("masterdata")]
        public IActionResult GetMasterData()
        {
            return new JsonResult(this._dashboardService.GetMasterData());
        }

        [HttpGet]
        [Route("transactions")]
        public IActionResult GetTransactionView(int? commodityId, int? modelId, DateTime? fromDate, DateTime? toDate)
        {
            return new JsonResult(this._dashboardService.GetTransactionView(commodityId, modelId, fromDate, toDate));
        }

    }
}
