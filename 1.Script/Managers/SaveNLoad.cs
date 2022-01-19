using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.UI;
using System;

[System.Serializable]
public class Order
{
    public int Engagement
    {
        get { return Mathf.FloorToInt(requireCount * requireQuality * 1.1f); }
    }
    public int requireQuality;
    public int requireCount;
    public string quest_Owner;
    public string quest_Contents;
    public bool isAccept;
    public Order()
    {
        requireQuality=0;
        requireCount=0;
        quest_Owner="";
        quest_Contents="";
        isAccept = false;
    }
}
[System.Serializable]
public struct IngotSave
{
    public Vector3 pos;
    public Vector3 rot;
    public float value;
    public float Sharpened;
    public bool isSharpened;
    public int hammerCount;
    public int sharpenNum;
    public Color color;

    public IngotSave(Ingot ingot) : this()
    {
        pos = ingot.transform.position;
        rot = ingot.transform.eulerAngles;
        value = ingot.value;
        Sharpened = ingot.Sharpened;
        isSharpened = ingot.isSharpened;
        hammerCount = ingot.hammerCount;
        sharpenNum = ingot.sharpenNum;
        color = ingot.color;
    }
}

[System.Serializable]
public struct SwordSave
{
    public Vector3 pos;
    public Vector3 rot;
    public float value;
    public Color color;
    public bool handleType;
    public BladeType bladeType;

    public SwordSave(Sword sword) : this()
    {
        pos = sword.transform.position;
        rot = sword.transform.eulerAngles;
        value = sword.value;
        color = sword.color;
        handleType = sword.handleType;
        bladeType = sword.bladeType;
    }
}
[System.Serializable]
public class SaveData /*���� ������ ���*/
{
    public int playerFame;
    public int playerMineLv;

    public int playerGold;

    public int week;
    public int day;
    public float time;

    public List<string> missionInBoard;
    public List<string> specialMission;
    public List<string> choiceOrder;
    public int[] currentOre = { 0, 0, 0, 0, 0, 0 };

    public List<Order> questData= new List<Order>();
    public SerializableDictionary<int, IngotSave> ingots=new SerializableDictionary<int, IngotSave>();
    public SerializableDictionary<int, SwordSave> swords = new SerializableDictionary<int, SwordSave>();

}
[System.Serializable]
//[CanEditMultipleObjects]
//[ExecuteInEditMode]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    public List<TKey> g_InspectorKeys;
    public List<TValue> g_InspectorValues;

    public SerializableDictionary()
    {
        g_InspectorKeys = new List<TKey>();
        g_InspectorValues = new List<TValue>();
        SyncInspectorFromDictionary();
    }
    /// <summary>
    /// ���ο� KeyValuePair�� �߰��ϸ�, �ν����͵� ������Ʈ
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public new void Add(TKey key, TValue value)
    {
        base.Add(key, value);
        SyncInspectorFromDictionary();
    }
    /// <summary>
    /// KeyValuePair�� �����ϸ�, �ν����͵� ������Ʈ
    /// </summary>
    /// <param name="key"></param>
    public new void Remove(TKey key)
    {
        base.Remove(key);
        SyncInspectorFromDictionary();
    }

    public void OnBeforeSerialize()
    {
    }
    /// <summary>
    /// �ν����͸� ��ųʸ��� �ʱ�ȭ
    /// </summary>
    public void SyncInspectorFromDictionary()
    {
        //�ν����� Ű ��� ����Ʈ �ʱ�ȭ
        g_InspectorKeys.Clear();
        g_InspectorValues.Clear();

        foreach (KeyValuePair<TKey, TValue> pair in this)
        {
            g_InspectorKeys.Add(pair.Key); g_InspectorValues.Add(pair.Value);
        }
    }

    /// <summary>
    /// ��ųʸ��� �ν����ͷ� �ʱ�ȭ
    /// </summary>
    public void SyncDictionaryFromInspector()
    {
        //��ųʸ� Ű ��� ����Ʈ �ʱ�ȭ
        foreach (var key in Keys.ToList())
        {
            base.Remove(key);
        }

        for (int i = 0; i < g_InspectorKeys.Count; i++)
        {
            //�ߺ��� Ű�� �ִٸ� ���� ���
            if (this.ContainsKey(g_InspectorKeys[i]))
            {
                Debug.LogError("�ߺ��� Ű�� �ֽ��ϴ�.");
                break;
            }
            base.Add(g_InspectorKeys[i], g_InspectorValues[i]);
        }
    }

    public void OnAfterDeserialize()
    {
        //�ν������� Key Value�� KeyValuePair ���¸� �� ���
        if (g_InspectorKeys.Count == g_InspectorValues.Count)
        {
            SyncDictionaryFromInspector();
        }
    }
}


