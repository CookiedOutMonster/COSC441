using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mock : MonoBehaviour
{
    public GameObject cubePrefab;  // The prefab to instantiate
    private Stack<GameObject> blockStack = new Stack<GameObject>();  // The stack to hold the blocks

    private Compare compare;  // Reference to the Compare component

    void Awake()
    {
        getCompare();  // Initialize the compare reference 
    }

    // 2 right but not done 
    void test()
    {
        // Add blocks for testing
        GameObject temp = Instantiate(cubePrefab, Vector3.zero, Quaternion.identity);
        IntegerVariableBlock type = temp.AddComponent<IntegerVariableBlock>();
        blockStack.Push(temp);  // Add the block to the stack

        GameObject temp2 = Instantiate(cubePrefab, Vector3.zero, Quaternion.identity);
        EqualsBlock type2 = temp2.AddComponent<EqualsBlock>();
        blockStack.Push(temp2);  // Add the block to the stack
    }

    // 1 wrong 1 right
    void test2()
    {
        // Add blocks for testing
        GameObject temp = Instantiate(cubePrefab, Vector3.zero, Quaternion.identity);
        IntegerVariableBlock type = temp.AddComponent<IntegerVariableBlock>();
        blockStack.Push(temp);  // Add the block to the stack

        GameObject temp2 = Instantiate(cubePrefab, Vector3.zero, Quaternion.identity);
        FloatVariableBlock type2 = temp2.AddComponent<FloatVariableBlock>();
        blockStack.Push(temp2);  // Add the block to the stack
    }

    // all right
    void test3()
    {
        // Add blocks for testing
        GameObject temp = Instantiate(cubePrefab, Vector3.zero, Quaternion.identity);
        IntegerVariableBlock type = temp.AddComponent<IntegerVariableBlock>();
        blockStack.Push(temp);  // Add the block to the stack

        GameObject temp2 = Instantiate(cubePrefab, Vector3.zero, Quaternion.identity);
        EqualsBlock type2 = temp2.AddComponent<EqualsBlock>();
        blockStack.Push(temp2);  // Add the block to the stack

        GameObject temp3 = Instantiate(cubePrefab, Vector3.zero, Quaternion.identity);
        FloatVariableBlock type3 = temp3.AddComponent<FloatVariableBlock>();
        blockStack.Push(temp3);  // Add the block to the stack
    }

    // Start is called before the first frame update
    void Start()
    {

        bool interpit;
        interpit = true;

        /*
        test();
        bool test1_results = compare.checkBlocksOnBoard(blockStack, interpit);
        Debug.Log("observed " + test1_results + "wanted " + false);

        test2();
        bool test2_results = compare.checkBlocksOnBoard(blockStack, interpit);
        Debug.Log("observed " + test2_results + "wanted " + false);
        */
        Debug.LogError("hello?");
        //test3();
        //bool test3_results = compare.checkBlocksOnBoard(blockStack, interpit);
        //Debug.Log("observed " + test3_results + "wanted " + true);


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void getCompare()
    {
        // Find the GameObject called "Board" (not "whiteboard-header" as in Compare)
        GameObject board = GameObject.Find("Board");

        if (board != null)
        {
            // Get the Compare component attached to it
            compare = board.GetComponent<Compare>();  // Correctly store the Compare component
        }
        else
        {
            Debug.Log("There was an error retrieving the Compare component. This is not going to work.");
        }
    }




}
