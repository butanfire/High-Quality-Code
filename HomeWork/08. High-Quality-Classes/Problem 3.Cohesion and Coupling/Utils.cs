namespace CohesionAndCoupling
{
    using DataValidation;

    public static class Utils
    {
        public static string GetFileExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (DataValidator.FileExtensionValidator(fileName, indexOfLastDot))
            {
                return fileName.Substring(indexOfLastDot + 1);
            }

            return string.Empty;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            ////usually the file cannot be created without a filename by the OS, so no need to check for empty/null strings.
            ////but for the sake of the homework we will do it!
            if (DataValidator.FileNameValidator(fileName))
            {
                int indexOfLastDot = fileName.LastIndexOf(".");
                return indexOfLastDot == -1 ? fileName : fileName.Substring(0, indexOfLastDot);
            }

            return string.Empty;
        }
    }
}
