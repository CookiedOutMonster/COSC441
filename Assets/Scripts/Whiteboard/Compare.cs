using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class Compare : MonoBehaviour
{

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
    public bool checkBlocksOnBoard(Stack<GameObject> userStack, bool interpit)
    {
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

        int problemLength = solnStack.Count;
        int inputLength = userStack.Count;

        // reverse both the user stack and the soln stack to compare one by one 
        //Stack<GameObject> revUser = ReverseStack(userStack);
        Stack<string> revSoln = ReverseStack(solnStack);

        // iterate over the user supplied input only and compare 1:1 to the solution stack 
        while (userStack.Count > 0)
            checkBlock(userStack, revSoln, ref errors);

        // return true if there are no errors in the code and the user has completed the question
        return errors == 0 && inputLength == problemLength && userStack.Count == 0 ? true : false;
    }

    private bool compileBlocksOnBoard(Stack<GameObject> userStack)
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

        int errors = 0;

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

        if (solution != userInput)
        {
            // make the blocks freak! 
            Debug.Log("Incorrect expected =  " + solution + " actual " + userInput);
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
