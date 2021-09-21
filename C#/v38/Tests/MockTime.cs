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
        private DateTime _fakeNow;

        public MockTime()
        {
            _fakeNow = DateTime.Now;
        }

        public DateTime Now()
        {
            return _fakeNow;
        }

        public void SetNowTo(DateTime newNow)
        {
            _fakeNow = newNow;
        }
    }
}
