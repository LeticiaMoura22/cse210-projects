using System;

namespace OnlineOrdering
{
    public class Address
    {
        private string _street;
        private string _city;
        private string _state;
        private string _country;

        public Address(string street, string city, string state, string country)
        {
            _street = street;
            _city = city;
            _state = state;
            _country = country;
        }

        public string GetStreet()
        {
            return _street;
        }

        public void SetStreet(string street)
        {
            _street = street;
        }

        public string GetCity()
        {
            return _city;
        }

        public void SetCity(string city)
        {
            _city = city;
        }

        public string GetState()
        {
            return _state;
        }

        public void SetState(string state)
        {
            _state = state;
        }

        public string GetCountry()
        {
            return _country;
        }

        public void SetCountry(string country)
        {
            _country = country;
        }

        public bool IsInUSA()
        {
            return _country.Equals("USA", StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return _street + "\n" + _city + "\n" + _state + "\n" + _country;
        }
    }
}
