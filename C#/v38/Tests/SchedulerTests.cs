using System;
using System.Collections.Generic;
using System.IO;
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
            var store = new InMemoryStore();
            var scheduler = new Scheduler(store);

            scheduler.AddAppointment("buy milk", 
                DateTime.Today + TimeSpan.FromDays(1));

            var active = scheduler.GetActiveAppointments();

            Assert.Equal("buy milk", active[0].What);
        }

        [Fact]
        void Test_BothActiveAndFinishedAppointmentsExists()
        {
            var store = new InMemoryStore();
            var scheduler = new Scheduler(store);

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
            var store = new InMemoryStore();

            using (var scheduler = new Scheduler(store))
            {
                scheduler.AddAppointment("buy milk",
                    DateTime.Today + TimeSpan.FromDays(1));
            }
            
            using (var scheduler = new Scheduler(store))
            {
                var active = scheduler.GetActiveAppointments();

                Assert.Equal(1, active.Count);
                Assert.Equal("buy milk", active[0].What);
            }
        }

        [Fact]
        void Test_FileStore()
        {
            // bestäm vägen till filen
            var path = Environment.GetFolderPath(
                Environment.SpecialFolder.UserProfile);
            path = Path.Combine(path, "appointments.txt");

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            // förbered vad som ska testas
            var store = new FileStore(path);
            var when = DateTime.Today + TimeSpan.FromDays(1);

            // testa att spara ner
            var appointmentsToSave = new List<Appointment>();
            appointmentsToSave.Add(new Appointment()
            {
                What = "buy milk",
                When = when
            });
            store.Save(appointmentsToSave);

            // dubbelkolla filen
            Assert.True(File.Exists(path));
            using (var sr = new StreamReader(path))
            {
                var firstRow = sr.ReadLine();
                Assert.Equal("buy milk," + when, firstRow);
            }
            
            // testa att ladda in
            var loadedAppointments = store.Load();

            // dubbelkolla vad vi fick tillbaka
            Assert.Equal("buy milk", loadedAppointments[0].What);
            Assert.Equal(when, loadedAppointments[0].When);
        }
    }
}
