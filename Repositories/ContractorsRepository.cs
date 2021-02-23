using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using jobs.Models;

namespace jobs.Repositories
{
    public class ContractorsRepository
    {
        private readonly IDbConnection _db;

        public ContractorsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Contractor> Get()
        {
            string sql = "SELECT * FROM contractors;";
            return _db.Query<Contractor>(sql);
        }

        internal Contractor Get(int id)
        {
            string sql = "SELECT * FROM contractors WHERE id = @id;";
            return _db.QueryFirstOrDefault<Contractor>(sql, new { id });
        }

        internal int Create(Contractor newContractor)
        {
            string sql = @"
      INSERT INTO contractors
      (name, role)
      VALUES
      (@Name, @Role);
      SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newContractor);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM contractors WHERE id = @id;";
            _db.Execute(sql, new { id });
        }


        internal IEnumerable<Contractor> GetContractorsByPersonnelId(int persId)
        {
            string sql = @"
      SELECT b.*,
      p.id as perId 
      FROM personnel p
      JOIN contractors c ON c.id = p.contractorId
      WHERE persId = @persId";

            return _db.Query<PersonnelViewModel>(sql, new { persId });
        }
    }
}