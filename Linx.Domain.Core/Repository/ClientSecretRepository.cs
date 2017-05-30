using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linx.Domain.Core.Repository
{
    public  class ClientSecretRepository : Repository<Linx.Domain.Mapping.Entities.ClientSecret>
    {
        public ClientSecretRepository() : base(new DataAccessLayer.dbContext.dbContext())
        {

        }
    }
}
