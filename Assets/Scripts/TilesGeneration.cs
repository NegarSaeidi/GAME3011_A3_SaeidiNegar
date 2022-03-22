using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TilesGeneration : MonoBehaviour
{
    public GameObject tilePrefab;
    public GameObject[] RowsParent;
    public GameObject root;
    public static bool gameStarted;
    public  Sprite[] tileSprites;
    public GameObject winPanel;
    public static int maxRange;
    public static  List<GameObject> gridTiles;
    public bool FadeInCoroutineStarted, FadeOutCoroutineStarted;
    public GameObject[] scoreTiles;
    public static int[] scores;
   public static bool tilesGenerating;
    private int previousRandom;

    void Start()
    {
        tilesGenerating = false;
        maxRange = 10;
        previousRandom = 1;
        scores = new int[10];
        gridTiles = new List<GameObject>();
        for (int i=0; i<RowsParent.Length;i++)
        GenerateTiles(i);
        for (int k = 0; k < scores.Length; k++)
        {
            scores[k] = 0;

            scoreTiles[k].GetComponent<TextMeshProUGUI>().text = "0";

        }

    }

    private void GenerateTiles(int row)
    {
        for (int i = 0; i < 7; i++)
        {
            int rand;
            //tilesGenerating = true;
            GameObject tile = Instantiate(tilePrefab, RowsParent[row].transform.position, RowsParent[row].transform.rotation, RowsParent[row].transform);
            do
            {
               rand = Random.Range(1, maxRange);
            }
            while (previousRandom == rand);
            previousRandom = rand;
            if (DifficultyLevelSet.level=="hard" || DifficultyLevelSet.level == "medium")
            if (rand == maxRange - 1)
                tile.GetComponent<Button>().enabled = false;
            tile.GetComponent<Image>().sprite = tileSprites[rand];
            gridTiles.Add(tile);
            tile.transform.parent = RowsParent[row].transform;

        }
        
     
    }
    private void Update()
    {
        if (!tilesGenerating)
        {
            CheckForWin();
            CheckVertical();
            CheckHorizontal();
        }
        
    }
    private void CheckForWin()
    {
        int counter = 0;
        for (int i = 0; i < scores.Length; i++)
        {
            if (scores[i] > 0)
                counter++;
        }
       
        if (DifficultyLevelSet.level=="easy")
        {
            if (counter == 3)
                winPanel.gameObject.SetActive(true);
        }
        else if (DifficultyLevelSet.level == "medium")
        {
            if (counter ==4)
                winPanel.gameObject.SetActive(true);
        }
        else if (DifficultyLevelSet.level == "hard")
        {
            if (counter ==5)
                winPanel.gameObject.SetActive(true);
        }

    }
    public  void CheckVertical()
    {
        for (int i = 0; i < gridTiles.Count; i++)
        {
            if (i + 14 < gridTiles.Count)
                if (gridTiles[i].GetComponent<Image>().sprite == gridTiles[i + 7].GetComponent<Image>().sprite)
                {
                    if (gridTiles[i].GetComponent<Image>().sprite == gridTiles[i + 14].GetComponent<Image>().sprite)
                    {
                        if (gridTiles[i].GetComponent<Image>().sprite.name == "bomb_circle")
                        {
                           // tilesGenerating = true;
                            for (int j = 0; j < gridTiles.Count; j++)
                            {
                                bombImmoveableEffect(j);
                            }
                            for (int k = 0; k < scores.Length; k++)
                            {
                                scores[k] = 0;

                                scoreTiles[k].GetComponent<TextMeshProUGUI>().text = "0";

                            }
                           // tilesGenerating = false;
                        }
                        else
                        {
                            if (!FadeInCoroutineStarted)
                            {
                                if (!FadeOutCoroutineStarted)
                                {
                                    GetComponent<AudioSource>().Play();
                                    Scoring(gridTiles[i].GetComponent<Image>().sprite);
                                    FadeOutCoroutineStarted = true;
                                    gridTiles[i].GetComponent<Animator>().SetTrigger("Disappear");
                                    gridTiles[i + 7].GetComponent<Animator>().SetTrigger("Disappear");
                                    gridTiles[i + 14].GetComponent<Animator>().SetTrigger("Disappear");
                                 
                                    StartCoroutine(FadeOut(i, i + 7, i + 14));
                                }



                               

                                FadeInCoroutineStarted = true;
                                StartCoroutine(DelayBeforeRegenerate(i, i + 7, i + 14));

                            }



                        }
                    }
                }
        }
    }
    private void bombImmoveableEffect(int index)
    {
       
        int rand = Random.Range(1, maxRange);
        if (DifficultyLevelSet.level == "hard" || DifficultyLevelSet.level == "medium")
            if (rand == maxRange - 1)
            gridTiles[index].GetComponent<Button>().enabled = false;
        else
            gridTiles[index].GetComponent<Button>().enabled = true;
        gridTiles[index].GetComponent<Image>().sprite = tileSprites[rand];
        gridTiles[index].GetComponent<Animator>().SetTrigger("Appear");
      
    }
    public void CheckHorizontal()
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
                                if (gridTiles[i].GetComponent<Image>().sprite.name == "bomb_circle")
                                {
                                    for (int j = 0; j < gridTiles.Count; j++)
                                        bombImmoveableEffect(j);
                                    for (int k = 0; k < scores.Length; k++)
                                    {
                                        scores[k] = 0;
                                       
                                        scoreTiles[k].GetComponent<TextMeshProUGUI>().text = "0";
                                        
                                    }
                                }
                                else
                                {
                                    if (!FadeInCoroutineStarted)
                                    {
                                        if (!FadeOutCoroutineStarted)
                                        {
                                            GetComponent<AudioSource>().Play();
                                            Scoring(gridTiles[i].GetComponent<Image>().sprite);
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
        yield return new WaitForSeconds(0.5f);

        int rand = Random.Range(1, maxRange);
        if (rand == maxRange - 1)
        gridTiles[i].GetComponent<Button>().enabled = false;
        gridTiles[i].GetComponent<Image>().sprite = tileSprites[rand];
       gridTiles[i].GetComponent<Animator>().SetTrigger("Appear");
        gridTiles[i].GetComponent<Image>().color = new Color(gridTiles[i].GetComponent<Image>().color.r, gridTiles[i].GetComponent<Image>().color.g, gridTiles[i].GetComponent<Image>().color.b, 255);
        rand = Random.Range(1, maxRange);
        if (rand == maxRange - 1)
        gridTiles[j].GetComponent<Button>().enabled = false;
        gridTiles[j].GetComponent<Image>().sprite = tileSprites[rand];
        gridTiles[j].GetComponent<Animator>().SetTrigger("Appear");
        gridTiles[j].GetComponent<Image>().color = new Color(gridTiles[j].GetComponent<Image>().color.r, gridTiles[j].GetComponent<Image>().color.g, gridTiles[j].GetComponent<Image>().color.b, 255);
        rand = Random.Range(1, maxRange);
        if (rand == maxRange - 1)
       gridTiles[k].GetComponent<Button>().enabled = false;
        gridTiles[k].GetComponent<Image>().sprite = tileSprites[rand];
       gridTiles[k].GetComponent<Animator>().SetTrigger("Appear");
        gridTiles[k].GetComponent<Image>().color = new Color(gridTiles[k].GetComponent<Image>().color.r, gridTiles[k].GetComponent<Image>().color.g, gridTiles[k].GetComponent<Image>().color.b, 255);
        FadeInCoroutineStarted = false;
    }
    private void Scoring(Sprite sp)
    {
        switch(sp.name)
        {
            case "43":
                scores[0]++;
                scoreTiles[0].GetComponent<TextMeshProUGUI>().text = scores[0].ToString();
                break;
            case "36":
                scores[1]++;
                scoreTiles[1].GetComponent<TextMeshProUGUI>().text = scores[1].ToString();
                break;
            case "14":
                scores[2]++;
                scoreTiles[2].GetComponent<TextMeshProUGUI>().text = scores[2].ToString();
                break;
            case "11":
                scores[3]++;
                scoreTiles[3].GetComponent<TextMeshProUGUI>().text = scores[3].ToString();
                break;
            case "21":
                scores[4]++;
                scoreTiles[4].GetComponent<TextMeshProUGUI>().text = scores[4].ToString();
                break;
            case "22":
                scores[5]++;
                scoreTiles[5].GetComponent<TextMeshProUGUI>().text = scores[5].ToString();
                break;
            case "33":
                scores[6]++;
                scoreTiles[6].GetComponent<TextMeshProUGUI>().text = scores[6].ToString();
                break;
            case "2":
                scores[7]++;
                scoreTiles[7].GetComponent<TextMeshProUGUI>().text = scores[7].ToString();
                break;
            case "1":
                scores[8]++;
                scoreTiles[8].GetComponent<TextMeshProUGUI>().text = scores[8].ToString();
                break;
            case "48":
                scores[9]++;
                scoreTiles[9].GetComponent<TextMeshProUGUI>().text = scores[9].ToString();
                break;
        }
    }
}
