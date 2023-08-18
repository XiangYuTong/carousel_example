using UnityEngine;

/// <summary>
/// FPS��ʾ����
/// </summary>
public class FPSDisplay : MonoBehaviour
{
    [Header("�Ƿ���ʾ")]
    public bool isShow = true;
    [Header("���¼��")]
    public float updateInterval = 1f;
    [Header("�����С")]
    public int fontSize = 42;
    [Header("������ɫ")]
    public Color fontColor = Color.white;
    [Header("�����Ե")]
    public int margin = 50;
    [Header("��ʾλ��")]
    public TextAnchor alignment = TextAnchor.UpperLeft;

    private GUIStyle guiStyle;
    private Rect rect;
    private int frames;
    private float fps;
    private float lastInterval;

    void Start()
    {
        guiStyle = new GUIStyle();
        guiStyle.fontStyle = FontStyle.Bold;        //����Ӵ�
        guiStyle.fontSize = fontSize;               //�����С
        guiStyle.normal.textColor = fontColor;      //������ɫ
        guiStyle.alignment = alignment;             //���䷽ʽ

        rect = new Rect(margin, margin, Screen.width - (margin * 2), Screen.height - (margin * 2));
        lastInterval = Time.realtimeSinceStartup;
        frames = 0;
        fps = 0.0f;
    }
    void Update()
    {
        ++frames;
        float timeNow = Time.realtimeSinceStartup;
        if (timeNow > lastInterval + updateInterval)
        {
            fps = frames / (timeNow - lastInterval);
            frames = 0;
            lastInterval = timeNow;
        }
    }
    void OnGUI()
    {
        if (!isShow) return;
        GUI.Label(rect, "FPS: " + fps.ToString("F2"), guiStyle);
    }
}
