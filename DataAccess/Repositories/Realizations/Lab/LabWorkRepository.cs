﻿using DataAccess.Repositories.Realizations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Realizations.Lab
{
    public class LabWorkRepository : RepositoryBase<LabWorkRepository>
    {
        public LabWorkRepository(LabTradeDbContext context)
            : base(context)
        {
            
        }
    }
}
