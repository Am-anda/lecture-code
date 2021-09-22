using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Scheduler : IDisposable
    {
        private List<Appointment> _appointments;
        private readonly IStore _store;

        public Scheduler(IStore store)
        {
            _appointments = store.Load();
            _store = store;
        }

        public void Dispose()
        {
            _store.Save(_appointments);
        }

        public void AddAppointment(string what, DateTime when)
        {
            _appointments.Add(new Appointment()
            {
                What = what,
                When = when
            });
        }

        public List<Appointment> GetActiveAppointments()
        {
            var active = new List<Appointment>();

            foreach (var appointment in _appointments)
            {
                if (appointment.When > DateTime.Now)
                {
                    active.Add(appointment);
                }
            }

            return active;
        }
        public List<Appointment> GetFinishedAppointments()
        {
            var finished = new List<Appointment>();

            foreach (var appointment in _appointments)
            {
                if (appointment.When <= DateTime.Now)
                {
                    finished.Add(appointment);
                }
            }

            return finished;
        }
    }
}
