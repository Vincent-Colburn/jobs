using System;
using System.Data;
using Dapper;
using jobs.Models;

namespace jobs.Repositories
{
    public class PersonnelRepository
    {
        private readonly IDbConnection _db;

        public PersonnelRepository(IDbConnection db)
        {
            _db = db;
        }

        public int Create(Personnel newP)
        {
            string sql = @"
        INSERT INTO personnel
        (jobId, contractorId)
        VALUES
        (@JobId, @ContractorId);
        SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newP);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM personnel WHERE id = @id;";
            _db.Execute(sql, new { id });
        }
    }
}