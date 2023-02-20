using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class DegitalTime : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public string timeZoneId;

    private DateTime now;
    private TimeZoneInfo timeZone;
    // Start is called before the first frame update
    void Start()
    {
        timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        setCurrTimeData();
        updateTime();
    }

    // Update is called once per frame
    void Update()
    {
        setCurrTimeData();
        updateTime();
    }

    public void setCurrTimeData()
    {
        now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
    }

    public void updateTime()
    {
        timeText.text = now.ToString("yyyy.MM.dd\nHH:mm:ss");
    }

}
