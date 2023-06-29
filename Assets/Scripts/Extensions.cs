using System;
using System.Collections.Generic;

public static class Extensions
{
    public static void ForEach<T>(this IEnumerable<T> sequence, Action<T, int> action)
    {
        int i = 0;
        foreach (T item in sequence)
        {
            action(item, i);
            i++;
        }
    }
}
