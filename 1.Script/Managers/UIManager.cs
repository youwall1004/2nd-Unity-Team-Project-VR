using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    //���� UI ������Ʈ ����
    public GameObject gameLabel;
    Image smithImg;

    void Start()
    {
        smithImg = gameLabel.GetComponent<Image>();
        StartCoroutine(ReadyToStart());
    }

    //�������� �̹��� �������鼭 
    IEnumerator ReadyToStart()
    {
        float fadeCount = 1;
        while (fadeCount >= 0.0f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            smithImg.color = new Color(0, 0, 0, fadeCount);
        }
        gameLabel.SetActive(false);
        smithImg.color = new Color(255, 255, 255, 255);
    }
}
