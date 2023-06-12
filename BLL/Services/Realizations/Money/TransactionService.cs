using BLL.Services.Interfaces;
using DataAccess.Repositories.Realizations.Money;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Realizations.Money
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public int GetNumberOfPurchasedLabWorks(int purchasedLabId)
        {
            var number = _transactionRepository.Include(t => t.PurchasedLabWork).Where(t => t.PurchasedLabWork.Id == purchasedLabId).Count();
            return number;
        }
    }
}
