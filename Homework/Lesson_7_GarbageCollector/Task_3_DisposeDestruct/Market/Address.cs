namespace Task_3_DisposeDestruct
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

        public override string ToString() => $"[City: {City}; street: {Street}]";
    }
}
