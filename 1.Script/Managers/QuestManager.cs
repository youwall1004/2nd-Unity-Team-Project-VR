using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    Dictionary<int, string[]> questData;
    private void Awake()
    {   // int �� : ���� ���Ⱚ ����
        //string ù��° �迭 : ��û�ڸ� , �ι�° �迭 : ����Ʈ ����
        questData = new Dictionary<int, string[]>();
        OpenedMine_1();
        OpenedMine_2();
        OpenedMine_3();
        OpenedMine_4();
        OpenedMine_5();
        OpenedMine_6();
    }

    /*ù ���� �رݽ�*/
    void OpenedMine_1()
    {
        questData.Add(1, new string[] { "Mrs.Jung", "�Ƶ��� ������ ��� ������ ���� �ʿ��ϴٳ�" });
        questData.Add(2, new string[] { "James", "������� �غ��Ҹ��� �Ʒÿ� ���� �常�� ��ȹ�Դϴ�." });
        questData.Add(3, new string[] { "�߾� ��ȸ", "������ ������ ������ ���� �غ����ְ�." });
        questData.Add(4, new string[] { "KATE ���尣", "������ Smith�� ���� �������� �ñ��Ѱ�?" });
        questData.Add(5, new string[] { "����", "�ʱ� ��������� ����� ���� ���� �����ְ�." });
    }

    /*�ι�° ���� �رݽ�*/
    void OpenedMine_2()
    {
        questData.Add(1, new string[] { "Mrs.Jung", "�Ƶ��� �ι�° ���꿡 ����ʹٳ׿�. ������� ���� �� ����." });
        questData.Add(2, new string[] { "James", "���꿡 ���� ������ Į�� �常�� ��ȹ�Դϴ�." });
        questData.Add(3, new string[] { "�߾� ��ȸ", "��ȸ�� �����ϴ� ����鿡�� �ϻ��� ���� �ʿ��ϳ�." });
        questData.Add(4, new string[] { "KATE ���尣", "������ Smith�� ���� �������ٴ� �ҹ��� �ִ���." });
        questData.Add(5, new string[] { "����", "�ʱ� ��������� �� ���� ���� �޶�� �ƿ켺�̾�." });
    }

    /*����° ���� �رݽ�*/
    void OpenedMine_3()
    {
        questData.Add(1,new string[] { "Mrs.Jung", "�Ƶ��� �ι�° ���꿡 ����ʹٳ׿�. ������� ���� �� ����." });
        questData.Add(2,new string[] { "James", "���꿡 ���� ������ Į�� �常�� ��ȹ�Դϴ�." });
        questData.Add(3,new string[] { "�߾� ��ȸ", "������ ������ ���� �غ����ְ�." });
        questData.Add(4,new string[] { "KATE ���尣", "������ Smith�� ���� �������ٴ� �ҹ��� �ִ���." });
        questData.Add(5,new string[] { "����", "�ʱ� ��������� �� ���� ���� �޶�� �ƿ켺�̾�." });
    }

    /*�׹�° ���� �رݽ�*/
    void OpenedMine_4()
    {
        questData.Add(1, new string[] { "Mrs.Jung", "�Ƶ��� �ι�° ���꿡 ����ʹٳ׿�. ������� ���� �� ������.." });
        questData.Add(2, new string[] { "James", "������� �غ��Ҹ��� �Ʒÿ� ���� �常�� ��ȹ�Դϴ�." });
        questData.Add(3, new string[] { "�߾� ��ȸ", "������ ������ ������ ���� �غ����ְ�." });
        questData.Add(4, new string[] { "KATE ���尣", "������ Smith�� ���� �������� �ñ��Ѱ�?" });
        questData.Add(5, new string[] { "����", "�������� �����ϴ� ���̷����� ��� ���� �����ְ�." });
    }

    /*�ټ���° ���� �رݽ�*/
    void OpenedMine_5()
    {
        questData.Add(1, new string[] { "Mrs.Jung", "�Ƶ��� �ι�° ���꿡 ����ʹٳ׿�. ������� ���� �� ������.." });
        questData.Add(2, new string[] { "James", "������� �غ��Ҹ��� �Ʒÿ� ���� �常�� ��ȹ�Դϴ�." });
        questData.Add(3, new string[] { "�߾� ��ȸ", "������ ������ ������ ���� �غ����ְ�." });
        questData.Add(4, new string[] { "KATE ���尣", "������ Smith�� ���� �������� �ñ��Ѱ�?" });
        questData.Add(5, new string[] { "����", "�������� �����ϴ� ���̷����� ��� ���� �����ְ�." });
    }
    /*������ ���̿� ���*/
    void OpenedMine_6()
    {
        questData.Add(1, new string[] { "Mrs.Jung", "�Ƶ��� �ι�° ���꿡 ����ʹٳ׿�. ������� ���� �� ������.." });
        questData.Add(2, new string[] { "James", "������� �غ��Ҹ��� �Ʒÿ� ���� �常�� ��ȹ�Դϴ�." });
        questData.Add(3, new string[] { "�߾� ��ȸ", "������ ������ ������ ���� �غ����ְ�." });
        questData.Add(4, new string[] { "KATE ���尣", "������ Smith�� ���� �������� �ñ��Ѱ�?" });
        questData.Add(5, new string[] { "����", "�������� �����ϴ� ���̷����� ��� ���� �����ְ�." });
    }
    //_id�� ������ �ְ� 
    //public string GetMonoData(int _id, int ownerStr, int missionstr)
    //{
        //if (str_Idx == questData[_id].Length)
        //{
        //    return null;
        //}
        //else
        //{
            //return questData[_id][str_Idx];
        //}
   // }
}
