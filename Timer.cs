using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text _timerText;

    public static float GameTime;
    public static float BestTime = 0;

    void Update()
    {
        GameTime += Time.deltaTime;

        _timerText.text = GameTime + " sec";
    }
}
