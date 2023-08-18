using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class ChangeFontTool : EditorWindow
{
    // Start is called before the first frame update
    private GameObject selectGameObject;
    private TMP_FontAsset changeTmpFont;
    private Font changeTextFont;
    [MenuItem("Tools/�滻����")]
    private static void Init()
    {
        var window = GetWindow(typeof(ChangeFontTool), true, "�滻����");
        window.Show();
    }
    private void OnGUI()
    {
        GUILayout.Label("Ŀ������:");
        selectGameObject = (GameObject)EditorGUILayout.ObjectField(selectGameObject, typeof(GameObject), true, GUILayout.MinWidth(100f));
        GUILayout.Label("�滻��TMP����:");
        changeTmpFont = (TMP_FontAsset)EditorGUILayout.ObjectField(changeTmpFont, typeof(TMP_FontAsset), true, GUILayout.MinWidth(100f));
        GUILayout.Label("�滻��Text����:");
        changeTextFont = (Font)EditorGUILayout.ObjectField(changeTextFont, typeof(Font), true, GUILayout.MinWidth(100f));
        if (GUILayout.Button("�滻"))
        {
            if (selectGameObject == null)
            {
                Debug.LogError("ѡ������Ϊ�գ��뽫��������ָ��λ�ã�");
                return;
            }
            if (changeTmpFont != null)
            {
                TextMeshProUGUI[] Tmps = selectGameObject.GetComponentsInChildren<TextMeshProUGUI>();
                foreach (var item in Tmps)
                {
                    item.font = changeTmpFont;
                    EditorUtility.SetDirty(item);
                }
            }
            if (changeTextFont != null)
            {
                Text[] texts = selectGameObject.GetComponentsInChildren<Text>();
                foreach (var item in texts)
                {
                    item.font = changeTextFont;
                    EditorUtility.SetDirty(item);
                }
            }
            if (changeTmpFont == null && changeTextFont == null)
            {
                Debug.LogError("�����ٷ���һ�����壡");
            }
        }
        if (GUILayout.Button("ȫ�����滻"))
        {
            if (changeTmpFont != null)
            {
                TextMeshProUGUI[] Tmps = FindObjectsOfType<TextMeshProUGUI>();
                foreach (var item in Tmps)
                {
                    item.font = changeTmpFont;
                    EditorUtility.SetDirty(item);
                }
            }
            if (changeTextFont != null)
            {
                Text[] texts = FindObjectsOfType<Text>();
                foreach (var item in texts)
                {
                    item.font = changeTextFont;
                    EditorUtility.SetDirty(item);
                }
            }
            if (changeTmpFont == null && changeTextFont == null)
            {
                Debug.LogError("�����ٷ���һ�����壡");
            }
        }
    }
}
