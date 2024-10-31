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

    private void Start()
    {
        Type = BlockType.VariableBlock;
    }

    public override void Spawn()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
    }

    public override void Delete()
    {
        // Common delete logic for variable blocks (if any)
    }
}