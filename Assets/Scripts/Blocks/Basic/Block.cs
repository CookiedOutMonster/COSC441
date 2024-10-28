using UnityEngine;
public enum BlockType
{
    VariableBlock,
    ComparisonBlock,
    BoolAlgBlock,
    AssignmentBlock,
    MathBlock
}

// Interface for general block functionality
public interface IBlock
{
    void Spawn();    // Method to spawn the block in the scene
    void Delete();   // Method to delete the block from the scene
}

// Abstract base class for all block types
public abstract class Block : MonoBehaviour, IBlock
{
    public BlockType Type { get; protected set; }
    public abstract Color BlockColor { get; }

    // Define a virtual property for the symbol, to be overridden by derived classes
    protected virtual string Symbol => ""; // Default is empty; override in derived classes

    public abstract void Spawn();
    public abstract void Delete();

    protected void AddSymbolToSides()
    {
        Vector3[] positions = {
        new Vector3(0, 0, 0.51f),
        new Vector3(0, 0, -0.51f),
        new Vector3(-0.51f, 0, 0),
        new Vector3(0.51f, 0, 0),
    };

        Vector3[] rotations = {
        new Vector3(0, 0, 0),
        new Vector3(0, 180, 0),
        new Vector3(0, 90, 0),
        new Vector3(0, -90, 0),
    };

        for (int i = 0; i < positions.Length; i++)
        {
            GameObject textObject = new GameObject("SymbolText");
            textObject.transform.SetParent(this.transform);

            textObject.transform.localPosition = positions[i];
            textObject.transform.localEulerAngles = rotations[i];
            textObject.transform.localScale = new Vector3(1, 1, 1); // Adjust scale as needed

            TextMesh textMesh = textObject.AddComponent<TextMesh>();
            textMesh.text = Symbol;
            textMesh.fontSize = 80;
            textMesh.anchor = TextAnchor.MiddleCenter;
            textMesh.characterSize = 0.1f;
            textMesh.color = Color.black;

            // Optional: Adjust text mesh alignment
            textMesh.transform.localPosition += new Vector3(0, 0, 0.1f); // Slightly offset if needed
        }
    }
}