public class SaveNLoad : Singleton<SaveNLoad>
{
    public SaveData saveData = new SaveData();
    public readonly int[] oreValue = { 500, 800, 1100, 1400, 1700, 2000 };
    public readonly int[] orePrice = { 500, 800, 1100, 1400, 1700, 2000 };
    public readonly string[] oreName = { "��", "ö", "��ö", "�̽���", "�����ϸ���", "�ƴٸ�Ƽ��" };
    public readonly Color[] oreColor = {new Color(1,0.5f,0,1),Color.red,Color.black,
    Color.white,Color.cyan,Color.yellow};
    public GameObject ingot;
    public GameObject handle0;
    public GameObject handle1;
    public GameObject blade0;
    public GameObject blade1;
    public GameObject blade2;
    public SerializableDictionary<int,SwordSave> handleSword;
    public Action timeAction;

    //������ ���
    private string path;
    //���� �̸�
    private string savefileName = "/SaveFile.txt";

    //�÷��̾� ��ǥ���� �޾ƿ��� ����
    //private tempPlayer thePlayer;/*�����׽�Ʈ �÷��̾� Ŭ���� �̸��� tempPlayer�� ���߿� �ٲپ������*/

    private Vector3 vector;
    //������ ��ħ 9�ÿ� �� ������Ʈ
    public GameObject questPanel;
    //�Ͽ��� �� 9�ÿ� �� ������Ʈ
    public GameObject AccountBox;
    //��, ȭ, ��, �� ���� ������ ����������� �����ǸŴ�
    public GameObject MerchantSET;
    OrderControl orderControlSc;


    [SerializeField] Text _text;
    public float secForHour = 1;
    public int amTimes = 3;
    public int pmTimes = 13;

    void Start()
    {                                              //������ ����Ǵ� ���� ���� ��
        path = Path.Combine(Application.dataPath,"Save.json");
        //������ ���ٸ� �ڵ����� ���������ش�.
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
    }

