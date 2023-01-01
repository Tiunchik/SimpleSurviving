
using System;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    // TODO - util
    public static Vector3 Copy(Vector3 src, float x = float.NaN, float y = float.NaN, float z = float.NaN)
    => new(
        (float.IsNaN(x)) ? src.x : x,
        (float.IsNaN(y)) ? src.y : y,
        (float.IsNaN(z)) ? src.z : z);

    // Е - может interface что реализует Фактический Component - 
    // то есть, мы Задаём interface и найдём Первый objcet(component) что реализует этот interface.
    public static T findComponentInTree<T>(Component root)
    {
        var queue = new Queue<Transform>();
        queue.Enqueue(root.transform);
        while (queue.Count != 0)
        {
            var curr = queue.Dequeue();
            if (curr.TryGetComponent<T>(out T component))
                return component;
            GetAllChilds(curr).ForEach(queue.Enqueue);
        }
        return default(T);
    } 
    
    public static GameObject findGameObjectInTree(GameObject root, Predicate<GameObject> predicate)
    {
        var queue = new Queue<Transform>();
        queue.Enqueue(root.transform);
        while (queue.Count != 0)
        {
            var curr = queue.Dequeue();
            var go = curr.gameObject;
            if (predicate.Invoke(go))
                return go;
            GetAllChilds(curr).ForEach(queue.Enqueue);
        }
        return null;
    }


    // https://answers.unity.com/questions/594210/get-all-children-gameobjects.html
    public static List<Transform> GetAllChilds(Transform root)
    {
        List<Transform> ts = new List<Transform>();
        foreach (Transform t in root)
        {
            ts.Add(t);
            if (t.childCount > 0) ts.AddRange(GetAllChilds(t));
        }
        return ts;
    }

    // https://answers.unity.com/questions/594210/get-all-children-gameobjects.html
    public static List<GameObject> GetAllChilds(this GameObject root)
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < root.transform.childCount; i++)
            list.Add(root.transform.GetChild(i).gameObject);
        return list;
    }
}