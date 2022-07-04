using Lab3.Contracts;

namespace Lab3.Factories
{
    internal abstract class FileSystemItemCreator
    {
        public abstract FileSystemItem Create(FileSystemItem parent, string name);

    }
}
