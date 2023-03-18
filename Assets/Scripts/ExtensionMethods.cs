using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    public static void Si(this EventHandler handler, object sender, EventArgs e)
    {
        if (handler != null) handler(sender, e);
    }
}
