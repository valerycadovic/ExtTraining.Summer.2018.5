using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution
{
    public class PrinterEntity : IEquatable<PrinterEntity>
    {
        public PrinterEntity(string name, string model)
        {
            this.Name = name;
            this.Model = model;
        }

        public string Name { get; }

        public string Model { get; }

        public static bool operator ==(PrinterEntity lhs, PrinterEntity rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(PrinterEntity lhs, PrinterEntity rhs)
        {
            return !(lhs == rhs);
        }

        public bool Equals(PrinterEntity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name) && string.Equals(Model, other.Model);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PrinterEntity) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (Model != null ? Model.GetHashCode() : 0);
            }
        }
    }
}
