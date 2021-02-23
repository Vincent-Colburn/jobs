using System;
using System.Collections.Generic;
using jobs.Models;
using jobs.Repositories;

namespace jobs.Services
{
    public class ContractorsService
    {
        private readonly ContractorsRepository _crepo;
        private readonly JobsRepository _jrepo;

        public ContractorsService(ContractorsRepository crepo, JobsRepository jrepo)
        {
            _crepo = crepo;
            _jrepo = jrepo;
        }


        internal IEnumerable<Contractor> Get()
        {
            return _crepo.Get();
        }
        internal Contractor Get(int id)
        {
            Contractor exists = _crepo.Get(id);
            if (exists == null)
            {
                throw new Exception("Invalid Id");
            }
            return exists;
        }

        internal Contractor Create(Contractor newContractor)
        {
            int id = _crepo.Create(newContractor);
            newContractor.Id = id;
            return newContractor;
        }


        internal string Delete(int id)
        {
            Get(id);
            _crepo.Delete(id);
            return "Successfully Deleted";
        }



        internal IEnumerable<Contractor> GetContractorsByPersonnelId(int persId)
        {
            Job valid = _jrepo.Get(persId);
            if (valid == null)
            {
                throw new Exception("Invalid Id");
            }
            return _crepo.GetContractorsByPersonnelId(persId);
        }
    }
}