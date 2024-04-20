namespace ProblematicSearcher
{
    public class PeopleSearcher
    {
        public IEnumerable<Person> Search(string name)
        {
            return PersonsRepository.Query("select * from Person where Name like '%" + name + "%'");
        }
    }
}