    public void SaveData()
    {
        //thePlayer = FindObjectOfType<tempPlayer>();/*�����׽�Ʈ �÷��̾� Ŭ���� �̸��� tempPlayer�� ���߿� �ٲپ������*/
       //�÷��̾� ��ġ
        //saveData.playerPos = thePlayer.transform.position;
        //saveData.playerRot = thePlayer.transform.eulerAngles;

        /*saveData�� ���̽�������ȭ(str), �ڿ� true�� ���־�� ������ ���� ���� ���ĵ�*/
        string jsonData = JsonUtility.ToJson(saveData,true);
        //�������
        File.WriteAllText(path + savefileName, jsonData);
        Debug.Log("����Ϸ�");
        Debug.Log(path+" "+jsonData);
    }
    public void LoadData()
    {
        if (File.Exists(path + savefileName))
        {
            //��� �б�
            string loadjson = File.ReadAllText(path + savefileName);
            //���̽�ȭ�� loadjson�� �ٽ� SaveData�� Ǯ����
            saveData = JsonUtility.FromJson<SaveData>(loadjson);
            //thePlayer = FindObjectOfType<tempPlayer>();
            //thePlayer.transform.position = saveData.playerPos;
            //thePlayer.transform.eulerAngles= saveData.playerRot;
            if (saveData != null)
            {
                foreach(int key in saveData.ingots.Keys)
                {
                    LoadIngot(key);
                }
                foreach (int key in saveData.swords.Keys)
                {
                    SwordSave ss = saveData.swords[key];
                    LoadSword(ss);
                    saveData.swords.Remove(key);
                }
            }
            Debug.Log("�ε� �Ϸ�");
        }
        else
            Debug.Log("���̺� ������ �����ϴ�.");
    }
    public Ingot LoadIngot(int key)
    {
        Ingot newIngot = Instantiate(ingot).GetComponent<Ingot>();
        newIngot.transform.position = saveData.ingots[key].pos;
        newIngot.transform.eulerAngles = saveData.ingots[key].rot;
        newIngot.value = saveData.ingots[key].value;
        newIngot.Sharpened = saveData.ingots[key].Sharpened;
        newIngot.isSharpened = saveData.ingots[key].isSharpened;
        newIngot.hammerCount = saveData.ingots[key].hammerCount;
        newIngot.sharpenNum = saveData.ingots[key].sharpenNum;
        newIngot.color = saveData.ingots[key].color;
        newIngot.GetComponent<Renderer>().material.color = newIngot.color;
        Vector3 scale = newIngot.transform.localScale;
        scale.x *= Mathf.Pow(1.1f, newIngot.hammerCount);
        newIngot.transform.localScale = scale;
        if (newIngot.isSharpened)
        {
            Blade blade;
            if (newIngot.hammerCount > 9)
            {
                newIngot.longSword.SetActive(true);
                newIngot.longSword.GetComponent<Renderer>().material.color = newIngot.color;
                blade = newIngot.longSword.GetComponent<Blade>();
            }
            else if (newIngot.Sharpened < 1f)
            {
                newIngot.broadSword.SetActive(true);
                newIngot.broadSword.GetComponent<Renderer>().material.color = newIngot.color;
                blade = newIngot.broadSword.GetComponent<Blade>();
            }
            else
            {
                newIngot.normalSword.SetActive(true);
                newIngot.normalSword.GetComponent<Renderer>().material.color = newIngot.color;
                blade = newIngot.normalSword.GetComponent<Blade>();
            }
            blade.value = newIngot.value;
            GetComponent<MeshRenderer>().enabled = false;
            transform.localScale = new Vector3(0.4f, 0.1f, 0.15f);
            GetComponent<BoxCollider>().enabled = false;
        }
        return newIngot;
    }
    public Sword LoadSword(SwordSave ss)
    {
        Sword sword;
        Blade blade;
        if (ss.handleType)
        {
            sword = Instantiate(handle1).GetComponent<Sword>();
        }
        else
        {
            sword = Instantiate(handle0).GetComponent<Sword>();
        }
        if (ss.bladeType == BladeType.Broad)
        {
            blade = Instantiate(blade0).GetComponent<Blade>();
        }
        else if (ss.bladeType == BladeType.Fuller)
        {
            blade = Instantiate(blade1).GetComponent<Blade>();
        }
        else
        {
            blade = Instantiate(blade2).GetComponent<Blade>();
        }
        sword.bladeType = ss.bladeType;
        sword.handleType = ss.handleType;
        blade.GetComponent<Renderer>().material.color = ss.color;
        blade.transform.parent = sword.transform;
        blade.transform.localPosition = Vector3.zero;
        blade.transform.localEulerAngles = Vector3.zero;
        sword.blade = blade.transform;
        sword.value = ss.value;
        sword.color = ss.color;
        sword.bladeType = ss.bladeType;
        sword.transform.position = ss.pos;
        sword.transform.eulerAngles = ss.rot;
        saveData.swords.Add(sword.GetInstanceID(), new SwordSave(sword));
        Destroy(blade);
        return sword;
    }
    private void Update()
    {
        if (saveData.time < amTimes)
        {
            saveData.time += Time.deltaTime / secForHour;
        }
        else if (saveData.time <= pmTimes)
        {
            saveData.time += Time.deltaTime / secForHour;
        }
        else
        {
            saveData.day++;
            saveData.time = 0;
        }
    }
    public string TimeString()
    {
        if (saveData.time < amTimes)
        {
            return DisplayWeekString() + "th Week" + "\r\n" + DisplayDateString() + "\r\n" + "AM " + DisplayTimeString();
        }
        else
        {
            return DisplayWeekString() + "th Week" + "\r\n" + DisplayDateString() + "\r\n" + "PM " + DisplayTimeString();
        }
    }
    public string DisplayWeekString()
    {
        string week = saveData.week.ToString();
        return week;
    }
    public string DisplayDateString()
    {
        string date = "";
        if (saveData.day < 0)
        {
            saveData.day = 0;
        }
        else if (saveData.day > 6)
        {
            saveData.day = 0;
            saveData.week++;
        }
        switch (saveData.day)
        {
            case 0: date += "MONDAY"; break;
            case 1: date += "TUESDAY"; break;
            case 2: date += "WEDNESDAY"; break;
            case 3: date += "THURSDAY"; break;
            case 4: date += "FRIDAY"; break;
            case 5: date += "SATURDAY"; break;
            case 6: date += "SUNDAY"; break;
        }
        return date;
    }
    public string DisplayTimeString()
    {
        if (saveData.time < 0)
        {
            saveData.time = 0;
        }

        float minute = Mathf.FloorToInt(saveData.time / 60);
        float second = Mathf.FloorToInt(saveData.time % 60) + 9;
        float milisecond = saveData.time % 1 * 1000;
        return string.Format("{0:00}:{1:00}", second, minute);
    }
}
