using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Executor : MonoBehaviour
{

    private bool interpit;

    // Compare is used to compare the user inputted stack to the one read from a file. 
    // Shelf uses Box-Colliders to get a stack of user inputted blocks, left to right 
    private Compare compare;
    private Shelf shelf;

    // Live update of the blocks that the user places on the WhiteBoard Shelf 
    private Stack<GameObject> userStack = new Stack<GameObject>();

    // ~ for debugging ~ 
    private bool printStack = false;


    void Awake()
    {
        getCompare();
        getShelf();
    }



    void Start()
    {
        interpit = true;
    }

    // Update is called once per frame
    void Update()
    {
        userStack = shelf.GetSortedBlocksLeftToRight();

        bool results = false;
        if (userStack.Count > 0)
        {
            results = compare.checkBlocksOnBoard(userStack, interpit);
        }

        //Debug.Log(results);

        if (printStack) debugStack();

    }

    private void debugStack()
    {
        userStack = shelf.GetSortedBlocksLeftToRight();

        Debug.Log("Executor Blocks from left to right:");
        while (userStack.Count > 0)
        {
            GameObject block = userStack.Pop();
            Debug.Log($" Executor: {block.name} at position {block.transform.position} eskeddit");
        }

    }

    private void getCompare()
    {
        // Find the GameObject called "Board"
        GameObject temp = GameObject.Find("Board");

        if (temp != null)
        {
            // Get the Compare component attached to it
            compare = temp.GetComponent<Compare>();
        }
        else
        {
            Debug.Log("There was an error retrieving the Compare component. This is not going to work.");
        }
    }

    private void getShelf()
    {
        // find the shelf 
        GameObject temp = GameObject.Find("Shelf");

        if (temp != null)
        {
            shelf = temp.GetComponent<Shelf>();
        }
        else
        {
            Debug.Log("Error getting the shelf component in Executor. We are fucked.");
        }
    }

}
