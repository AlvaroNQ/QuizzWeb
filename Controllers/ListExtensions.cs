using System;
using System.Collections.Generic;

public static class ListExtensions
{
    public static void RemoveDuplicates<T>(this List<T> list) where T : IEquatable<T>
    {
        int cont;
        for( int i=0; i<list.Count; i++)
        {
            cont = 0;
            for (int j = 0; j < list.Count; j++)
            {
                if (list[i].Equals(list[j]))
                    cont++;
                if (cont > 1)
                {
                    list.RemoveAt(j);
                    cont = 1;
                }
            }
        }
    }
}
