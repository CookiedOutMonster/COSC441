using System.Collections;
using UnityEngine;

public enum BlockType
{
    VariableBlock,
    ComparisonBlock,
    BoolAlgBlock,
    AssignmentBlock,
    MathBlock
}
public interface IBlock
{
    void Spawn();   
    void Delete();   
}

// Abstract base class for all block types
public abstract class Block : MonoBehaviour, IBlock
{
    public BlockType Type { get; protected set; }
    private MeshRenderer blockRenderer;

    protected void Start()
    {
        blockRenderer = GetComponent<MeshRenderer>();

        if (blockRenderer == null)
        {
            Debug.LogError("MeshRenderer component not found on the GameObject.");
        }
    }

    public void Correct()
    {
        if (blockRenderer != null)
        {
            StartCoroutine(ChangeColorTemporarily(Color.green, 1f));
        }
    }

    public void False()
    {
        if (blockRenderer != null)
        {
            StartCoroutine(ChangeColorTemporarily(Color.red, 1f));
        }
    }

    private IEnumerator ChangeColorTemporarily(Color color, float duration)
    {
        blockRenderer.material.SetColor("_BaseColor", color);
        Debug.Log("Block color set to " + color.ToString() + " for " + duration + " seconds.");
        yield return new WaitForSeconds(duration);
        blockRenderer.material.SetColor("_BaseColor", Color.white);
        Debug.Log("Block color reset to default.");
    }

    public abstract void Spawn();
    public abstract void Delete();
}
