using System;
using System.Collections.Generic;
using System.Linq;
using Lab3.Contracts;
using Lab3.Factories;

namespace Lab3
{
    internal class FileSystem
    {
        public void Init()
        {
            string answer = string.Empty;

            FileSystemItem currentNode = null;
            List<FileSystemItem> disks = new List<FileSystemItem>();
            do
            {
                if (!(currentNode is Contracts.File))
                {
                    Console.WriteLine("\n1 - створити диск; 2 - створити каталог; 3 - створити файл");
                    answer = Console.ReadLine();

                    short res;
                    if (short.TryParse(answer, out res))
                    {
                        FileSystemItemCreator factory;
                        switch (res)
                        {
                            case (short)FileSystemItemType.Disk:
                                Console.WriteLine("Введіть назву");
                                factory = new DiskCreator();
                                currentNode = factory.Create(null, GetName());
                                disks.Add(currentNode);
                                break;
                            case (short)FileSystemItemType.Catalog:
                                if (currentNode == null)
                                {
                                    Console.WriteLine("Неможливо створити каталог без диска");
                                    break;
                                }
                                Console.WriteLine("Введіть назву");
                                factory = new CatalogCreator();
                                currentNode = factory.Create(currentNode, GetName());
                                break;
                            case (short)FileSystemItemType.File:
                                if (currentNode == null)
                                {
                                    Console.WriteLine("Неможливо створити файл без диска");
                                    break;
                                }
                                Console.WriteLine("Введіть назву");
                                factory = new FileCreator();
                                currentNode = factory.Create(currentNode, GetName());
                                break;
                        }
                    }
                }
                Console.WriteLine("\n7 - виберіть батьківський вузол; 0 - вихід; 4 - намалювати дерево вузлів; 5 - клонувати об'єкт; 6 - намалювати всю файлову систему");
                answer = Console.ReadLine();

                if (currentNode != null)
                {
                    switch (answer)
                    {
                        case "4":
                            currentNode.Draw();
                            break;
                        case "7":
                            currentNode = currentNode.Parent == null ? currentNode : currentNode.Parent;
                            break;
                        case "5":
                            currentNode = currentNode.Clone();
                            if (currentNode is Disk)
                            {
                                int number = disks.Where(x => x.Name.StartsWith(currentNode.Name)).Count();
                                currentNode.Name += string.Format(" ({0})", number);
                                disks.Add(currentNode);
                            }
                            break;
                        case "6":
                            DrawFileSystem(disks);
                            break;
                    }
                }
                if (currentNode != null)
                {
                    Console.WriteLine("Поточний вузол : {0}", currentNode.Name);
                }
            } while (answer != "0");
        }

        private void DrawFileSystem(List<FileSystemItem> disks)
        {
            foreach (var disk in disks)
            {
                disk.DrawAll();
            }
        }

        private string GetName()
        {
            string name = Console.ReadLine();

            while (String.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Неправильне введення. Спробуйте ще раз:");
                name = Console.ReadLine();
            }

            return name;
        }
    }
}
