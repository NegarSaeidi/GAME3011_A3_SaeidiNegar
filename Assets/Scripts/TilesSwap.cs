using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TilesSwap : MonoBehaviour
{
    private Vector3 mouseDownPosition;
    private int thisTileIndex;
    private bool clicked;
  public void OnClikTile()
    {
      
        
            mouseDownPosition = Input.mousePosition;
            clicked = true;
        
    }

    private void Update()
    {

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

                if (Input.mousePosition.x > mouseDownPosition.x)
                {
                    if ((thisTileIndex + 1) % 7 != 0)
                    {

                        Sprite temp = TilesGeneration.gridTiles[thisTileIndex + 1].GetComponent<Image>().sprite;
                        TilesGeneration.gridTiles[thisTileIndex + 1].GetComponent<Image>().sprite = TilesGeneration.gridTiles[thisTileIndex].GetComponent<Image>().sprite;
                        TilesGeneration.gridTiles[thisTileIndex].GetComponent<Image>().sprite = temp;

                    }
                    clicked = false;
                }
                else if (Input.mousePosition.x < mouseDownPosition.x)
                {
                    if ((thisTileIndex) % 7 != 0)
                    {

                        Sprite temp = TilesGeneration.gridTiles[thisTileIndex - 1].GetComponent<Image>().sprite;
                        TilesGeneration.gridTiles[thisTileIndex - 1].GetComponent<Image>().sprite = TilesGeneration.gridTiles[thisTileIndex].GetComponent<Image>().sprite;
                        TilesGeneration.gridTiles[thisTileIndex].GetComponent<Image>().sprite = temp;

                    }
                    clicked = false;
                }
                else if (Input.mousePosition.y < mouseDownPosition.y)
                {
                    if (thisTileIndex / 7 != 0)
                    {

                        Sprite temp = TilesGeneration.gridTiles[thisTileIndex - 7].GetComponent<Image>().sprite;
                        TilesGeneration.gridTiles[thisTileIndex - 7].GetComponent<Image>().sprite = TilesGeneration.gridTiles[thisTileIndex].GetComponent<Image>().sprite;
                        TilesGeneration.gridTiles[thisTileIndex].GetComponent<Image>().sprite = temp;

                    }
                    clicked = false;
                }
                else if (Input.mousePosition.y > mouseDownPosition.y)
                {
                    if ((thisTileIndex / 7 != 6))
                    {

                        Sprite temp = TilesGeneration.gridTiles[thisTileIndex + 7].GetComponent<Image>().sprite;
                        TilesGeneration.gridTiles[thisTileIndex + 7].GetComponent<Image>().sprite = TilesGeneration.gridTiles[thisTileIndex].GetComponent<Image>().sprite;
                        TilesGeneration.gridTiles[thisTileIndex].GetComponent<Image>().sprite = temp;

                    }
                    clicked = false;
                }
            }
        
    }



}
