using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compare : MonoBehaviour
{

    // get reference to the whiteboard for the solution stack 
    private ProblemBoard problemBoard;
    private bool interpit;



    // Start is called before the first frame update
    void Awake()
    {
        getProblemBoardRef();
        //getSolutionStack();
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


    public bool checkBlocksOnBoard(Stack<GameObject> userStack, bool interpit)
    {
        // Early return if the stack is empty
        if (userStack.Count == 0)
            return true;

        // stare at it until it makes sense (easy)
        if (interpit)
            return interpitBlocksOnBoard(userStack);
        else
            return compileBlocksOnBoard(userStack);
    }


    private bool interpitBlocksOnBoard(Stack<GameObject> userStack)
    {

        int errors = 0;

        // retrieve soln stack from problem-board
        Stack<string> solnStack = getSolutionStack();

        // reverse both the user stack and the soln stack to compare one by one 
        Stack<GameObject> revUser = ReverseStack(userStack);
        Stack<string> revSoln = ReverseStack(solnStack);


        // iterate over the user supplied input only and compare 1:1 to the solution stack 
        while (revUser.Count > 0)
        {
            // retrieve reference to the block the user put in
            GameObject block = revUser.Pop();
            Block temp = block.GetComponent<Block>();
            string userInput = temp.Type.ToString();

            // get the solution
            string solution = revSoln.Pop();

            if (solution != userInput)
            {
                // make the blocks freak! 
                Debug.Log("solution = " + solution + " userInput " + userInput);
                errors++;
            }
        }
        // return true if there are no errors in the code and the user has completed the question
        return errors == 0 && userStack.Count == revSoln.Count ? true : false;
    }

    private bool compileBlocksOnBoard(Stack<GameObject> userStack)
    {
        Debug.Log("This was called!");
        return false;
    }

    public static Stack<T> ReverseStack<T>(Stack<T> stack)
    {
        // Create a temporary stack to hold the reversed elements
        Stack<T> rev = new Stack<T>();

        // Move all elements from the original stack to the temporary stack
        while (stack.Count > 0)
        {
            rev.Push(stack.Pop());
        }

        return rev;
    }


    private Stack<string> getSolutionStack()
    {
        // retrieve problem's index in order to get correct stack from file 
        int index = problemBoard.getCurrProblemIndex();
        Stack<string> solutionStack = problemBoard.getSolutionStack(index);
        return solutionStack;
    }

}
