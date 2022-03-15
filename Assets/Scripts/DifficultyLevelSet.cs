using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DifficultyLevelSet : MonoBehaviour
{
    public GameObject[] scoreTiles;
    private int[] scores;
    public Sprite[] tileSprites;
    public static string level;
    private int resetScore = 0;
    private void Start()
    {
        level = "easy";
        scores = new int[10];
    }
    public void OnEasyClicked()
    {
        if (Timer.time > 1)
        {
            level = "easy";
            TilesGeneration.maxRange = 10;
            Timer.time = 120;
            for (int i = 0; i < TilesGeneration.gridTiles.Count; i++)
                Regenrate(i);
            for (int i = 0; i < scoreTiles.Length; i++)
            {
                scoreTiles[i].GetComponent<TextMeshProUGUI>().text = resetScore.ToString();
                scores[i] = 0;
            }
        }
    }
    public void OnMediumClicked()
    {
        if (Timer.time > 1)
        {
            level = "medium";
            TilesGeneration.maxRange = 12;
            Timer.time = 120;
            for (int i = 0; i < TilesGeneration.gridTiles.Count; i++)
                Regenrate(i);
            for (int i = 0; i < scoreTiles.Length; i++)
            {
                scoreTiles[i].GetComponent<TextMeshProUGUI>().text = resetScore.ToString();
                scores[i] = 0;
            }
        }
    }
    public void OnHardClicked()
    {
        if (Timer.time > 1)
        {
            level = "hard";
            TilesGeneration.maxRange = 12;
            Timer.time = 120;
            for (int i = 0; i < TilesGeneration.gridTiles.Count; i++)
                Regenrate(i);
            for (int i = 0; i < scoreTiles.Length; i++)
            {
                scoreTiles[i].GetComponent<TextMeshProUGUI>().text = resetScore.ToString();
                scores[i] = 0;
            }
        }
    }
    private void Regenrate(int index)
    {

        int rand = Random.Range(1, TilesGeneration.maxRange);
        if (DifficultyLevelSet.level == "hard" || DifficultyLevelSet.level == "medium")
            if (rand == TilesGeneration. maxRange - 1)
            TilesGeneration.gridTiles[index].GetComponent<Button>().enabled = false;
        else
            TilesGeneration.gridTiles[index].GetComponent<Button>().enabled = true;
        TilesGeneration.gridTiles[index].GetComponent<Image>().sprite = tileSprites[rand];
        TilesGeneration.gridTiles[index].GetComponent<Animator>().SetTrigger("Appear");

    }
}
