using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MyButton : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    public UnityEvent OnPointerDownEvent, OnPointerUpEvent;
    public void OnPointerDown(PointerEventData eventData)
    {

        OnPointerDownEvent.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnPointerUpEvent.Invoke();

    }

}
