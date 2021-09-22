
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class FileStore : IStore
    {
        private readonly string _path;
        public FileStore(string path)
        {
            _path = path;
        }
        public List<Appointment> Load()
        {
            // om en fil inte finns
            if (!File.Exists(_path))
            {
                // tom lista tillbaks
                return new List<Appointment>();
            }
            else
            {
                // läs in filen
                using (var sr = new StreamReader(_path))
                {
                    var result = new List<Appointment>();

                    // läs en rad i taget
                    var line = sr.ReadLine();
                    while (line != null)
                    {
                        // dela upp raden i två bitar separerade med ett tecken
                        var parts = line.Split(',');

                        // tolka om texten till ett bokningsobjekt
                        var appointment = new Appointment();
                        appointment.What = parts[0];
                        appointment.When = DateTime.Parse(parts[1]);

                        // lagra objektet
                        result.Add(appointment);

                        line = sr.ReadLine();
                    }

                    // skicka tillbaka det vi hittade
                    return result;
                }
            }
        }

        public void Save(List<Appointment> appointments)
        {
            // skapa filen
            using (var sw = new StreamWriter(_path))
            {
                // för varje bokningsobjekt
                foreach (var appointment in appointments)
                {
                    // skriv om objektet som en rad text
                    string line = appointment.What + ',' + appointment.When;
                    // skriv ut raden
                    sw.WriteLine(line);
                }
            }
        }
    }
}
