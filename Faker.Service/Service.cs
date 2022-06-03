namespace FakerPoc.Service
{
    public class Service
    {
        private readonly ISomeService _someClass;

        public Service(ISomeService someClass)
        {
            _someClass = someClass;
        }

        public int GetSomeInt()
        {
            return _someClass.GetSomeInt();
        }

        public string GetSomeString()
        {
            return _someClass.GetSomeString();
        }

        public SomeClass GetSomeClass()
        {
            return _someClass.GetSomeClass();
        }
    }
}