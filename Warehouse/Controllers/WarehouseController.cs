using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Warehouse.core.IService;

namespace Warehouses.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpPost]
        public async Task CreateWarehouse([FromBody] Entities.Warehouse warehouse)
        {
            await _warehouseService.CreateWarehouse(warehouse);
        }

        [HttpPut]
        public async Task UpdateWarehouse([FromBody] Entities.Warehouse warehouse)
        {
            await _warehouseService.UpdateWarehouse(warehouse);
        }

        [HttpDelete]
        [Route("delete/{warehouseid}")]
        public async Task DeleteWarehouse(int warehouseid)
        {
            await _warehouseService.DeleteWarehouse(warehouseid);
        }

        [HttpGet("{warehouseid}")]
        public async Task<Entities.Warehouse> GetWarehouseById(int warehouseid)
        {
            return await _warehouseService.GetWarehouseById(warehouseid);
        }

        [HttpGet]
        public async Task<List<Entities.Warehouse>> GetAllWarehouses()
        {
            return await _warehouseService.GetAllWarehouses();
        }

        [HttpGet]
        [Route("CountWarehouses")]
        public async Task<int> CountWarehouses()
        {
            return _warehouseService.GetAllWarehouses().Result.Count();
        }

    }    
}
