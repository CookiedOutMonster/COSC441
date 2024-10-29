using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ProblemBoard : MonoBehaviour
{
    private string[] problems;
    private string[] solutions;

    // Start is called before the first frame update
    void Start()
    {
        readProblemsFromTextFile();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
    * Method description: 
    * Read in any # of problem statements and corresponding solution stacks from .txt file
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
}
