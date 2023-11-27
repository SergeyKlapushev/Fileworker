using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Fileworker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string targetDirectory = @"D:\Семинары GB\C# разработка приложений\FileWorker\Fileworker\Fileworker\";
            Console.WriteLine($"Поиск происходит в дирректории: {targetDirectory}");
            string fileExtension = ".txt";
            Console.WriteLine($"Введите поисковой текст (подсказка: в файлах содержится следующие текста (Hey, Hello, Hi))");
            string searchText = Console.ReadLine();

            SearchFilesWithText(targetDirectory, fileExtension, searchText, true);

            Console.WriteLine("Поиск завершён");
        }

        static void SearchFilesWithText(string targetDirectory, string fileExtension, string searchText, bool recursive)
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(targetDirectory);

                FileInfo[] files = directory.GetFiles($"*{fileExtension}");

                foreach (FileInfo file in files)
                {
                    if (File.ReadAllText(file.FullName).Contains(searchText))
                    {
                        Console.WriteLine($"Найдено в файле: {file.FullName}");
                    }
                }


                if (recursive)
                {
                    DirectoryInfo[] subDirectories = directory.GetDirectories();
                    foreach (DirectoryInfo subDirectory in subDirectories)
                    {
                        SearchFilesWithText(subDirectory.FullName, fileExtension, searchText, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при поиске файлов: {ex.Message}");
            }
        }
    }
}
