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

    // ~ for visual feedback
    // ogMaterial is the current material on any given block 
    private MeshRenderer meshRenderer;
    private Material ogMaterial;
    // need reference to the correct/false material 
    private Material correctMaterial;
    private Material incorrectMaterial;

    private string correctMaterialPath = "Material/Correct";
    private string incorrectMaterialPath = "Material/Incorrect";


    // ~ for debugging 
    private bool printErrors = false;



    // ~ for audio feedback
    private AudioSource audioSource;
    public string correctSoundPath = "Audio/CorrectSound"; // Path to the correct sound in Resources/Audio
    public string falseSoundPath = "Audio/FalseSound";     // Path to the false sound in Resources/Audio

    private AudioClip correctSound;
    private AudioClip falseSound;

    protected void Awake()
    {
        // setting up renderer, getting og material 
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        ogMaterial = meshRenderer.material;
        // need to get Correct and Incorrect material 
        correctMaterial = Resources.Load<Material>(correctMaterialPath);
        incorrectMaterial = Resources.Load<Material>(incorrectMaterialPath);
    }

    protected void Start()
    {
        /*
        audioSource = GetComponent<AudioSource>();

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
        */

    }

    public void Validate(bool isCorrect)
    {
        Material whichMaterial = isCorrect ? correctMaterial : incorrectMaterial;

        if (printErrors)
            Debug.Log("this was called " + meshRenderer + " plus the supposed material " + ogMaterial);

        ChangeColor(whichMaterial, 2f);

    }

    private void ChangeColor(Material material, float duration)
    {
        // Temporarily change the block color
        //blockRenderer.material.color = color;
        meshRenderer.material = material;

        if (material == incorrectMaterial)
            meshRenderer.material.color = Color.red;

        if (printErrors)
            Debug.Log("Block color set to " + material + " for " + duration + " seconds.");

    }

    public void ResetMaterial()
    {
        if (meshRenderer != null)
        {
            meshRenderer.material = ogMaterial;
        }
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
