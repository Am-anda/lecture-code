using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    interface IStore
    {
        public List<Appointment> Load();
        public void Save(List<Appointment> appointments);
    }
}
