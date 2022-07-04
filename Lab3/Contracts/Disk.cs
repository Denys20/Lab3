namespace Lab3.Contracts
{
    internal class Disk : FileSystemItem
    {
        public Disk(string name)
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
            var clone = new Disk(Name) { Parent = null };

            InitializeInterval(clone);
            InitializeChildTree(this, clone);

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
            return new Disk(name);
        }
    }
}
