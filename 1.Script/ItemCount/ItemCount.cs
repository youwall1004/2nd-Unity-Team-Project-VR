using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCount : MonoBehaviour
{
    public string itemName;//sword, Lv1stone~Lv2stone
    public int count;
    [SerializeField] private Text text_Count;

    //»πµÊ
    public void AddItem(int _count = 1)
    {
        count += _count;
        text_Count.text = count.ToString();
    }

    //√ ±‚»≠Ω√
    private void ClearSlot()
    {
        count = 0;
        text_Count.text = "0";
    }
}
