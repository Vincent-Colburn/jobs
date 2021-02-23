using System;
using jobs.Models;
using jobs.Repositories;

namespace jobs.Services
{
    public class PersonnelService
    {
        private readonly PersonnelRepository _prepo;

        public PersonnelService(PersonnelRepository prepo)
        {
            _prepo = prepo;
        }

        public Personnel Create(Personnel newPers)
        {
            int id = _prepo.Create(newPers);
            newPers.Id = id;
            return newPers;
        }

        internal string Delete(int id)
        {
            _prepo.Delete(id);
            return "Successfully Deleted";
        }
    }
}