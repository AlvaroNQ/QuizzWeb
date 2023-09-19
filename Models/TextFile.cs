using Microsoft.AspNetCore.Hosting.Server;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using System.Web;
using System.Text;

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
                content = File.ReadAllText("./Models/TextFile.txt", Encoding.GetEncoding("iso-8859-1"));
                Console.WriteLine("File Content:");
                Console.WriteLine(content);
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the file: " + e.Message);
                this.content = "Error: couldnt Read the file specified";
                //this.content = "Error: Couldnt Open the file";

            }
        }
    }
}
