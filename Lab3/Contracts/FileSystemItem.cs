using System;
using System.Collections.Generic;

namespace Lab3.Contracts
{
    internal abstract class FileSystemItem
    {
        public FileSystemItem(string name)
        {
            Name = name;
            Children = new List<FileSystemItem>();
            Interval = "";
        }

        public FileSystemItem Parent { get; internal set; }

        public IList<FileSystemItem> Children { get; internal set; }

        public virtual string Name { get; set; }

        ////??
        //public string Path
        //{
        //    get
        //    {
        //        var path = string.Empty;
        //        if (Parent != null)
        //        {
        //            path += Parent.Path;
        //        }
        //        return path + Name + @"\";
        //    }
        //}

        public string Interval { get; private set; }


        public abstract void AddChild(FileSystemItem child);

        public abstract FileSystemItem Clone();

        public abstract void InitializeChildTree(FileSystemItem original, FileSystemItem parent);

        public abstract FileSystemItem GetInstance(string name);

        public abstract void SetInterval(FileSystemItem node);

        protected virtual void CreateInterval(FileSystemItem child)
        {
            child.Interval = Interval + "--";
        }

        protected virtual void InitializeInterval(FileSystemItem clone)
        {
            clone.Interval = Interval;
        }

        public void Draw()
        {
            if (Parent != null)
            {
                Parent.Draw();
            }
            Console.WriteLine(Interval + Name);
        }

        public void DrawAll()
        {
            Console.WriteLine(Interval + Name);
            if (Children != null)
            {
                foreach (var child in Children)
                {
                    child.DrawAll();
                }
            }
        }
    }
}
