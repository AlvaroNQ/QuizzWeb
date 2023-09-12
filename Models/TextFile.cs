using Microsoft.AspNetCore.Hosting.Server;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using System.Web;

namespace QuizzWeb.Models
{
    public class TextFile
    {
        public string? content = null;
        public TextFile()
        {
            try
            {
                Console.WriteLine("Attempt to read file;");
                content = File.ReadAllText("C:\\Users\\Alvaro\\myStuff\\university\\Software Engineering I-II\\InternationalTeam\\QuizzWeb\\wwwroot\\TextFile.txt");
                Console.WriteLine("File Content:");
                Console.WriteLine(content);
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the file: " + e.Message);
                this.content = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                //this.content = "Error: Couldnt Open the file";

            }
        }
    }
}
