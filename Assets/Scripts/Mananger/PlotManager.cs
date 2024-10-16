using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{
    public static PlotManager plotManager;
    private int childMaxCount=0;      // 最多可能有几个选项
    private void Awake() {
        plotManager=this;
    }
    private void Start() {
        childMaxCount=Dialog.dialog.optsBut.Count;
    }
    private List<DialogGroup> plot;     // 剧情
    private int count=0;    // 对话组的第几句对话
    private int nowDialogGroup=0;       // 播放的对话组
    private int choose=0;       // 按钮选择
    // 开始剧情
    public void Play(List<DialogGroup> plot){
        this.plot=plot;     // 开始的某个剧情
        Dialog.dialog.show();       // 显示的对话框
        Continue();     // 播放第一句
    }
    // 结束剧情
    public void End(){
        count=0;
        nowDialogGroup=0;
        Dialog.dialog.hideNextBut();
        Dialog.dialog.hideOptsBut();

        InputControl.LockMouse();
        InParam.inParam.isPlot=false;
        Dialog.dialog.hide();
    }
    private int showOptsButs=0;       // 显示的选项按钮数量
    public void Continue(){
        // 开始默认隐藏，等待处理
        Dialog.dialog.hideNextBut();
        Dialog.dialog.hideOptsBut();
        if(count<plot[nowDialogGroup].dialogs.Length){
            // 当前对话组没有结束时
            Dialog.dialog.showNextBut();
            Dialog.dialog.SetUIName(plot[nowDialogGroup].dialogs[count].name);
            Dialog.dialog.SetUIContent(plot[nowDialogGroup].dialogs[count].content);
            count++;
        }
        else{
            // 当前对话组结束时，显示按钮，切换对话组
            showOptsButs=CalShowOptBut();
            if(showOptsButs==0){
                // 没有选项就结束剧情
                End();
                return;
            }
            // 计算显示的数量并设置按钮的文本
            Dialog.dialog.showOptsBut( showOptsButs );
            count=0;
        }
    }
    // 计算要显示的按钮
    private int CalShowOptBut(){
        int showCount=0;
        // 设置按钮文本
        for(int i=nowDialogGroup*childMaxCount+1;i<=nowDialogGroup*childMaxCount+childMaxCount && i<plot.Count;i++){
            if(plot[i]!=null){
                Dialog.dialog.setOptsButText(i-nowDialogGroup*childMaxCount-1,getFirstDialog( plot[i] ));
            }
        }
        // 计算显示的数量
        for(int i=nowDialogGroup*childMaxCount+1;i<=nowDialogGroup*childMaxCount+childMaxCount && i<plot.Count;i++){
            if(plot[i]!=null){
                showCount++;
            }
        }
        return showCount;
    }

    // 计算要切换对话组的下标
    private void updataDialogGroup(){
        nowDialogGroup=nowDialogGroup*childMaxCount+choose;
    }
    // 获取对话组的第一句
    private string getFirstDialog(DialogGroup item){;
        return item.dialogs[0].content;
    }
    //选项1
    public void Opt1(){
        choose=1;
        updataDialogGroup();
        Continue();
    }
    //选项2
    public void Opt2(){
        choose=2;
        updataDialogGroup();
        Continue();
    }
    //选项3
    public void Opt3(){
        choose=3;
        updataDialogGroup();
        Continue();
    }
}
