using System;
using System.Diagnostics;
using Xunit;

namespace Tester
{
    public class Tester
    {
        [Fact]
        public void AlwaysSucceed()
        {
            Assert.True(true);
            Assert.Equal(2, 2);
        }
        [Fact]
        public void AlwaysFail()
        {
            Assert.True(false);
        }

        [Fact]
        public void TestaVariabler()
        {
            string name;
            bool lever = false;

            if (lever)
            {
                name = "Mr Smith";
            }
            else
            {
                name = "Björn Strömberg Per Gunnar";
            }

            Assert.Equal("Björn Strömberg Per Gunnar", name);
        }

        [Fact]
        public void TestaEmptyString()
        {
            Assert.Equal(string.Empty, "");
        }


        [Fact]
        public void Foo()
        {
            char letter = 'A';

            int number = (int) letter;
        }
    }
}
