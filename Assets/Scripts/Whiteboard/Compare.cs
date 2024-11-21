using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class Compare : MonoBehaviour
{

    // ~ for debugging 
    private bool printErrors = false;

    // used for interpit 
    private Stack<GameObject> lastVerifiedStack = null;


    // get reference to the problems for the solution stack 
    private ProblemBoard problemBoard;

    // Start is called before the first frame update
    void Awake()
    {
        getProblemBoardRef();
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


    // @Todo return enum and not bool? 
    public bool checkBlocksOnBoard(Stack<GameObject> userStack, bool interpit, ref int errors)
    {

        Debug.Log(interpit);

        // stare at it until it makes sense (easy)
        if (interpit && IsStackDifferent(userStack))
            return interpitBlocksOnBoard(userStack, ref errors);
        else if (!interpit && IsStackDifferent(userStack))
            return compileBlocksOnBoard(userStack, ref errors);
        else
            return false;
    }

    // not confident in this approach 
    private bool IsStackDifferent(Stack<GameObject> currentStack)
    {
        // First check
        if (lastVerifiedStack == null)
        {
            lastVerifiedStack = new Stack<GameObject>(currentStack);
            return true;
        }

        // Compare stack counts
        if (currentStack.Count != lastVerifiedStack.Count)
        {
            lastVerifiedStack = new Stack<GameObject>(currentStack);
            return true;
        }

        // Compare each block
        var currentArray = currentStack.ToArray();
        var lastArray = lastVerifiedStack.ToArray();

        for (int i = 0; i < currentArray.Length; i++)
        {
            if (currentArray[i] != lastArray[i])
            {
                lastVerifiedStack = new Stack<GameObject>(currentStack);
                return true;
            }
        }

        return false;
    }

    private bool interpitBlocksOnBoard(Stack<GameObject> userStack, ref int errors)
    {

        // retrieve soln stack from problem-board
        Stack<string> solnStack = getSolutionStack();

        int problemLength = solnStack.Count;
        int inputLength = userStack.Count;

        // reverse both the user stack and the soln stack to compare one by one 
        //Stack<GameObject> revUser = ReverseStack(userStack);
        Stack<string> revSoln = ReverseStack(solnStack);

        if (printErrors)
            Debug.Log("Count = " + userStack.Count);

        // iterate over the user supplied input only and compare 1:1 to the solution stack 
        while (userStack.Count > 0)
            checkBlock(userStack, revSoln, ref errors);

        // return true if there are no errors in the code and the user has completed the question
        return errors == 0 && inputLength == problemLength && userStack.Count == 0 ? true : false;
    }

    private bool compileBlocksOnBoard(Stack<GameObject> userStack, ref int errors)
    {

        if (userStack.Count == 0)
        {
            Debug.Log("Problem is not finished!");
            return false;
        }

        Stack<string> solnStack = getSolutionStack();

        // @TODO user interaction if the problem is not done yet
        if (userStack.Count != solnStack.Count)
        {
            // display a problem to the user
            // TODO: Julia this is when the code needs an error for the user. 
            // this might need some more finessing on my part due to my implementation.
            // TODO Gerren cook on this 
            Debug.Log("Problem is not finished!");
            return false;
        }

        // compile
        while (userStack.Count > 0)
            checkBlock(userStack, solnStack, ref errors);

        // return true if there are no errors and false if there are errors 
        return errors == 0 ? true : false;
    }

    private void checkBlock(Stack<GameObject> userStack, Stack<string> solnStack, ref int errors)
    {
        // retrieve reference to the block the user put in
        GameObject block = userStack.Pop();
        var blockComponent = GetBlockType(block);
        //var method = cunt.GetMethod("talk");

        // get the solution
        string solution = solnStack.Pop();
        string userInput = blockComponent.ToString();

        if (printErrors)
        {
            Debug.Log($"userinput = {userInput} solution = {solution}");
        }

        // check by removing spaces for both and ignoring caps (just in case!)
        // be wary of the ! operator <- sneaky! 
        if (!(string.Equals(solution.Replace(" ", ""), userInput.Replace(" ", ""), StringComparison.OrdinalIgnoreCase)))
        {
            // make the blocks freak! 
            errors++;
        }
    }

    private Type GetBlockType(GameObject block)
    {
        Block temp = block.gameObject.GetComponentInChildren<Block>(); // Get the Block component (could be derived class like BoolAlgBlock)
        Type someBlock = temp.GetType(); // Get the actual type (e.g., BoolAlgBlock, VariableBlock, etc.)
        return someBlock; // Return the Type (like BoolAlgBlock)
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
