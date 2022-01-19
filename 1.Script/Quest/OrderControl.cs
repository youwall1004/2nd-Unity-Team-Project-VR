using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderControl : MonoBehaviour
{
    public SaveData saveData;
    public OrderKey[] OrderSc;
    public List<OrderKey> acceptOrderSc;
    public List<OrderKey> sortedOrderSc;
    //public 
    Dictionary<int, string[]> questData;
    [SerializeField] Text[] quest_Owner;
    [SerializeField] Text[] quest_Contents;
    [SerializeField] Text[] request_Quality;
    [SerializeField] Text[] amount;
    GameObject tempQuest;
    private bool isChecked;
    int questCount = 0;
    //_text.text = DisplayWeekString() + "th Week" + "\r\n" + DisplayDateString() + "\r\n" + "AM " + DisplayTimeString();
    private void Start()
    {
        saveData = SaveNLoad.instance.saveData;
    }
    private void Update()
    {
        if (saveData.day == 6 && saveData.time > 12 && !isChecked)
        {
            Debug.Log("üũ��");
            CheckAcceptOrder();
            isChecked = true;
        }
        if (saveData.day == 0 && isChecked)
        {
            Debug.Log("������");
            UpdateOrderBoard();
            isChecked = false;
        }
    }
    public void UpdateOrderBoard()
    {
        questData = new Dictionary<int, string[]>();
        questCount = OrderCount(SaveNLoad.instance.saveData.playerMineLv);
        sortedOrderSc.Sort((o1,o2)=>o1.order.Engagement.CompareTo(o2.order.Engagement));
        UpdateQuestBoard();
        RandAmount();
        Randquest_Contents();
        Randquest_Quality();
    }

    //������ ����Ʈ�� ����Ʈ�� ����
    public void CheckAcceptOrder()
    {
        for (int i = 0; i < 5; i++)
        {
            if (OrderSc[i].order.isAccept == true)
            {
                if (acceptOrderSc.Contains(OrderSc[i])) continue;
                else acceptOrderSc.Add(OrderSc[i]);
            }
        }
    }

    public void RandAmount()
    {
        for (int i = 0; i < amount.Length; i++)
        {
            int temp = Random.Range(1, 4);//�׽�Ʈ �غ� ���, �ִ�ġ�� 3
            amount[i].text = temp.ToString() + "��";
            saveData.questData[i].requireCount = temp;
        }
    }
    /*
    <����Ʈ Į ǰ�� �䱸���� ����ġ>, ���� ���溰
    1: 100~500
    2: 400~1000
    3: 800~1500
    4: 1300~ 2000
    5: 1800~3000
    6: 2500~3500
     */
    public void Randquest_Quality()
    {
        for (int i = 0; i < request_Quality.Length; i++)
        {
            int temp = 0;
            switch (SaveNLoad.instance.saveData.playerMineLv)
            {
                case 1:
                    if(SaveNLoad.instance.saveData.week==2) temp = Random.Range(10, 50);
                    else temp = Random.Range(100, 501);
                    break;
                case 2: temp = Random.Range(400, 1001); 
                    break;
                case 3: temp = Random.Range(800, 1501); 
                    break;
                case 4: temp = Random.Range(1300, 2001); 
                    break;
                case 5: temp = Random.Range(1800, 3001); 
                    break;
                case 6: temp = Random.Range(2500, 3501); 
                    break;
            }
            request_Quality[i].text = "Quality : " + temp.ToString() + " �̻�";
            saveData.questData[i].requireQuality = temp;
            quest_Owner[i].text = saveData.questData[i].quest_Owner;
            quest_Contents[i].text = saveData.questData[i].quest_Contents;
        }
    }

    public void Randquest_Contents()
    {
        switch (SaveNLoad.instance.saveData.playerMineLv)
        {
            case 1: questData.Clear(); OpenedMine_1(); break;
            case 2: questData.Clear(); OpenedMine_2(); break;
            case 3: questData.Clear(); OpenedMine_3(); break;
            case 4: questData.Clear(); OpenedMine_4(); break;
            case 5: questData.Clear(); OpenedMine_5(); break;
            case 6: questData.Clear(); OpenedMine_6(); break;
        }
        int[] temp = { 1, 2, 3, 4, 5,6,7,8 };
        NumShuffle(temp);

        for (int i = 0; i < questCount; i++)
        {
            saveData.questData[i].quest_Owner = questData[temp[i]][0];
            saveData.questData[i].quest_Contents = questData[temp[i]][1];
        }
    }

    public int OrderCount(int OpenedMine)
    {
        int quset = 0;
        switch (OpenedMine)
        {
            case 0: quset = 0; break;
            case 1: 
                if(SaveNLoad.instance.saveData.week == 2) quset =1;
                else quset = 2; break;
            case 2: quset = 3; break;
            case 3: quset = 3; break;
            case 4: quset = 4; break;
            case 5: quset = 4; break;
            case 6: quset = 5; break;
        }
        return quset;
    }
    public void UpdateQuestBoard()
    {
        if (questCount != 0)
        {
            for (int i = 0; i < questCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
                //quest_Owner[i-1]
                //quest_Contents[i-1]
            }
        }
    }
    /*ù ���� �رݽ�*/
    void OpenedMine_1()
    {
        questData.Add(1, new string[] { "Mrs.Jung", "�Ƶ��� ������ ��� ������ ���� �ʿ��ϴٳ�" });
        questData.Add(2, new string[] { "James", "������ ���� �Ʒÿ� ���� �常�� ��ȹ�Դϴ�." });
        questData.Add(3, new string[] { "�߾� ��ȸ", "�����ڵ鿡�� ������ ������ ���� �غ����ְ�." });
        questData.Add(4, new string[] { "KATE ���尣", "������ Smith�� ���� �������� �ñ��Ѱ�?" });
        questData.Add(5, new string[] { "����", "�ʱ� ��������� ����� ���� ���� �����ְ�." });
        questData.Add(6, new string[] { "Lux", "Smith���� �ƹ����� ��� ������ �ܰ��̾����ϴ�." });
        questData.Add(7, new string[] { "Adam", "���꿡 ���̷����� �ִٰ� �ϳ�... Į�� ����߰ھ��." });
        questData.Add(8, new string[] { "Mr.Gang", "���� �������� �峭��ó�� ������ Į�� �� �ְ�." });
    }

    /*�ι�° ���� �رݽ�*/
    void OpenedMine_2()
    {
        questData.Add(1, new string[] { "Mrs.Lee", "���� �ι�° ���꿡 ����ʹٳ׿�. ������� ���� �� ����." });
        questData.Add(2, new string[] { "Lucas", "���꿡 ���� ������ Į�� �常�� ��ȹ�Դϴ�." });
        questData.Add(3, new string[] { "�߾� ��ȸ", "��ȸ�� �����ϴ� ����鿡�� �ϻ��� ���� �ʿ��ϳ�." });
        questData.Add(4, new string[] { "LOMI ���尣", "������ Smith���尣 ���� �峭�� ���ؾƴѰ�?" });
        questData.Add(5, new string[] { "����", "�ʱ� ��������� �� ���� ���� �޶�� �ƿ켺�̾�." });
        questData.Add(6, new string[] { "Mrs.Jung", "�Ƶ��� ������ ��� ���� �콽� �μ�����." });
        questData.Add(7, new string[] { "Daniel", "���谡�� �ǰ� ������.. �ϴ� �˺��� ��η���." });
        questData.Add(8, new string[] { "Adam", "�ι�° ������ ���ȴٰ� �ϴ� �� ���� �ʿ���." });
    }

    /*����° ���� �رݽ�*/
    void OpenedMine_3()
    {
        questData.Add(1, new string[] { "Mrs.Kim", "�Ƶ��� ����° ���꿡 ����ʹٳ׿�. �� ������ּ���." });
        questData.Add(2, new string[] { "Mason", "����° ���꿡 �ִ� ���̷����� ������ ���߰ھ�." });
        questData.Add(3, new string[] { "�߾� ��ȸ", "�����ڵ鵵 ���� �ʿ��ϱ� ��������." });
        questData.Add(4, new string[] { "CASS ���尣", "������ Smith ���� ���� ���ٴ� �ҹ��� ��������..." });
        questData.Add(5, new string[] { "����", "����° ������ ���� �ڷ� ��������� ���� ��������." });
        questData.Add(6, new string[] { "Mrs.Lee", "���� ���� ���� �غ� ��â�̾�." });
        questData.Add(7, new string[] { "Henry", "������� �ڲ� ���� ����ǰ�� �ڶ��ؼ� ���� ��������." });
        questData.Add(8, new string[] { "Lux", "Smith���� �ƹ����� �߳����� Smith���� ���� �⻵���ٵ���." });
    }

    /*�׹�° ���� �رݽ�*/
    void OpenedMine_4()
    {
        questData.Add(1, new string[] { "Mrs.Gang", "��ī�� �׹�° ���꿡 ���ٳ׿�. ���� Į�� �ּ���." });
        questData.Add(2, new string[] { "Henry", "�׹�° ���꿡 �ִ� ���̷����� ������ ���߰ھ�." });
        questData.Add(3, new string[] { "�߾� ��ȸ", "������ ���� ������� ���� ������ ���� ��ȸ �����Ⱑ ����." });
        questData.Add(4, new string[] { "RAYMOND ���尣", "������ Smith ���� ���� ���ٴ� �ҹ��� ��������..." });
        questData.Add(5, new string[] { "����", "�׹�° ������ ���� �ڷ� ��������� �ٺ�����." });
        questData.Add(6, new string[] { "Mrs.Kim", "�Ƶ��� �� ���� Į�� ������ �ʹٰ� �ڲ� ��ä��. "});
        questData.Add(7, new string[] { "������", "���� ���� ���鿡�� Smith���� ���� �ຼ�� ��." });
        questData.Add(8, new string[] { "Lux", "Smith���� �ƹ����� �߳����� Smith���� ���� �⻵���ٵ���." });
    }

    /*�ټ���° ���� �رݽ�*/
    void OpenedMine_5()
    {
        questData.Add(1, new string[] { "Mrs.Park", "������ �ټ���° ���꿡 ���ٳ׿�. ���� Į�� �ּ���." });
        questData.Add(2, new string[] { "Daniel", "�ټ���° ���꿡 �ִ� ���̷����� ������ ���߰ھ�." });
        questData.Add(3, new string[] { "�߾� ��ȸ", "����� ǰ���� �������� ���� Simth���� ���̶�� ���� �� �־�." });
        questData.Add(4, new string[] { "JAYCOB ���尣", "������ Smith ���� ���� ���׽�Ʈ ��� �ĺ��� ������ �ִٸ�?" });
        questData.Add(5, new string[] { "����", "�ټ���° ������ ���� �ڷ� �� ���� Į���� �ʿ�������." });
        questData.Add(6, new string[] { "Miss.im", "���� ���� �佺Ƽ������ ���� ������ ���� �;�. ���� Į�� ��Ź��." });
        questData.Add(7, new string[] { "������", "���� ���� ������ Smith�� ���� ���������� ����ʹٰ� �߾�." });
        questData.Add(8, new string[] { "Lux", "Smith���� �ƹ����� �߳����� Smith���� ���� �⻵���ٵ���." });
    }
    /*������ ���� �رݽ�*/
    void OpenedMine_6()
    {
        questData.Add(1, new string[] { "Miss.Ryu", "�ƹ����� ������ ���꿡 ���ٳ׿�. ������ Į�� �ּ���." });
        questData.Add(2, new string[] { "Adam", "������ ���꿡 �ִ� ���̷����� ������ ���߰ھ�." });
        questData.Add(3, new string[] { "�߾� ��ȸ", "�߾ӱ�ȸ�� Simth���� �˸��� ���� �־�. ������������." });
        questData.Add(4, new string[] { "JAYCOB ���尣", "������ Smith���� ������ �������̰� �� ���� �ִٴµ�..." });
        questData.Add(5, new string[] { "����", "������ ������ ���� �ڷ� �� ���� Į���� �ʿ�������." });
        questData.Add(6, new string[] { "Mrs.Song", "�ùε鵵 ���� ���꿡 ����ٴµ� ���� ��������" });
        questData.Add(7, new string[] { "Miss.Choi", " ��� ����� ��� Simth���� �˿� ��ź�ϴ���." });
        questData.Add(8, new string[] { "Lux", "Smith���� �ƹ����� �߳����� Smith���� ���� �⻵���ٵ���." });
    }

    //���� ���� �Լ�
    int[] NumShuffle(int[] x)
    {
        int rand1;
        int rand2;
        int tmp;
        for (int i = 0; i < 25; i++)
        {
            rand1 = Random.Range(0, x.Length);
            rand2 = Random.Range(0, x.Length);
            tmp = x[rand1];
            x[rand1] = x[rand2];
            x[rand2] = tmp;
        }
        return x;
        }

}
