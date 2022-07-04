using Lab3.Contracts;

namespace Lab3.Factories
{
    internal class FileCreator : FileSystemItemCreator
    {
        public override FileSystemItem Create(FileSystemItem parent, string name)
        {
            var file = new Contracts.File(name);

            parent.AddChild(file);

            return file;
        }
    }
}
