using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard.Model
{
    [Table("Transaction", Schema = "Analytics")]
    public class Transaction : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public int Quanity { get; set; }
        public int CurrentQuantity { get; set; }
        public float Price { get; set; }
        public int ContractId { get; set; }
        public int ModelId { get; set; }
        public int CommodityId { get; set; }
    }
}
