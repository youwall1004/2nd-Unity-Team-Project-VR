using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    //현재 UI 오브젝트 상태
    public GameObject gameLabel;
    Image smithImg;

    void Start()
    {
        smithImg = gameLabel.GetComponent<Image>();
        StartCoroutine(ReadyToStart());
    }

    //대장장이 이미지 옅어지면서 
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
