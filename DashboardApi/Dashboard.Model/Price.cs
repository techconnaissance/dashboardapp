using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Dashboard.Model
{
    [Table("Price", Schema = "Ref")]
    public class Price
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int CommodityId { get; set; }
        public int ModelId { get; set; }
        [Column(name:"Price")]
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string DateStr {
            get {
                return Date.ToString("dd-MM-yyyy", CultureInfo.CreateSpecificCulture("en-US"));
            }

        }
    }
}
