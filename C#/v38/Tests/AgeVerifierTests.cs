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

            var oldEnough = verfier.Try(person, DateTime.Now);

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

            var oldEnough = verfier.Try(person, DateTime.Now);

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

            var now = DateTime.Now;

            var oldEnough = verfier.Try(person, now);
            Assert.False(oldEnough);

            // det går ett år
            now += TimeSpan.FromDays(365 * 1);

            oldEnough = verfier.Try(person, now);
            Assert.True(oldEnough);
        }
    }
}
