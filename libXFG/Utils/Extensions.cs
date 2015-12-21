using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFG.Utils
{
    public static class Extensions
    {
        /// <summary>
        /// Fills an array with default value.
        /// </summary>
        /// <typeparam name="T">Type of array</typeparam>
        /// <param name="array">Actual array</param>
        /// <param name="defaultVaue">Default value</param>
        public static void Fill<T>(this T[] array, T defaultVaue)
        {
            if (array == null)
                return;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = defaultVaue;
            }
        }
        public static void Fill<T>(this T[] array,int from, int to, T defaultVaue)
        {
            if (array == null)
                return;
            for (int i = from; i <to; i++)
            {
                array[i] = defaultVaue;
            }
        }
        public static T[] CopyOf<T>(this T[] array, int from)
        {
            T[] res = new T[array.Length-from];
            Array.Copy(array, from, res, 0, array.Length - from);
            return res;
        }
        public static T[] CopyOfRange<T>(this T[] array, int from,int to)
        {
            T[] res = new T[to - from];
            Array.Copy(array, from, res, 0, to - from);
            return res;
        }
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
}

