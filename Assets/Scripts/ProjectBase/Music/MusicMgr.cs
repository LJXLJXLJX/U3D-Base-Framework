using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MusicMgr : BaseManager<MusicMgr>
{
    private AudioSource bkMusic = null;
    private float bkVolume = 1f;

    private GameObject soundObj = null;
    private List<AudioSource> soundList = new List<AudioSource>();
    private float soundVolume = 1f;

    public MusicMgr()
    {
        MonoMgr.GetInstance().AddUpdateListener(Update);
    }

    private void Update()
    {
        for (int i = soundList.Count - 1; i >= 0; ++i)
        {
            if (!soundList[i].isPlaying)
            {
                GameObject.Destroy(soundList[i]);
                soundList.RemoveAt(i);
            }
        }
    }

    /// <summary>
    /// 播放背景音乐
    /// </summary>
    /// <param name="name"></param>
    public void PlayBkMusic(string name)
    {
        if (bkMusic == null)
        {
            GameObject obj = new GameObject();
            obj.name = "BkMusic";
            bkMusic = obj.AddComponent<AudioSource>();
        }
        //异步加载背景音乐 加载完成后播放
        ResMgr.GetInstance().LoadAsync<AudioClip>("Music/BK/" + name, (clip) =>
        {
            bkMusic.clip = clip;
            bkMusic.volume = bkVolume;
            bkMusic.loop = true;
            bkMusic.Play();
        });
    }

    /// <summary>
    /// 设置背景音乐音量
    /// </summary>
    /// <param name="v"></param>
    public void SetBkVolume(float v)
    {
        bkVolume = v;
        if (bkMusic == null)
            return;
        bkMusic.volume = bkVolume;
    }


    /// <summary>
    /// 暂停背景音乐
    /// </summary>
    public void PauseBkMusic()
    {
        if (bkMusic == null)
            return;
        bkMusic.Pause();
    }

    /// <summary>
    /// 停止背景音乐
    /// </summary>
    /// <param name="name"></param>
    public void StopBkMusic()
    {
        if (bkMusic == null)
            return;
        bkMusic.Stop();
    }

    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="name"></param>
    public void PlaySound(string name, bool isLoop, UnityAction<AudioSource> callback = null)
    {
        if (soundObj == null)
        {
            soundObj = new GameObject();
            soundObj.name = "Sound";
        }

        ResMgr.GetInstance().LoadAsync<AudioClip>("Sound/" + name, (clip) =>
        {
            AudioSource source = soundObj.AddComponent<AudioSource>();
            source.clip = clip;
            source.volume = bkVolume;
            source.loop = isLoop;
            source.Play();
            soundList.Add(source);
            if (callback != null)
                callback(source);
        });
    }

    /// <summary>
    /// 停止音效
    /// </summary>
    /// <param name="name"></param>
    public void StopSound(AudioSource source)
    {
        if (soundList.Contains(source))
        {
            soundList.Remove(source);
            source.Stop();
            GameObject.Destroy(source);
        }
    }

    public void SetSoundVolume(float v)
    {
        soundVolume = v;
        for (int i = 0; i < soundList.Count; ++i)
        {
            soundList[i].volume = v;
        }
    }
}
