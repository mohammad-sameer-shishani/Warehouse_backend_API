using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Warehouses.core.IRepository;
using Warehouses.core.IService;

namespace Warehouses.infra.Service
{
    public class SupplyDocumentService : ISupplyDocumentService
    {
        private readonly ISupplyDocumentRepository _supplyDocumentRepository;

        public SupplyDocumentService(ISupplyDocumentRepository supplyDocumentRepository)
        {
            _supplyDocumentRepository = supplyDocumentRepository;
        }

        async Task ISupplyDocumentService.CreateSupplyDocument(Supplydocument doc)
        {
            await _supplyDocumentRepository.CreateSupplyDocument(doc);
        }

        async Task ISupplyDocumentService.DeleteSupplyDocument(int supplydocumentid)
        {
            await _supplyDocumentRepository.DeleteSupplyDocument(supplydocumentid);
        }

        async Task<List<Supplydocument>> ISupplyDocumentService.GetAllSupplyDocuments()
        {
            return await _supplyDocumentRepository.GetAllSupplyDocuments();
        }

        async Task<Supplydocument> ISupplyDocumentService.GetSupplyDocumentById(int supplydocumentid)
        {
            return await _supplyDocumentRepository.GetSupplyDocumentById(supplydocumentid);
        }

        async Task ISupplyDocumentService.UpdateSupplyDocument(Supplydocument doc)
        {
            await _supplyDocumentRepository.UpdateSupplyDocument(doc);
        }

    }
}
