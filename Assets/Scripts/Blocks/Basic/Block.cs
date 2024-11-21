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
    private AudioSource audioSource;

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
            StartCoroutine(ChangeColorTemporarily(Color.green, 0.5f));
            PlaySound(correctSound);
        }
    }

    public void False()
    {
        if (blockRenderer != null)
        {
            StartCoroutine(ChangeColorTemporarily(Color.red, 1f));
            PlaySound(falseSound);
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
