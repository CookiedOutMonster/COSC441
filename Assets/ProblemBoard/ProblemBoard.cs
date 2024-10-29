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


    // Start is called before the first frame update
    void Start()
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
    private void displayProblem(int id)
    {
        TextMeshProUGUI whiteboardLabel = this.gameObject.GetComponent<TextMeshProUGUI>();
        whiteboardLabel.SetText(problems[id]);
    }
}
