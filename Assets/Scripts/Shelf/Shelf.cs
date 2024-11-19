using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Shelf : MonoBehaviour
{
    [Header("Detection Settings")]
    [SerializeField] private float detectionHeight = 0.1f; // Height above the shelf to detect blocks.
    [SerializeField] private LayerMask blockLayer; // The layer mask for the blocks that are detectable.
    [SerializeField] private float snapThreshold = 0.1f; // The distance threshold for snapping blocks to the surface.
    [SerializeField] private Vector3 snapOffset = new Vector3(0, 0.5f, 0); // Offset applied when snapping the block to the surface.

    private BoxCollider rectangleCollider; // Reference to the BoxCollider attached to this object.
    private List<Transform> detectedBlocks = new List<Transform>(); // List of blocks detected above the shelf.

  private void Start()
    { 
        rectangleCollider = GetComponent<BoxCollider>();
        //Debug.Log(rectangleCollider);
        //Debug.Log(rectangleCollider.bounds);
    }

    // Update method that runs every frame
    private void Update()
    {
        DetectBlocksAbove(); // Detect blocks above the shelf.
        //SnapBlocksToSurface(); // Snap detected blocks to the surface of the shelf.
        //SortBlocksLeftToRight(); // Sort detected blocks from left to right.
        //PrintOrderedBlocks(); // Print the list of sorted blocks (for debugging).
    }

    private void OnDrawGizmos()
    {
        if (rectangleCollider != null)
        {
            // Get the bounds of the BoxCollider in world space
            Bounds colliderBounds = rectangleCollider.bounds;

            // Set the Gizmo color to red
            Gizmos.color = Color.yellow;

            // Draw the wireframe cube to visualize the BoxCollider bounds
            Gizmos.DrawWireCube(colliderBounds.center, colliderBounds.size);
        }
    }

    // Detect blocks above the shelf within the specified detection area.
    private void DetectBlocksAbove()
    {
        detectedBlocks.Clear(); // Clear the previous list of detected blocks.
        
        // Calculate the detection bounds for the area above the shelf.
        Bounds detectBounds = rectangleCollider.bounds;
        detectBounds.center += Vector3.up * detectionHeight; // Offset the detection bounds upwards based on the detectionHeight.
        
        // Perform an OverlapBox check to detect colliders (blocks) in the defined bounds.
        Collider[] hitColliders = Physics.OverlapBox(
            detectBounds.center, // Center of the detection area.
            detectBounds.extents, // Size of the detection area (half of the total width, height, and depth).
            transform.rotation, // Rotation of the detection area (aligned with the shelf's rotation).
            blockLayer // Only detect objects on the specified blockLayer.
        );

        // Iterate through the detected colliders and check if they are valid blocks above the shelf.
        foreach (Collider col in hitColliders)
        {
            //Debug.Log(col); // this prints out the name of the collider 
            
            // issue #1 is the block is not above the rectangle 
            if (IsBlockAboveRectangle(col.transform)) // Check if the block is above the shelf's rectangle.
            {
                Debug.Log(col);
                detectedBlocks.Add(col.transform); // Add the block to the list of detected blocks.
            }
            else
            {
                //Debug.Log("we are here");
            }
            
        }
    }

    // Check if a given block is above the shelf's rectangle area.
    private bool IsBlockAboveRectangle(Transform block)
    {
        // get position of block 
        Vector3 blockPosition = block.position;
        
        // Convert block position to the local space of the shelf to check if it's within the bounds.
        Vector3 localPos = transform.InverseTransformPoint(blockPosition);
        Bounds localBounds = rectangleCollider.bounds;

        Debug.Log(localBounds);

        localBounds.center = transform.InverseTransformPoint(localBounds.center);

        //Debug.Log(localPos);
        // Check if the block is inside the shelf's rectangle bounds (on the X and Z axes) and above it on the Y axis.
        bool isAbove = Mathf.Abs(localPos.x) <= localBounds.extents.x &&
                    Mathf.Abs(localPos.z) <= localBounds.extents.z &&
                    blockPosition.y > transform.position.y;

        Debug.Log($"Block Above Rectangle: {isAbove}");

        return isAbove;
    }

    // Snap detected blocks to the shelf's surface within a defined threshold.
    private void SnapBlocksToSurface()
    {
        foreach (Transform block in detectedBlocks)
        {
            Vector3 targetPosition = new Vector3(
                block.position.x, // Keep the X position unchanged.
                transform.position.y + snapOffset.y, // Adjust the Y position based on the snapOffset.
                block.position.z // Keep the Z position unchanged.
            );

            // If the block is within the snapping threshold, snap it to the target position.
            if (Vector3.Distance(block.position, targetPosition) <= snapThreshold)
            {
                Debug.Log("This happened");
                block.position = targetPosition;
            }
            else
            {
                Debug.Log("Snapping did not happen");
            }
        }
    }

    // Sort the detected blocks from left to right based on their X position in local space.
    private void SortBlocksLeftToRight()
    {
        // Sort the blocks based on their local X position (relative to the shelf).
        detectedBlocks = detectedBlocks
            .OrderBy(block => transform.InverseTransformPoint(block.position).x)
            .ToList();

        // Now detectedBlocks contains blocks ordered from left to right in local space.
        // Optionally, you can perform further processing on the sorted blocks here.
        for (int i = 0; i < detectedBlocks.Count; i++)
        {
            Transform block = detectedBlocks[i];
            // You can access the block's components or properties here for further processing.
            // Example: block.GetComponent<BlockProperties>()
        }
    }

    // Public method to get the list of ordered blocks.
    public List<Transform> GetOrderedBlocks()
    {
        return new List<Transform>(detectedBlocks); // Return a copy of the list of ordered blocks.
    }
    
    // Code to print the number of ordered blocks (for debugging purposes).
    public void PrintOrderedBlocks()
    {
        List<Transform> blocks = GetOrderedBlocks(); // Get the ordered blocks.
        Debug.Log(blocks.Count); // Print the number of ordered blocks in the debug console.
    }
}
