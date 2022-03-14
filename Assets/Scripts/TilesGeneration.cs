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
    private int maxRange;
    public static  List<GameObject> gridTiles;
    public bool FadeInCoroutineStarted, FadeOutCoroutineStarted;
    void Start()
    {
        maxRange = 11;
        gridTiles = new List<GameObject>();
        for (int i=0; i<RowsParent.Length;i++)
        GenerateTiles(i);
       
    }

    private void GenerateTiles(int row)
    {
        for (int i = 0; i < 7; i++)
        {
            GameObject tile = Instantiate(tilePrefab, RowsParent[row].transform.position, RowsParent[row].transform.rotation, RowsParent[row].transform);
            int rand = Random.Range(1, maxRange);
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
                        if (!FadeInCoroutineStarted )
                        {
                            if (!FadeOutCoroutineStarted)
                            {
                                FadeOutCoroutineStarted = true;
                                gridTiles[i].GetComponent<Animator>().SetTrigger("Disappear");
                                gridTiles[i+7].GetComponent<Animator>().SetTrigger("Disappear");
                                gridTiles[i+14].GetComponent<Animator>().SetTrigger("Disappear");
                                StartCoroutine(FadeOut(i, i + 7, i + 14));
                            }
                           
                         
                          


                            FadeInCoroutineStarted = true;
                            StartCoroutine(DelayBeforeRegenerate(i,i+7,i+14));
                          
                        }

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
                                if (!FadeInCoroutineStarted)
                                {
                                    if (!FadeOutCoroutineStarted)
                                    {
                                        FadeOutCoroutineStarted = true;
                                        gridTiles[i].GetComponent<Animator>().SetTrigger("Disappear");
                                        gridTiles[i + 1].GetComponent<Animator>().SetTrigger("Disappear");
                                        gridTiles[i + 2].GetComponent<Animator>().SetTrigger("Disappear");
                                        StartCoroutine(FadeOut(i, i + 1, i + 2));
                                    }
                                    FadeInCoroutineStarted = true;
                                    StartCoroutine(DelayBeforeRegenerate(i, i + 1, i + 2));

                                }
                    }
                }
            }

        }
    }
    public void MoveTile()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


    }

    IEnumerator FadeOut(int i, int j, int k)
    {
        yield return new WaitForSeconds(0.5f);
      
        gridTiles[i].GetComponent<Image>().color = new Color(gridTiles[i].GetComponent<Image>().color.r, gridTiles[i].GetComponent<Image>().color.g, gridTiles[i].GetComponent<Image>().color.b, 0);
        gridTiles[j].GetComponent<Image>().color = new Color(gridTiles[j].GetComponent<Image>().color.r, gridTiles[j].GetComponent<Image>().color.g, gridTiles[j].GetComponent<Image>().color.b, 0);
        gridTiles[k].GetComponent<Image>().color = new Color(gridTiles[k].GetComponent<Image>().color.r, gridTiles[k].GetComponent<Image>().color.g, gridTiles[k].GetComponent<Image>().color.b, 0);
        FadeOutCoroutineStarted = false;
    }
    IEnumerator DelayBeforeRegenerate(int i,int j, int k)
    {
        yield return new WaitForSeconds(2f);

        int rand = Random.Range(1, maxRange);
        gridTiles[i].GetComponent<Image>().sprite = tileSprites[rand];
       gridTiles[i].GetComponent<Animator>().SetTrigger("Appear");
        gridTiles[i].GetComponent<Image>().color = new Color(gridTiles[i].GetComponent<Image>().color.r, gridTiles[i].GetComponent<Image>().color.g, gridTiles[i].GetComponent<Image>().color.b, 255);
        rand = Random.Range(1, maxRange);
        gridTiles[j].GetComponent<Image>().sprite = tileSprites[rand];
        gridTiles[j].GetComponent<Animator>().SetTrigger("Appear");
        gridTiles[j].GetComponent<Image>().color = new Color(gridTiles[j].GetComponent<Image>().color.r, gridTiles[j].GetComponent<Image>().color.g, gridTiles[j].GetComponent<Image>().color.b, 255);
        rand = Random.Range(1, maxRange);
        gridTiles[k].GetComponent<Image>().sprite = tileSprites[rand];
       gridTiles[k].GetComponent<Animator>().SetTrigger("Appear");
        gridTiles[k].GetComponent<Image>().color = new Color(gridTiles[k].GetComponent<Image>().color.r, gridTiles[k].GetComponent<Image>().color.g, gridTiles[k].GetComponent<Image>().color.b, 255);
        FadeInCoroutineStarted = false;
    }
}
