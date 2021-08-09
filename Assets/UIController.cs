using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController
{
    private static UIController ins;
    public static UIController Instance
    {
        get {
            if (ins == null)
                ins = new UIController();
            return ins; }
    }

    public List<Panel> panels = new List<Panel>();
    public void RegistEvent()
    {
        for (int i = 0; i < panels.Count; i++)
        {
            panels[i].RegistEvent();
        }
    }
}
