using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Tests
{
    class InMemoryStore : IStore
    {
        public List<Appointment> Load()
        {
            throw new NotImplementedException();
        }

        public void Save(List<Appointment> appointments)
        {
            throw new NotImplementedException();
        }
    }
}
