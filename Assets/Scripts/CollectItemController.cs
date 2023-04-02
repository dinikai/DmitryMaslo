using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectItemController : MonoBehaviour
{
    [SerializeField] private Text collectText;
    public int itemsCollected = 0;

    private void Update()
    {
        collectText.text = itemsCollected.ToString() + "/3";
    }
}
