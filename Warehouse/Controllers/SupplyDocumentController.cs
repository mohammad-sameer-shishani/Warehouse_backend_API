using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Warehouses.core.IService;

namespace Warehouses.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplyDocumentController : ControllerBase
    {
        private readonly ISupplyDocumentService _supplyDocumentService;

        public SupplyDocumentController(ISupplyDocumentService supplyDocumentService)
        {
            _supplyDocumentService = supplyDocumentService;
        }

        [HttpPost]
        public async Task CreateSupplyDocument([FromBody] Supplydocument doc)
        {
            await _supplyDocumentService.CreateSupplyDocument(doc);
        }

        [HttpPut]
        public async Task UpdateSupplyDocument([FromBody] Supplydocument doc)
        {
            await _supplyDocumentService.UpdateSupplyDocument(doc);
        }

        [HttpDelete]
        [Route("delete/{supplydocumentid}")]
        public async Task DeleteSupplyDocument(int supplydocumentid)
        {
            await _supplyDocumentService.DeleteSupplyDocument(supplydocumentid);
        }

        [HttpGet("{supplydocumentid}")]
        public async Task<Supplydocument> GetSupplyDocumentById(int supplydocumentid)
        {
            return await _supplyDocumentService.GetSupplyDocumentById(supplydocumentid);
        }

        [HttpGet]
        public async Task<List<Supplydocument>> GetAllSupplyDocuments()
        {
            return await _supplyDocumentService.GetAllSupplyDocuments();
        }

        [HttpGet]
        [Route("CountSupplyDocuments")]
        public async Task<int> CountSupplyDocuments()
        {
            return _supplyDocumentService.GetAllSupplyDocuments().Result.Count();
        }

    }
}
