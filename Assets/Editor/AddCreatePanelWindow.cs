using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
using System;

public class AddCreatePanelWindow : EditorWindow
{
    private static string panelName;
    private static string tip = "";
    private static string uiFrefabPath = "UI/PanelPrefab";
    private static string scriptModelPath= "Assets/Scripts/UI/ModelPanel.cs";
    private static string _spawnPath = "Assets/Scripts/UI/";
    private static string scriptModelContent;

    [MenuItem("Tools/����һ���µ�UIPanel")]
    private static void Init()
    {
        var window = GetWindow(typeof(AddCreatePanelWindow),true,"����UIPanel������");
        window.Show();
        scriptModelContent = File.ReadAllText(scriptModelPath);
    }
    private void OnGUI()
    {
        panelName = EditorGUILayout.TextField("Panel������:", panelName);
        GUI.color = Color.red;
        GUILayout.Label(tip);
        GUI.color = Color.white;
        if (GUILayout.Button("����"))
        {
            if (string.IsNullOrEmpty(panelName))
            {
                tip = "���ֲ���Ϊ�գ����������룡";
                return;
            }
            GameObject uimgr = FindObjectOfType<UIMgr>().gameObject;
            if (uimgr == null)
            {
                tip = "�����в�����UIMgr,����ӣ�";
                return;
            }
            GameObject panel = GameObject.Instantiate(Resources.Load<GameObject>(uiFrefabPath));
            if (panel == null)
            {
                tip = "UIPanelԤ����Ϊ�գ����飡";
                return;
            }
            if (string.IsNullOrEmpty(scriptModelContent))
            {
                tip = "ģ������Ϊ��,���飡";
                return;
            }
            panel.transform.parent = uimgr.transform;
            panel.name = panelName;


            var path = _spawnPath + panelName + ".cs";
            //�滻����
            scriptModelContent = scriptModelContent.Replace("ModelPanel", panelName);

            if (scriptModelContent != null)
            {
                //�滻�����ռ�
                //scriptModelContent = scriptModelContent.Replace("TemplateNameSpace", NameSpace);
            }
            //����֯�õ�����д���ļ�
            File.WriteAllText(path, scriptModelContent, Encoding.UTF8);
            //ˢ��һ����Դ����Ȼ�������ļ����һʱ�䲻����ʾ
            AssetDatabase.Refresh();

            //panel.AddComponent(Type.GetType(panelName));
        }

    }

}
