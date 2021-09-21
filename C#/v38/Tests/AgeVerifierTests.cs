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
            AgeVerifier verfier = new AgeVerifier(18);
            Person person = new Person() 
                {
                    Name = "Sandra", 
                    BirthDate = DateTime.Today
                };

            bool oldEnough = verfier.Try(person, DateTime.Now);

            Assert.False(oldEnough);
        }

        [Fact]
        public void Test_AdultAllowed()
        {
            AgeVerifier verfier = new AgeVerifier(18);
            Person person = new Person()
            {
                Name = "Sandra",
                BirthDate = DateTime.Today - TimeSpan.FromDays(365 * 19)
            };

            bool oldEnough = verfier.Try(person, DateTime.Now);

            Assert.True(oldEnough);
        }

        [Fact]
        public void Test_ComingOfAge()
        {
            AgeVerifier verfier = new AgeVerifier(18);
            Person person = new Person()
            {
                Name = "Sandra",
                BirthDate = DateTime.Today - TimeSpan.FromDays(365 * 17)
            };

            DateTime now = DateTime.Now;

            bool oldEnough = verfier.Try(person, now);
            Assert.False(oldEnough);

            // det går ett år
            now += TimeSpan.FromDays(365 * 1);

            oldEnough = verfier.Try(person, now);
            Assert.True(oldEnough);
        }
    }
}
