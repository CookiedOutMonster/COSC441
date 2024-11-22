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

    protected void Start()
    {
        base.Start();
        Type = BlockType.VariableBlock;

        
    }
    // Method to set the value
    public void SetValue(string newValue)
    {
        Value = newValue;
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
