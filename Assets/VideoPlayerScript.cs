using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerScript : MonoBehaviour
{

    //public VideoClip videoClip;
    public VideoPlayer videoPlayer;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        audioSource = gameObject.AddComponent<AudioSource>();
        LoadAndPlay();
    }

    public void LoadAndPlay()
    {
        //videoPlayer.clip = videoClip;
        videoPlayer.playOnAwake = true;

        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }
    }
}
