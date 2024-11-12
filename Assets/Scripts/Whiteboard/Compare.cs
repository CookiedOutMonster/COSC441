using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compare : MonoBehaviour
{

    // get reference to the whiteboard for the solution stack 
    private ProblemBoard problemBoard;
    private bool interpit;

    // Start is called before the first frame update
    void Start()
    {
        getProblemBoardRef();
        getSolutionStack();
    }

    // Update is called once per frame
    void Update()
    {
        if (interpit)
        {
            checkBlocksOnBoard();
        }
    }

    public void setInterpit(bool interpit)
    {
        interpit = interpit;
    }

    public bool getInterpit()
    {
        return interpit;
    }

    private void getProblemBoardRef()
    {
        // Find the GameObject called "whiteboard-header"
        GameObject whiteboardHeader = GameObject.Find("whiteboard-header");

        if (whiteboardHeader != null)
        {
            // Get the ProblemBoard component attached to it
            problemBoard = whiteboardHeader.GetComponent<ProblemBoard>();
        }
        else
        {
            Debug.Log("There was an error retrieving the ProblemBoard. This shit is not gonna work man.");
        }
    }

    private Stack<string> getSolutionStack()
    {
        // retrieve problem's index in order to get correct stack from file 
        int index = problemBoard.getCurrProblemIndex();
        Stack<string> solutionStack = problemBoard.getSolutionStack(index);
        return solutionStack;
    }

    // mock this method
    private Stack<string> getBlocksOnBoard()
    {

    }

    public bool checkBlocksOnBoard()
    {
        // call getBlocksOnBoard 
        // call getSolutionStack() 
        // compare them 
        // yell at appropriate blocks 
        // return true or false? 
        return false;
    }
}
