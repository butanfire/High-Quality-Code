namespace ReformatYourCode.Required
{
    using System;

    public class Payment
    {
        private string pname;
        private double price;

        public Payment(string pname, double price)
        {
            Price = price;
            ProductName = pname;
        }

        public string ProductName
        {
            get
            {
                return pname;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Product cannot be null");
                }

                pname = value;
            }
        }

        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative");
                }

                price = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}: {1:C0}", ProductName, Price);
        }
    }
}
