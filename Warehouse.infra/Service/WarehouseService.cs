using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.core.IRepository;
using Warehouse.core.IService;

namespace Warehouse.infra.Service
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseService(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        async Task IWarehouseService.CreateWarehouse(Entities.Warehouse warehouse)
        {
            await _warehouseRepository.CreateWarehouse(warehouse);
        }

        async Task IWarehouseService.DeleteWarehouse(int warehouseid)
        {
            await _warehouseRepository.DeleteWarehouse(warehouseid);
        }

        async Task<List<Entities.Warehouse>> IWarehouseService.GetAllWarehouses()
        {
            return await _warehouseRepository.GetAllWarehouses();
        }

        async Task<Entities.Warehouse> IWarehouseService.GetWarehouseById(int warehouseid)
        {
            return await _warehouseRepository.GetWarehouseById(warehouseid);
        }

        async Task IWarehouseService.UpdateWarehouse(Entities.Warehouse warehouse)
        {
            await _warehouseRepository.UpdateWarehouse(warehouse);
        }
    }
}
