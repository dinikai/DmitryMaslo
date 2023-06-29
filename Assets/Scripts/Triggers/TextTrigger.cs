using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : Trigger
{
    public string text;

    public override void RunTrigger()
    {
        PublicObjects.TextController.WriteText(text);
    }
}
