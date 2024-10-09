using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Entities;
using Warehouse.core.ICommon;
using Warehouses.core.IRepository;

namespace Warehouses.infra.Repository
{
    public class SupplyDocumentRepository : ISupplyDocumentRepository
    {
        private readonly IDbContext _dbContext;
        public SupplyDocumentRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateSupplyDocument(Supplydocument doc)
        {
            var param = new DynamicParameters();
            param.Add("c_SupplyDocumentName", doc.Documentname, DbType.String, direction: ParameterDirection.Input);
            param.Add("c_SupplyDocumentSubject", doc.Documentsubject, DbType.String, direction: ParameterDirection.Input);
            param.Add("c_CreatedBy", doc.Createdby, DbType.Int32, direction: ParameterDirection.Input);
            param.Add("c_CreatedDate", doc.Createddate, DbType.DateTime, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("SUPPLYDOCUMENT_PACKAGE.create_SupplyDocuments", param, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateSupplyDocument(Supplydocument doc)
        {
            var param = new DynamicParameters();
            param.Add("u_SupplyDocumentID", doc.Documentid, DbType.Int32, direction: ParameterDirection.Input);
            param.Add("u_SupplyDocumentName", doc.Documentname, DbType.String, direction: ParameterDirection.Input);
            param.Add("u_SupplyDocumentSubject", doc.Documentsubject, DbType.String, direction: ParameterDirection.Input);
            param.Add("u_CreatedBy", doc.Createdby, DbType.Int32, direction: ParameterDirection.Input);
            param.Add("u_CreatedDate", doc.Createddate, DbType.DateTime, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("SUPPLYDOCUMENT_PACKAGE.update_SupplyDocuments", param, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteSupplyDocument(int supplydocumentid)
        {
            var param = new DynamicParameters();
            param.Add("d_SupplyDocumentID", supplydocumentid, DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("SUPPLYDOCUMENT_PACKAGE.delete_SupplyDocuments", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<Supplydocument> GetSupplyDocumentById(int supplydocumentid)
        {
            var param = new DynamicParameters();
            param.Add("get_DocumentID", supplydocumentid, DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Supplydocument>("supplydocuments_package.get_SupplyDocuments_by_id", param, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<List<Supplydocument>> GetAllSupplyDocuments()
        {
            var result = await _dbContext.Connection.QueryAsync<Supplydocument>("supplydocuments_package.get_all_SupplyDocuments", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

    }
}
