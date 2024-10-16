using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum plotType{
    Daily,
    Force
}

// 序列化
[Serializable]
public class DialogItem  // 单次对话存储结构 对应json文件内层结构
{
    public string name; // 对话人物名字
    public string content;  // 对话内容
}
// 序列化
[Serializable]
public class DialogGroup  // 单次剧情存储结构 对应json文件外层结构
{
    public string position;
    public DialogItem[] dialogs;
}
