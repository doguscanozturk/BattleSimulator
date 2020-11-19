using System.Collections.Generic;

namespace Commons.Extensions
{
    public static class ListExtensions
    {
        public static T GetRandomElement<T>(this List<T> list)
        {
            return list[UnityEngine.Random.Range(0, list.Count)];
        }
    }
}