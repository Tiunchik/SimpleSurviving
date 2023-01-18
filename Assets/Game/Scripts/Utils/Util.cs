using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Utils
{
    public static class Other
    {
        public static Vector3 Copy(this Vector3 src, float x = float.NaN, float y = float.NaN, float z = float.NaN)
        => new(
            (float.IsNaN(x)) ? src.x : x,
            (float.IsNaN(y)) ? src.y : y,
            (float.IsNaN(z)) ? src.z : z);

        public static List<T> MutableListOf<T>(params T[] initElems)
        {
            var rsl = new List<T>();
            foreach (var elem in initElems) rsl.Add(elem);
            return rsl;
        }

        // Е - может interface что реализует Фактический Component - 
        // то есть, мы Задаём interface и найдём Первый objcet(component) что реализует этот interface.
        public static T FindComponentInTree<T>(Component root)
        {
            var queue = new Queue<Transform>();
            queue.Enqueue(root.transform);
            while (queue.Count != 0)
            {
                var curr = queue.Dequeue();
                if (curr.TryGetComponent<T>(out T component)) return component;
                GetAllChildren(curr).ForEach(queue.Enqueue);
            }
            return default(T);
        }


        public static GameObject FindGameObjectInTree(GameObject root, Predicate<GameObject> predicate)
        {
            var queue = new Queue<Transform>();
            queue.Enqueue(root.transform);
            while (queue.Count != 0)
            {
                var curr = queue.Dequeue();
                var obj = curr.gameObject;
                if (predicate.Invoke(obj)) return obj;
                GetAllChildren(curr).ForEach(queue.Enqueue);
            }
            return null;
        }


        // https://answers.unity.com/questions/594210/get-all-children-gameobjects.html
        public static List<Transform> GetAllChildren(Transform root)
        {
            List<Transform> ts = new List<Transform>();
            foreach (Transform t in root)
            {
                ts.Add(t);
                if (t.childCount > 0) ts.AddRange(GetAllChildren(t));
            }
            return ts;
        }

        // https://answers.unity.com/questions/594210/get-all-children-gameobjects.html
        public static List<GameObject> GetAllChildren(GameObject root)
        {
            List<GameObject> list = new List<GameObject>();
            for (int i = 0; i < root.transform.childCount; i++)
                list.Add(root.transform.GetChild(i).gameObject);
            return list;
        }


        public static void WalkByComponentTree(Component root, Action<Component> doForEachComponent)
            => WalkByComponentTree(root.gameObject, doForEachComponent);

        public static void WalkByComponentTree(GameObject root, Action<Component> doForEachComponent)
        {
            var objectsTree = new Queue<GameObject>();
            objectsTree.Enqueue(root.gameObject);
            while (objectsTree.Count != 0)
            {
                var currObject = objectsTree.Dequeue();
                var currObjectComponents = currObject.GetComponents(typeof(Component));

                foreach (var comp in currObjectComponents) doForEachComponent.Invoke(comp);
                ForEachChildrenGameObject(currObject, objectsTree.Enqueue);
            }
        }
        public static void ForEachChildrenGameObject(GameObject root, Action<GameObject> forEachChild)
        {
            for (int i = 0; i < root.transform.childCount; i++)
                forEachChild.Invoke(root.transform.GetChild(i).gameObject);
        }

    }

// todo - extension like Kotlin|Java - Map.computeIfAbsent(...)
    public static class Dictionary {
        public static V computeIfAbsent<K,V>(this Dictionary<K, V> context, K key, Func<K, V> valueGetter) {
            if(context.TryGetValue(key, out V rsl)) 
                return rsl;
            else return (context[key] = valueGetter(key));
        }
    }
    public static class Reflection
    {

        // public static Dictionary<string, string> GetFieldValues(object obj)
        // {
        //     return obj.GetType()
        //               .GetFields(BindingFlags.Public | BindingFlags.Static)
        //               .Where(f => f.FieldType == typeof(string))
        //               .ToDictionary(f => f.Name,
        //                             f => (string)f.GetValue(null));
        // }

        public static Dictionary<string, T> GetAllStaticConstsForClassByType<T>(Type clazz)
            => clazz
                    .GetFields(BindingFlags.Public | BindingFlags.Static)
                    .Where(f => f.FieldType == typeof(T))
                    .ToDictionary(f => f.Name, f => (T)f.GetValue(null));
    }
}