namespace Task2
{
    public interface IFileSystemIterator // common interface for filesystem iterators
    {
        // returns current node and moves iterator to the next node
        public DummyNode Next();
    }
}
