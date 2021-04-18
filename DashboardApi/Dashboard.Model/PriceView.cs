using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Dashboard.Model
{
    [Table("vw_Price", Schema = "Analytics")]
    public class PriceView
    {
        [Key]
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public string CommodityName { get; set; }
        public string ModelName { get; set; }
        public int CommodityId { get; set; }
        public int ModelId { get; set; }

        public string DateStr
        {
            get
            {
                return Date.ToString("dd-MM-yyyy", CultureInfo.CreateSpecificCulture("en-US"));
            }
        }
    }
}
