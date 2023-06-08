using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private string text;
    private TextMeshProUGUI tmp;

    private void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        text = tmp.text;
    }
    public void OnPointerEnter(PointerEventData eventData) => tmp.text = "►" + text;
    public void OnPointerExit(PointerEventData eventData) => tmp.text = text;
}
