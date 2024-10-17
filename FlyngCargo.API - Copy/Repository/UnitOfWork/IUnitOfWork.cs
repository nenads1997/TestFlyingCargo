using Repository.RepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IProductRepository Products { get; }
        Task<int> CompleteAsync();
    }
}
