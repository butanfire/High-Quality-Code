namespace CompareDataStructures.PhoneBook
{
    public class Person
    {
        public Person(string name, string phone)
        {
            this.Name = name;
            this.Phone = phone;
        }

        public string Name { get; set; }

        public string Phone { get; set; }

        public override string ToString()
        {
            return this.Name + " " + this.Phone.ToString();
        }
    }
}
