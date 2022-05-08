namespace Lab2_Kazimierowski.rest.Model
{
    public class PersonS
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public PersonS(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}