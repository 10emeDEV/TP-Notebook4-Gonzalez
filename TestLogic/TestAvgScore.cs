using System;
using System.Collections.Generic;
using System.Text;
using Logic;
using Xunit;

namespace TestLogic
{
    public class TestAvgScore
    {
        [Fact]
        public void TestName()
        {
            Module m = new Module() { Name = "Test", Coef = 2 };
            AvgScore avg = new AvgScore(10, m);
            Assert.Equal("Test", avg.Element.Name);
            Assert.Equal(10, avg.Average, 3);
        }

        [Fact]
        public void TestComputeModule()
        {
            Module m = new Module() { Name = "Test", Coef = 2 };
            Exam e1 = new Exam() { Coef = 2, Module = m, Score = 9 };
            Exam e2 = new Exam() { Coef = 1.5f, Module = m, Score = 14.5f };
            Module m2 = new Module() { Name = "test 2", Coef = 1 };
            Exam e3 = new Exam() { Coef = 3, Module = m2, Score = 15 };
            List<Exam> exams = new List<Exam>() { e1, e2 ,e3 };
            var expectedAvg = (14.5 * 1.5 + 9 * 2) / 3.5;
            AvgScore avg = m.ComputeAverage(exams);
            Assert.NotNull(avg);
            Assert.Equal(avg.Average, expectedAvg, 3);
            Assert.Equal(m.Name, avg.Element.Name);

            Module m3 = new Module() { Name = "fake", Coef = 3 };
            AvgScore test2 = m3.ComputeAverage(exams);
            Assert.Null(test2);
        }

        [Fact]
        public void TestComputeUnit()
        {
            Unit u1 = new Unit() { Coef = 12, Name = "UE1" };
            Module m = new Module() { Name = "Test", Coef = 2 };
            Exam e1 = new Exam() { Coef = 2, Module = m, Score = 9 };
            Exam e2 = new Exam() { Coef = 1.5f, Module = m, Score = 14.5f };
            Module m2 = new Module() { Name = "test 2", Coef = 1 };
            Exam e3 = new Exam() { Coef = 3, Module = m2, Score = 15 };
            List<Exam> exams = new List<Exam>() { e1, e2, e3 };
            var expectedAvg = (14.5 * 1.5 + 9 * 2) / 3.5;
            var expectedAvg2 = 15;
            u1.Add(m);
            u1.Add(m2);

            var list = u1.ComputeAverages(exams);
            Assert.NotNull(list);
            Assert.Equal(2, list.Length);
            Assert.Equal(m.Name, list[0].Element.Name);
            Assert.Equal(m2.Name, list[1].Element.Name);
            Assert.Equal(expectedAvg, list[0].Average,3);
            Assert.Equal(expectedAvg2, list[1].Average, 3);
        }

        [Fact]
        public void TestComputeTotal()
        {
            Notebook nb = new Notebook();
            Unit u1 = new Unit() { Coef = 12, Name = "UE1" };
            Module m = new Module() { Name = "Test", Coef = 2 };
            Exam e1 = new Exam() { Coef = 2, Module = m, Score = 9 };
            Exam e2 = new Exam() { Coef = 1.5f, Module = m, Score = 14.5f };
            Module m2 = new Module() { Name = "test 2", Coef = 1.5f };
            Exam e3 = new Exam() { Coef = 3, Module = m2, Score = 15 };
            u1.Add(m);
            u1.Add(m2);
            nb.AddUnit(u1);
            nb.AddExam(e1);
            nb.AddExam(e2);
            nb.AddExam(e3);

            Unit u2 = new Unit() { Coef = 10, Name = "UE2" };
            Module m3 = new Module() { Coef = 1, Name = "M2102" };
            Exam e4 = new Exam() { Coef = 2, Module = m3, Score = 10 };
            u2.Add(m3);
            nb.AddUnit(u2);
            nb.AddExam(e4);

            AvgScore[] list = nb.ComputeScores();
            Assert.NotNull(list);
            Assert.Equal(6, list.Length); // 3 modules, 2 unités, 1 général
            // calculer les moyennes
            // m : (9*2+14.5*1.5)/3.5 = 11.35714
            // m2 : 15
            // m3 : 10
            // u1 : (11.35714*2 + 15*1.5)/3.5 = 12.91837
            // u2 : 10
            // général : (12.91837*12 + 10*10)/22 = 11.5918

            Assert.Same(m, list[0].Element);
            Assert.Equal(11.35714, list[0].Average, 2);
            Assert.Same(m2, list[1].Element);
            Assert.Equal(15, list[1].Average,2);
            Assert.Same(u1, list[2].Element);
            Assert.Equal(12.91837, list[2].Average, 2);
            Assert.Same(m3, list[3].Element);
            Assert.Equal(10, list[3].Average,2);
            Assert.Same(u2, list[4].Element);
            Assert.Equal(10, list[4].Average,2);
            Assert.Equal(11.5918, list[5].Average, 2);
        }
    }
}
