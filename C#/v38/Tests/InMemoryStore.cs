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
        private List<Appointment> _appointments;

        public List<Appointment> Load()
        {
            if (_appointments == null)
                _appointments = new List<Appointment>();
            return _appointments;
        }

        public void Save(List<Appointment> appointments)
        {
            _appointments = appointments;
        }
    }
}
