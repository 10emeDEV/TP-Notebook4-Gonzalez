using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Logic;

namespace TestLogic
{
    public class TestNotebook
    {
        [Fact]
        public void TestList()
        {
            Notebook nb = new Notebook();
            var list = nb.ListUnits();
            Assert.NotNull(list);
            Assert.Empty(list);
        }

        [Fact]
        public void TestAdd()
        {
            Notebook nb = new Notebook();
            Unit u1 = new Unit();
            u1.Name = "Test";
            u1.Coef = 1;
            nb.AddUnit(u1);
            var units = nb.ListUnits();
            Assert.Single(units);
            Assert.Same(u1, units[0]);
            // bonus 
            var u2 = new Unit();
            u2.Name = "Test";
            u2.Coef = 2;
            Assert.Throws<Exception>(() => { nb.AddUnit(u2); });
            u2.Name = "Test 2";
            nb.AddUnit(u2);
            units = nb.ListUnits();
            Assert.Equal(2, units.Length);
            Assert.Same(u2, units[1]);
        }

        [Fact]
        public void TestRemove()
        {
            Notebook nb = new Notebook();
            Unit u1 = new Unit();
            u1.Name = "Test";
            u1.Coef = 1;
            nb.AddUnit(u1);
            nb.RemoveUnit(u1);
            var units = nb.ListUnits();
            Assert.Empty(units);            
        }

        [Fact]
        public void TestListModules()
        {
            Notebook nb = new Notebook();
            Unit u1 = new Unit();
            u1.Name = "UE1";
            u1.Coef = 12;
            nb.AddUnit(u1);
            Unit u2 = new Unit() { Coef = 11, Name = "UE2" };
            nb.AddUnit(u2);
            Module m1 = new Module() { Name = "M1101", Coef=3 };
            Module m2 = new Module() { Name = "M1102", Coef = 2 };
            u1.Add(m1);
            u1.Add(m2);
            Module m3 = new Module() { Name = "M1210", Coef = 2.5f };
            u2.Add(m3);
            var modules = nb.ListModules();
            Assert.Equal(3, modules.Length);
            Assert.Same(m1, modules[0]);
            Assert.Same(m2, modules[1]);
            Assert.Same(m3, modules[2]);
                
        }

        [Fact]
        public void TestAddListExams()
        {
            Notebook nb = new Notebook();
            Unit u1 = new Unit();
            u1.Name = "UE1";
            u1.Coef = 12;
            nb.AddUnit(u1);
            Unit u2 = new Unit() { Coef = 11, Name = "UE2" };
            nb.AddUnit(u2);
            Module m1 = new Module() { Name = "M1101", Coef = 3 };
            Module m2 = new Module() { Name = "M1102", Coef = 2 };
            u1.Add(m1);
            u1.Add(m2);
            Module m3 = new Module() { Name = "M1210", Coef = 2.5f };
            u2.Add(m3);

            Exam test = new Exam() { Coef = 1, DateExam = DateTime.Now, IsAbsent = false, Module = m1, Score = 14.5f, Teacher = "test" };
            nb.AddExam(test);
            var list = nb.ListExams();
            Assert.Single(list);
            Assert.Same(test, list[0]);
        }
    }
}
