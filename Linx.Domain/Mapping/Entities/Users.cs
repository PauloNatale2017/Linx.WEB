using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linx.Domain.Mapping.Entities
{
    public class Users : BaseEntity.baseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
