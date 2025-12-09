using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    [DataContract]
    /// <summary>
    /// A simple element of the program
    /// </summary>
    public class EducationalElement
    {
        [DataMember] private string name;
        [DataMember] private float coef;

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        /// <exception cref="Exception">If the name is empty</exception>
        public string Name 
        { 
            get => name; 
            set
            {
                if (value == null || value == "") throw new Exception("The name must not be empty");
                name = value;                
            }
        }

        /// <summary>
        /// Gets or sets the coef
        /// </summary>
        /// <exception cref="Exception">If the coef is <=0 </exception>
        public float Coef { get => coef;
            set
            {
                if (value <= 0) throw new Exception("The coef must not be less or equal to 0");
                coef = value;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is EducationalElement element &&
                   name == element.name &&
                   coef == element.coef;
        }

        public override int GetHashCode()
        {
            int hashCode = -539382730;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + coef.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return name + " (" + coef.ToString() + ")";
        }

    }
}
