using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Logic;

namespace TestLogic
{
    public class TestUnit
    {
        [Fact]
        public void TestListModules()
        {
            Unit unit = new Unit();
            var list = unit.ListModules();
            Assert.Empty(list);
            // pas d'autre test possible pour l'instant
        }

        [Fact]
        public void TestAdd()
        {
            Unit unit = new Unit();
            Module m = new Module();
            m.Coef = 1.5f;
            m.Name = "test";
            unit.Add(m);
            var list = unit.ListModules();
            Assert.Single(list);
            Assert.Same(m, list[0]);
        }

        [Fact]
        public void TestRemove()
        {
            Unit unit = new Unit();
            Module m = new Module();
            m.Coef = 1.5f;
            m.Name = "test";
            unit.Add(m);
            unit.Remove(m);
            var list = unit.ListModules();
            Assert.Empty(list);
            unit.Add(m);
            Module m2 = new Module();
            m2.Coef = 3;
            m2.Name = "dummy";
            unit.Add(m2);
            unit.Remove(m);
            list = unit.ListModules();
            Assert.Single(list);
            Assert.Same(m2, list[0]);
        }
    }
}
