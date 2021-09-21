using System;

namespace Logic
{
    public class AgeVerifier
    {
        private readonly int _ageLimit;

        public AgeVerifier(int ageLimit)
        {
            _ageLimit = ageLimit;
        }

        public bool Try(Person person, DateTime now)
        {
            var age = now - person.BirthDate;

            var yearsOld = age.Days / 365;
            var ofAge = yearsOld >= _ageLimit;

            return ofAge;
        }
    }
}
