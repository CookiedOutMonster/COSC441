using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class Compare : MonoBehaviour
{

    // ~ for debugging 
    private bool printErrors = true;

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

    // @Todo return enum and not bool? 
    public bool checkBlocksOnBoard(Stack<GameObject> userStack, ref int errors)
    {

        bool hasChanged = IsStackDifferent(userStack);
        // stare at it until it makes sense (easy)
        if (hasChanged)
            return Compile(userStack, ref errors);
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

    private bool Compile(Stack<GameObject> userStack, ref int errors)
    {

        // retrieve soln stack from problem-board
        Stack<string> solnStack = getSolutionStack();

        int problemLength = solnStack.Count;
        int inputLength = userStack.Count;

        // reverse both the user stack and the soln stack to compare one by one 
        //Stack<GameObject> revUser = ReverseStack(userStack);
        Stack<string> revSoln = ReverseStack(solnStack);

        // too many blocks! yell at user     
        if (userStack.Count > revSoln.Count)
        {
            // maybe a TODO is not make them all go red... only the ones that are too long go red... but im gonna get the rest of this working right now...
            while (userStack.Count > 0)
            {
                GameObject block = userStack.Pop();
                Block grandDaddy = block.GetComponent<Block>();
                grandDaddy.Validate(false);
                errors++;
            }

        }

        // iterate over the user supplied input only and compare 1:1 to the solution stack 
        while (userStack.Count > 0)
            checkBlock(userStack, revSoln, ref errors);

        if (printErrors)
        {
            Debug.Log("inputLength = " + inputLength);
            Debug.Log("problemLength = " + problemLength);
            Debug.Log("errors = " + errors);
            Debug.Log("userStack.Count " + userStack.Count);
            Debug.Log("evaluation " + (errors == 0 && inputLength == problemLength && userStack.Count == 0));
        }


        // return true if there are no errors in the code and the user has completed the question
        return errors == 0 && inputLength == problemLength && userStack.Count == 0;
    }

    private void checkBlock(Stack<GameObject> userStack, Stack<string> solnStack, ref int errors)
    {
        // retrieve reference to the block the user put in
        GameObject block = userStack.Pop();

        // This is done because of the way that the blocks are programmed. I needed to get the "child" on the fly, which is why there is that
        // GetBlockType() there. If it were me, I would not have done that. 
        Block grandDaddy = block.GetComponent<Block>();
        var blockComponent = GetBlockType(block);

        // get the solution
        string solution = solnStack.Pop();
        string userInput = blockComponent.ToString();


        if (printErrors)
        {
            Debug.Log($"userinput = {userInput} solution = {solution}");
        }

        // check by removing spaces for both and ignoring caps (just in case!)
        // be wary of the ! operator <- sneaky! 
        if ((string.Equals(solution.Replace(" ", ""), userInput.Replace(" ", ""), StringComparison.OrdinalIgnoreCase)) == false)
        {
            // make the blocks freak! 
            grandDaddy.Validate(false);
            errors++;
        }

        else if (((string.Equals(solution.Replace(" ", ""), userInput.Replace(" ", ""), StringComparison.OrdinalIgnoreCase)) == true))
        {
            grandDaddy.Validate(true);
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
        Stack<string> solutionStack = problemBoard.getSolutionStack();
        return solutionStack;
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

}
