using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    /*
    Declare SerializeFields for each block
    */

    public GameObject intBlock;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    /*
        Spawning function for each block? 
    */

    /*
        OnClick event for each block 
    */


    public void spawnInt(){
        Debug.Log("Spawned add block");
        Instantiate(intBlock, spawnBlockToTheLeft(1.0f), Quaternion.identity);
    }

    public void OnEquals(){
        Debug.Log("Spawned equals block");
    }

    public void OnSubtract(){
        Debug.Log("Spawned On Subtract Block");
    }
    
    private Vector3 spawnBlockToTheLeft(float scalar){
        return (transform.position + (Vector3.left*scalar));
    }
}
