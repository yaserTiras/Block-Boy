using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BlockPrefab;
    public Transform LastBlocPref;
    public GameObject CrystalPrefab;
    public Transform crysPos;
    Vector3 LastBlockPos;
    public float Distance;
    void Start()
    {
        LastBlockPos = LastBlocPref.transform.position;
        InvokeRepeating("CreateBlock", 1, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateBlock()
    {
        GameObject Block = Instantiate(BlockPrefab, transform);
        int rand = Random.Range(0,12);
        if(rand>6)
        {
            Block.transform.position = new Vector3(LastBlockPos.x + Distance, LastBlockPos.y, LastBlockPos.z );
        }
        else
        {
            Block.transform.position = new Vector3(LastBlockPos.x, LastBlockPos.y, LastBlockPos.z + Distance);
        }
        bool CreateCrys = rand % 3 == 2;
        Block.transform.GetChild(0).gameObject.SetActive(CreateCrys);
            
        
        LastBlockPos = Block.transform.position;
        
    }
}
