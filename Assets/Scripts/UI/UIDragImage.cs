using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIDragImage : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private CanvasScaler scaler;

    private Vector2 startingPosition;
    public UnityAction OnBeginDragAction;

    public void Init(CanvasScaler scaler)
    {
        this.scaler = scaler;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        OnBeginDragAction?.Invoke();
        startingPosition = rectTransform.anchoredPosition;
    }

    public UnityAction OnDragAction;
    public void OnDrag(PointerEventData eventData)
    {
        OnDragAction?.Invoke();
        float dx = eventData.delta.x / scaler.transform.localScale.x;
        float dy = eventData.delta.y / scaler.transform.localScale.y;
        rectTransform.anchoredPosition += new Vector2(dx,dy);
    }

    public UnityAction OnEndDragAction;
    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = startingPosition;
        OnEndDragAction?.Invoke();
    }
}
