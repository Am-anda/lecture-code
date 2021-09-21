using System;

namespace Logic
{
    public class AgeVerifier
    {
        private readonly int _ageLimit;
        private readonly ITime _time;

        public AgeVerifier(int ageLimit, ITime time)
        {
            _ageLimit = ageLimit;
            _time = time;
        }

        public bool Try(Person person)
        {
            var age = _time.Now - person.BirthDate;

            var yearsOld = age.Days / 365;
            var ofAge = yearsOld >= _ageLimit;

            return ofAge;
        }
    }
}
