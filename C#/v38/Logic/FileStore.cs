
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class FileStore : IStore
    {
        public FileStore(string path)
        {

        }
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
