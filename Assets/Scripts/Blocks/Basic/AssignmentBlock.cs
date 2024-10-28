using UnityEngine;
     public enum AssignmentType
    {
        Equals,
        NotEquals
    }
public abstract class AssignmentBlock : Block
{
    // Property for Assignment type; set in derived classes
    public AssignmentType AssignmentType { get; protected set; }
    public override Color BlockColor => Color.red;
    protected override string Symbol => "?";

    private void Start()
    {
        Type = BlockType.AssignmentBlock;
    }

    public override void Spawn()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = BlockColor;
        }
        AddSymbolToSides();
        // Common spawn logic for assignment blocks (if any)
    }

    public override void Delete()
    {
        // Common delete logic for assignment blocks (if any)
    }
}
