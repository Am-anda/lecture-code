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

        public Scheduler()
        {
            _appointments = new List<Appointment>();
            // Här vill vi ladda in våra bokade datum sen innan
        }

        public void Dispose()
        {
            // Här vill vi spara ner våra bokade datum
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
