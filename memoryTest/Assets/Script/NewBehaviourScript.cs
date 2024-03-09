using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public static class Extensions
{
    public static T[] RemoveAt<T>(this T[] source, int index)
    {
        return source.Where((_, i) => i != index).ToArray();
    }
}

public static class StaticCount
{
    public static int count = 0, c = 0, c1 = 0;
}
