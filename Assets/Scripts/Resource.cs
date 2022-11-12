using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : SelectorOutput
{
    public enum Type
    {
        Stone,
        Iron,
        Wood
    }

    private Type type;

    public Resource(Type type)
    {
        this.type = type;
    }

    public Type getType()
    {
        return this.type;
    }

    public override void SetOutput(string output)
    {
        throw new System.NotImplementedException();
    }
}
