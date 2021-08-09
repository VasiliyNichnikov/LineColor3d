using UnityEngine;

public static class GetInterfaceArray
{
    public delegate T ElementArray<T>(int index);
    
    public static T[] Getting<T>(Object[] objects, ElementArray<T> elementArray)
    {
        T[] array = new T[objects.Length];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = elementArray(i);
        }

        return array;
    }
}
