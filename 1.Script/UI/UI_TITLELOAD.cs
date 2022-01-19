using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_TITLELOAD : Singleton<UI_TITLELOAD>
{
    public AudioClip[] clips;
    Scene scene;
    public void Start()
    {
        StartCoroutine(HideLoad());
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hammer")
        {
            SoundManager.instance.SFXPlay("VolumeKey", clips[0]);
            Debug.Log("�ε�õ�");
            StartCoroutine(LoadCo());
            StartCoroutine(Vanish());
        }
    }
    IEnumerator Vanish()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    IEnumerator HideLoad()
    {
        while (true)
        {
            scene = SceneManager.GetActiveScene();
            if (SceneManager.GetActiveScene().name == "Opening") Destroy(gameObject);
            yield return null;
        }
    }

    IEnumerator LoadCo()
    {
        Debug.Log("�ε�����");
        AsyncOperation operation = SceneManager.LoadSceneAsync("Forge", LoadSceneMode.Single);
        while (!operation.isDone)
        {
            Debug.Log("Debug.Log(operation.isDone);"+operation.isDone);
            yield return null;
            Debug.Log("Debug.Log(operation.isDone);"+operation.isDone);
        }
        SaveNLoad.instance = FindObjectOfType<SaveNLoad>();
        Debug.Log("1"+gameObject.name);
        SaveNLoad.instance.LoadData();
        Debug.Log("2"+gameObject.name);
        gameObject.SetActive(false);
        Debug.Log("3"+gameObject.name);
    }
}

////////////////////
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//public class UI_LOAD : UIKey
//{
//    [SerializeField] private SaveNLoad theSaveNLoad;
//    [SerializeField] private GameObject LoadPanel;
//    [SerializeField] private GameObject StatusPanel;
//    public UI_LOAD instance;
//    private void Awake()
//    {
//        if (instance == null)
//        {
//            instance = this;
//            DontDestroyOnLoad(gameObject);
//        }
//        else
//            Destroy(this.gameObject);
//    }
//    public override void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.tag == "Hammer")
//        {
//            SoundManager.instance.SFXPlay("VolumeKey", clips[0]);
//            if (SceneManager.GetActiveScene().name == "Title")
//            {
//                StartCoroutine(LoadCo());
//            }
//            else
//            {
//                Debug.Log("�ε�õ�");
//                LoadPanel.SetActive(false);
//                StatusPanel.SetActive(true);
//                theSaveNLoad.LoadData();
//            }
//        }
//    }
//    IEnumerator LoadCo()
//    {
//        AsyncOperation operation = SceneManager.LoadSceneAsync("Forge");
//        while (!operation.isDone)
//        {
//            yield return null;
//        }
//        //SceneManager.LoadScene(1);
//        gameObject.SetActive(false);
//    }
//    public override void OnCollisionExit(Collision collision)
//    {
//        if (collision.gameObject.tag == "Hammer")
//        {
//        }
//    }
//}
