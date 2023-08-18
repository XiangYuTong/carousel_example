using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MouseSwipe : MonoBehaviour
{
    // ������һ�������С�ƶ���
    public float minSwipeDistance = 100f;

    // ���¼�
    public UnityEngine.Events.UnityEvent onSwipeLeft;

    // �һ��¼�
    public UnityEngine.Events.UnityEvent onSwipeRight;

    private Vector2 swipeStartPosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            swipeStartPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector2 swipeEndPosition = Input.mousePosition;
            float swipeDistance = swipeEndPosition.x - swipeStartPosition.x;

            if (Mathf.Abs(swipeDistance) >= minSwipeDistance)
            {
                if (swipeDistance < 0f)
                {
                    // ִ�����¼�
                    onSwipeLeft.Invoke();
                }
                else
                {
                    // ִ���һ��¼�
                    onSwipeRight.Invoke();
                }
            }
        }
    }
}

