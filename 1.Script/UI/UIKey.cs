using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIKey : MonoBehaviour
{
    public AudioClip[] clips;
    public Color originColor;

    public virtual void Start()
    {
        originColor = GetComponent<MeshRenderer>().materials[0].color;
    }
    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hammer")
        {
            SoundManager.instance.SFXPlay("VolumeKey", clips[0]);
            GetComponent<MeshRenderer>().materials[0].color = Color.red;
        }
    }
    public virtual void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Hammer")
        {
            GetComponent<MeshRenderer>().materials[0].color = originColor;
        }
    }

}
