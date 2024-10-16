using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
// 剧情处罚类
public class Plot : MonoBehaviour
{
    public float CoolingTime=60;
    private float waitCount=0;
    private bool PlotEnable=true;
    private void Update() {
        if(PlotEnable==false && InParam.inParam.isPlot==false){
            waitCount+=Time.deltaTime;
            if(waitCount>=CoolingTime){
                PlotEnable=true;
                waitCount=0;
            }
        }
    }
    // 触发剧情
    private void OnTriggerStay(Collider other) {
        if(plotFile!=null && PlotEnable && InParam.inParam.isPlot!=true){
            if(type==plotType.Force || Input.GetKey(InputControl.input.EnterPlotKey)){
                InputControl.UnLockMouse();
                PlotManager.plotManager.Play(plot);
                InParam.inParam.isPlot=true;
                PlotEnable=false;
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        PlotEnable=false;
        InParam.inParam.isPlot=false;
        Dialog.dialog.hide();
        if(type!=plotType.Daily && InParam.inParam.isPlot==false){
            transform.GameObject().SetActive(false);
        }
    }
    public TextAsset[] plotFile;      // 剧情文件
    public plotType type;
    private List<DialogGroup> plot;      // 处理过的剧情对话

    private void Start() {
        // 初始化
        plot=new List<DialogGroup>();
        for(int i=0;i<plotFile.Length;i++){
            plot.Add(null);
        }
        // 加载剧情同时处理
        getPlot();
    }
    private void getPlot(){
        for(int i=0;i<plotFile.Length;i++){
            // 设置一组对话的位置
            SetDialogGroupPosition(JsonTools.LoadPlot(plotFile[i]));
        }
    }
    // 设置一组对话的位置
    private void SetDialogGroupPosition(DialogGroup item){
        string[] tagPos=item.position.Split('-');      // 处理对话组的排序标识
        int pos=0;      // 当前对话组的位置
        for(int i=0;i<tagPos.Length;i++){
            pos=pos*3+int.Parse(tagPos[i]);     // 计算位置
        }
        while(pos>=plot.Count){
            plot.Add(null);     // 扩展列表大小
        }
        plot[pos]=item;
    }
}
