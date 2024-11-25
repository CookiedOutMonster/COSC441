using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Number
{
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Decimal
}

public abstract class NumberBlock : Block
{
    public Number Number { get; protected set; } // what actual number it is (or if it's a decimal), uses the enum

    protected void Start()
    {
        base.Start();
        Type = BlockType.NumberBlock;
    }

    public override void Spawn()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
    }

    public override void Delete()
    {
        // Common delete logic for number blocks (if any)
    }
}
