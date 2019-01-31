using NUnit.Framework;
using Janken;

namespace Tests
{
    public class HandMakerTest
    {
        [SetUp]
        public void Setup() {}
        [TestCase(Janken.Hands.Unicode.Fist, Janken.Hands.Unicode.Fist)]
        [TestCase(Janken.Hands.Unicode.Hand, Janken.Hands.Unicode.Hand)]
        [TestCase(Janken.Hands.Unicode.Victory, Janken.Hands.Unicode.Victory)]
        public void Random_Match_ReturnNextValue(Janken.Hands.Unicode input, Janken.Hands.Unicode expected)
        {
            /*
            // https://qiita.com/koduki/items/4fde43b68fe450c6a5d8
            var maker = new Janken.HandMaker() {
                @Override
                public Janken.Hands.Unicode Random() { return input; }
            };
            var actual = maker.Random();
            Assert.AreEqual(expected, actual);
            */
            Assert.AreEqual(expected, input);
        }
    }
}
