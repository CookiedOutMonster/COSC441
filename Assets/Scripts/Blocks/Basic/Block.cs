using System.Collections;
using UnityEngine;

public enum BlockType
{
    VariableBlock,
    ComparisonBlock,
    BoolAlgBlock,
    AssignmentBlock,
    MathBlock,
    BooleanOperationNot
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
    private AudioSource audioSource;

    // To store the original material
    private Material originalMaterial;

    public string correctSoundPath = "Audio/CorrectSound"; // Path to the correct sound in Resources/Audio
    public string falseSoundPath = "Audio/FalseSound";     // Path to the false sound in Resources/Audio

    private AudioClip correctSound;
    private AudioClip falseSound;

    protected void Start()
    {
        blockRenderer = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();

        if (blockRenderer == null)
        {
            Debug.LogError("MeshRenderer component not found on the GameObject.");
        }

        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on the GameObject.");
        }

        // Store the original material of the block (this could be the prefab's material)
        originalMaterial = blockRenderer.material;
        Debug.Log(originalMaterial);

        // Load audio clips from Resources/Audio
        correctSound = Resources.Load<AudioClip>(correctSoundPath);
        falseSound = Resources.Load<AudioClip>(falseSoundPath);

        if (correctSound == null)
        {
            Debug.LogError("Correct sound not found at path: " + correctSoundPath);
        }

        if (falseSound == null)
        {
            Debug.LogError("False sound not found at path: " + falseSoundPath);
        }
    }

    public void Correct()
    {
        if (blockRenderer != null)
        {
            // Temporarily change the color to green and play the sound
            StartCoroutine(ChangeColorTemporarily(Color.green, 0.5f));
            PlaySound(correctSound);
        }
    }

    public void False()
    {
        if (blockRenderer != null)
        {
            // Temporarily change the color to red and play the sound
            StartCoroutine(ChangeColorTemporarily(Color.red, 1f));
            PlaySound(falseSound);
        }
    }

    private IEnumerator ChangeColorTemporarily(Color color, float duration)
    {
        // Temporarily change the block color
        blockRenderer.material.color = color;
        Debug.Log("Block color set to " + color.ToString() + " for " + duration + " seconds.");

        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // After the duration, reset the material back to the original material (no change in appearance)
        blockRenderer.material = originalMaterial;
        Debug.Log("Block color reset to original.");
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public abstract void Spawn();
    public abstract void Delete();
}
