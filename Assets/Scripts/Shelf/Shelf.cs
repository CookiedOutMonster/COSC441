using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Shelf : MonoBehaviour
{
    [Header("Detection Settings")]
    [SerializeField] private float detectionHeight = 1f;

    [Header("Optional Snapping")]
    [SerializeField] private bool enableSnapping = true;
    [SerializeField] private float snapHeight = 0.1f;  // Height above shelf surface
    [SerializeField] private float snapThreshold = 0.5f;  // How close block needs to be to snap

    [Header("Debug")]
    [SerializeField] private bool showDebugLogs;

    private BoxCollider shelfCollider;
    private List<Transform> detectedBlocks = new List<Transform>();
    private Stack<GameObject> sortedBlocks = new Stack<GameObject>();

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

        Stack<GameObject> arms = GetSortedBlocksLeftToRight();

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
        sortedBlocks = new Stack<GameObject>(
            detectedBlocks
                .OrderBy(block =>
                {
                    Vector3 localPos = transform.InverseTransformPoint(block.gameObject.transform.position);
                    return localPos.x;
                })
                .Select(block => block.gameObject)
                .Reverse()
        );
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

    // Public methods for external access
    public List<Transform> GetDetectedBlocks()
    {
        return new List<Transform>(detectedBlocks);
    }

    public Stack<GameObject> GetSortedBlocksLeftToRight()
    {
        return new Stack<GameObject>(new Stack<GameObject>(sortedBlocks));
    }

    public int GetBlockCount()
    {
        return detectedBlocks.Count;
    }



    /*
    public Transform GetBlockAtIndex(int index)
    {
        if (index >= 0 && index < sortedBlocks.Count)
            return sortedBlocks[index];
        return null;
    }
    */
}