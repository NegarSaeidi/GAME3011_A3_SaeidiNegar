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
    public static  List<GameObject> gridTiles;
    void Start()
    {
        gridTiles = new List<GameObject>();
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
            gridTiles.Add(tile);
            tile.transform.parent = RowsParent[row].transform;
        }
        
     
    }
    private void Update()
    {
        CheckVertical();
        CheckHorizontal();
    }
    private void CheckVertical()
    {
        for (int i = 0; i < gridTiles.Count; i++)
        {
            if (i + 14 < gridTiles.Count)
                if (gridTiles[i].GetComponent<Image>().sprite == gridTiles[i + 7].GetComponent<Image>().sprite)
                {
                    if (gridTiles[i].GetComponent<Image>().sprite == gridTiles[i + 14].GetComponent<Image>().sprite)
                    {
                        gridTiles[i].transform.GetChild(0).gameObject.SetActive(true);
                        gridTiles[i+7].transform.GetChild(0).gameObject.SetActive(true);
                        gridTiles[i+14].transform.GetChild(0).gameObject.SetActive(true);
                    }
                }
        }
    }
    private void CheckHorizontal()
    {
        for (int i = 0; i < gridTiles.Count; i++)
        {
            if (i + 2 < gridTiles.Count)
            {
                if((i/7)== ((i+1)/7))
                if (gridTiles[i].GetComponent<Image>().sprite == gridTiles[i + 1].GetComponent<Image>().sprite)
                {
                     if ((i / 7) == ((i + 2) / 7))
                    if (gridTiles[i].GetComponent<Image>().sprite == gridTiles[i + 2].GetComponent<Image>().sprite)
                    {

                        gridTiles[i].transform.GetChild(0).gameObject.SetActive(true);
                        gridTiles[i + 1].transform.GetChild(0).gameObject.SetActive(true);
                        gridTiles[i + 2].transform.GetChild(0).gameObject.SetActive(true);
                    }
                }
            }

        }
    }
    public void MoveTile()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


    }

}
