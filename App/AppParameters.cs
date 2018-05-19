namespace App
{
    /// <summary>
    /// Represents already parsed command line arguments passed to application
    /// </summary>
    public class AppParameters
    {
        public enum ProcessType
        {
            SaveToFile,
            DisplayOnConsole
        }

        public int NumberOfVertices { get; set; }
        public double SideLength { get; set; }
        public ProcessType Option { get; set; }
    }
}