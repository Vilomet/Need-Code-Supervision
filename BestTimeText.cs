using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestTimeText : MonoBehaviour
{
    [SerializeField] private Text _bestTimeText;
    [SerializeField] private GameObject _bestTime;

    void Start()
    {
        if (Timer.BestTime > 0)
        {
            _bestTime.SetActive(true);
        }

        _bestTimeText.text = "Best time: " + Timer.BestTime + " sec";
    }
}
