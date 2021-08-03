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
}
