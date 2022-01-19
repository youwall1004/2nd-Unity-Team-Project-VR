using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenforCont : MonoBehaviour
{
   public ItemCount[] slots;
    private void Start()
    {
        slots = gameObject.transform.GetComponentsInChildren<ItemCount>();
    }

    //public void AcquireItem(Item _item, int _count)
    //{
    //    for (int i = 0; i < slots.Length; i++)
    //    {
    //        if (slots[i].itemName == _item.itemName)
    //        {
    //            slots[i].AddItem(_count);
    //            return;
    //        }
    //    }
    // }
}

