using NUnit.Framework;
using Janken;

namespace Tests
{
    public class HandsTest
    {
        [SetUp]
        public void Setup() {}

        [TestCase(Janken.Hands.Unicode.Fist, 0x270A)]
        [TestCase(Janken.Hands.Unicode.Hand, 0x270B)]
        [TestCase(Janken.Hands.Unicode.Victory, 0x270C)]
        public void Unicode_Match_ReferenceValue(Janken.Hands.Unicode actual, int expected)
        {
            Assert.AreEqual(expected, (int)actual);
        }

        [TestCase(Janken.Hands.Unicode.Fist, Janken.Hands.Unicode.Hand)]
        [TestCase(Janken.Hands.Unicode.Hand, Janken.Hands.Unicode.Victory)]
        [TestCase(Janken.Hands.Unicode.Victory, Janken.Hands.Unicode.Fist)]
        public void Next_Match_ReturnNextValue(Janken.Hands.Unicode input, Janken.Hands.Unicode expected)
        {
            var hands = new Janken.Hands();
            var actual = hands.Next(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(Janken.Hands.Unicode.Fist, Janken.Hands.Unicode.Victory)]
        [TestCase(Janken.Hands.Unicode.Hand, Janken.Hands.Unicode.Fist)]
        [TestCase(Janken.Hands.Unicode.Victory, Janken.Hands.Unicode.Hand)]
        public void Previous_Match_ReturnNextValue(Janken.Hands.Unicode input, Janken.Hands.Unicode expected)
        {
            var hands = new Janken.Hands();
            var actual = hands.Previous(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(Janken.Hands.Unicode.Fist, Janken.Hands.Unicode.Hand)]
        [TestCase(Janken.Hands.Unicode.Hand, Janken.Hands.Unicode.Victory)]
        [TestCase(Janken.Hands.Unicode.Victory, Janken.Hands.Unicode.Fist)]
        public void Winable_Match_ReturnNextValue(Janken.Hands.Unicode input, Janken.Hands.Unicode expected)
        {
            var hands = new Janken.Hands();
            var actual = hands.Winable(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(Janken.Hands.Unicode.Fist, Janken.Hands.Unicode.Victory)]
        [TestCase(Janken.Hands.Unicode.Hand, Janken.Hands.Unicode.Fist)]
        [TestCase(Janken.Hands.Unicode.Victory, Janken.Hands.Unicode.Hand)]
        public void Losable_Match_ReturnNextValue(Janken.Hands.Unicode input, Janken.Hands.Unicode expected)
        {
            var hands = new Janken.Hands();
            var actual = hands.Losable(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(Janken.Hands.Unicode.Fist, Janken.Hands.Unicode.Fist)]
        [TestCase(Janken.Hands.Unicode.Hand, Janken.Hands.Unicode.Hand)]
        [TestCase(Janken.Hands.Unicode.Victory, Janken.Hands.Unicode.Victory)]
        public void Drawable_Match_ReturnNextValue(Janken.Hands.Unicode input, Janken.Hands.Unicode expected)
        {
            var hands = new Janken.Hands();
            var actual = hands.Drawable(input);
            Assert.AreEqual(expected, actual);
        }
    }
}
