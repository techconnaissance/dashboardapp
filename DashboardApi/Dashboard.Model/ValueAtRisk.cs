using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard.Model
{
    [Table("VaR", Schema = "Ref")]
    public class ValueAtRisk
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int CommodityId { get; set; }
        public double Value { get; set; }
    }
}
