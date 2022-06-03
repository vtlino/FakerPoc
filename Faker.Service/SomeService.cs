namespace FakerPoc.Service
{
    public class SomeService : ISomeService
    {
        string ISomeService.GetSomeString()
        {
            return new Random().Next().ToString();
        }

        int ISomeService.GetSomeInt()
        {
            return new Random().Next();
        }

        public SomeClass GetSomeClass()
        {
            return new SomeClass();
        }
    }
}