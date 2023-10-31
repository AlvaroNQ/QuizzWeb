namespace QuizzWeb.Models.QuizModels
{
    public struct CreationInfo
    {
        public string name { get; set; }
        public DateTime CreationDate { get; set; }
        public string FileName { get; set; }

        public CreationInfo(string filename="DefaultName") { 
            this.name = System.Environment.MachineName;
            this.FileName = filename;
            this.CreationDate = DateTime.Now;
        }
    }
}
