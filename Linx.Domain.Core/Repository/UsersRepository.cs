using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linx.Domain.Core.Repository
{
    public  class UsersRepository : Repository<Linx.Domain.Mapping.Entities.Users>
    {
        public UsersRepository() : base(new DataAccessLayer.dbContext.dbContext())
        {

        }
    }
}
