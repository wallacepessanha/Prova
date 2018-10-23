using System;
using System.Collections.Generic;
using System.Text;

namespace Lvmendes.Util
{
    public static class Parte
    {
        public static T GetRandom<T>(this List<T> list)
        {
            return list[(int)(DateTime.Now.Ticks % list.Count)];
        }
    }
}
