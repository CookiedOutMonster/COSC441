using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum Text
{
    A,
    B,
    C,
    X,
    Y,
    Z
}

public abstract class TextBlock : Block
{
    public Text Text { get; protected set; } // what actual text does this textblock contain (from the enum)

    protected void Start()
    {
        base.Start();
        Type = BlockType.TextBlock;
    }

    public override void Spawn()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
    }

    public override void Delete()
    {
        // Common delete logic for text blocks (if any)
    }
}
