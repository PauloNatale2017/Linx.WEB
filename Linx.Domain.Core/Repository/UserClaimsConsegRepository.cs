using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linx.Domain.Core.Repository
{
    public  class UserClaimsConsegRepository : Repository<Linx.Domain.Mapping.Entities.UserClaimsConseg>
    {
        public UserClaimsConsegRepository() : base(new DataAccessLayer.dbContext.dbContext())
        {

        }
    }
}
