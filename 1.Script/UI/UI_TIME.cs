using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//광산에서 돌아오면 자동으로 주++, AM 9시부터 월요일부터 시작하는 로직 추가 예정 
public class UI_TIME : MonoBehaviour
{
    //월요일 아침 9시에 켤 오브젝트
    public GameObject questPanel;
    //일요일 밤 9시에 켤 오브젝트
    public GameObject AccountBox;
    //월, 화, 수, 목 동안 등장할 상인프리펩과 광석판매대
    public GameObject MerchantSET;
    OrderControl orderControlSc;

    //시간 프로퍼티
    public int GameTime
    {
        get { return (int)saveData.time; }
        set
        {
            saveData.time = value;
        }
    }
    //요일 프로퍼티
    public int Date
    {
        get { return saveData.day; }
        set
        {
            saveData.day = value;
        }
    }

    [SerializeField] Text _text;
    public float secForHour=1;
    const int amTimes = 3;
    const int pmTimes = 13;
    SaveData saveData;
    private void Start()
    {
        orderControlSc = FindObjectOfType<OrderControl>();
        saveData = SaveNLoad.instance.saveData;
    }
    private void Update()
    {
        if (saveData.time < amTimes)
        {
            saveData.time += Time.deltaTime/secForHour;
            _text.text = DisplayWeekString() + "th Week" + "\r\n" + DisplayDateString() + "\r\n" + "AM " + DisplayTimeString();
        }
        else if (saveData.time <= pmTimes)
        {
            saveData.time += Time.deltaTime/secForHour;
            _text.text = DisplayWeekString() + "th Week" + "\r\n" + DisplayDateString() + "\r\n" + "PM " + DisplayTimeString();
        }
        else
        {
            saveData.day++;
            saveData.time = 0;
        }
        if (saveData.day == 6 && saveData.time > 12&& saveData.time < 13)
        {
            if(orderControlSc!=null)
            {
                orderControlSc.CheckAcceptOrder();
                //orderControlSc.SortAcceptOrder();
                //CalculateSword(orderControlSc.acceptOrderSc);
            }
            else
            {
                orderControlSc = FindObjectOfType<OrderControl>();
                orderControlSc.CheckAcceptOrder();
                //orderControlSc.SortAcceptOrder();
            }
            AccountBox.SetActive(true);
            questPanel.SetActive(false);
            questPanel.transform.GetChild(0).GetComponent<OrderControl>().enabled=false;
        }
        else
        {
            AccountBox.SetActive(false);
        }
        if (saveData.day == 0)
        {
            questPanel.SetActive(true);
            questPanel.transform.GetChild(0).GetComponent<OrderControl>().enabled = true;
        }
    }
    public string DisplayWeekString()
    {
        string week = saveData.week.ToString();
        return week;
    }
    public string DisplayDateString()
    {
        string date = "";
        if (saveData.day < 0)
        {
            saveData.day = 0;
        }
        else if (saveData.day > 6)
        {
            saveData.day = 0;
            saveData.week++;
        }
        switch (saveData.day)
        {
            case 0: date += "MONDAY"; break;
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
        if (saveData.time < 0)
        {
            saveData.time = 0;
        }

        float minute = Mathf.FloorToInt(saveData.time / 60);
        float second = Mathf.FloorToInt(saveData.time % 60) + 9;
        float milisecond = saveData.time % 1 * 1000;
        return string.Format("{0:00}:{1:00}", second, minute);
    }
}
