using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountSword : MonoBehaviour
{
    public AudioClip[] clips;
    OrderControl orderControlSc;
    public List<OrderKey> acceptOrderSc;
    public List<Sword> sortedSwords;
    public int earn_Gold;
    public int earn_Fame;
    int tempGold;
    int tempFame;
    int bonusGold;
    int bonusFame;
    //�Ͽ��� �� 9�� �ϰ� ����
    //�ȷ��� ������ �� �߿�����
    //1) ������ �̼ǿ� �ش��ϴ� �˸��� �Ⱦƾ���
    //2) ������ �̼� �߿��� ���� �ջ��� ���� ������� �Ⱦƾ���
    UI_GOLD uI_GOLDSc;
    public void Awake()
    {
        uI_GOLDSc = FindObjectOfType<UI_GOLD>();
        orderControlSc = FindObjectOfType<OrderControl>();
    }
    public void GetSword()
    {
        SearchSword();
        SortSword();
        CalculateSword();
    }
    public void CalculateSword()
    {
        if (orderControlSc != null)
        {
            for (int i = 0; i < orderControlSc.sortedOrderSc.Count; i++)
            {
                int tempCount = orderControlSc.sortedOrderSc[i].order.requireCount;
                int BonusSword = 0;
                int SpecialBonusSword = 0;
                for (int j = 0; j < orderControlSc.sortedOrderSc[i].order.requireCount; j++)
                {
                    if (orderControlSc.sortedOrderSc[i].order.requireQuality <= sortedSwords[j].value)
                    {
                        if (sortedSwords[j].value >= orderControlSc.sortedOrderSc[i].order.requireQuality * 1.5)
                        {
                            SpecialBonusSword++;
                        }
                        if (sortedSwords[j].value >= orderControlSc.sortedOrderSc[i].order.requireQuality * 1.2f)
                        {
                            Debug.Log("1");
                            BonusSword++;
                        }
                        Debug.Log("1");
                        tempCount--;
                        if (tempCount <= 0)
                        {
                            MissionClear(orderControlSc.sortedOrderSc[i], SpecialBonusSword, BonusSword);
                            SoundManager.instance.SFXPlay("sellsound", clips[0]); 
                            for (int k = 0; k < orderControlSc.sortedOrderSc[i].order.requireCount; k++)
                            {
                                Debug.Log("���ǿ� �����Ͽ� �ȸ� �� : " + sortedSwords[k].gameObject.name);
                                //sortedSwords[k].gameObject.SetActive(false);
                                Destroy(sortedSwords[k].gameObject);
                                sortedSwords.RemoveAt(k);
                            }
                        }
                    }
                    else j = orderControlSc.acceptOrderSc[i].order.requireCount + 1;
                }
            }
        }
    }

    public void MissionClear(OrderKey clearOrders, int specialBonus, int normalBonus)
    {
        List<int> result = new List<int>();
        earn_Gold = RewardGold(clearOrders.order.requireQuality, clearOrders.order.requireCount, specialBonus, normalBonus);
        earn_Fame = RewardFame(clearOrders.order.requireQuality, clearOrders.order.requireCount, specialBonus, normalBonus);
        result.Add(earn_Gold);
        result.Add(earn_Fame);
        uI_GOLDSc.AddMoneyNFame(result);
    }
    public int RewardGold(int _Quality, int _Count, int _specialBonus=0, int _normalBonus=0)
    {
        int perGold = (int)(_Quality * 0.4f);
        Debug.Log("���� ���� : " + perGold);
        int gold = perGold * _Count;
        Debug.Log("���ʽ� �߰� �� �� ���� : " + gold);
        int n_Bonus = (int)(perGold * 0.2f) * _normalBonus;
        Debug.Log("���� �븻 ���ʽ� : " + n_Bonus);
        int s_Bonus = (int)(perGold * 0.5f) * _specialBonus;
        Debug.Log("���� ����� ���ʽ� : " + s_Bonus);
        int result_Bonus = n_Bonus + s_Bonus;
        Debug.Log("�� ���� ���ʽ� : " + result_Bonus);
        gold += result_Bonus;
        Debug.Log("�� ���� : " + gold);
        return gold;
    }
    public int RewardFame(int _Quality, int _Count, int _specialBonus = 0, int _normalBonus = 0)
    {
        int perFame = (int)(_Quality * 0.01f);
        Debug.Log("���� �� : " + perFame);
        int fame = perFame * _Count;
        Debug.Log("���ʽ� �߰� �� �� �� : " + fame);
        int n_fBonus = (int)(fame * 0.01f) * _normalBonus;
        Debug.Log("�� �븻 ���ʽ� : " + n_fBonus);
        int s_fBonus = (int)(fame * 0.02f) * _specialBonus;
        Debug.Log("�� ����� ���ʽ� : " + s_fBonus);
        int result_fBonus = n_fBonus + s_fBonus;
        Debug.Log("�� �� ���ʽ� : " + result_fBonus);
        fame += result_fBonus;
        Debug.Log("���ʽ� �߰� �� �� ������ : " + fame);
        return fame;
    }
    public void SearchSword()
    {
        //10�� ���̾� Sword�� �����ؾߵ�
        BoxCollider box = GetComponent<BoxCollider>();
        Collider[] colls = Physics.OverlapBox(box.center, box.size / 2);
        for (int i = 0; i < colls.Length; i++)
        {
            if (colls[i].transform.GetComponent<Sword>() != null)
            {
                //MissionGains(colls[i]);//�ϴ� �������ʱ�
                        if (sortedSwords.Contains(colls[i].gameObject.GetComponent<Sword>())) continue;
                        else sortedSwords.Add(colls[i].gameObject.GetComponent<Sword>());
            }
        }
    }
    public void SortSword()
    {
        sortedSwords.Sort((o1, o2) => o1.value.CompareTo(o2.value));
        for (int i = 0; i < sortedSwords.Count; i++)
        {
            Debug.Log(i + "��° �� : " + sortedSwords[i].value);
        }
    }

}
