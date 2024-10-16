using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InParam : MonoBehaviour
{
    // 单例模式
    public static InParam inParam;
    private void Awake() {
        inParam=this;
    }
    public bool moveEnabled=true; // 允许移动
    public bool jumpEnabled=true;   // 允许跳跃
    public bool mouseEnabled=true; // 允许鼠标输入
    public bool isPlot=false;
}
