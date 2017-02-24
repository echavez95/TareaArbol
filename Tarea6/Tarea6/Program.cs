using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tarea6
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    DirectoryInfo rootDir = new DirectoryInfo(fbd.SelectedPath);
                    Console.WriteLine(rootDir.ToString());

                    Console.WriteLine("--------------- Preorder ---------------");
                    Console.WriteLine(rootDir.Name);
                    Preorder(rootDir);

                    Console.WriteLine("--------------- Postorder --------------");
                    PostOrder(rootDir);
                    Console.WriteLine(rootDir.Name);

                    Console.WriteLine("--------------- inOrder --------------");
                    InOrder(rootDir);

                    Console.ReadKey();
                }
            }

            
        }

        static void Preorder( DirectoryInfo root)
        {
            DirectoryInfo[] subDirs = root.GetDirectories();
            
            foreach ( DirectoryInfo dirInfo in subDirs)
            {
                Console.WriteLine(dirInfo.Name);
                // Resursive call for each subdirectory.
                Preorder(dirInfo);
            }

        }

        static void PostOrder( DirectoryInfo root)
        {
             DirectoryInfo[] subDirs = root.GetDirectories();
            foreach ( DirectoryInfo dirInfo in subDirs)
            {
                // Resursive call for each subdirectory.
                PostOrder(dirInfo);
                Console.WriteLine(dirInfo.Name);
            }
        }

        static void InOrder(DirectoryInfo root)
        {
            DirectoryInfo[] subDirs = root.GetDirectories();

            if (subDirs.Length == 0)
            {
                return;
            }

            int mitad;
            
            if (subDirs.Length % 2 == 0)
            {
                mitad = subDirs.Length / 2;
            }
            else
            {
                mitad = Convert.ToInt32((subDirs.Length / 2) + 0.5);
            }
            
            for(int i = 0; i < mitad; i++)
            {
                InOrder(subDirs[i]);
                Console.WriteLine(subDirs[i].Name);
            }
            Console.WriteLine(root.Name);
            for (int i = mitad; i < subDirs.Length; i++)
            {
                InOrder(subDirs[i]);
                Console.WriteLine(subDirs[i].Name);
            }
        }

    }
}
