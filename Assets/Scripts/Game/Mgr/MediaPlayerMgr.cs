using RenderHeads.Media.AVProVideo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MediaPlayerMgr : MonoBehaviour
{   
    private static MediaPlayerMgr _instance;//����

    public static MediaPlayerMgr instance
    {
        get
        {
            if (_instance == null)
            {
                MediaPlayerMgr ins = FindObjectOfType<MediaPlayerMgr>();
                if (ins == null)
                {
                    Debug.LogError("������û��MediaPlayerMgr����������");
                }
                else
                {
                    _instance = ins;
                }
            }
            return _instance;
        }
    }

    public void Init()
    {
       
    }
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    /// <summary>
    /// ������һ����Ƶ
    /// </summary>
    public void PlayNext()
    {   
        //mediaPlayer.OpenMedia(MediaPathType.RelativeToStreamingAssetsFolder, Common.videoFileName[index++], true);
    }
}
