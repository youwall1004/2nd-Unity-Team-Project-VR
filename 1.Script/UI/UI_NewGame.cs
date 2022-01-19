using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UI_NewGame : UIKey
{
    public string sceneName;
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hammer")
        {
            StartCoroutine(Vanish());
            Debug.Log("������");
            //�����ڵ�
            //SceneManager.LoadScene("Forge");
            //�����׾� �߰�
            SceneManager.LoadScene(sceneName);
        }
    }
    public IEnumerator Vanish()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    public override void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Hammer")
        {
        }
    }
}
