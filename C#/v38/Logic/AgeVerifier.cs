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
            TimeSpan age = now - person.BirthDate;

            int yearsOld = age.Days / 365;
            bool ofAge = yearsOld >= _ageLimit;

            return ofAge;
        }
    }
}
