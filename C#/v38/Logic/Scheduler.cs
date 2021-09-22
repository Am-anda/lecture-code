using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Scheduler
    {
        private List<Appointment> _appointments;

        public Scheduler()
        {
            _appointments = new List<Appointment>();
        }

        public void AddAppointment(string what, DateTime when)
        {
            _appointments.Add(new Appointment()
            {
                What = what
            });
        }

        public List<Appointment> GetActiveAppointments()
        {
            return _appointments;
        }
    }
}
