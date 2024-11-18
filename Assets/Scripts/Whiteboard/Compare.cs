using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    public bool checkBlocksOnBoard(Stack<GameObject> userStack, bool interpit)
    {
        Stack<GameObject> userCopy = DeepCopy(userStack);

        // stare at it until it makes sense (easy)
        if (interpit)
            return interpitBlocksOnBoard(userCopy);
        else
            return compileBlocksOnBoard(userCopy);
    }

    // Generic function to deep copy a Stack<T>
    private Stack<T> DeepCopy<T>(Stack<T> originalStack) where T : new()
    {
        // Create a new Stack to hold the copied items
        Stack<T> copiedStack = new Stack<T>();

        // Create a list to temporarily hold the items so we don't modify the original stack
        List<T> tempList = new List<T>(originalStack);

        // Iterate through the tempList (which contains the items in original stack's order)
        foreach (T item in tempList)
        {
            // Create a new instance of T for each item and add it to the copied stack
            T newItem = (T)Activator.CreateInstance(typeof(T));  // Create a new instance of T
            copiedStack.Push(newItem);  // Push the new instance onto the copied stack
        }

        // Return the deep copied stack
        return copiedStack;
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
            checkBlock(revUser, revSoln, errors);

        // return true if there are no errors in the code and the user has completed the question
        return errors == 0 && userStack.Count == revSoln.Count ? true : false;
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
            checkBlock(userStack, solnStack, errors);

        // return true if there are no errors and false if there are errors 
        return errors == 0 ? true : false;
    }

    private void checkBlock(Stack<GameObject> userStack, Stack<string> solnStack, int errors)
    {
        // retrieve reference to the block the user put in
        GameObject block = userStack.Pop();
        Block temp = block.GetComponent<Block>();
        string userInput = temp.Type.ToString();

        // get the solution
        string solution = solnStack.Pop();

        if (solution != userInput)
        {
            // make the blocks freak! 
            Debug.Log("solution =  " + solution + " userInput " + userInput);
            errors++;
        }
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
