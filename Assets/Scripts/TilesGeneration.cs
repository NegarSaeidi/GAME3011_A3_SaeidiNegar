using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TilesGeneration : MonoBehaviour
{
    public GameObject tilePrefab;
    public GameObject[] RowsParent;
    public GameObject root;
    public Sprite[] tileSprites;
    private Vector3 FinalPos;
    void Start()
    {
       
        for (int i=0; i<RowsParent.Length;i++)
        GenerateTiles(i);
    }

    private void GenerateTiles(int row)
    {
        for (int i = 0; i < 7; i++)
        {
            GameObject tile = Instantiate(tilePrefab, RowsParent[row].transform.position, RowsParent[row].transform.rotation, RowsParent[row].transform);
            int rand = Random.Range(1, 10);
            tile.GetComponent<Image>().sprite = tileSprites[rand];

            tile.transform.parent = RowsParent[row].transform;
        }
        
     
    }
  
 
}
