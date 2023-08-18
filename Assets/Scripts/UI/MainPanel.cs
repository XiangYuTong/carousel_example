using DG.Tweening;
using RenderHeads.Media.AVProVideo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : UIpanel
{
    VideoItem[] items;
    public int currentIndex = 0;
    public override void Init()
    {
        base.Init();
        items = GetComponentsInChildren<VideoItem>(true);
        for (int i = 0; i < items.Length; i++)
        {
            items[i].index = i;
            items[i].Init();
        }
         OnLevelWasLoaded();
    }
    void Start()
    {
       
    }

    void Update()
    {
    }

    public override void Open()
    {
        base.Open();
    }
    public override void Close()
    {
        base.Close();
    }
    public void ChangeVideo()
    {
        Common.isPlaying = true;
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].index != currentIndex)
            {
                items[i].rectTransform.SetAsLastSibling();  
                items[i].rectTransform.DOAnchorPosX(0, 1).OnComplete(() =>
                {
                    currentIndex = (currentIndex + 1) % Common.videoFileName.Length;
                    OnLevelWasLoaded();
                    int tempindex = (currentIndex + 1) % 2;
                    items[tempindex].rectTransform.DOAnchorPosX(Screen.width, 1).OnComplete(() => {
                        items[tempindex].index = (items[tempindex].index + 2) % Common.videoFileName.Length;
                        items[tempindex].player.OpenMedia(MediaPathType.RelativeToStreamingAssetsFolder, Common.videoFileName[currentIndex], false); ;
                        Common.isPlaying = false;
                    });
               
                });
            }


        }
       
        
    }
    public void OnLevelWasLoaded()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].index == currentIndex)
            {
                items[i].PlayVideo();
            }
        }
    }
}


