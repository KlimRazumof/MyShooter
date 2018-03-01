using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public static class BoundsExtensions
    {
        /// <summary>
        /// Метод расширения для определения центра объекта в зависимости от положения его тела.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Bounds GroundBounds(this Bounds a, Bounds b)
        {
            var max = Vector3.Max(a.max, b.max);
            var min = Vector3.Min(a.min, b.min);

            a = new Bounds((max + min) * 0.5F, max - min);

            return a;
        }

    }

}

