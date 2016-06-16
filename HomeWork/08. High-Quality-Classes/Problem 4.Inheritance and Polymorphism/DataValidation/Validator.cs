namespace InheritanceAndPolymorphism.DataValidation
{
    using Exception;

    public static class Validator
    {
        public static bool NameValidator(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new NameException("Name cannot be empty or null! : " + name);
                }
            }
            catch (NameException e)
            {
                System.Console.Write(e.Message);
                return false;
            }

            return true;
        }
    }
}
