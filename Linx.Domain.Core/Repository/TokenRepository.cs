using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linx.Domain.Core.Repository
{
    public  class TokenRepository : Repository<Linx.Domain.Mapping.Entities.Token>
    {
        public TokenRepository() : base(new DataAccessLayer.dbContext.dbContext())
        {

        }
    }
}
