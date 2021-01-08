using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waves : MonoBehaviour
{
    public GameObject[] WaveImg = new GameObject[10];
    public static int stageNumber = 1;
    public Text TextStageNumber;
    void Update()
    {
        for (int i = 1; i <= 10; i++)
        {
            if (Game.WaveEnemy > i)
            {
                WaveImg[i-1].GetComponent<Image>().color = new Color(251 / 255.0f, 145 / 255.0f, 44 / 255.0f);
            }
            else WaveImg[i-1].GetComponent<Image>().color = new Color(183 / 255.0f, 183 / 255.0f, 183 / 255.0f);
        }
        TextStageNumber.text = "" + stageNumber;

    }
}
