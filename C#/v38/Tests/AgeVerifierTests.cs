using System;
using System.Threading;
using Logic;
using Xunit;

namespace Tests
{
    public class AgeVerifierTests
    {
        [Fact]
        public void Test_MinorNotAllowed()
        {
            var verfier = new AgeVerifier(18);
            var person = new Person() 
                {
                    Name = "Sandra", 
                    BirthDate = DateTime.Today
                };

            var oldEnough = verfier.Try(person);

            Assert.False(oldEnough);
        }

        [Fact]
        public void Test_AdultAllowed()
        {
            var verfier = new AgeVerifier(18);
            var person = new Person()
            {
                Name = "Sandra",
                BirthDate = DateTime.Today - TimeSpan.FromDays(365 * 19)
            };

            var oldEnough = verfier.Try(person);

            Assert.True(oldEnough);
        }

        [Fact]
        public void Test_ComingOfAge()
        {
            var verfier = new AgeVerifier(18);
            var person = new Person()
            {
                Name = "Sandra",
                BirthDate = DateTime.Today - TimeSpan.FromDays(365 * 17)
            };

            var oldEnough = verfier.Try(person);
            Assert.False(oldEnough);

            // det går ett år

            oldEnough = verfier.Try(person);
            Assert.True(oldEnough);
        }
    }
}
