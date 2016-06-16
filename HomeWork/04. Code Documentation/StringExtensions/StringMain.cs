namespace StringExtensions
{
    /// <summary>
    /// Entry points for the program
    /// </summary>
    public class StringMain
    {
        public static void Main(string[] args)
        {   
            string programCheck = "nullCheck";
            System.Console.WriteLine(StringExtension.CapitalizeFirstLetter("null"));
            System.Console.WriteLine(StringExtension.CapitalizeFirstLetter(programCheck));
        }
    }
}
