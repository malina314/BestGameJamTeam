using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;

public class UIWarrior : MonoBehaviour
{
    public UIDragImage draggableImage;
    public Image image;
    public TextMeshProUGUI text;

    private WarriorType warriorType;

    public void Init(WarriorData warriorData,CanvasScaler gameCanvasScaler)
    {
        draggableImage.Init(gameCanvasScaler);
        draggableImage.OnEndDragAction += OnEndDrag;

        image.sprite = warriorData.sprite;
        text.text = warriorData.name;
        warriorType = warriorData.warriorType;
    }

    public UnityAction<PointerEventData,WarriorType> OnEndDragAction;
    public void OnEndDrag(PointerEventData eventData)
    {
        OnEndDragAction.Invoke(eventData,warriorType);
    }
}
