using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Entities;
using Warehouse.core.ICommon;
using Warehouse.core.IRepository;

namespace Warehouse.infra.Repository
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly IDbContext _dbContext;
        public WarehouseRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateWarehouse(Entities.Warehouse warehouse)
        {
            var param = new DynamicParameters();
            param.Add("c_WarehouseName", warehouse.Warehousename, DbType.String, direction: ParameterDirection.Input);
            param.Add("c_WarehouseDescription", warehouse.Warehousedescription, DbType.String, direction: ParameterDirection.Input);
            param.Add("c_CreatedBy", warehouse.Createdby, DbType.Int32, direction: ParameterDirection.Input);
            param.Add("c_CreatedDate", warehouse.Createddate, DbType.DateTime, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("WAREHOUSES_PACKAGE.create_warehouses", param, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateWarehouse(Entities.Warehouse warehouse)
        {
            var param = new DynamicParameters();
            param.Add("u_WarehouseID", warehouse.Warehouseid, DbType.Int32, direction: ParameterDirection.Input);
            param.Add("u_WarehouseName", warehouse.Warehousename, DbType.String, direction: ParameterDirection.Input);
            param.Add("u_WarehouseDescription", warehouse.Warehousedescription, DbType.String, direction: ParameterDirection.Input);
            param.Add("u_CreatedBy", warehouse.Createdby, DbType.Int32, direction: ParameterDirection.Input);
            param.Add("u_CreatedDate", warehouse.Createddate, DbType.DateTime, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("WAREHOUSES_PACKAGE.update_warehouses", param, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteWarehouse(int warehouseid)
        {
            var param = new DynamicParameters();
            param.Add("d_WarehouseID", warehouseid, DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("WAREHOUSES_PACKAGE.delete_warehouses", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<Entities.Warehouse> GetWarehouseById(int warehouseid)
        {
            var param = new DynamicParameters();
            param.Add("get_WarehouseID", warehouseid, DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Entities.Warehouse>("WAREHOUSES_PACKAGE.get_warehouses_by_id", param, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<List<Entities.Warehouse>> GetAllWarehouses()
        {
            var result = await _dbContext.Connection.QueryAsync<Entities.Warehouse>("WAREHOUSES_PACKAGE.get_all_warehouses", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }



    }
}
