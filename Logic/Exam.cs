using Microsoft.SqlServer.Server;
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
    /// An exam
    /// </summary>
    /// <since>TP4</since>
    public class Exam
    {
        [DataMember] private string teacher;
        [DataMember] private DateTime dateExam = DateTime.Now;
        [DataMember] private float coef=1;
        [DataMember] private bool isAbsent=true;
        [DataMember] private float score=0;
        [DataMember] private Module module;

        /// <summary>
        /// Gets or Sets the teacher's name
        /// </summary>
        public string Teacher { get => teacher; set => teacher = value; }

        /// <summary>
        /// Gets or sets the date of the Exam
        /// </summary>
        
        public DateTime DateExam { get => dateExam; set => dateExam = value; }
        /// <summary>
        /// Gets or sets the exam's coef
        /// </summary>
        /// <exception cref="Exception">If the coef is invalid</exception>
        public float Coef 
        { 
            get => coef; 
            set
            {
                if (value <= 0) throw new Exception("Coef must be >0");
                coef = value;
            }
        }

        /// <summary>
        /// Gets or sets the absent's state. If the student is absent, the score is 0.
        /// </summary>
        public bool IsAbsent 
        { 
            get => isAbsent;
            set
            {
                isAbsent = value;
                if(value)
                    score = 0;
            }
        }
        /// <summary>
        /// Gets or sets the student's score (must be between 0 and 20)
        /// </summary>
        /// <exception cref="Exception">if the score is not valid</exception>
        public float Score 
        { 
            get => score; 
            set
            {
                if (value < 0 || value > 20) throw new Exception("Invalid score : must be between 0 and 20");
                score = value;
            }
        }
        /// <summary>
        /// Gets or sets the module
        /// </summary>
        /// <exception cref="Exception">If the module is unset (null)</exception>
        public Module Module 
        { 
            get => module;
            set
            {
                if (value == null) throw new Exception("Module must be set");
                module = value;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Exam exam &&
                   teacher == exam.teacher &&
                   dateExam.ToShortDateString().Equals(exam.dateExam.ToShortDateString()) &&
                   coef == exam.coef &&
                   isAbsent == exam.isAbsent &&
                   score == exam.score &&
                   module.Equals(exam.Module);
        }
    }
}
