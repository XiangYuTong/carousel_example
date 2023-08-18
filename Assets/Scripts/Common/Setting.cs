using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class Setting
{
    public  Dictionary<string, string> settingDate = new Dictionary<string, string>();

    public void Open(string filePath)
    {
        if (File.Exists(filePath))
        {
            try
            {
                // ��ȡ�ı��ļ�������
                string text = File.ReadAllText(filePath);
                if (text != "")
                {
                    ReadSetting(text);
                }
                // ʹ���ļ����ݽ��к�������
                Debug.Log("�ļ����ݣ�" + text);
            }
            catch (IOException e)
            {
                Debug.LogError("��ȡ�ļ�ʱ��������" + e.Message);
            }
        }
    }
    private void ReadSetting(string text)
    {
        string[] data = text.Split("\r\n");
        foreach (var pair in data)
        {
            string[] parts = pair.Split(':');
            if (parts.Length == 2)
            {
                string key = parts[0];
                string value = parts[1];
                settingDate.Add(key, value);
            }

        }
    }

    public string ReadValue(string key,string defaultValue)
    {
        if (settingDate.ContainsKey(key))
        {
            return settingDate[key];
           
        }
        else
        {
            return defaultValue;
        }
        
    }

}
