using UnityEngine;

     public enum VariableType
    {
        Boolean,
        Float,
        Integer,
        String
    }
public abstract class VariableBlock : Block
{
    // Properties for variable block; set in derived classes
    public string Value { get; protected set; }
    public VariableType VariableType { get; protected set; }
    public override Color BlockColor => Color.blue;
    protected override string Symbol => "?";

    private void Start()
    {
        Type = BlockType.VariableBlock;
    }

    public override void Spawn()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = BlockColor;
        }
        AddSymbolToSides();
        // Common spawn logic for variable blocks (if any)
    }

    public override void Delete()
    {
        // Common delete logic for variable blocks (if any)
    }
}
