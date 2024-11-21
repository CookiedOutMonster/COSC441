using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Random = UnityEngine.Random;

[Serializable]
public class StudySettings
{
    public int participantID; // Enter PID in Unity
    public FeedbackType feedbackType; // Immediate or delayed 
    public int repetitions;
}

public enum FeedbackType //allows feedback selection type to be made in unity inspector
{
    ImmediateFeedback = 0,
    DelayedFeedback = 1
}

public class StudyBehavior : MonoBehaviour
{
    private ProblemBoard problemBoard;
    [SerializeField] private StudySettings studySettings;
    [SerializeField] private TextMeshProUGUI feedbackText; // displays feedback to participant 

    private float timer = 0f;
    private int currentTrialIndex = 0;
    private int wrongAnswerProvided = 0; //incorrect attempts   
    private bool isCorrect = false;
    private Stack<string> participantSolution = new Stack<string>(); // Stores participant solution
    private List<int> blockSequence = new List<int>();

    private string[] header = { //for storing data
        "PID",
        "FeedbackType",
        "ResponseTime",
        "IncorrectSubmissions"
    };

    private void Awake()
    {
        getProblemBoardRef();
    }

    private void Start()
    {
        //LogHeader(); //logs above header for data
        CreateBlock(); //creates data block
        //newTrial(); //starts trial
    }

    private void Update()
    {
        // boolean flag to start the timer 
        /*
        if (!isCorrect) //tracks time until correct solution
        {
            timer += Time.deltaTime;
        }
        */
    }

    public FeedbackType GetFeedbackType()
    {
        return studySettings.feedbackType;
    }

    private void CreateBlock()
    {
        for (int i = 0; i < studySettings.repetitions; i++) // Repeat problems set
        {
            for (int problemIndex = 0; problemIndex < problemBoard.GetTotalProblems(); problemIndex++) // Loop problems
            {
                blockSequence.Add(problemIndex); // Add problem index to block sequence
            }
        }
        blockSequence = YatesShuffle(blockSequence); // yates shuffle logic provided in bubble cursor lab
    }


    // consider making this return false indicating that the study is done 
    public void newTrial()
    {
        if (currentTrialIndex >= blockSequence.Count) //checks if there are reamining trials
        {
            EndStudy();
            return; //return false
        }

        //int problemIndex = blockSequence[currentTrialIndex]; // Get current problem index (from yates shuffle)
        // for now I am just going to use 0
        int problemIndex = currentTrialIndex;

        problemBoard.displayProblem(problemIndex); // Displays problem 

        timer = 0f; // Reset timer for new trial
        wrongAnswerProvided = 0; // Reset incorrect attempts
        isCorrect = false; // Reset correct status

        currentTrialIndex++; // Move next trial index
        // ProvideFeedback(""); // Clear previous feedback
    }

    public void immediate() //handles immediate feedback 
    {
        // TODO: figure out participant solutions besides novel implementation below
        Stack<string> participantSolution = GetParticipantSolution(); // Get participant solution 
        Stack<string> correctSolution = problemBoard.getSolutionStack(problemBoard.getCurrProblemIndex()); // Get solution ref to ProblemBoard

        if (IsSolutionCorrect(participantSolution, correctSolution))
        {
            isCorrect = true;
            LogData();

            if (studySettings.feedbackType == FeedbackType.ImmediateFeedback)
            {
                ProvideFeedback("Correct! Next Problem");
                newTrial();
            }
        }
        else
        {
            wrongAnswerProvided++;
            if (studySettings.feedbackType == FeedbackType.ImmediateFeedback)
            {
                ProvideFeedback("Incorrect block or placement");
            }
        }
    }

    //getter for participant solution
    public Stack<string> GetParticipantSolution()
    {
        return participantSolution;
    }

    public void delayed() //Handles delayed feedback
    {
        if (studySettings.feedbackType == FeedbackType.DelayedFeedback)
        {
            if (isCorrect)
            {
                ProvideFeedback("Correct! Next Problem");
                newTrial();
            }
            else
            {
                ProvideFeedback("Contains incorrect blocks or block placements, please try again.");
            }
        }
    }

    private bool IsSolutionCorrect(Stack<string> participantSolution, Stack<string> correctSolution)
    {
        return participantSolution.SequenceEqual(correctSolution); // Checks if provided answer is correct
    }

    private void ProvideFeedback(string message)
    {
        Debug.Log(message); //debugging
        feedbackText.text = message; // Display feedback if needed
    }

    private void LogHeader()
    {
        CSVManager.AppendToCSV(header);
    }

    private void LogData()
    {
        string[] data = {
            studySettings.participantID.ToString(),
            studySettings.feedbackType.ToString(),
            timer.ToString(),
            wrongAnswerProvided.ToString()
        };

        CSVManager.AppendToCSV(data);
    }

    private void EndStudy()
    {
        Debug.Log("Study completed");
        SceneManager.LoadScene("EndScreen");
    }

    private static List<T> YatesShuffle<T>(List<T> list) //same as bubble cursor yates shuffle
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            (list[i], list[randomIndex]) = (list[randomIndex], list[i]);
        }
        return list;
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