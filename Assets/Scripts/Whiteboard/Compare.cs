using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compare : MonoBehaviour
{

    // get reference to the whiteboard for the solution stack 
    private ProblemBoard problemBoard;

    // Start is called before the first frame update
    void Start()
    {

        getProblemBoardRef();
        getSolutionStack();

    }

    // Update is called once per frame
    void Update()
    {

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

    private void getSolutionStack()
    {
        // retrieve problem's index in order to get correct stack from file 
        int index = problemBoard.getCurrProblemIndex();
        Stack<string> solutionStack = problemBoard.getSolutionStack(index);
        Debug.Log(solutionStack);
    }
}
