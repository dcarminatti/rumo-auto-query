using Oracle.ManagedDataAccess.Client;
using RumoAutoQuery.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumoAutoQuery.services
{
    internal class DatabaseService
    {
        private DatabaseRepository _databaseRepository;

        public DatabaseService()
        {
            this._databaseRepository = new DatabaseRepository();
        }

        public List<String> findAllByProductKey(List<string> productKeys)
        {
            return this._databaseRepository.findAllByProductKey(productKeys);
        }
    }
}

