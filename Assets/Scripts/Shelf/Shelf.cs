using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Shelf : MonoBehaviour
{
    // Header attributes in Unity inspector for better organization of variables.
    [Header("Detection Settings")]
    [SerializeField] private float detectionHeight = 1f;  // The height from the shelf to detect blocks above it

    [Header("Optional Snapping")]
    [SerializeField] private bool enableSnapping = true;  // Determines whether snapping functionality is enabled
    [SerializeField] private float snapHeight = 0.1f;     // The height offset at which blocks will snap above the shelf surface
    [SerializeField] private float snapThreshold = 0.5f;  // The distance within which the blocks will snap to the shelf surface

    [Header("Debug")]
    [SerializeField] private bool showDebugLogs;  // Flag to enable/disable debug log messages

    // Private variables
    private BoxCollider shelfCollider;  // The collider attached to the shelf object for detection
    private List<Transform> detectedBlocks = new List<Transform>();  // List of blocks currently detected above the shelf
    private Stack<GameObject> sortedBlocks = new Stack<GameObject>();  // Stack to store sorted blocks from left to right

    private void Start()
    {
        // Get the BoxCollider attached to the shelf object
        shelfCollider = GetComponent<BoxCollider>();
        if (shelfCollider == null)
        {
            Debug.LogError("No BoxCollider found on " + gameObject.name);  // If no collider is found, log an error
            return;
        }

        // Optionally print debug info if enabled
        if (showDebugLogs) PrintDebugInfo();
    }

    // Debug information about the shelf, printed to the console
    private void PrintDebugInfo()
    {
        Debug.Log("=== Shelf Debug Info ===");
        Debug.Log($"Shelf Position: {transform.position}");  // Log position of the shelf
        Debug.Log($"Shelf Scale: {transform.lossyScale}");  // Log scale of the shelf
        Debug.Log($"Collider Size: {shelfCollider.size}");  // Log size of the shelf collider
    }

    private void Update()
    {
        // Detect blocks that are above the shelf
        DetectBlocksAbove();

        // Sort the detected blocks from left to right based on their X position
        SortBlocksLeftToRight();

        // If snapping is enabled, snap blocks to the shelf
        if (enableSnapping) SnapBlocksToShelf();

        // Retrieve the sorted blocks and optionally print debug logs
        Stack<GameObject> arms = GetSortedBlocksLeftToRight();

        // Log the sorted blocks from left to right
        if (showDebugLogs && sortedBlocks.Count > 0)
        {
            Debug.Log("Shelf Blocks from left to right:");
            while (arms.Count > 0)
            {
                GameObject block = arms.Pop();
                Debug.Log($"Shelf {block.name} at position {block.transform.position} eskeddit");
            }
        }
    }

    // Detect blocks that are above the shelf by performing an OverlapBox check
    private void DetectBlocksAbove()
    {
        detectedBlocks.Clear();  // Clear previous detection results

        // Calculate the top of the shelf (based on the collider's center and size)
        Vector3 shelfTop = transform.TransformPoint(shelfCollider.center);
        shelfTop.y += (transform.lossyScale.y * shelfCollider.size.y * 0.5f);  // Adjust to the top of the shelf

        // Define the center and size for the detection box above the shelf
        Vector3 detectionCenter = shelfTop + (Vector3.up * detectionHeight * 0.5f);
        Vector3 detectionSize = new Vector3(
            transform.lossyScale.x * shelfCollider.size.x,
            detectionHeight,  // Height of the detection box
            transform.lossyScale.z * shelfCollider.size.z
        );

        // Perform an OverlapBox check to detect colliders above the shelf
        Collider[] hitColliders = Physics.OverlapBox(
            detectionCenter,
            detectionSize * 0.5f,  // Half the size of the detection box
            transform.rotation
        );

        // Add any detected colliders (blocks) to the list of detected blocks, skipping the shelf itself
        foreach (Collider col in hitColliders)
        {
            if (col.transform == transform) continue;  // Skip the shelf object itself
            detectedBlocks.Add(col.transform);  // Add the detected block to the list
        }
    }

    // Sort the detected blocks from left to right based on their X position
    private void SortBlocksLeftToRight()
    {
        sortedBlocks = new Stack<GameObject>(
            detectedBlocks
                .OrderBy(block =>
                {
                    Vector3 localPos = transform.InverseTransformPoint(block.gameObject.transform.position);
                    return localPos.x;  // Sort based on the X position relative to the shelf
                })
                .Select(block => block.gameObject)  // Select the GameObjects from the transforms
                .Reverse()  // Reverse the order to have left-to-right sorting
        );
    }

    // Snap detected blocks to the shelf at a specific Y position, if they are close enough
    private void SnapBlocksToShelf()
    {
        Vector3 shelfTop = transform.TransformPoint(shelfCollider.center);
        shelfTop.y += (transform.lossyScale.y * shelfCollider.size.y * 0.5f);  // Get the top of the shelf
        float snapY = shelfTop.y + snapHeight;  // The Y position where blocks should snap to

        // Loop through all detected blocks and snap their Y position if within the threshold
        foreach (Transform block in detectedBlocks)
        {
            Vector3 blockPos = block.position;
            if (Mathf.Abs(blockPos.y - snapY) <= snapThreshold)
            {
                // Snap only the Y position, keep X and Z unchanged
                block.position = new Vector3(blockPos.x, snapY, blockPos.z);
            }
        }
    }

    // Public methods for external access

    // Returns a copy of the detected blocks (to avoid external modification of internal list)
    public List<Transform> GetDetectedBlocks()
    {
        return new List<Transform>(detectedBlocks);
    }

    // Returns a copy of the sorted blocks (to avoid external modification of internal stack)
    public Stack<GameObject> GetSortedBlocksLeftToRight()
    {
        return new Stack<GameObject>(new Stack<GameObject>(sortedBlocks));
    }

    // Returns the number of blocks detected above the shelf
    public int GetBlockCount()
    {
        return detectedBlocks.Count;
    }

    /*
    // This method is commented out, but would allow getting a block by index from the sorted stack
    public Transform GetBlockAtIndex(int index)
    {
        if (index >= 0 && index < sortedBlocks.Count)
            return sortedBlocks[index];  // Return the block at the specified index
        return null;  // Return null if the index is invalid
    }
    */
}
