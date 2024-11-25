
using System.Collections;
using UnityEditor;
using UnityEngine;

/*
VarTypeBlock: declare a variable and set its type (int, float, string, bool), that's it
ComparisonBlock: !=, ==, <, >, >=, <=
BoolAlgBlock: and &, or |, not !
AssignmentBlock: =, !=
MathBlock: +, -, *, /

TextBlock: text value to be assigned to a String VarTypeBlock 
NumberBlock: number to be assigned to an Int or Float VarTypeBlock
TrueFalseBlock: true/false value, to be assigned to a Bool VarTypeBlock
*/
public enum BlockType
{
    VarTypeBlock,
    ComparisonBlock,
    BoolAlgBlock,
    AssignmentBlock,
    MathBlock,
    TextBlock,
    NumberBlock,
    TrueFalseBlock
}

public interface IBlock
{
    void Spawn();
    void Delete();
}

public abstract class Block : MonoBehaviour, IBlock
{
    public BlockType Type { get; protected set; }

    private MeshRenderer meshRenderer;
    private Material ogMaterial;
    private Material correctMaterial;
    private Material incorrectMaterial;

    private string correctMaterialPath = "Material/Correct";
    private string incorrectMaterialPath = "Material/Incorrect";

    private bool printErrors = false;

    private AudioSource audioSource;
    public string correctSoundPath = "Audio/CorrectSound";
    public string falseSoundPath = "Audio/FalseSound";

    private AudioClip correctSound;
    private AudioClip falseSound;

    private GameObject markObject;
    private TextMesh textMesh;
    private Vector3 markOffset = new Vector3(0, 0.4f, 0); // Offset from block position

    protected void Awake()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        ogMaterial = meshRenderer.material;
        correctMaterial = Resources.Load<Material>(correctMaterialPath);
        incorrectMaterial = Resources.Load<Material>(incorrectMaterialPath);

        // Create validation mark as an independent GameObject
        markObject = new GameObject("ValidationMark_" + gameObject.name);
        textMesh = markObject.AddComponent<TextMesh>();
        textMesh.alignment = TextAlignment.Center;
        textMesh.anchor = TextAnchor.MiddleCenter;
        textMesh.fontSize = 100;
        textMesh.characterSize = 0.05f;

        // Position the mark
        UpdateMarkPosition();

        // Add billboard effect to always face camera
        markObject.AddComponent<Billboard>();

        markObject.SetActive(false);
    }

    private void UpdateMarkPosition()
    {
        if (markObject != null)
        {
            markObject.transform.position = transform.position + markOffset;
        }
    }

    private void LateUpdate()
    {
        UpdateMarkPosition();
    }

    protected void Start()
    {
        /*
        audioSource = GetComponent<AudioSource>();
        
        if (audioSource == null) {
            Debug.LogError("AudioSource component not found on the GameObject.");
        }
        // Load audio clips from Resources/Audio
        correctSound = Resources.Load<AudioClip>(correctSoundPath);
        falseSound = Resources.Load<AudioClip>(falseSoundPath);
        
        if (correctSound == null) {
            Debug.LogError("Correct sound not found at path: " + correctSoundPath);
        }
        
        if (falseSound == null) {
            Debug.LogError("False sound not found at path: " + falseSoundPath);
        }
        */
    }

    public void Validate(bool isCorrect)
    {
        Material whichMaterial = isCorrect ? correctMaterial : incorrectMaterial;

        if (printErrors)
            Debug.Log("this was called " + meshRenderer + " plus the supposed material " + ogMaterial);

        //ChangeColor(whichMaterial);
        ShowValidationMark(isCorrect);
    }

    private void ShowValidationMark(bool isCorrect)
    {
        if (markObject != null)
        {
            textMesh.text = isCorrect ? "✓" : "X";
            textMesh.color = isCorrect ? Color.green : Color.red;
            markObject.SetActive(true);
        }
    }

    private void ChangeColor(Material material)
    {
        meshRenderer.material = material;

        if (material == incorrectMaterial)
            meshRenderer.material.color = Color.red;

        if (printErrors)
            Debug.Log("Block color set to " + material);
    }

    public void ResetMaterial()
    {
        if (meshRenderer != null)
        {
            meshRenderer.material = ogMaterial;
        }
        if (markObject != null)
        {
            markObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        // Clean up the mark object when the block is destroyed
        if (markObject != null)
        {
            Destroy(markObject);
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

// Billboard script to make text face camera
public class Billboard : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        if (mainCamera != null)
        {
            transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,
                           mainCamera.transform.rotation * Vector3.up);
        }
    }
}
