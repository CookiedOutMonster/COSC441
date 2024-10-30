# COSC441
Block programming in VR for a COSC441 research project. Made in Unity. 

## Preparing Unity for Git 
https://stackoverflow.com/questions/21573405/how-to-prepare-a-unity-project-for-git-step-by-step

## Pull Requests 

Should have work done explained via bullet points. 

Two people to review each PR. Code reviews are not important, just determine if the PR actually works and does not result in any errors. 

## Merging: 

Fixing merge issues is up to the creator of the PR.

## Branch names: 

Branch names shall be named as feature-subfeature. For example: interaction-blocks. 

---

## Documentation:

This section of the README is to contain info for developers regarding how various parts of the code work, example uses, ideas for how to connect parts of the code together, etc.

### ProblemBoard

#### Format for adding new problems to problemset.txt

Line 1: number of problems in the file

The rest of the file contains problems, where each problem consists of a problem statement and a solution. Therefore each problem = 2 lines.

- Problem statement: in plain English; this is what will be displayed on the ProblemBoard for the user to see
- Solution: as a list of block types, where each block type is delimited by ", " (note: we can and probably will change this later on!)

There should be no additional spaces or blank lines in the file.

#### For information re: problem that's currently on the whiteboard/actively being worked on

##### getCurrProblemIndex(): 
Returns an integer representing the current problem's index/id, AKA its position in the file (and in the arrays storing problem statements and solutions)
- 0 means it's the 1st problem in the file, 1 means it's the second, and so on

##### getCurrProblemStatement(): 
Returns a string, the actual text of the problem currently being displayed on the whiteboard

#### Get solution stack for current problem

1. Get the id of the current problem using getCurrProblemIndex().
2. Then pass that as a parameter to getSolutionStack(), which will return a Stack of strings which form that problem's solution.
   - Each item in the Stack is a block type name (for example, "Var_Integer" for a variable of type int).

#### Using the solution stack to check participant's work

Todo: generate another Stack that represents the participant's solution, containing all the types of blocks they used in the order that they placed them. Follow same format as solution stack.

1. Check that the Stacks are of equal length (if participant used all same blocks as solution, they should have the same # of those blocks).
2. Then pop() Stack elements one-by-one and compare participant stack items to solution stack items.
3. Any time there's a mismatch, means they have an error. Indicate this visually (red underline, etc.)
4. If we get to the end and there hasn't been any mismatches, their solution is correct!

#### Moving onto next problem in the set

Once the participant has correctly solved the current problem (we've checked it against the solution stack and it matches up 100%), use **nextProblem()** to advance to the next problem. If they've just completed the last problem in the set, this method displays a completion message on the ProblemBoard and sets currProblem = -1. 

- Why -1? My thought was that -1 makes it easy to restart the problem set if we need to: simply increment by 1 and you're back to the beginning of the file.