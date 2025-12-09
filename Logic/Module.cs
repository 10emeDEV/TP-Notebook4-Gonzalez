using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Simple Module
    /// </summary>
    public class Module : EducationalElement
    {
        /// <summary>
        /// Compute the average score of the module
        /// </summary>
        /// <param name="exams">the total exams</param>
        /// <returns>the average score, or null if no exams in the module</returns>
        public AvgScore ComputeAverage(IEnumerable<Exam> exams)
        {
            AvgScore avg = null;
            float score = 0;
            float coefs = 0;
            foreach(Exam e in exams)
            {
                if(e.Module == this)
                {
                    score += e.Score * e.Coef;
                    coefs += e.Coef;
                }
            }
            if(coefs!=0)
            {
                float average = score / coefs;
                avg = new AvgScore(average, this);
            }
            return avg;
        }
    }
}
