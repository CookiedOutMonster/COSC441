using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For handling UI elements (Image, Text)


public class Executor : MonoBehaviour
{
    // ~ constants ~
    private const bool FINISHED_STUDY = true;
    private const bool HAS_NOT_FINISHED_STUDY = false;

    // ~ local to class ~
    private bool isProblemStarted = false;
    private bool hasExecuted = false;
    private bool studyStatus = false;

    // might be dangerous to have as a global varialbe
    private bool isCorrect = false;

    private int totalErrors = 0;

    // ~ getting from my own shit ~ 
    private GameObject compile;
    private GameObject startProblem;
    private GameObject interpit;
    private GameObject correctNext;
    private GameObject finished;


    // ~ getting from other shit ~
    // Shelf uses Box-Colliders to get a stack of user inputted blocks, left to right 
    // Compare is used to compare the user inputted stack to the one read from a file. 
    private Shelf shelf;
    private Compare compare;
    private StudyBehavior std;
    private FeedbackType feedBackType;
    private BlockSpawner blockSpawner;

    // Live update of the blocks that the user places on the WhiteBoard Shelf 
    private Stack<GameObject> userStack = new Stack<GameObject>();


    // ~ for debugging ~ 
    private bool logStack = false;
    private bool printErrors = false;
    private bool spawnBlock = true;


    public GameObject prefab_Int;


    void Awake()
    {
        getCompare();
        getShelf();
        getStudyBehavior();
        InitializeChildren();
        getBlockSpawner();
    }


