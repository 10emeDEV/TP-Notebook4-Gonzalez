using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Logic;

namespace TestLogic
{
    public class TestExam
    {
        [Fact]
        public void TestTeacher()
        {
            Exam e = new Exam();
            e.Teacher = "toto";
            Assert.Equal("toto", e.Teacher);
        }

        [Fact]
        public void TestDateExam()
        {
            Exam e = new Exam();
            DateTime dt = new DateTime(2020, 09, 29);
            e.DateExam = dt;
            Assert.Equal(dt, e.DateExam);            
        }

        [Fact]
        public void TestCoef()
        {
            Exam e = new Exam();
            e.Coef = 3.5f;
            Assert.Equal(3.5f, e.Coef, 3);
            Assert.Throws<Exception>(() => { e.Coef = 0; });
            Assert.Throws<Exception>(() => { e.Coef = -5; });
        }

        [Fact]
        public void TestScore()
        {
            Exam e = new Exam();
            e.Score = 14.5f;
            Assert.Equal(14.5, e.Score, 2);
            Assert.Throws<Exception>(() => { e.Score = -2; });
            Assert.Throws<Exception>(() => { e.Score = 20.4f; });
            e.Score = 0;
            Assert.Equal(0, e.Score, 2);
            e.Score = 20;
            Assert.Equal(20, e.Score, 2);
        }

        [Fact]
        public void TestAbsent()
        {
            Exam e = new Exam();
            Assert.True(e.IsAbsent);
            e.IsAbsent = false;
            e.Score = 10;
            Assert.False(e.IsAbsent);
            Assert.Equal(10, e.Score, 2);
            e.IsAbsent = true;
            Assert.True(e.IsAbsent);
            Assert.Equal(0, e.Score, 2);
        }

        [Fact]
        public void TestModule()
        {
            Exam e = new Exam();
            Module m = new Module() { Coef = 1, Name = "test" };
            e.Module = m;
            Assert.Same(m, e.Module);
            Assert.Throws<Exception>(() => { e.Module = null; });
        }

        [Fact]
        public void TestEquals()
        {
            Module m = new Module() { Coef = 1, Name = "test" };
            Exam e = new Exam() { Module = m, Coef = 3, DateExam = new DateTime(2020, 10, 20), Teacher = "Toto", IsAbsent = false, Score = 14 };
            Module m2 = new Module() { Coef = 1, Name = "test" };
            Exam e2 = new Exam() { Module = m2, Coef = 3, DateExam = new DateTime(2020, 10, 20), Teacher = "Toto", IsAbsent = false, Score = 14 };

            Assert.Equal(e, e2);
        }
    }
}
