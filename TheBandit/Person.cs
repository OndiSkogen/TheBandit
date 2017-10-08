//Andreas Norberg, 2017
namespace TheBandit
{
    class Person
    {
        private string _name;
        private int _age;

        public Person(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public string Name()
        {
            return _name;
        }
    }
}