    void Start()
    {
        feedBackType = std.GetFeedbackType();

        // ~ for debugging
        if (spawnBlock)
        {
            GameObject temp = Instantiate(prefab_Int, transform.position, Quaternion.identity);
            IntegerVariableBlock type = temp.AddComponent<IntegerVariableBlock>();
            type.Validate(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isProblemStarted);
        if (isProblemStarted == true && studyStatus == HAS_NOT_FINISHED_STUDY)
        {
            ManageStudy();
        }
        else if (studyStatus == FINISHED_STUDY)
        {
            ShowFinishedScreen();
        }
    }

    private void ManageStudy()
    {
        // Get reference to the blocks on the board
        userStack = shelf.GetSortedBlocksLeftToRight();

        // Determine which "execute" method to use based on feedback type
        switch (feedBackType)
        {
            case FeedbackType.ImmediateFeedback:
                // continous feedback
                whichScreen("InterpitScreen");
                CheckAndLogErrors();
                break;

            case FeedbackType.DelayedFeedback:
                // feedback is controlled by a button
                whichScreen("CompileScreen");
                // imagine CompileButton() is right here
                break;
        }
    }

    // Method to show the appropriate screen (Interpit or Compile) based on feedback type
    private void whichScreen(string screen)
    {
        // Execute a single time
        if (!this.hasExecuted)
        {
            if (screen.Equals("InterpitScreen"))
                ShowInterpitScreen();

            else if (screen.Equals("CompileScreen"))
                ShowCompileScreen();

            this.hasExecuted = true;
        }

    }

    public void CompileButton()
    {
        CheckAndLogErrors();
        OnCorrect();
    }

    public void SubmitImmediateFeedback() // *this is a button*
    {
        OnCorrect();
    }

    // Helper method to check blocks on board and update total errors
    private void CheckAndLogErrors()
    {
        int errors = 0; // glitch with errors needs fixing

        // Check blocks on the board
        this.isCorrect = compare.checkBlocksOnBoard(this.userStack, ref errors);

        // Update the total errors
        this.totalErrors += errors;

        // Optionally log the errors if needed
        if (printErrors)
        {
            if (totalErrors > 0)
            {
                Debug.Log(totalErrors);
            }
            if (isCorrect)
            {
                Debug.Log($"Problem Finished! with {totalErrors}");
            }
        }
    }

    public void OnCorrect()
    {
        if (!isCorrect)
        {
            HandleIncorrectSolution();
            return;
        }

        HandleCorrectSolution();
    }

    private void HandleCorrectSolution()
    {
        // Stop the Update loop
        isProblemStarted = false;

        // Hide appropriate menus based on feedback type
        HideAppropriateMenus();

        // Hide any error messages
        HideErrorMessages();

        // Show success screen and cleanup
        ShowCorrectNextScreen();
        std.LogData(totalErrors);
        shelf.DeleteDetectedBlocks();
        totalErrors = 0;
        HideBlockSpawner();
    }

    private void HandleIncorrectSolution()
    {
        const string NOT_FINISHED_MESSAGE = "   Problem not finished!";
        const string WRONG_ANSWER_MESSAGE = "   Wrong solution. Try again!";

        string errorMessage = feedBackType == FeedbackType.ImmediateFeedback
            ? NOT_FINISHED_MESSAGE
            : WRONG_ANSWER_MESSAGE;

        FeedBack feedback = GetFeedbackComponent();
        ShowError(feedback, errorMessage);
    }

    private void HideAppropriateMenus()
    {
        if (feedBackType == FeedbackType.ImmediateFeedback)
        {
            HideInterpitScreen();
        }
        else if (feedBackType == FeedbackType.DelayedFeedback)
        {
            HideCompile();
        }
    }

    private void HideErrorMessages()
    {
        FeedBack feedback = GetFeedbackComponent();
        feedback.HideError();
    }

    private FeedBack GetFeedbackComponent()
    {
        return feedBackType == FeedbackType.ImmediateFeedback
            ? interpit.GetComponent<FeedBack>()
            : compile.GetComponent<FeedBack>();
    }
    private void ShowError(FeedBack feedback, string errorMessage)
    {
        if (feedback != null)
        {
            feedback.ShowError(errorMessage);
        }
        else
        {
            Debug.LogWarning("Feedback not found");
        }
    }

    public void NextProblemButton()
    {
        // show block spawner 
        ShowBlockSpawner();
        // hide screen
        HideCorrectNextScreen();
        // on button press start the trail, if true, set the study status to finished study which updates the main loop
        studyStatus = std.newTrial() ? FINISHED_STUDY : HAS_NOT_FINISHED_STUDY;
        // indicate to this Object that the problem has started and we should be looking for blocks on the whiteboard in the Update method 
        isProblemStarted = true;
        // show ze screen 
        hasExecuted = false;
    }

    public void StartProblemButton()
    {
        // on button press start the trail
        studyStatus = std.newTrial() ? FINISHED_STUDY : HAS_NOT_FINISHED_STUDY;
        // indicate to this Object that the problem has started and we should be looking for blocks on the whiteboard in the Update method 
        isProblemStarted = true;
        // hide the StartProblem screen on the menu
        HideStartScreen();
        // Show the block spawner
        ShowBlockSpawner();
    }

    public void onSubmit()
    {
        Debug.Log("Cunt");
    }

    // Method to show the "Compile" child
    private void ShowCompileScreen()
    {
        if (compile != null)
        {
            compile.SetActive(true);
            Debug.Log(compile.activeSelf);
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
            Debug.Log("we got here boys and squirrels" + interpit.activeSelf);

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

    private void ShowFinishedScreen()
    {
        if (finished != null)
        {
            finished.SetActive(true);
        }
    }

    private void ShowBlockSpawner()
    {
        if (blockSpawner != null)
        {
            blockSpawner.gameObject.SetActive(true);
        }
    }

    private void HideBlockSpawner()
    {
        if (blockSpawner != null)
        {
            blockSpawner.gameObject.SetActive(false);
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

    // little diff cause we need the hidden 1 
    private void getBlockSpawner()
    {
        BlockSpawner temp = FindObjectOfType<BlockSpawner>(includeInactive: true);

        if (temp != null)
        {
            blockSpawner = temp;
        }
        else
        {
            Debug.Log("There was an error retrieving the Block Spawner component.");
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
            Debug.Log("There was an error retrieving the Study Behavior component. This is not going to work.");
        }
    }

    // Method to initialize references to the child GameObjects
    private void InitializeChildren()
    {
        // include inactive objects. 
        Transform[] allChildren = GetComponentsInChildren<Transform>(true);

        foreach (Transform child in allChildren)
        {
            if (child.name == "CompileScreen")
                compile = child.gameObject;
            if (child.name == "Begin")
                startProblem = child.gameObject;
            if (child.name == "Interpit")
                interpit = child.gameObject;
            if (child.name == "Correct-Next")
                correctNext = child.gameObject;
            if (child.name == "Finished")
                finished = child.gameObject;
        }

        // Check if any are null and log accordingly
        if (compile == null) Debug.LogError("Compile GameObject was not found.");
        if (startProblem == null) Debug.LogError("StartProblem GameObject was not found.");
        if (interpit == null) Debug.LogError("Interpit GameObject was not found.");
        if (correctNext == null) Debug.LogError("correctNext GameObject was not found.");
    }
}
