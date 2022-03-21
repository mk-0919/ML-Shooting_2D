using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float countTime = 30.0f;
    [HideInInspector] public float setTime;
    [HideInInspector] public bool isCount = false;
    Text timeText;
    private void Start()
    {
        timeText = GetComponent<Text>();
        timeText.text = countTime.ToString();
        setTime = countTime;
    }
    private void Update()
    {
        if (isCount == true && countTime > 0)
        {
            countTime -= Time.deltaTime;
            timeText.text = countTime.ToString("F0");
        }
    }
}
