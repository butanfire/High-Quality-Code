namespace CohesionAndCoupling.DataValidation
{
    using Exceptions;

    public static class DataValidator
    {
        /// <summary>
        /// Validate whether the file has an extension.
        /// </summary>
        /// <param name="name">Filename for validation.</param>
        /// <param name="extensionIndex">Index of the last "." in the filename.</param>
        /// <returns>True, if valid</returns>
        public static bool FileExtensionValidator(string name, int extensionIndex)
        {
            try
            {
                if (extensionIndex == -1)
                {
                    throw new FileExtensionException("The file does not have a valid extension : " + name);
                }
            }
            catch (FileExtensionException e)
            {
                System.Console.Write(e.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validate whether the file has a valid name.
        /// </summary>
        /// <param name="name">Filename for validation.</param>
        /// <returns>True, if valid</returns>
        public static bool FileNameValidator(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new FileNameException("Name cannot be empty or null");
                }
            }
            catch (FileNameException e)
            {
                System.Console.Write(e.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validatr whether the number has a negative value.
        /// </summary>
        /// <param name="number">Number to validate.</param>
        /// <returns>True, if valid</returns>
        public static bool NumericValidator(double number)
        {
            try
            {
                if (number < 0)
                {
                    throw new NumericDataException("Number cannot be negative!" + number.ToString());
                }
            }
            catch (NumericDataException e)
            {
                System.Console.Write(e.Message);
                return false;
            }

            return true;
        }
    }
}