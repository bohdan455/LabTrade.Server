using DataAccess.Entities.User;
using DataAccess.Repositories.Interfaces;
using DataAccess.Repositories.Realizations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Realizations.User
{
    public class SellerRepository : RepositoryBase<Seller>,ISellerRepository
    {
        public SellerRepository(LabTradeDbContext context)
            : base(context)
        {
            
        }
    }
}
