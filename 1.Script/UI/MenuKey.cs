using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//���갡�� ������ ���� ¥����
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
                    break;//SaveNLoad ��ũ��Ʈ ����
                case "LOAD":
                    theSaveNLoad.LoadData();
                    break;//SaveNLoad ��ũ��Ʈ ����
                case "SETTING": break;//å�� �� ���빰�� SettingTable�� �ٲٸ� ��
                case "OPTION": break;//if(�� å�� == title å��)title å�� else(InGameTable)
                case "RESET": break;//���尣 ������ �ʱ�ȭ
                case "EXIT": Application.Quit(); break;
            }
        }
    }
}
