using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Value
{
    True,
    False
}

public abstract class TrueFalseBlock : Block
{
    public Value Value { get; protected set; } // whether it's true or false (from the enum)

    protected void Start()
    {
        base.Start();
        Type = BlockType.TrueFalseBlock;
    }

    public override void Spawn()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
    }

    public override void Delete()
    {
        // Common delete logic for truefalse blocks (if any)
    }
}
