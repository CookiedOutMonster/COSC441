using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ProblemBoard : MonoBehaviour
{
    private string[] problems;
    private string[] solutions;
    private int currProblem = 0;
    private const int PROBLEM_SET_COMPLETE = -1; // to be assigned to currProblem, indicates that participant has completed everything

    // Start is called before the first frame update
    void Awake()
    {
        readProblemsFromTextFile();
        displayProblem(currProblem);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
    * Method description: 
    * Read in any # of problem statements and corresponding solutions from .txt file
    * 
    * Assumptions:
    * First line = # of problems
    * Subsequent lines are couplets, where 1st line = problem statement and 2nd line = solution to be used for checking answer
    * No blank lines in file  
    * 
    * Notes :
    * Format for how solution is written is TBD and subject to change based on block implementation
    */
    private void readProblemsFromTextFile()
    {
        const string FILE_PATH = "Assets/ProblemBoard/problemset.txt";
        StreamReader reader = new StreamReader(FILE_PATH);

        int NUM_PROBLEMS = int.Parse(reader.ReadLine());

        problems = new string[NUM_PROBLEMS];
        solutions = new string[NUM_PROBLEMS];

        for (int i = 0; i < NUM_PROBLEMS; i++)
        {
            problems[i] = reader.ReadLine();
            solutions[i] = reader.ReadLine();
        }

        reader.Close();
    }

    /*
    * Method description:
    * Displays a given problem (specify by id param, where 1st problem in file is 0) on the whiteboard
    */
    public void displayProblem(int id) //updated to public for use in StudyBehavior
    {
        TextMeshProUGUI whiteboardLabel = this.gameObject.GetComponent<TextMeshProUGUI>();

        if (id == PROBLEM_SET_COMPLETE)
        {
            whiteboardLabel.SetText("All tasks are now complete. Thank you for your participation.");
        }
        else
        {
            whiteboardLabel.SetText(problems[id]);
        }

    }

    /*
    * Method description:
    * Advances to next problem, if exists, and updates display. If participant's currProblem is last problem in the set, displays msg indicating completion
    * To be used by submit/skip button logic
    */
    public void nextProblem()
    {
        // if there's at least one problem remaining (not last one)
        if (currProblem > PROBLEM_SET_COMPLETE && currProblem < problems.Length - 1)
        {
            currProblem++;
        }
        else
        {
            currProblem = PROBLEM_SET_COMPLETE;
        }

        // update display
        displayProblem(currProblem);
    }

    /*
    * Method description:
    * Returns the solution for a given problem (specify by id param) as a stack, to be compared against the participant's stack
    * 
    * Notes:
    * This method will likely change based on how we want the solution stack to be formatted/how the blocks end up being set up.
    * General idea should stay same though
    */
    public Stack<string> getSolutionStack(int id)
    {
        Stack<string> solnStack = new Stack<string>();
        string[] solnBlocks = solutions[id].Split(", ");

        for (int i = 0; i < solnBlocks.Length; i++)
        {
            solnStack.Push(solnBlocks[i]);
        }

        return solnStack;
    }

    /*
    * Getter for currProblem, which is an index value/id that corresponds to a problem statement and its solution.
    */
    public int getCurrProblemIndex()
    {
        return currProblem;
    }

    /*
    * Getter for the actual text of the current problem that participant is working on.
    */
    public string getCurrProblemStatement()
    {
        return problems[currProblem];
    }

//getter to return total problems to ref in study behavior
    public int GetTotalProblems() 
{
    return problems.Length;
}


}
