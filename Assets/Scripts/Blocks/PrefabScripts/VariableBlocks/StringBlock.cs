using UnityEngine;

public class StringVariableBlock : VariableBlock
{
    private void Start()
    {
        // Set the block type and variable type specific to this block
        Type = BlockType.VariableBlock;
        VariableType = VariableType.String;
        
        // Initialize the Value to a default boolean value, like "true" or "false"
        Value = "null";
    }

    public override void Spawn()
    {
        // Custom spawn logic for BooleanVariableBlock, if needed
        Debug.Log("Spawning String Variable Block with default value: " + Value);
    }

    public override void Delete()
    {
        // Custom delete logic for BooleanVariableBlock, if needed
        Debug.Log("Deleting String Variable Block");
    }
}
