using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For handling UI elements (Image, Text)


public class Executor : MonoBehaviour
{
    // ~ local to class ~
    private bool isProblemStarted = false;
    private bool hasExecuted = false;
    private bool isCorrect = false;

    private int totalErrors = 0;

    // ~ getting from my own shit ~ 
    private GameObject compile;
    private GameObject startProblem;
    private GameObject interpit;
    private GameObject correctNext;


    // ~ getting from other shit ~
    // Shelf uses Box-Colliders to get a stack of user inputted blocks, left to right 
    // Compare is used to compare the user inputted stack to the one read from a file. 
    private Shelf shelf;
    private Compare compare;
    private StudyBehavior std;
    private FeedbackType feedBackType;

    // Live update of the blocks that the user places on the WhiteBoard Shelf 
    private Stack<GameObject> userStack = new Stack<GameObject>();


    // ~ for debugging ~ 
    private bool logStack = false;
    private bool printErrors = false;


    void Awake()
    {
        getCompare();
        getShelf();
        getStudyBehavior();
        InitializeChildren();
    }


    void Start()
    {
        feedBackType = std.GetFeedbackType();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isProblemStarted);
        if (isProblemStarted)
        {
            // Get reference to the blocks on the board
            userStack = shelf.GetSortedBlocksLeftToRight();

            // Determine which "execute" method to use based on feedback type
            switch (feedBackType)
            {
                case FeedbackType.ImmediateFeedback:

                    // execute a single time
                    if (hasExecuted == false)
                    {
                        ShowInterpitScreen();
                        hasExecuted = true;
                    }

                    ImmediateFeedback();


                    break;

                case FeedbackType.DelayedFeedback:
                    // Handle delayed feedback (compile)
                    // show the compile buttons on the board 
                    //Debug.Log("Compilation has started");
                    break;


            }
        }
    }

    // this method is responsible for calling the checkBlocksOnBoard from Compare 
    // also tracks the global error
    private void ImmediateFeedback()
    {
        int errors = 0;

        // only check if there are blocks on the board
        if (userStack.Count > 0)
        {
            isCorrect = compare.checkBlocksOnBoard(userStack, true, ref errors);
        }

        totalErrors += errors;

        if (printErrors)
        {
            if (totalErrors > 0) Debug.Log(totalErrors);
            if (isCorrect) Debug.Log($"Problem Finished! with {totalErrors}");
        }
    }

    public void SubmitImmediateFeedback()
    {
        if (isCorrect && feedBackType == FeedbackType.ImmediateFeedback)
        {
            // prevent the Update loop from fucking with my shit
            isProblemStarted = false;
            // Hiding appropriate menus
            HideInterpitScreen();
            ShowCorrectNextScreen(); // i want to play a sound here lol
            std.LogData(totalErrors);
            // log data 
        }
        else if (!isCorrect && feedBackType == FeedbackType.ImmediateFeedback)
        {

            // TODO make another screen...
        }
    }

    public void StartProblemButton()
    {
        // on button press start the trail
        std.newTrial();
        // indicate to this Object that the problem has started and we should be looking for blocks on the whiteboard in the Update method 
        isProblemStarted = true;
        // hide the StartProblem subsection 
        HideStartScreen();
    }

    public void onSubmit()
    {
        Debug.Log("Cunt");
    }

    // Method to show the "Compile" child
    private void ShowCompile()
    {
        if (compile != null)
        {
            compile.SetActive(true);
        }
    }

    // Method to hide the "Compile" child
    private void HideCompile()
    {
        if (compile != null)
        {
            compile.SetActive(false);
        }
    }

    // Method to show the "Start Problem" child
    private void ShowStartProblem()
    {
        if (startProblem != null)
        {
            startProblem.SetActive(true);
        }
    }

    // Method to hide the "Start Problem" child
    private void HideStartScreen()

    {
        if (startProblem != null)
        {
            startProblem.SetActive(false);
        }

    }

    // Function to show (activate) the "Correct-Next" GameObject
    public void ShowCorrectNextScreen()
    {
        if (correctNext != null)
        {
            correctNext.SetActive(true); // Show the GameObject by setting it active
        }
        else
        {
            Debug.LogWarning("Correct-Next child not found!");
        }
    }

    // Function to hide (deactivate) the "Correct-Next" GameObject
    public void HideCorrectNextScreen()
    {
        if (correctNext != null)
        {
            correctNext.SetActive(false); // Hide the GameObject by setting it inactive
        }
        else
        {
            Debug.LogWarning("Correct-Next child not found!");
        }
    }

    // Method to show the "Interpit" child
    private void ShowInterpitScreen()
    {
        if (interpit != null)
        {
            interpit.SetActive(true);
        }
    }

    // Method to hide the "Interpit" child
    private void HideInterpitScreen()
    {
        if (interpit != null)
        {
            interpit.SetActive(false);
        }
    }

    private void printStack()
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

    private void getStudyBehavior()
    {
        // Find the GameObject called "Board"
        GameObject temp = GameObject.Find("Executor");

        if (temp != null)
        {
            // Get the Compare component attached to it
            std = temp.GetComponent<StudyBehavior>();
        }
        else
        {
            Debug.Log("There was an error retrieving the Compare component. This is not going to work.");
        }
    }

    // Method to initialize references to the child GameObjects
    private void InitializeChildren()
    {
        // include inactive objects. 
        Transform[] allChildren = GetComponentsInChildren<Transform>(true);

        foreach (Transform child in allChildren)
        {
            if (child.name == "Compile")
                compile = child.gameObject;
            if (child.name == "Begin")
                startProblem = child.gameObject;
            if (child.name == "Interpit")
                interpit = child.gameObject;
            if (child.name == "Correct-Next")
                correctNext = child.gameObject;
        }

        // Check if any are null and log accordingly
        if (compile == null) Debug.LogError("Compile GameObject was not found.");
        if (startProblem == null) Debug.LogError("StartProblem GameObject was not found.");
        if (interpit == null) Debug.LogError("Interpit GameObject was not found.");
        if (correctNext == null) Debug.LogError("correctNext GameObject was not found.");
    }
}
