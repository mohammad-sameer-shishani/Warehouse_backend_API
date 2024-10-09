using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Warehouse.core.IRepository
{
    public interface IWarehouseRepository
    {
        Task CreateWarehouse(Entities.Warehouse warehouse);
        Task UpdateWarehouse(Entities.Warehouse warehouse);
        Task DeleteWarehouse(int warehouseid);
        Task<Entities.Warehouse> GetWarehouseById(int warehouseid);
        Task<List<Entities.Warehouse >> GetAllWarehouses();
    }
}
