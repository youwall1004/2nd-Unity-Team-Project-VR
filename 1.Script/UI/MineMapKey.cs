using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineMapKey : UIKey
{
    //���� �ر��� ������ �޴� �Լ��� �޵� ��·��... ���� �ر��� ������ �޴� ����
    public int openMines =1;
    SaveData saveData;
    public GameObject tableKey;
    public GameObject sellKart;
    //Awake Start onEnable ��� 
    public override void Start()
    {
        saveData = SaveNLoad.instance.saveData;
        //���� �رݸ� ��ŭ�� ���� ����
        UpdateBoard();
    }
    public void UpdateBoard()
    {
        if (openMines != 0)
        {
            int openedMines = SaveNLoad.instance.saveData.playerMineLv;
            if (openedMines != 6) openedMines++;
            for (int i = 1; i <= openedMines; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
                tableKey.gameObject.transform.GetChild(i-1).gameObject.SetActive(true);
            }
        }
    }

    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "PlayerFinger")
        {
            //SoundManager.instance.SFXPlay("Jump", clips[0]);
            //�ݿ����� �ƴϸ�,
            if (saveData.day != 4)
            {
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
    //public override void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Hammer")
    //    {
    //        GetComponent<MeshRenderer>().materials[0].color = originColor;
    //    }
    //}
}
