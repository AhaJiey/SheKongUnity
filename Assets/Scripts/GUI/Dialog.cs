using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public static Dialog dialog;
    private void Awake() {
        dialog=this;
        optsBut=new List<GameObject>(optionButGroup.transform.childCount);      // 初始化选项列表
        for(int i=0;i<optionButGroup.transform.childCount;i++){
            optsBut.Add(optionButGroup.transform.GetChild(i).GameObject());
        }
        hideNextBut();      // 默认隐藏
        hideOptsBut();
        hide();

    }
    public GameObject dialogObj;    // 对话框对象
    public TextMeshProUGUI Name;    // 人物名称
    public TextMeshProUGUI Content;     // 人物对话内容
    public GameObject nextBut;      // 继续对话按钮
    public GameObject optionButGroup;      // 选项按钮父类
    public List<GameObject> optsBut;      // 选项按钮
    // 显示对话框
    public void show(){
        dialogObj.SetActive(true);
    }
    // 隐藏对话框
    public void hide(){
        dialogObj.SetActive(false);
    }
    // 设置人物名称
    public void SetUIName(string text){
        Name.text=text;
    }
    // 设置对话内容
    public void SetUIContent(string text){
        Content.text=text;
    }
    // 显示继续按钮
    public void showNextBut(){
        nextBut.SetActive(true);
    }
    // 隐藏
    public void hideNextBut(){
        nextBut.SetActive(false);
    }
    // 设置继续按钮内容
    public void setNextButText(string text){
        nextBut.GetComponentInChildren<TextMeshProUGUI>().text=text;
    }
    // 显示选项按钮
    public void showOptsBut(int count){
        for(int i=0;i<count;i++){
            optsBut[i].SetActive(true);
        }
    }
    // 隐藏
    public void hideOptsBut(){
        for(int i=0;i<optsBut.Count;i++){
            optsBut[i].SetActive(false);
            setOptsButText(i,"");
        }
    }
    // 设置选项按钮内容
    public void setOptsButText(int index,string text){
        optsBut[index].GetComponentInChildren<TextMeshProUGUI>().text=text;
    }
}
