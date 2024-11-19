using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class BlockDetector : MonoBehaviour
{
    [Header("Detection Settings")]
    [SerializeField] private float detectionHeight = 1f;
    
    [Header("Optional Snapping")]
    [SerializeField] private bool enableSnapping = false;
    [SerializeField] private float snapHeight = 0.1f;  // Height above shelf surface
    [SerializeField] private float snapThreshold = 0.5f;  // How close block needs to be to snap
    
    [Header("Debug")]
    [SerializeField] private bool showDebugGizmos = true;
    [SerializeField] private bool showDebugLogs = true;
    
    private BoxCollider shelfCollider;
    private List<Transform> detectedBlocks = new List<Transform>();
    private List<Transform> sortedBlocks = new List<Transform>();

    private void Start()
    {
        shelfCollider = GetComponent<BoxCollider>();
        if (shelfCollider == null)
        {
            Debug.LogError("No BoxCollider found on " + gameObject.name);
            return;
        }
        
        if (showDebugLogs) PrintDebugInfo();
    }

    private void PrintDebugInfo()
    {
        Debug.Log("=== Shelf Debug Info ===");
        Debug.Log($"Shelf Position: {transform.position}");
        Debug.Log($"Shelf Scale: {transform.lossyScale}");
        Debug.Log($"Collider Size: {shelfCollider.size}");
    }

    private void Update()
    {
        DetectBlocksAbove();
        SortBlocksLeftToRight();
        if (enableSnapping) SnapBlocksToShelf();
        
        if (showDebugLogs && sortedBlocks.Count > 0)
        {
            Debug.Log("Blocks from left to right:");
            for (int i = 0; i < sortedBlocks.Count; i++)
            {
                Debug.Log($"{i + 1}. {sortedBlocks[i].name} at position {sortedBlocks[i].position} Gerren is cool");
            }
        }
    }

    private void DetectBlocksAbove()
    {
        detectedBlocks.Clear();
        
        Vector3 shelfTop = transform.TransformPoint(shelfCollider.center);
        shelfTop.y += (transform.lossyScale.y * shelfCollider.size.y * 0.5f);
        
        Vector3 detectionCenter = shelfTop + (Vector3.up * detectionHeight * 0.5f);
        Vector3 detectionSize = new Vector3(
            transform.lossyScale.x * shelfCollider.size.x,
            detectionHeight,
            transform.lossyScale.z * shelfCollider.size.z
        );

        Collider[] hitColliders = Physics.OverlapBox(
            detectionCenter,
            detectionSize * 0.5f,
            transform.rotation
        );

        foreach (Collider col in hitColliders)
        {
            if (col.transform == transform) continue;
            detectedBlocks.Add(col.transform);
        }
    }

    private void SortBlocksLeftToRight()
    {
        // Convert world positions to local space relative to the shelf
        sortedBlocks = detectedBlocks
            .OrderBy(block => {
                // Convert block's position to shelf's local space
                Vector3 localPos = transform.InverseTransformPoint(block.position);
                // Sort based on local X position (left to right)
                return localPos.x;
            })
            .ToList();
    }

    private void SnapBlocksToShelf()
    {
        Vector3 shelfTop = transform.TransformPoint(shelfCollider.center);
        shelfTop.y += (transform.lossyScale.y * shelfCollider.size.y * 0.5f);
        float snapY = shelfTop.y + snapHeight;

        foreach (Transform block in detectedBlocks)
        {
            Vector3 blockPos = block.position;
            if (Mathf.Abs(blockPos.y - snapY) <= snapThreshold)
            {
                // Only snap the Y position, maintain X and Z
                block.position = new Vector3(blockPos.x, snapY, blockPos.z);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (!showDebugGizmos || shelfCollider == null) return;

        // Draw shelf bounds
        Gizmos.color = Color.blue;
        Matrix4x4 originalMatrix = Gizmos.matrix;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(shelfCollider.center, shelfCollider.size);
        
        // Draw detection area
        Vector3 shelfTop = transform.TransformPoint(shelfCollider.center);
        shelfTop.y += (transform.lossyScale.y * shelfCollider.size.y * 0.5f);
        
        Vector3 detectionCenter = shelfTop + (Vector3.up * detectionHeight * 0.5f);
        Vector3 detectionSize = new Vector3(
            transform.lossyScale.x * shelfCollider.size.x,
            detectionHeight,
            transform.lossyScale.z * shelfCollider.size.z
        );
        
        Gizmos.matrix = originalMatrix;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(detectionCenter, detectionSize);

        // Draw detected blocks and their order
        if (sortedBlocks.Count > 0)
        {
            // Draw lines connecting blocks in order
            Gizmos.color = Color.green;
            for (int i = 0; i < sortedBlocks.Count - 1; i++)
            {
                if (sortedBlocks[i] != null && sortedBlocks[i + 1] != null)
                {
                    Gizmos.DrawLine(sortedBlocks[i].position, sortedBlocks[i + 1].position);
                }
            }

            // Draw spheres and numbers for each block
            for (int i = 0; i < sortedBlocks.Count; i++)
            {
                if (sortedBlocks[i] != null)
                {
                    Gizmos.DrawWireSphere(sortedBlocks[i].position, 0.2f);
                }
            }
        }
    }

    // Public methods for external access
    public List<Transform> GetDetectedBlocks()
    {
        return new List<Transform>(detectedBlocks);
    }

    public List<Transform> GetSortedBlocksLeftToRight()
    {
        return new List<Transform>(sortedBlocks);
    }

    public int GetBlockCount()
    {
        return sortedBlocks.Count;
    }

    public Transform GetBlockAtIndex(int index)
    {
        if (index >= 0 && index < sortedBlocks.Count)
            return sortedBlocks[index];
        return null;
    }
}