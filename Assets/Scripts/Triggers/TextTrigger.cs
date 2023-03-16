using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : Trigger
{
    [SerializeField] private TextController textController;
    public string text;

    public override void RunTrigger()
    {
        textController.WriteText(text);
    }
}
