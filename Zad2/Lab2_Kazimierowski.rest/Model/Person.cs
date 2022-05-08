namespace Lab2_Kazimierowski.rest.Model
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(int personId, string firstName, string lastName)
        {
            PersonId = personId;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}