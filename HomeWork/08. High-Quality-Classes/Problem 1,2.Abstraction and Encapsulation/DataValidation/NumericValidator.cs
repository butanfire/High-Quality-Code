namespace Abstraction.DataValidation
{
    using Exceptions;

    public static class NumericValidator
    {
        public static bool ValidateNumber(double number)
        {
            try
            {
                if (number < 0)
                {
                    throw new NumericNegativeException("Number cannot be negative! Number provided " + number.ToString());
                }
            }
            catch(NumericNegativeException e)
            {
                System.Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }
    }
}
