using NUnit.Framework;
using Moq;
using Janken;
﻿using System; // Enum
using System.Linq;
using System.Collections.Generic;

namespace Tests
{
    public class RuleTest
    {
        [SetUp]
        public void Setup() {}

        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Fist, Rule.Result.Draw)]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Victory, Rule.Result.Win)]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Hand, Rule.Result.Lose)]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Hand, Rule.Result.Draw)]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Fist, Rule.Result.Win)]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Victory, Rule.Result.Lose)]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Victory, Rule.Result.Draw)]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Hand, Rule.Result.Win)]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Fist, Rule.Result.Lose)]
        public void Judge_vsNPC_ReturnResult(Hands.Unicode player, Hands.Unicode npc, Rule.Result expected)
        {
            var actual = Rule.Instance.Judge(player, npc);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Fist, Rule.Result.Draw, Rule.Result.Draw)]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Victory, Rule.Result.Win, Rule.Result.Lose)]
        [TestCase(Hands.Unicode.Fist, Hands.Unicode.Hand, Rule.Result.Lose, Rule.Result.Win)]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Hand, Rule.Result.Draw, Rule.Result.Draw)]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Fist, Rule.Result.Win, Rule.Result.Lose)]
        [TestCase(Hands.Unicode.Hand, Hands.Unicode.Victory, Rule.Result.Lose, Rule.Result.Win)]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Victory, Rule.Result.Draw, Rule.Result.Draw)]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Hand, Rule.Result.Win, Rule.Result.Lose)]
        [TestCase(Hands.Unicode.Victory, Hands.Unicode.Fist, Rule.Result.Lose, Rule.Result.Win)]
        public void Judge_vs2_ReturnResult(Hands.Unicode player, Hands.Unicode npc, Rule.Result playerResult, Rule.Result npcResult)
        {
            var input = new List<Hands.Unicode>() { player, npc };
            var actual = Rule.Instance.Judge(input);
            var expected = new List<Rule.Result>() { playerResult, npcResult };
            Assert.That(expected, Is.EqualTo(actual));
        }

        /*
        private List<Hands.Unicode> judge_vs2_FF = new List<Hands.Unicode>() { Hands.Unicode.Fist, Hands.Unicode.Fist };
        private object[] judge_vs2_inputs = new object[] {
            new List<Hands.Unicode>() { Hands.Unicode.Fist, Hands.Unicode.Fist },
            new List<Hands.Unicode>() { Hands.Unicode.Fist, Hands.Unicode.Hand },
            new List<Hands.Unicode>() { Hands.Unicode.Fist, Hands.Unicode.Victory },
            new List<Hands.Unicode>() { Hands.Unicode.Hand, Hands.Unicode.Fist },
            new List<Hands.Unicode>() { Hands.Unicode.Hand, Hands.Unicode.Hand },
            new List<Hands.Unicode>() { Hands.Unicode.Hand, Hands.Unicode.Victory },
            new List<Hands.Unicode>() { Hands.Unicode.Victory, Hands.Unicode.Fist },
            new List<Hands.Unicode>() { Hands.Unicode.Victory, Hands.Unicode.Hand },
            new List<Hands.Unicode>() { Hands.Unicode.Victory, Hands.Unicode.Victory },
        }
        private object[] judge_vs2_expects = new object[] {
            new List<Rule.Result>() { Hands.Unicode.Fist, Hands.Unicode.Fist },
            new List<Hands.Unicode>() { Hands.Unicode.Fist, Hands.Unicode.Hand },
            new List<Hands.Unicode>() { Hands.Unicode.Fist, Hands.Unicode.Victory },
            new List<Hands.Unicode>() { Hands.Unicode.Hand, Hands.Unicode.Fist },
            new List<Hands.Unicode>() { Hands.Unicode.Hand, Hands.Unicode.Hand },
            new List<Hands.Unicode>() { Hands.Unicode.Hand, Hands.Unicode.Victory },
            new List<Hands.Unicode>() { Hands.Unicode.Victory, Hands.Unicode.Fist },
            new List<Hands.Unicode>() { Hands.Unicode.Victory, Hands.Unicode.Hand },
            new List<Hands.Unicode>() { Hands.Unicode.Victory, Hands.Unicode.Victory },
        }
        [Test, TestCaseSource("judge_vs2")]
        public void Judge_vsNPC_ReturnResult(Hands.Unicode player, Hands.Unicode npc, int expected)
        {
            var actual = Rule.Judge(player, npc);
            Assert.AreEqual(expected, actual);
        }
        */
    }
}
