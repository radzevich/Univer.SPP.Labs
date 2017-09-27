namespace _6
{
    public class TestData
    {
        private static int _counter = 0;

        public int Id { get; }

        public TestData()
        {
            Id = _counter;
            _counter++;
        }

        public TestData(int idToSet)
        {
            Id = idToSet;
        }
    }
}