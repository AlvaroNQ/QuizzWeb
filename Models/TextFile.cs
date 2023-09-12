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
                content = File.ReadAllText("./TextFile.txt");
                Console.WriteLine("File Content:");
                Console.WriteLine(content);
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the file: " + e.Message);
                this.content = "Error: Couldnt Open the file";
            }
        }
    }
}
