using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TilesSwap : MonoBehaviour
{
    private Vector3 mouseDownPosition;
    private int thisTileIndex;
    private bool clicked;
    public GameObject arrow;
    private GameObject direction;
  public void OnClikTile()
    {

             TilesGeneration.gameStarted = true;
             direction = Instantiate(arrow, this.transform);
       
            mouseDownPosition = Input.mousePosition;
            clicked = true;
        
    }

    private void Update()
    {
        if (Timer.time < 1)
        {
            for (int i = 0; i < TilesGeneration.gridTiles.Count; i++)
            {
                TilesGeneration.gridTiles[i].gameObject.GetComponent<Button>().interactable = false;
            }
        }
        if (clicked)
        {
            
            
                for (int i = 0; i < TilesGeneration.gridTiles.Count; i++)
                {
                    if ((TilesGeneration.gridTiles[i].transform.position.x == transform.position.x) &&
                         (TilesGeneration.gridTiles[i].transform.position.y == transform.position.y))
                    {
                        thisTileIndex = i;
                    }
                }
                //right
                if (Input.mousePosition.x > mouseDownPosition.x)
                {
                    if ((thisTileIndex + 1) % 7 != 0)
                    {
                    if (TilesGeneration.gridTiles[thisTileIndex + 1].GetComponent<Button>().isActiveAndEnabled)
                    {

                      //  if (CheckHorizontal() || CheckVertical())
                        {
                            direction.GetComponent<Animator>().SetBool("Right", true);
                            StartCoroutine(causeDelay());
                          
                            Sprite temp = TilesGeneration.gridTiles[thisTileIndex + 1].GetComponent<Image>().sprite;
                            TilesGeneration.gridTiles[thisTileIndex + 1].GetComponent<Image>().sprite = TilesGeneration.gridTiles[thisTileIndex].GetComponent<Image>().sprite;
                            TilesGeneration.gridTiles[thisTileIndex].GetComponent<Image>().sprite = temp;
                        }
                    }

                    }
                    clicked = false;
                TilesGeneration.gameStarted = false;
            }
                else if (Input.mousePosition.x < mouseDownPosition.x)
                {
                    if ((thisTileIndex) % 7 != 0)
                    {
                    if (TilesGeneration.gridTiles[thisTileIndex -1].GetComponent<Button>().isActiveAndEnabled)
                    {
                        direction.GetComponent<Animator>().SetBool("Left", true);
                        StartCoroutine(causeDelay());
                        Sprite temp = TilesGeneration.gridTiles[thisTileIndex - 1].GetComponent<Image>().sprite;
                        TilesGeneration.gridTiles[thisTileIndex - 1].GetComponent<Image>().sprite = TilesGeneration.gridTiles[thisTileIndex].GetComponent<Image>().sprite;
                        TilesGeneration.gridTiles[thisTileIndex].GetComponent<Image>().sprite = temp;
                    }

                    }
                    clicked = false;
                TilesGeneration.gameStarted = false;
            }
                else if (Input.mousePosition.y < mouseDownPosition.y)
                {
                    if (thisTileIndex / 7 != 0)
                    {
                    if (TilesGeneration.gridTiles[thisTileIndex - 7].GetComponent<Button>().isActiveAndEnabled)
                    {
                        direction.GetComponent<Animator>().SetBool("Down", true);
                        StartCoroutine(causeDelay());
                        Sprite temp = TilesGeneration.gridTiles[thisTileIndex - 7].GetComponent<Image>().sprite;
                        TilesGeneration.gridTiles[thisTileIndex - 7].GetComponent<Image>().sprite = TilesGeneration.gridTiles[thisTileIndex].GetComponent<Image>().sprite;
                        TilesGeneration.gridTiles[thisTileIndex].GetComponent<Image>().sprite = temp;
                    }
                    }
                    clicked = false;
                TilesGeneration.gameStarted = false;
            }
                else if (Input.mousePosition.y > mouseDownPosition.y)
                {
                    if ((thisTileIndex / 7 != 6))
                    {
                    if (TilesGeneration.gridTiles[thisTileIndex + 7].GetComponent<Button>().isActiveAndEnabled)
                    {
                        direction.GetComponent<Animator>().SetBool("Up", true);
                        StartCoroutine(causeDelay());
                        Sprite temp = TilesGeneration.gridTiles[thisTileIndex + 7].GetComponent<Image>().sprite;
                        TilesGeneration.gridTiles[thisTileIndex + 7].GetComponent<Image>().sprite = TilesGeneration.gridTiles[thisTileIndex].GetComponent<Image>().sprite;
                        TilesGeneration.gridTiles[thisTileIndex].GetComponent<Image>().sprite = temp;
                    }
                    }
                    clicked = false;
                TilesGeneration.gameStarted = false;
            }
            }
        
    }

    public bool CheckVertical()
    {
        bool matched=false;
        for (int i = 0; i < TilesGeneration.gridTiles.Count; i++)
        {
            if (i + 14 < TilesGeneration.gridTiles.Count)
                if (TilesGeneration.gridTiles[i].GetComponent<Image>().sprite == TilesGeneration.gridTiles[i + 7].GetComponent<Image>().sprite)
                {
                    if (TilesGeneration.gridTiles[i].GetComponent<Image>().sprite == TilesGeneration.gridTiles[i + 14].GetComponent<Image>().sprite)
                    {



                        matched = true;

                       
                    }
                }
        }
        return matched;
    }
    IEnumerator causeDelay()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(direction);
    }
    public bool CheckHorizontal()
    {
        bool matched = false;
        for (int i = 0; i < TilesGeneration.gridTiles.Count; i++)
        {
            if (i + 2 < TilesGeneration.gridTiles.Count)
            {
                if ((i / 7) == ((i + 1) / 7))
                    if (TilesGeneration.gridTiles[i].GetComponent<Image>().sprite == TilesGeneration.gridTiles[i + 1].GetComponent<Image>().sprite)
                    {
                        if ((i / 7) == ((i + 2) / 7))
                            if (TilesGeneration.gridTiles[i].GetComponent<Image>().sprite == TilesGeneration.gridTiles[i + 2].GetComponent<Image>().sprite)
                            {
                                matched = true;
                            }
                    }
            }

        }
        return matched;
    }

}
