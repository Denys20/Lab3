using Lab3.Contracts;

namespace Lab3.Factories
{
    internal class DiskCreator : FileSystemItemCreator
    {
        public override FileSystemItem Create(FileSystemItem parent, string name)
        {
            return new Disk(name);
        }
    }
}
