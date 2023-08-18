using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIMgr : MonoBehaviour
{
    private static UIMgr _instance;//����

    public static UIMgr instance
    {
        get
        {
            if (_instance == null)
            {
                UIMgr ins = FindObjectOfType<UIMgr>();
                if (ins == null)
                {
                    Debug.LogError("������û��UIMgr����������");
                }
                else
                {
                    _instance = ins;
                }
            }
            return _instance;
        }
    }
    Dictionary<string, UIpanel> ui_dict = new Dictionary<string, UIpanel>(); // ���Uipanel���ֵ�


    /// <summary>
    /// ��ȡ�������µ�����panel�ӵ��ֵ���,���ҳ�ʼ��
    /// </summary>
    public void Init()
    {
        UIpanel[] panel = transform.GetComponentsInChildren<UIpanel>(true);

        for (int i = 0; i < panel.Length; i++)
        {
            string name = panel[i].GetType().Name;
            if (!ui_dict.ContainsKey(name))
            {
                ui_dict.Add(name, panel[i]);
            }
            else
            {
                Debug.LogError("������ͬ��Panel������");
            }
        }
        foreach (var item in ui_dict)
        {
            item.Value.Init();
        }
    }
    /// <summary>
    /// ��ȡ�ֵ��е�panel
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T GetPanel<T>() where T : UIpanel
    {
        return (T)ui_dict[typeof(T).Name];
    }
    /// <summary>
    /// ֱ�Ӵ��ֵ��е�panel
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T Open<T>() where T : UIpanel
    {
        ui_dict[typeof(T).Name].Open();
        return (T)ui_dict[typeof(T).Name];
    }
    /// <summary>
    /// ֱ�ӹر��ֵ��е�panel
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T Close<T>() where T : UIpanel
    {
        ui_dict[typeof(T).Name].Close();
        return (T)ui_dict[typeof(T).Name];
    }
    // Update is called once per frame
    void Update()
    {
     
    }
    [ContextMenu("�Զ�ע�����нű�")]
    public void RegisterPanel()
    {
        Debug.Log("ע��");
        foreach (var item in ui_dict)
        {

        }
    }
}

