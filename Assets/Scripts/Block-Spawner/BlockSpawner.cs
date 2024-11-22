using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    // block prefabs for each block type, which are assigned values via the inspector
    public GameObject prefab_Int;
    public GameObject prefab_Float;
    public GameObject prefab_Bool;
    public GameObject prefab_String;

    public GameObject prefab_Greater;
    public GameObject prefab_Less;
    public GameObject prefab_Equal;
    public GameObject prefab_GreaterOrEqual;
    public GameObject prefab_LessOrEqual;
    public GameObject prefab_NotEqual;

    public GameObject prefab_And;
    public GameObject prefab_Or;
    public GameObject prefab_Not;

    public GameObject prefab_EqualsAssign;
    public GameObject prefab_NotEqualAssign;

    public GameObject prefab_Add;
    public GameObject prefab_Subtract;
    public GameObject prefab_Multiply;
    public GameObject prefab_Divide;


    public GameObject prefab_A;
    public GameObject prefab_B;
    public GameObject prefab_C;
    public GameObject prefab_X;
    public GameObject prefab_Y;
    public GameObject prefab_Z;


    public GameObject prefab_1;
    public GameObject prefab_2;
    public GameObject prefab_3;
    public GameObject prefab_4;
    public GameObject prefab_5;
    public GameObject prefab_6;
    public GameObject prefab_7;
    public GameObject prefab_8;
    public GameObject prefab_9;
    public GameObject prefab_0;
    public GameObject prefab_decimal;


    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    }

    /*
        Private method used to calculate an offset (to the left) of the spawn point to spawn the block. 
    */
    private Vector3 spawnBlockToTheLeft()
    {
        float scalar = 1.0f;
        return (transform.position + (Vector3.left * scalar));
    }

    /*
        Look, I know this isn't the best way to program this, but I didn't want to spend time adding another serializable field for an enum or something like that for each button. 
        So instead I hardcoded it. But hey man, it works.

            - Each method is 1:1 for a button. 
            - Each method spawns a cube prefab, defined above as a seriazable field called temp 
            - Each method assigns temp it's own unique script to determine the block type. 
    */

    /*
        For Variables 
    */

    public void spawnInt()
    {
        GameObject temp = Instantiate(prefab_Int, spawnBlockToTheLeft(), Quaternion.identity);
        IntegerVariableBlock type = temp.AddComponent<IntegerVariableBlock>();
    }

    public void spawnFloat()
    {
        GameObject temp = Instantiate(prefab_Float, spawnBlockToTheLeft(), Quaternion.identity);
        FloatVariableBlock type = temp.AddComponent<FloatVariableBlock>();
    }

    public void spawnBool()
    {
        GameObject temp = Instantiate(prefab_Bool, spawnBlockToTheLeft(), Quaternion.identity);
        BooleanVariableBlock type = temp.AddComponent<BooleanVariableBlock>();
    }

    public void spawnString()
    {
        GameObject temp = Instantiate(prefab_String, spawnBlockToTheLeft(), Quaternion.identity);
        StringVariableBlock type = temp.AddComponent<StringVariableBlock>();
    }

    /*
        For Comparison 
    */

    public void spawnGreaterThan()
    {
        GameObject temp = Instantiate(prefab_Greater, spawnBlockToTheLeft(), Quaternion.identity);
        GreaterThanBlock type = temp.AddComponent<GreaterThanBlock>();
    }


    public void spawnLessThan()
    {
        GameObject temp = Instantiate(prefab_Less, spawnBlockToTheLeft(), Quaternion.identity);
        LessThanBlock type = temp.AddComponent<LessThanBlock>();
    }

    public void spawnEqualTo()
    {
        GameObject temp = Instantiate(prefab_Equal, spawnBlockToTheLeft(), Quaternion.identity);
        EqualBlock type = temp.AddComponent<EqualBlock>();
    }

    public void spawnGreaterThanOrEqual()
    {
        GameObject temp = Instantiate(prefab_GreaterOrEqual, spawnBlockToTheLeft(), Quaternion.identity);
        GreaterThanEqualBlock type = temp.AddComponent<GreaterThanEqualBlock>();
    }

    public void spawnLessThanOrEqual()
    {
        GameObject temp = Instantiate(prefab_LessOrEqual, spawnBlockToTheLeft(), Quaternion.identity);
        LessThanEqualBlock type = temp.AddComponent<LessThanEqualBlock>();
    }

    public void spawnNotEqual()
    {
        GameObject temp = Instantiate(prefab_NotEqual, spawnBlockToTheLeft(), Quaternion.identity);
        NotEqualBlock type = temp.AddComponent<NotEqualBlock>();
    }

    /*
        For Boolean Algebra
    */

    public void spawnAnd()
    {
        GameObject temp = Instantiate(prefab_And, spawnBlockToTheLeft(), Quaternion.identity);
        AndBlock type = temp.AddComponent<AndBlock>();
    }

    public void spawnOr()
    {
        GameObject temp = Instantiate(prefab_Or, spawnBlockToTheLeft(), Quaternion.identity);
        OrBlock type = temp.AddComponent<OrBlock>();
    }

    public void spawnNot()
    {
        GameObject temp = Instantiate(prefab_Not, spawnBlockToTheLeft(), Quaternion.identity);
        NotBlock type = temp.AddComponent<NotBlock>();
    }

    /*
        For Assignment Operators
    */

    public void spawnEqualsAssignment()
    {
        GameObject temp = Instantiate(prefab_EqualsAssign, spawnBlockToTheLeft(), Quaternion.identity);
        EqualsBlock type = temp.AddComponent<EqualsBlock>();
    }

    public void spawnNotEqualsAssignment()
    {
        GameObject temp = Instantiate(prefab_NotEqualAssign, spawnBlockToTheLeft(), Quaternion.identity);
        NotEqualsBlock type = temp.AddComponent<NotEqualsBlock>();
    }

    /*
        For Math Operators
    */

    public void spawnAdd()
    {
        GameObject temp = Instantiate(prefab_Add, spawnBlockToTheLeft(), Quaternion.identity);
        AdditionBlock type = temp.AddComponent<AdditionBlock>();
    }

    public void spawnSubtraction()
    {
        GameObject temp = Instantiate(prefab_Subtract, spawnBlockToTheLeft(), Quaternion.identity);
        SubtractionBlock type = temp.AddComponent<SubtractionBlock>();
    }

    public void spawnMultiplication()
    {
        GameObject temp = Instantiate(prefab_Multiply, spawnBlockToTheLeft(), Quaternion.identity);
        MultiplicationBlock type = temp.AddComponent<MultiplicationBlock>();
    }

    public void spawnDivision()
    {
        GameObject temp = Instantiate(prefab_Divide, spawnBlockToTheLeft(), Quaternion.identity);
        DivisionBlock type = temp.AddComponent<DivisionBlock>();
    }
