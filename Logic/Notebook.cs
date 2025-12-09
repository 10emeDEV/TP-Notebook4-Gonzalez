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
    /// Facade to logic layer
    /// </summary>
    public class Notebook
    {
        [DataMember] private List<Unit> units = new List<Unit>();
        [DataMember] private List<Exam> exams = new List<Exam>();


        /// <summary>
        /// Gives all the units 
        /// </summary>
        /// <returns>an array contains all units</returns>
        public Unit[] ListUnits()
        {
            return units.ToArray();
        }

        /// <summary>
        /// Add a unit
        /// </summary>
        /// <param name="unit">the unit to add</param>
        /// /// <since>TP2</since>
        public void AddUnit(Unit unit)
        {
            // bonus : teste si l'unité existe déjà
            if (units.Find((u) => { return u.Name == unit.Name; }) != null)
                throw new Exception("An unit with this name already exists");
            units.Add(unit);
        }

        /// <summary>
        /// remove the unit
        /// </summary>
        /// <param name="unit">unit to remove</param>
        /// <since>TP2</since>
        public void RemoveUnit(Unit unit)
        {
            units.Remove(unit);            
        }

        /// <summary>
        /// List all the modules, Unit by unit
        /// </summary>
        /// <returns>an array contains all the modules</returns>
        /// <since>TP4</since>
        public Module[] ListModules()
        {
            List<Module> list = new List<Module>();
            foreach(var unit in units)
            {
                list.AddRange(unit.ListModules());
            }
            return list.ToArray();
        }

        /// <summary>
        /// Add an exam
        /// </summary>
        /// <param name="e"></param>
        /// <since>TP4</since>
        public void AddExam(Exam e)
        {
            exams.Add(e);            
        }

        /// <summary>
        /// List all the exams
        /// </summary>
        /// <returns>an array containing all the exams</returns>
        /// <since>TP5</since>
        public Exam[] ListExams()
        {
            return exams.ToArray();
        }

        public AvgScore[] ComputeScores()
        {
            List<AvgScore> scores = new List<AvgScore>();
            float totalGeneral = 0;
            float totalCoefs = 0;
            foreach(Unit u in units)
            {
                var list = u.ComputeAverages(exams);
                float total = 0, coefs = 0;
                foreach(var e in list)
                {
                    total += e.Average * e.Element.Coef;
                    coefs += e.Element.Coef;
                    scores.Add(e);
                }
                if(coefs!=0)
                {
                    float moyenne = total / coefs;
                    AvgScore avg = new AvgScore(moyenne, u);
                    scores.Add(avg);
                    totalGeneral += moyenne * u.Coef;
                    totalCoefs += u.Coef;
                }
            }
            if(totalCoefs!=0)
            {
                EducationalElement general = new EducationalElement() { Coef = 1, Name = "General" };
                AvgScore final = new AvgScore(totalGeneral / totalCoefs, general);
                scores.Add(final);
            }

            return scores.ToArray();
        }
    }
}
