namespace ProblematicSearcher
{
    public class Person
    {
        private readonly string _name;
        private readonly string _surname;

        public Person(string name, string surname)
        {
            _name = name;
            _surname = surname;
        }

        public override string ToString()
        {
            return $"{nameof(_name)}: {_name}, {nameof(_surname)}: {_surname}";
        }
    }
}