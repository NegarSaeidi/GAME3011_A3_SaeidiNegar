using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public GameObject timerText;
    private float time;
    private void Start()
    {
        time = 120;
    }
    void Update()
    {
        time -= Time.deltaTime;
        timerText.GetComponent<TextMeshProUGUI>().text = Mathf.FloorToInt(time / 60) + " : " + Mathf.FloorToInt(time % 60);
    }
}
