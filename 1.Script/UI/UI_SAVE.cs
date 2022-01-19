using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SAVE : UIKey
{
    [SerializeField] private SaveNLoad theSaveNLoad;
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hammer")
        {
            SoundManager.instance.SFXPlay("VolumeKey", clips[0]);
            Debug.Log("���̺�õ�");
            theSaveNLoad.SaveData();
        }
    }
    public override void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Hammer")
        {
        }
    }
}
