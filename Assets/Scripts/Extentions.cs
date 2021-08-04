using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extentions
{
    public static T[] Shuffle<T>(this T[] array)
    {
        for(int i = 0; i < array.Length; i++)
        {
            T temp = array[i];
            int j = Random.Range(0, array.Length);
            array[i] = array[j];
            array[j] = temp;
        }
        return array;
    }

    public static T[] Remove<T>(this T[] array, T a)
    {
        var result = new List<T>(array);
        result.Remove(a);
        return result.ToArray();
    }

    public static Color ChangeAlpha(this Color color, float a)
    {
        return new Color(color.r, color.g, color.b, a);
    }
}
