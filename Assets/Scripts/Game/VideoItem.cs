using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RenderHeads.Media.AVProVideo;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class VideoItem : MonoBehaviour
{
    public DisplayUGUI display;
    public MediaPlayer player;
    public RectTransform rectTransform;
    public Button Btn;
    public int index;
    Tween tween;
    // Start is called before the first frame update
    public void Init()
    {
        ///获取组件
        display = GetComponent<DisplayUGUI>();
        player = GetComponent<MediaPlayer>();
        rectTransform = GetComponent<RectTransform>();
        Btn = GetComponent<Button>();


        display.Player = player;

        player.Events.AddListener(OnMediaPlayerEvent);




        Btn.onClick.AddListener(btn_click);

        if (index == 1)
        {
            rectTransform.anchoredPosition = new Vector2(Screen.width, 0);
        }
        if (Common.videoFileName.Length != 0)
            player.OpenMedia(MediaPathType.RelativeToStreamingAssetsFolder, Common.videoFileName[index], false);

    }

    private void OnMediaPlayerEvent(MediaPlayer arg0, MediaPlayerEvent.EventType arg1, ErrorCode arg2)
    {
        switch (arg1)
        {
            case MediaPlayerEvent.EventType.Started:
                print("startedEvent开始事件触发");

                break;
            case MediaPlayerEvent.EventType.FinishedPlaying:
                print("finishedEvent结束事件触发");
                UIMgr.instance.GetPanel<MainPanel>().ChangeVideo();
                //player.OpenMedia(MediaPathType.RelativeToStreamingAssetsFolder, Common.videoFileName[index], false);
                break;
        }

    }

    private void btn_click()
    {
        if (!Common.isPlaying)
            UIMgr.instance.GetPanel<MainPanel>().ChangeVideo();
    }

    public void PlayVideo()
    {
        player.Play();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
