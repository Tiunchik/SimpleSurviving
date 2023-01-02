using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/**
    constructor()
    constructor(vararg Type... required for found)
    Fire Get<Fire>()
        * exception если не нашли
    List<Fire> GetAll<Fire>()
    void Refresh()
    void Start()
*/
public class TreeComponentStore
{
    // https://stackoverflow.com/questions/1273139/c-sharp-java-hashmap-equivalent
    /**
        key = ComponentType
        val = ComponentObject
    */
    private Dictionary<Type, List<Component>> table = new();
    private Type[] requiredComponents;
    private GameObject root;

    public TreeComponentStore() { }
    public TreeComponentStore(params Type[] requiredComponents)
        => this.requiredComponents = requiredComponents;

    /// Invoke this method in ScriptComponent.Start().
    public void Start(GameObject root)
    {
        this.root = root;
        Utils.walkByComponentTree(root, this.Add);
        foreach (var item in requiredComponents ?? Enumerable.Empty<Type>())
            if (!table.ContainsKey(item))
                throw new Exception($"Component {item} is not present in Tree of GameObject='{root.name}'!");
    }


    public void Add(Component componentObject)
    {
        var componentType = componentObject.GetType();
        this.RegistryPair(componentObject, componentType);
        foreach (var componentInterface in componentType.GetInterfaces())
            this.RegistryPair(componentObject, componentInterface);
    }

    private void RegistryPair(Component componentObject, Type componentType)
    {
        if (table.TryGetValue(componentType, out List<Component> compList))
            compList.Add(componentObject);
        else table.Add(componentType, Utils.MutableListOf(componentObject));
    }


    /// как кастить к типам в C# = http://www.java2s.com/Code/CSharp/Reflection/ConverttypefrominitialValue.htm
    public T Get<T>(bool nullable = false)
    {
        var componentTypeExpected = typeof(T);
        if (table.TryGetValue(componentTypeExpected, out List<Component> compList))
        {
            if (!nullable && compList.Count == 0)
                throw new Exception($"Component {componentTypeExpected} not found for {root.name}!");

            // object rsl = compList[0];
            // Debug.Log($"componentTypeExpected = {componentTypeExpected} :: rsl = {rsl}");
            // return (T)rsl;
            return (T)(object)compList[0];
        }
        throw new Exception($"Component {componentTypeExpected} not found for {root.name}!");
    }

    public void Refresh() { table.Clear(); Start(this.root); }


}
