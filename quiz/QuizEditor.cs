namespace quiz
{
    internal class QuizEditor
    {
        public QuizEditor()
        {
            СreateFile("Answers", "./Biology");
            СreateFile("Questions", "./Biology");
            СreateFile("Top20", "./Biology");

            СreateFile("Answers", "./Informatics");
            СreateFile("Questions", "./Informatics");
            СreateFile("Top20", "./Informatics");

            СreateFile("Answers", "./Mathematics");
            СreateFile("Questions", "./Mathematics");
            СreateFile("Top20", "./Mathematics");
        }

        public void СreateFile(string fileName, string directory, string format = ".txt")
        {  
            if (!Directory.Exists(directory))
            {
               Directory.CreateDirectory(directory);
            }
            using (FileStream file = File.Create(Path.Combine(directory, fileName + format))) { }
        }  
    }
}

        


                
            
            

    

