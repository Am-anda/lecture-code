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
            var mockTime = new MockTime();
            var verfier = new AgeVerifier(18, mockTime);
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
            var mockTime = new MockTime();
            var verfier = new AgeVerifier(18, mockTime);
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
            var mockTime = new MockTime();
            var verfier = new AgeVerifier(18, mockTime);
            var person = new Person()
            {
                Name = "Sandra",
                BirthDate = DateTime.Today - TimeSpan.FromDays(365 * 17)
            };

            var oldEnough = verfier.Try(person);
            Assert.False(oldEnough);

            // det går ett år
            mockTime.SetNowTo(DateTime.Now + TimeSpan.FromDays(365 * 1));

            oldEnough = verfier.Try(person);
            Assert.True(oldEnough);
        }
    }
}
