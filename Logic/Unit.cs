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
    /// Pedagogical Unit; contains modules
    /// </summary>
    public class Unit: EducationalElement
    {
        [DataMember] private List<Module> modules = new List<Module>();

        /// <summary>
        /// List the modules
        /// </summary>
        /// <returns>an array containing the modules</returns>
        /// <since>TP3</since>
        public Module[] ListModules()
        {
            return modules.ToArray();
        }

        /*
        public Unit()
        {
            Module test = new Module();
            test.Name = "test";
            test.Coef = 1;
            modules.Add(test);
        } */

        /// <summary>
        /// Add a module
        /// </summary>
        /// <param name="m">the module to add</param>
        /// <since>TP3</since>
        public void Add(Module m)
        {
            modules.Add(m);
        }

        /// <summary>
        /// Remove a module
        /// </summary>
        /// <param name="m">the module to delete</param>
        /// <since>TP3</since>
        public void Remove(Module m)
        {
            modules.Remove(m);
        }

        /// <summary>
        /// List the average score of each module
        /// </summary>
        /// <param name="exams">the whole list of exams</param>
        /// <returns>an array of avgscores (may be empty if no exam)</returns>
        public AvgScore[] ComputeAverages(IEnumerable<Exam> exams)
        {
            List<AvgScore> avgScores = new List<AvgScore>();
            foreach(Module m in modules)
            {
                AvgScore avg = m.ComputeAverage(exams);
                if(avg!=null)
                {
                    avgScores.Add(avg);
                }
            }
            return avgScores.ToArray();
        }
    }
}
