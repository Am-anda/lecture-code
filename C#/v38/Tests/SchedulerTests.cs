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

            scheduler.AddAppointment("buy milk", 
                DateTime.Today + TimeSpan.FromDays(1));

            var active = scheduler.GetActiveAppointments();

            Assert.Equal("buy milk", active[0].What);
        }

        [Fact]
        void Test_BothActiveAndFinishedAppointmentsExists()
        {
            var scheduler = new Scheduler();

            scheduler.AddAppointment("buy eggs", 
                DateTime.Today - TimeSpan.FromDays(1));
            scheduler.AddAppointment("buy milk",
                DateTime.Today + TimeSpan.FromDays(1));

            var active = scheduler.GetActiveAppointments();
            var finished = scheduler.GetFinishedAppointments();

            Assert.Equal(1, active.Count);
            Assert.Equal(1, finished.Count);

            Assert.Equal("buy milk", active[0].What);
            Assert.Equal("buy eggs", finished[0].What);
        }

        [Fact]
        void Test_AppointmentsAreSaved()
        {
            var scheduler = new Scheduler();

            scheduler.AddAppointment("buy milk",
                DateTime.Today + TimeSpan.FromDays(1));

            // starta om scheduler
            scheduler = new Scheduler();

            var active = scheduler.GetActiveAppointments();

            Assert.Equal(1, active.Count);
            Assert.Equal("buy milk", active[0].What);
        }
    }
}
