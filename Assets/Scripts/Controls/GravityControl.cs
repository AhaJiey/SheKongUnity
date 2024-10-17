using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityControl : MonoBehaviour
{
    public PlayerControl playerControl; // 人物移动组件

    void Start() {
        playerControl=GetComponent<PlayerControl>(); // 获取人物移动组件
    }
    void Update()
    {
        Gravity();
    }

    public float gravity=9.82f;
    public Transform checkObj; // 检查碰撞的物体
    public float checkRadius;   // 碰撞半径
    public LayerMask checkLayer;    // 碰撞的层级
    public bool isGround=true;  // 是否站在地面

    // 重力效果
    private void Gravity(){
        isGround=Physics.CheckSphere(checkObj.position,checkRadius,checkLayer); // 检测碰撞
        CharacterParam.param.jumpEnabled=isGround;
        if(playerControl.moveInY.y<0 && isGround==true){    // 在地面时下落距离重置
            playerControl.moveInY.y=-0.5f;
        }
        playerControl.moveInY.y-=gravity*Time.deltaTime;    // 重力公式 每秒下落位移 dx=g*T^2; 另一个 T 在 playerControl 相乘
    }
}
