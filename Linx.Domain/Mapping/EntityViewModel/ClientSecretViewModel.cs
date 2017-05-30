using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linx.Domain.Mapping.EntityViewModel
{
   public class ClientSecretViewModel
    {
        [Key]
        public  int Id { get; set; }

        [Required]
        [StringLength(250)]
        public  string Value { get; set; }

        [StringLength(250)]
        public string Type { get; set; }

        [StringLength(2000)]
        public  string Description { get; set; }

        public  DateTimeOffset? Expiration { get; set; }

        //public virtual Client Client { get; set; }
    }
}
