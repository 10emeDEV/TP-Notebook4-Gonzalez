using System;
using Xunit;
using Logic;
using Storage;
namespace TestStorage
{
    public class TestJsonStorage
    {
        [Fact]
        public void TestSaveLoad()
        {
            Notebook nb = new Notebook();
            // ajouter unités, modules, examens.
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
            Exam e1 = new Exam() { Module = m1 };
            Exam e2 = new Exam() { Module = m3 };
            nb.AddExam(e1);
            nb.AddExam(e2);

            JsonStorage test = new JsonStorage("test.json"); // todo placer ailleurs
            test.Save(nb);

            Notebook temp = test.Load();
            
            Assert.Equal(temp.ListExams(), nb.ListExams());
            Assert.Equal(temp.ListModules(), nb.ListModules());
            Assert.Equal(temp.ListUnits(), nb.ListUnits());
        }
    }
}
