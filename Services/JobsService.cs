using System;
using System.Collections.Generic;
using jobs.Models;
using jobs.Repositories;

namespace jobs.Services
{
    public class JobsService
    {
        private readonly JobsRepository _jrepo;

        public JobsService(JobsRepository jrepo)
        {
            _jrepo = jrepo;
        }

        internal IEnumerable<Job> Get()
        {
            return _jrepo.Get();
        }
        internal Job Get(int id)
        {
            Job exists = _jrepo.Get(id);
            if (exists == null)
            {
                throw new Exception("Invalid Id");
            }
            return exists;
        }

        internal Job Create(Job newJobs)
        {
            int id = _jrepo.Create(newJobs);
            newJobs.Id = id;
            return newJobs;
        }

        internal string Delete(int id)
        {
            Get(id);
            _jrepo.Delete(id);
            return "Successfully Delorted";
        }
    }
}