/*
        For Letters
    */
    public void spawnA()
    {
        GameObject temp = Instantiate(prefab_A, spawnBlockToTheLeft(), Quaternion.identity);
        StringVariableBlock type = temp.AddComponent<StringVariableBlock>();
        type.SetValue("A");
    }

    public void spawnB()
    {
        GameObject temp = Instantiate(prefab_B, spawnBlockToTheLeft(), Quaternion.identity);
        StringVariableBlock type = temp.AddComponent<StringVariableBlock>();
        type.SetValue("B");
    }

    public void spawnC()
    {
        GameObject temp = Instantiate(prefab_C, spawnBlockToTheLeft(), Quaternion.identity);
        StringVariableBlock type = temp.AddComponent<StringVariableBlock>();
        type.SetValue("C");
    }

    public void spawnX()
    {
        GameObject temp = Instantiate(prefab_X, spawnBlockToTheLeft(), Quaternion.identity);
        StringVariableBlock type = temp.AddComponent<StringVariableBlock>();
        type.SetValue("X");
    }
    
     public void spawnY()
    {
        GameObject temp = Instantiate(prefab_Y, spawnBlockToTheLeft(), Quaternion.identity);
        StringVariableBlock type = temp.AddComponent<StringVariableBlock>();
        type.SetValue("Y");
    }

      public void spawnZ()
    {
        GameObject temp = Instantiate(prefab_Z, spawnBlockToTheLeft(), Quaternion.identity);
        StringVariableBlock type = temp.AddComponent<StringVariableBlock>();
        type.SetValue("Z");
    }

//     /*
//         For Numbers
//     */
 public void spawn0()
    {
        GameObject temp = Instantiate(prefab_0, spawnBlockToTheLeft(), Quaternion.identity);
        IntegerVariableBlock type = temp.AddComponent<IntegerVariableBlock>();
        type.SetValue("0");
    }

     public void spawn1()
    {
        GameObject temp = Instantiate(prefab_1, spawnBlockToTheLeft(), Quaternion.identity);
        IntegerVariableBlock type = temp.AddComponent<IntegerVariableBlock>();
        type.SetValue("1");
    }

     public void spawn2()
    {
        GameObject temp = Instantiate(prefab_2, spawnBlockToTheLeft(), Quaternion.identity);
        IntegerVariableBlock type = temp.AddComponent<IntegerVariableBlock>();
        type.SetValue("2");
    }

     public void spawn3()
    {
        GameObject temp = Instantiate(prefab_3, spawnBlockToTheLeft(), Quaternion.identity);
        IntegerVariableBlock type = temp.AddComponent<IntegerVariableBlock>();
        type.SetValue("3");
    }

     public void spawn4()
    {
        GameObject temp = Instantiate(prefab_4, spawnBlockToTheLeft(), Quaternion.identity);
        IntegerVariableBlock type = temp.AddComponent<IntegerVariableBlock>();
        type.SetValue("4");
    }

    public void spawn5()
    {
        GameObject temp = Instantiate(prefab_5, spawnBlockToTheLeft(), Quaternion.identity);
        IntegerVariableBlock type = temp.AddComponent<IntegerVariableBlock>();
        type.SetValue("5");
    }

     public void spawn6()
    {
        GameObject temp = Instantiate(prefab_6, spawnBlockToTheLeft(), Quaternion.identity);
        IntegerVariableBlock type = temp.AddComponent<IntegerVariableBlock>();
        type.SetValue("6");
    }

    public void spawn7()
    {
        GameObject temp = Instantiate(prefab_7, spawnBlockToTheLeft(), Quaternion.identity);
        IntegerVariableBlock type = temp.AddComponent<IntegerVariableBlock>();
        type.SetValue("7");
    }

     public void spawn8()
    {
        GameObject temp = Instantiate(prefab_8, spawnBlockToTheLeft(), Quaternion.identity);
        IntegerVariableBlock type = temp.AddComponent<IntegerVariableBlock>();
        type.SetValue("8");
    }

     public void spawn9()
    {
        GameObject temp = Instantiate(prefab_9, spawnBlockToTheLeft(), Quaternion.identity);
        IntegerVariableBlock type = temp.AddComponent<IntegerVariableBlock>();
        type.SetValue("9");
    }

    public void spawnDec()
    {
        GameObject temp = Instantiate(prefab_decimal, spawnBlockToTheLeft(), Quaternion.identity);
        IntegerVariableBlock type = temp.AddComponent<IntegerVariableBlock>();
        type.SetValue(".");
    }
    
}
