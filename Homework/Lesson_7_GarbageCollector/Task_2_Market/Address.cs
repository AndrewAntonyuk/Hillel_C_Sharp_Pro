namespace Task_2_Market
{
    internal class Address
    {
        #region data
        public string City { get; set; }
        public string Street { get; set; }
        #endregion

        #region constructors
        public Address(string city, string street)
        {
            City = city;
            Street = street;
        }
        #endregion

        public override string ToString()
        {
            return $"[City: {City}; street: {Street}]";
        }
    }
}
