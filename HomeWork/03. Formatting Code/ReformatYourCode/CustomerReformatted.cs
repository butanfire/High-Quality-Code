using ReformatYourCode;
using ReformatYourCode.Required;

namespace ReformatYourCode_Fixed
{
    using System;
    using System.Collections.Generic;
    using System.Text;    

    public class Customer : ICloneable, IComparable<Customer>
    {
        private string fname;
        private string mname;
        private string lname;
        private string id;
        private string permaddress;
        private string email;
        private List<Payment> payments;
        private string phone;
        private CustomerTypes type;

        public Customer(string fname, string mname, string lname, string id, string permaddrr, string mail, string phone, CustomerTypes type)
        {
            FirstName = fname;
            MiddleName = mname;
            LastName = lname;
            ID = id;
            PermAddress = permaddrr;
            Email = mail;
            payments = new List<Payment>();
            Phone = phone;
            Type = type;
        }

        public string FirstName
        {
            get
            {
                return fname;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First name cannot be null/empty");
                }

                fname = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return mname;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Middle name cannot be null/empty");
                }

                mname = value;
            }
        }

        public string LastName
        {
            get
            {
                return lname;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Last name cannot be null/empty");
                }

                lname = value;
            }
        }

        public string ID
        {
            get
            {
                return id;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("ID cannot be null/empty");
                }

                id = value;
            }
        }

        public string PermAddress
        {
            get
            {
                return permaddress;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Permament address cannot be null");
                }

                permaddress = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Phone cannot be null");
                }

                phone = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Email cannot be null");
                }

                email = value;
            }
        }

        public CustomerTypes Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public List<Payment> Payments
        {
            get
            {
                return payments;
            }
        }

        public static bool operator ==(Customer obj1, Customer obj2)
        {
            return Equals(obj1, obj2);
        }

        public static bool operator !=(Customer obj1, Customer obj2)
        {
            return !(obj1 == obj2);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(string.Format("{0} {1} {2} ", FirstName, MiddleName, LastName));
            output.Append(string.Format("{0} {1} {2} ", ID, PermAddress, Email));
            output.Append(string.Format("{0} {1}", Phone, Type));

            if (Payments != null)
            {
                output.AppendLine();
                output.AppendLine("Payments : ");
                foreach (var items in Payments)
                {
                    output.AppendLine(items.Price + items.ProductName);
                }
            }

            return output.ToString();
        }

        public override bool Equals(object obj)
        {
            var other = obj as Customer;
            if (other != null)
            {
                return Equals(ID, other.ID);
            }

            return false;
        }
        
        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ LastName.GetHashCode();
        }

        public object Clone()
        {
            var newCustomer = new Customer(
                FirstName, 
                MiddleName, 
                LastName, 
                ID, 
                PermAddress, 
                Email, 
                Phone, 
                Type);

            foreach (var payment in payments)
            {
                newCustomer.AddPayment(payment);
            }

            return newCustomer;
        }

        public void AddPayment(Payment payArgument)
        {
            Payments.Add(payArgument);
        }

        public int CompareTo(Customer other)
        {
            var comparator = string.Compare($"{FirstName} {MiddleName} {LastName}", $"{other.FirstName} {other.MiddleName} {other.LastName}", StringComparison.Ordinal);

            return comparator == 0 ? ID.CompareTo(other.ID) : comparator;
        }
    }
}
