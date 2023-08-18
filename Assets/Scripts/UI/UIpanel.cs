using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIpanel : MonoBehaviour
{
    public bool isOpen = false;
    public virtual void Init()
    {
        gameObject.SetActive(isOpen);
    }
    /// <summary>
    /// �򿪽���
    /// </summary>
    public virtual void Open()
    {
        HOpen();
    }
    /// <summary>
    /// �رս���
    /// </summary>
    public virtual void Close()
    {
        HClose();
    }
    /// <summary>
    /// ��Ч���Ĵ�
    /// </summary>
    public virtual void HOpen()
    {
        isOpen = true;
        gameObject.SetActive(true);
    }
    /// <summary>
    /// ��Ч���Ĺر�
    /// </summary>
    public virtual void HClose()
    {
        isOpen = false;
        gameObject.SetActive(false);
    }
}


