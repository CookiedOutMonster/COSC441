using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using System.Linq;

public class ProblemBoard : MonoBehaviour
{
    private string[] problems;
    private string[] solutions;
    private int currProblem = 0;
    private const int PROBLEM_SET_COMPLETE = -1; // to be assigned to currProblem, indicates that participant has completed everything

    private List<(string problem, string solution)> easyProblems = new List<(string, string)>
    {
        // Simple Comparisons (2 blocks)
        ("Write a program that checks if 3 equals 3",
         "ThreeBlock, EqualBlock, ThreeBlock"),
        ("Write a program that checks if 5 is greater than 2",
         "FiveBlock, GreaterThanBlock, TwoBlock"),
        ("Write a program that checks if 4 is less than 8",
         "FourBlock, LessThanBlock, EightBlock"),
        ("Write a program that checks if 6 equals 6",
         "SixBlock, EqualBlock, SixBlock"),
        ("Write a program that checks if 7 is less than 9",
         "SevenBlock, LessThanBlock, NineBlock"),
        
        // Variable Creation (2 blocks)
        ("Write a program that creates a string variable A",
         "StringVariableBlock, ABlock"),
        ("Write a program that creates a boolean variable X",
         "BooleanVariableBlock, XBlock"),
        ("Write a program that creates an integer variable B",
         "IntegerVariableBlock, BBlock"),
        ("Write a program that creates a float variable Y",
         "FloatVariableBlock, YBlock"),
        
        // Simple Variable Assignment (3 blocks)
        ("Write a program that creates an integer variable C and sets it to 5",
         "IntegerVariableBlock, CBlock, EqualsBlock, FiveBlock"),
        ("Write a program that creates a float variable Z and sets it to 3",
         "FloatVariableBlock, ZBlock, EqualsBlock, ThreeBlock")
    };

    // Medium problems (4-6 blocks) remain the same...
    private List<(string problem, string solution)> mediumProblems = new List<(string, string)>
    {
        // Math Operations
        ("Write a program that creates an integer variable Z equal to 3 plus 4",
         "IntegerVariableBlock, ZBlock, EqualsBlock, ThreeBlock, AdditionBlock, FourBlock"),
        ("Write a program that creates a float variable C equal to 9 minus 2",
         "FloatVariableBlock, CBlock, EqualsBlock, NineBlock, SubtractionBlock, TwoBlock"),
        ("Write a program that creates an integer variable X equal to 6 divided by 2",
         "IntegerVariableBlock, XBlock, EqualsBlock, SixBlock, DivisionBlock, TwoBlock"),
         
        // Complex Comparisons
        ("Write a program that checks if 6 is less than or equal to 8",
         "SixBlock, LessThanEqualBlock, EightBlock"),
        ("Write a program that checks if 4 is not equal to 5",
         "FourBlock, NotEqualBlock, FiveBlock"),
        
        // Boolean Operations
        ("Write a program that creates a boolean variable Y equal to NOT Z",
         "BooleanVariableBlock, YBlock, EqualsBlock, NotBlock, ZBlock"),
         
        // Mixed Operations
        ("Write a program that creates a float variable A equal to 5 times 2",
         "FloatVariableBlock, ABlock, EqualsBlock, FiveBlock, MultiplicationBlock, TwoBlock"),
        ("Write a program that creates an integer variable B equal to 8 minus 3",
         "IntegerVariableBlock, BBlock, EqualsBlock, EightBlock, SubtractionBlock, ThreeBlock")
    };

    // Hard problems (7-8 blocks) remain the same...
    private List<(string problem, string solution)> hardProblems = new List<(string, string)>
    {
        // Complex Math
        ("Write a program that creates an integer variable A equal to 2 times 3 plus 4",
         "IntegerVariableBlock, ABlock, EqualsBlock, TwoBlock, MultiplicationBlock, ThreeBlock, AdditionBlock, FourBlock"),
        ("Write a program that creates a float variable X equal to 8 divided by 2 plus 1",
         "FloatVariableBlock, XBlock, EqualsBlock, EightBlock, DivisionBlock, TwoBlock, AdditionBlock, OneBlock"),
         
        // Complex Boolean Logic
        ("Write a program that checks if 5 is greater than 3 AND 4 is less than 6",
         "FiveBlock, GreaterThanBlock, ThreeBlock, AndBlock, FourBlock, LessThanBlock, SixBlock"),
        ("Write a program that checks if X equals Y OR Z is less than 5",
         "XBlock, EqualBlock, YBlock, OrBlock, ZBlock, LessThanBlock, FiveBlock"),
        
        // Mixed Complex Operations
        ("Write a program that creates a float variable Z equal to 9 divided by 3 plus 2",
         "FloatVariableBlock, ZBlock, EqualsBlock, NineBlock, DivisionBlock, ThreeBlock, AdditionBlock, TwoBlock"),
        ("Write a program that checks if (4 plus 2) equals (3 times 2)",
         "FourBlock, AdditionBlock, TwoBlock, EqualBlock, ThreeBlock, MultiplicationBlock, TwoBlock")
    };

    /*
    @TODO there is a problem in reading a single solution. This board thinks that somehow, someway, that there is two answers? 
    */

    // Start is called before the first frame update
    void Awake()
    {
        //readProblemsFromTextFile();
        InitializeProblems();
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

    public (string[] problems, string[] solutions) GenerateProblemSet()
    {
        var random = new System.Random();
        var selectedProblems = new List<(string problem, string solution)>();  // Define tuple with named elements

        // Select random problems
        selectedProblems.AddRange(easyProblems.OrderBy(x => random.Next()).Take(3));
        selectedProblems.AddRange(mediumProblems.OrderBy(x => random.Next()).Take(2));
        selectedProblems.AddRange(hardProblems.OrderBy(x => random.Next()).Take(1));

        // Randomize the order of all selected problems
        selectedProblems = selectedProblems.OrderBy(x => random.Next()).ToList();

        // Split into separate arrays for problems and solutions
        string[] problems = selectedProblems.Select(x => x.problem).ToArray();
        string[] solutions = selectedProblems.Select(x => x.solution).ToArray();

        return (problems, solutions);
    }

    private void InitializeProblems()
    {
        var (generatedProblems, generatedSolutions) = GenerateProblemSet();
        problems = generatedProblems;
        solutions = generatedSolutions;
    }

    /*
    * Method description:
    * Displays a given problem (specify by id param, where 1st problem in file is 0) on the whiteboard
    * @TODO MIGHT HAFT TO RETURN FALSE OR SOME SHIT IF THE PROBLEM IS DONE
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
    public Stack<string> getSolutionStack()
    {
        Stack<string> solnStack = new Stack<string>();
        string[] solnBlocks = solutions[currProblem].Split(", ");

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
