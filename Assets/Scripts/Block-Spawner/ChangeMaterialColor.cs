using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialRimColor : MonoBehaviour
{
    void Start()
    {
        // Get the Renderer component attached to the GameObject
        Renderer renderer = GetComponent<Renderer>();

        // Check if the material supports the "_RimColor" property
        if (renderer != null && renderer.material.HasProperty("_RimColor"))
        {
            // Change the "_RimColor" property to white
            renderer.material.SetColor("_RimColor", Color.white);
        }
        else
        {
            Debug.LogWarning("The material does not have a _RimColor property.");
        }
    }
}


