using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using Xunit;

namespace Tests
{
    public class SchedulerTests
    {
        [Fact]
        void Test_CanAddAppointment()
        {
            var scheduler = new Scheduler();

            scheduler.AddAppointment("buy milk", DateTime.Today + TimeSpan.FromDays(1));

            var active = scheduler.GetActiveAppointments();

            Assert.Equal("get milk", active[0].What);
        }
    }
}
