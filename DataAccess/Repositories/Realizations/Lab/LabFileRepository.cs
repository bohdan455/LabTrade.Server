using DataAccess.Entities.Lab;
using DataAccess.Repositories.Realizations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Realizations.Lab
{
    public class LabFileRepository : RepositoryBase<LabFile>
    {
        public LabFileRepository(LabTradeDbContext context)
            : base(context)
        {
            
        }
    }
}
