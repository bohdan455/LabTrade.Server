using DataAccess.Repositories.Realizations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Realizations.Money
{
    public class TransactionRepository : RepositoryBase<TransactionRepository>
    {
        public TransactionRepository(LabTradeDbContext context)
            : base(context)
        {
            
        }
    }
}
