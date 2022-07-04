using Lab3.Contracts;

namespace Lab3.Factories
{
    internal class CatalogCreator : FileSystemItemCreator
    {
        public override FileSystemItem Create(FileSystemItem parent, string name)
        {
            var catalog = new Catalog(name);

            parent.AddChild(catalog);

            return catalog;
        }
    }
}
