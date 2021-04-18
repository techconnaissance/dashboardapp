using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard.Model
{
    public class Auditable
    {
        public DateTime? CreatedOn { get; set; }

        [NotMapped]
        public string CreatedOn_String
        {
            get
            {
                return CreatedOn?.ToString("dd/MM/yyyy");
            }
        }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        [NotMapped]
        public string UpdatedOn_String
        {
            get
            {
                return UpdatedOn?.ToString("dd/MM/yyyy");
            }
        }

        public string UpdatedBy { get; set; }
    }
}
