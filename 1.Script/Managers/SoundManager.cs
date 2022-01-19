using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

//Ÿ ��ũ��Ʈ���� ������ �� �Ʒ��� ���� ȣ��
/*public AudioClip[] clips;
if (Input.GetKeyDown(KeyCode.Space)) SoundManager.instance.SFXPlay("Jump", clips[0]);*/
public class SoundManager : Singleton<SoundManager>
{
    public float musicValue;

    public AudioMixer mixer;
    public AudioSource bgmSound;
    public AudioClip[] bglist; //bglist �迭�� ��ҷ� ������� �־��־�� ��
    public override void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else Destroy(gameObject);
    }

    private void Start()
    {
        musicValue = 1;
    }
    private void Update()
    {
        float musicVolume = musicValue;
        bgmSound.volume = musicVolume;
    }
    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        for (int i = 0; i < bglist.Length; i++)
        {
            if (arg0.name == bglist[i].name)
                BgmSoundPlay(bglist[i]);
        }
    }
    //�� ��ũ��Ʈ���� SoundManager.instance.SFXPlay("�ƹ��̸�",clips[0]); ������ ȣ���ϸ� ��
    public void SFXPlay(string stxName, AudioClip clip)
    {
        GameObject go = new GameObject(stxName + "_SFXsound");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = mixer.FindMatchingGroups("SFX")[0];
        audioSource.clip = clip;
        audioSource.Play();

        Destroy(go, clip.length);//Ŭ�� ���� ��ŭ ����� ������ �ڵ� �ı���
    }

    public void BgmSoundPlay(AudioClip clip)
    {
        bgmSound.outputAudioMixerGroup = mixer.FindMatchingGroups("Bgm")[0];
        bgmSound.clip = clip;
        bgmSound.loop = true;
        bgmSound.volume = 1f;
        bgmSound.Play();
    }
    public void BgmSoundVolume(float value)
    {
        mixer.SetFloat("BgmVolume", value);
     }
    public void EffectSoundVolume(float value)
    {
        mixer.SetFloat("EffectVolume", value);
    }

}
