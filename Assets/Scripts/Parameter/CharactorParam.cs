using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterParam : MonoBehaviour
{
    // 单例模式
    public static CharacterParam param;
    private void Awake() {
        param=this;
    }
    public bool moveEnabled=true; // 允许移动
    public bool jumpEnabled=true;   // 允许跳跃
    public bool mouseEnabled=true; // 允许鼠标输入
    public bool isPlot=false;
}
