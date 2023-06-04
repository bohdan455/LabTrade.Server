using DataAccess.Repositories.Realizations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Realizations.User
{
    public class SellerRepository : RepositoryBase<SellerRepository>
    {
        public SellerRepository(LabTradeDbContext context)
            : base(context)
        {
            
        }
    }
}
