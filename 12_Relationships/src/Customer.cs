namespace _12_Relationships.src
{
    public class Customer
    {
        public string FirstName { get; }
        public string LastName { get; }

        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
