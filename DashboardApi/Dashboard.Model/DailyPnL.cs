using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard.Model
{
    [Table("DailyPnL", Schema = "Analytics")]
    public class DailyPnL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long PriceId { get; set; }
        public float Amount { get; set; }
        public int ModelId { get; set; }
        public int CommodityId { get; set; }
    }
}
