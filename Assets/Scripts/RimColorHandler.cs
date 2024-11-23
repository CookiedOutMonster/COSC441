using UnityEngine;

public class RimColorHandler : MonoBehaviour
{
    public Color rimColor = Color.white; // Default Rim Color
    public float rimPower = 2.0f;        // Default Rim Power

    private Material material;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer == null)
        {
            Debug.LogWarning("No Renderer found on the GameObject.");
            return;
        }

        material = renderer.material;

        // Check if the shader supports _RimColor
        if (material.HasProperty("_RimColor"))
        {
            Debug.Log("Shader supports '_RimColor'. Setting Rim Color.");
            material.SetColor("_RimColor", rimColor);
        }
        else
        {
            Debug.LogWarning("Shader does not support '_RimColor'. Suppressing errors.");
        }

        // Check if the shader supports _RimPower
        if (material.HasProperty("_RimPower"))
        {
            Debug.Log("Shader supports '_RimPower'. Setting Rim Power.");
            material.SetFloat("_RimPower", rimPower);
        }
        else
        {
            Debug.LogWarning("Shader does not support '_RimPower'. Suppressing errors.");
        }
    }

    void Update()
    {
        // Add runtime updates if needed, but make sure to check for properties
        if (material != null && material.HasProperty("_RimColor"))
        {
            material.SetColor("_RimColor", rimColor);
        }
    }
}
