using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Warehouses.core.IService
{
    public interface ISupplyDocumentService
    {
        Task CreateSupplyDocument(Supplydocument doc);
        Task UpdateSupplyDocument(Supplydocument doc);
        Task DeleteSupplyDocument(int supplydocumentid);
        Task<Supplydocument> GetSupplyDocumentById(int supplydocumentid);
        Task<List<Supplydocument>> GetAllSupplyDocuments();
    }
}
