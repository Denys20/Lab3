using System.Linq;

namespace Lab3.Contracts
{
    internal class File : FileSystemItem
    {
        public File(string name)
            : base(name)
        {
        }

        /* public string Extension { get; set; }

         public override string Name { get => base.Name + "." + Extension; set => base.Name = value; }*/

        public override void AddChild(FileSystemItem child)
        {
        }

        public override FileSystemItem Clone()
        {
            int number = Parent.Children.Where(x => x is File && x.Name.StartsWith(Name)).Count();
            var clone = new File(string.Format("{0} ({1})", Name, number)) { Parent = Parent };

            InitializeInterval(clone);
            Parent.Children.Add(clone);

            return clone;
        }

        public override void SetInterval(FileSystemItem node)
        {
            CreateInterval(node);
        }

        public override void InitializeChildTree(FileSystemItem original, FileSystemItem parent)
        {
        }

        public override FileSystemItem GetInstance(string name)
        {
            return new File(name);
        }
    }
}
