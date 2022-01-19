using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : MonoBehaviour
{
    [SerializeField] Text _text;
    int tempWeek = 1;
    int tempDate = 0;
    float tempTime = 0;
    const int amTimes = 3;
    const int pmTimes = 12;
    int _score = 0;

    public void OnButtonClicked()
    {
        _score++;

    }
    private void Update()
    {
        if (tempTime < amTimes)
        {
            tempTime += Time.deltaTime;
            _text.text = DisplayWeekString()+"th Week" + "\r\n" + DisplayDateString() + "\r\n" + "AM " + DisplayTimeString();
        }
        else if (tempTime < pmTimes)
        {
            tempTime += Time.deltaTime;
            _text.text = DisplayWeekString() + "th Week" + "\r\n" + DisplayDateString()+ "\r\n" + "PM " + DisplayTimeString();
        }
        else
        {
            tempDate++;
            tempTime = 0;
        }
    }
    public string DisplayWeekString()
    {
        string week = tempWeek.ToString();
        return week;
    }
    public string DisplayDateString()
    {
        string date = "";
        if (tempDate < 0)
        {
            tempDate = 0;
        }
        else if(tempDate>6)
        {
            tempDate = 0;
            tempWeek++;
        }
        switch (tempDate)
        {
            case 0: date+= "MONDAY";break;
            case 1: date += "TUESDAY"; break;
            case 2: date += "WEDNESDAY"; break;
            case 3: date += "THURSDAY"; break;
            case 4: date += "FRIDAY"; break;
            case 5: date += "SATURDAY"; break;
            case 6: date += "SUNDAY"; break;
        }
        return date;
    }
    public string DisplayTimeString()
    {
        if (tempTime < 0)
        {
            tempTime = 0;
        }

        float minute = Mathf.FloorToInt(tempTime / 60);
        float second = Mathf.FloorToInt(tempTime % 60)+9;
        float milisecond = tempTime % 1 * 1000;
        return string.Format("{0:00}:{1:00}", second, minute);
    }
}
