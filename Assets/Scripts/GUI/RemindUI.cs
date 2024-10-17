using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RemindUI : BaseUI
{
    public static RemindUI remindUI;
    private void Awake() {
        remindUI=this;
    }
    private void Start() {
        hideInfoPlot();
    }

    public GameObject infoPlot;

    public void setInfoPlotText(string text){
        infoPlot.GetComponentInChildren<TextMeshProUGUI>().text=text;
    }

    public void showInfoPlot(){
        infoPlot.SetActive(true);
    }
    public void hideInfoPlot(){
        infoPlot.SetActive(false);
    }
}
