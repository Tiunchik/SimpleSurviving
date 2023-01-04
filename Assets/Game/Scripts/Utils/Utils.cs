using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Utils
{
    // outside of package use: using static Game.Scripts.Utils.Utils;
    public static class Utils
    {
        public static Vector3 Copy(Vector3 src, float x = float.NaN, float y = float.NaN, float z = float.NaN)
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
                GetAllChilds(curr).ForEach(queue.Enqueue);
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
        public static List<GameObject> GetAllChilds(GameObject root)
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
    public static class UtilsReflection
    {

        /// something like Java cast...

        // public static T Convert<T>(object initialValue) => Convert<T>(initialValue);
        // public static T Convert<T>(object initialValue, T convertToType)
        // {
        //     Type targetType = (convertToType is Type) ? convertToType as Type : typeof(T);
        //     Type initialType = (initialValue != null) ? initialValue.GetType() : null;

        //     var converter = System.ComponentModel.TypeDescriptor.GetConverter(targetType);

        //     if (converter == null || !converter.CanConvertFrom(initialType))
        //         throw new ApplicationException(string.Format("Could not convert from {0} to {1}", initialType, targetType));

        //     return (T)converter.ConvertFrom(initialValue);
        // }
    }
}