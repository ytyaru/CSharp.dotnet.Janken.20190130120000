using System;
using System.Linq;
using System.Collections.Generic;

namespace Janken
{
    class HandMaker {
        /*
        /// <summary>ランダムな手を返す</summary>
        /// <returns>ランダムな手</returns>
        public Hands.Unicode Random() {
            var r = new System.Random((int)DateTime.Now.Ticks);
            var random = r.Next(Enum.GetNames(typeof(Hands.Unicode)).Length));// 0〜2
            var hands = new Hands();
            var hand = Hands.Unicode.Fist;
            for (var i = 0; i < random; i++) {
                hand = hands.Next(hand);
            }
        }
        */

        /// <summary>ランダムな手を返す</summary>
        /// <returns>ランダムな手</returns>
        public Hands.Unicode Random() {
            System.Random r = new System.Random((int)DateTime.Now.Ticks);
            var random = r.Next(Enum.GetNames(typeof(Hands.Unicode)).Length);// 0〜2
            var hand = (int)Hands.Unicode.Fist + random;
            return (Hands.Unicode)Enum.ToObject(typeof(Hands.Unicode), hand);
        }
    }
}
