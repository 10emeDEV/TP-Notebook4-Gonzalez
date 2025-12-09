using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Average score linked to an educational element
    /// </summary>
    public class AvgScore
    {
        private float average;
        private EducationalElement element;

        /// <summary>
        /// Get the average score of the element
        /// </summary>
        public float Average { get => average; }

        
        /// <summary>
        /// Gets the element
        /// </summary>
        public EducationalElement Element { get => element; }
        
        /// <summary>
        /// Init the object
        /// </summary>
        /// <param name="score">the average score</param>
        /// <param name="element">the educational element</param>
        public AvgScore(float score, EducationalElement element)
        {
            this.average = score;
            this.element = element;
        }

        public override string ToString()
        {
            return element.Name + " : " + average.ToString("0.00");
        }
    }
}
