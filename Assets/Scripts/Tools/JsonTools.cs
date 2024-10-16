using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class JsonTools
{
    public static DialogGroup LoadPlot(TextAsset plotText){
        DialogGroup plot=JsonUtility.FromJson<DialogGroup>(plotText.text);
        return plot;
    }
}
