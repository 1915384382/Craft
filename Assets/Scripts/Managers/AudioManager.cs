using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioLayer
{
    BGM,
    SOUND,
}
public class AudioManager {
    Dictionary<AudioLayer, AudioSource> audioDic = new Dictionary<AudioLayer, AudioSource>();
    float volume = 1;
    private static AudioManager ins;
    public static AudioManager Instance
    {
        get
        {
            if (ins == null)
                ins = new AudioManager();
            return ins;
        } 
    }
    public void PlayBGM(string _name, bool isLoop = true) 
    {
        PlayLayerSound(AudioLayer.BGM, _name, isLoop);
    }
    public void Play(string _name,bool isLoop = false) 
    {
        PlayLayerSound(AudioLayer.SOUND, _name, isLoop);
    }
    void PlayLayerSound(AudioLayer layer, string _name,bool isLoop) 
    {
        AudioClip clip = Resources.Load<AudioClip>(GameManager.Instance.AddString("Music/", _name));
        if (clip == null)
        {
            Debug.LogError("music == null  name ========" + _name);
            return;
        }

        if (!audioDic.ContainsKey(layer))
        {
            GameObject audio = new GameObject(layer.ToString());
            audio.transform.parent = GameManager.Instance.transform;
            audioDic[layer] = audio.AddComponent<AudioSource>();
        }
        AudioSource source = audioDic[layer];
        
        if (isLoop)
        {
            if (source.clip != clip)
            {
                source.clip = clip;
                source.volume = volume;
                source.loop = isLoop;
                source.Play();
            }
        }
        else
        {
            source.clip = clip;
            source.volume = volume;
            source.loop = isLoop;
            source.Play();
        }
    }
}
