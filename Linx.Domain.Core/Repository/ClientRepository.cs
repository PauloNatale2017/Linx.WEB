using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linx.Domain.Core.Repository
{
    public  class ClientRepository : Repository<Linx.Domain.Mapping.Entities.Client>
    {
        public ClientRepository() : base(new DataAccessLayer.dbContext.dbContext())
        {

        }
    }
}
