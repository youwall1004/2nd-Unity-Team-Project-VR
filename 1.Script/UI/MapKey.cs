using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapKey : MonoBehaviour
{
    SaveData saveData;
    public void Start()
    {
        saveData = SaveNLoad.instance.saveData;
    }
    public void VanishKey()
    {
        transform.GetChild(1).gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerFinger")
        {
            //SoundManager.instance.SFXPlay("Jump", clips[0]);
            //�ݿ����̸�,
            if (saveData.day == 4)
            {
                transform.GetChild(1).gameObject.SetActive(true);
                Invoke("VanishKey",3.5f);
            }
        }
    }
}
