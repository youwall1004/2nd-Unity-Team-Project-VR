using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//광산가는 로직은 따로 짜야함
public class MenuKey : UIKey
{
    public string menuUIName;
    private SaveNLoad theSaveNLoad;
    public override void Start()
    {
        base.Start();
        theSaveNLoad = FindObjectOfType<SaveNLoad>();
    }
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hammer")
        {
            switch(menuUIName)
            {
                case "NEW_GAME": 
                    SceneManager.LoadScene("OPENING");
                    break;
                case "SAVE":
                    theSaveNLoad.SaveData();
                    break;//SaveNLoad 스크립트 연동
                case "LOAD":
                    theSaveNLoad.LoadData();
                    break;//SaveNLoad 스크립트 연동
                case "SETTING": break;//책상 위 내용물만 SettingTable로 바꾸면 됨
                case "OPTION": break;//if(전 책상 == title 책상)title 책상 else(InGameTable)
                case "RESET": break;//대장간 도구들 초기화
                case "EXIT": Application.Quit(); break;
            }
        }
    }
}
