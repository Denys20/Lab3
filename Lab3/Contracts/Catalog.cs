using System.Linq;

namespace Lab3.Contracts
{
    internal class Catalog : FileSystemItem
    {
        public Catalog(string name)
            : base(name)
        {
        }

        public override void AddChild(FileSystemItem child)
        {
            child.Parent = this;
            Children.Add(child);
            CreateInterval(child);
        }

        public override FileSystemItem Clone()
        {
            int number = Parent.Children.Where(x => x is Catalog && x.Name.StartsWith(Name)).Count();
            var clone = new Catalog(string.Format("{0} ({1})", Name, number)) { Parent = Parent };

            InitializeInterval(clone);
            InitializeChildTree(this, clone);
            Parent.Children.Add(clone);

            return clone;
        }

        public override void SetInterval(FileSystemItem node)
        {
            CreateInterval(node);
        }

        public override void InitializeChildTree(FileSystemItem original, FileSystemItem parent)
        {
            foreach (var child in original.Children)
            {
                var clone = child.GetInstance(child.Name);
                clone.Parent = parent;
                parent.SetInterval(clone);
                parent.Children.Add(clone);
                if (child.Children.Count > 0)
                {
                    InitializeChildTree(child, clone);
                }
            }
        }

        public override FileSystemItem GetInstance(string name)
        {
            return new Catalog(name);
        }
    }
}
