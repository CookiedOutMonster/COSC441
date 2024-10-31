using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    /*
     SerializeFields for generic block prefab
    */

    public GameObject cubePrefab;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    /*
        Pirvate method used to calculate an offset (to the left) of the spawn point to spawn the block. 
    */
    private Vector3 spawnBlockToTheLeft(){
        float scalar = 1.0f;
        return (transform.position + (Vector3.left*scalar));
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

    public void spawnInt(){
        GameObject temp = Instantiate(cubePrefab, spawnBlockToTheLeft(), Quaternion.identity);
        IntegerVariableBlock type = temp.AddComponent<IntegerVariableBlock>();
    }

    public void spawnFloat(){
        GameObject temp = Instantiate(cubePrefab, spawnBlockToTheLeft(), Quaternion.identity);
        FloatVariableBlock type = temp.AddComponent<FloatVariableBlock>();
    }
    
    public void spawnBool(){
        GameObject temp = Instantiate(cubePrefab, spawnBlockToTheLeft(), Quaternion.identity);
        BooleanVariableBlock type = temp.AddComponent<BooleanVariableBlock>();
    }

    public void spawnString(){ 
        GameObject temp = Instantiate(cubePrefab, spawnBlockToTheLeft(), Quaternion.identity);
        StringVariableBlock type = temp.AddComponent<StringVariableBlock>();
    }

    /*
        For Comparison 
    */

    public void spawnGreaterThan(){
        GameObject temp = Instantiate(cubePrefab, spawnBlockToTheLeft(), Quaternion.identity);
        GreaterThanBlock type = temp.AddComponent<GreaterThanBlock>();
    }

    
    public void spawnLessThan(){
        GameObject temp = Instantiate(cubePrefab, spawnBlockToTheLeft(), Quaternion.identity);
        LessThanBlock type = temp.AddComponent<LessThanBlock>();
    }

    public void spawnEqualTo(){
        GameObject temp = Instantiate(cubePrefab, spawnBlockToTheLeft(), Quaternion.identity);
        EqualBlock type = temp.AddComponent<EqualBlock>();
    }

    public void spawnGreaterThanOrEqual(){ 
        GameObject temp = Instantiate(cubePrefab, spawnBlockToTheLeft(), Quaternion.identity);
        GreaterThanEqualBlock type = temp.AddComponent<GreaterThanEqualBlock>();
    }

    public void spawnLessThanOrEqual(){
        GameObject temp = Instantiate(cubePrefab, spawnBlockToTheLeft(), Quaternion.identity);
        LessThanEqualBlock type = temp.AddComponent<LessThanEqualBlock>();
    }

    public void spawnNotEqual(){
        GameObject temp = Instantiate(cubePrefab, spawnBlockToTheLeft(), Quaternion.identity);
        NotEqualBlock type = temp.AddComponent<NotEqualBlock>();
    }

    /*
        For Boolean Algebra
    */

    public void spawnAnd(){
        GameObject temp = Instantiate(cubePrefab, spawnBlockToTheLeft(), Quaternion.identity);
        AndBlock type = temp.AddComponent<AndBlock>();
    }

    public void spawnOr(){
        GameObject temp = Instantiate(cubePrefab, spawnBlockToTheLeft(), Quaternion.identity);
        OrBlock type = temp.AddComponent<OrBlock>();
    }

    public void spawnNot(){
        GameObject temp = Instantiate(cubePrefab, spawnBlockToTheLeft(), Quaternion.identity);
        NotBlock type = temp.AddComponent<NotBlock>();
    }

    /*
        For Assignment Operators 
    */

    public void spawnEqualsAssignment(){
        GameObject temp = Instantiate(cubePrefab, spawnBlockToTheLeft(), Quaternion.identity);
        EqualsBlock type = temp.AddComponent<EqualsBlock>();
    }

    public void spawnNotEqualsAssignment(){
        GameObject temp = Instantiate(cubePrefab, spawnBlockToTheLeft(), Quaternion.identity);
        NotEqualsBlock type = temp.AddComponent<NotEqualsBlock>();
    }

    /*
        For Math Operators
    */ 

    public void spawnAdd(){
        GameObject temp = Instantiate(cubePrefab, spawnBlockToTheLeft(), Quaternion.identity);
        AdditionBlock type = temp.AddComponent<AdditionBlock>();
    }

    public void spawnSubtraction(){
        GameObject temp = Instantiate(cubePrefab, spawnBlockToTheLeft(), Quaternion.identity);
        SubtractionBlock type = temp.AddComponent<SubtractionBlock>();
    }

    public void spawnMultiplaction(){
        GameObject temp = Instantiate(cubePrefab, spawnBlockToTheLeft(), Quaternion.identity);
        MultiplicationBlock type = temp.AddComponent<MultiplicationBlock>();
    }

    public void spawnDivision(){
        GameObject temp = Instantiate(cubePrefab, spawnBlockToTheLeft(), Quaternion.identity);
        DivisionBlock type = temp.AddComponent<DivisionBlock>();
    }



}
