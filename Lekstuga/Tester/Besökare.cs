using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
    class Visitor
    {
        private int _tab;
        private bool _allowedService;

        public void PayOffTab(int amount)
        {
            _tab -= amount;
            _tab = Math.Max(0, _tab);
        }

        public void AddToTab(int amount)
        {
            _tab += amount;
            if (_tab > 1000)
                _allowedService = false;
        }
    }

    class Demo
    {
        public void Foo()
        {
        }
    }
}
