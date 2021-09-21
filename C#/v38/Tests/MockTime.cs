using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Tests
{
    class MockTime : ITime
    {
        public DateTime Now()
        {
            throw new NotImplementedException();
        }
    }
}
