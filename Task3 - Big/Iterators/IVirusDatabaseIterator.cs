namespace Task3
{
    public interface IVirusDatabaseIterator
    {
        bool HasNext();
        void Next();
        void Prev();
        VirusData Current();
    }
}
