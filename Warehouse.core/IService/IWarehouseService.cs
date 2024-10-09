using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.core.IService
{
    public interface IWarehouseService
    {
        Task CreateWarehouse(Entities.Warehouse warehouse);
        Task UpdateWarehouse(Entities.Warehouse warehouse);
        Task DeleteWarehouse(int warehouseid);
        Task<Entities.Warehouse> GetWarehouseById(int warehouseid);
        Task<List<Entities.Warehouse>> GetAllWarehouses();
    }
}
