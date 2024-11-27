using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Ensure this is included for RawImage
using TMPro;

public class FeedBack : MonoBehaviour
{
    // Reference to the RawImage component
    [SerializeField] private RawImage rawImage;
    [SerializeField] private TextMeshProUGUI message;

    // probably not the best way to do this but idgaf
    void Start()
    {
        HideIncorrectImage();
        HideMessage();
    }

    public void ShowError(string error)
    {
        ShowIncorectImage();
        ShowMessage(error);
    }

    // Function to show the RawImage
    private void ShowIncorectImage()
    {
        if (rawImage != null)
        {
            rawImage.enabled = true;  // Enable the RawImage to make it visible
        }
        else
        {
            Debug.LogWarning("Could not find RawImage");
        }
    }

    // Function to hide the RawImage
    private void HideIncorrectImage()
    {
        if (rawImage != null)
        {
            rawImage.enabled = false;  // Disable the RawImage to make it invisible
        }
    }

    // Function to show the TextMeshProUGUI message
    private void ShowMessage(string text)
    {
        if (message != null)
        {
            message.enabled = true;  // Make the TextMeshProUGUI visible
            message.text = text;  // Set the text to whatever you want to display
        }
        else
        {
            Debug.LogWarning("Could not find TextMeshProUGUI component");
        }
    }

    // Function to hide the TextMeshProUGUI message
    private void HideMessage()
    {
        if (message != null)
        {
            message.enabled = false;  // Make the TextMeshProUGUI invisible
        }
    }

    // Public method to hide both the error image and the message
    public void HideError()
    {
        HideIncorrectImage();  // Hide the RawImage (error image)
        HideMessage();         // Hide the TextMeshProUGUI message
    }
}
