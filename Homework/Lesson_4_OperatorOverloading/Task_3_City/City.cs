using System;
using System.Collections.Generic;

namespace Task_3_City
{
    public class City
    {
        #region internal data
        private string _name;
        private string _country;
        private long _peopleQuantity;
        #endregion

        #region properties
        public string Name { get => _name; set => _name = value; }
        public string Country { get => _country; set => _country = value; }
        public long PeopleQuantity
        {
            get => _peopleQuantity;
            set
            {
                CheckQuantity(value);
                _peopleQuantity = value;
            }
        }
        #endregion

        #region constructors
        public City() : this("UndefCity")
        {
        }

        public City(string name) : this(name, "UndefCountry")
        {
        }

        public City(string name, string country) : this(name, country, 0)
        {
        }

        public City(string name, string country, long peopleQuantity)
        {
            Name = name;
            Country = country;
            PeopleQuantity = peopleQuantity;
        }

        public City(City city)
        {
            this.Country = city.Country;
            this.Name = city.Name;
            this.PeopleQuantity = city.PeopleQuantity;
        }
        #endregion

        #region puplic methods
        public static City operator +(City city1, long increaseQuantity)
        {
            City retCity = new City(city1);

            retCity.PeopleQuantity += increaseQuantity;

            return retCity;
        }

        public static City operator -(City city1, long increaseQuantity)
        {
            City retCity = new City(city1);

            retCity.PeopleQuantity -= increaseQuantity;

            return retCity;
        }

        public static bool operator ==(City city1, City city2)
        {
            return city1.PeopleQuantity == city2.PeopleQuantity;
        }

        public static bool operator !=(City city1, City city2)
        {
            return city1.PeopleQuantity != city2.PeopleQuantity;
        }

        public static bool operator >(City city1, City city2)
        {
            return city1.PeopleQuantity > city2.PeopleQuantity;
        }

        public static bool operator <(City city1, City city2)
        {
            return city1.PeopleQuantity < city2.PeopleQuantity;
        }

        public override bool Equals(object obj)
        {
            if (obj is City city)
                return Name.Equals(city.Name)
                    && Country.Equals(city.Country)
                    && PeopleQuantity == city.PeopleQuantity;
            else
                return false;
        }

        public override string ToString()
        {
            return $"Country: {Country}; city: {Name}; quantity of people: {PeopleQuantity}";
        }

        public override int GetHashCode()
        {
            int hashCode = -1493686905;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_country);
            hashCode = hashCode * -1521134295 + _peopleQuantity.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Country);
            hashCode = hashCode * -1521134295 + PeopleQuantity.GetHashCode();
            return hashCode;
        }
        #endregion

        #region internal methods
        private void CheckQuantity(long quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentException("Quantity of people can't be less than zero");
            }
        }
        #endregion
    }
}
