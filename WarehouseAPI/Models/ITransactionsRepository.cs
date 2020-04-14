using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseAPI.Models
{
    public interface ITransactionsRepository : IDisposable
    {
        TransactionDto CreateTransaction(TransactionDto request);
    }
}
