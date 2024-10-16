using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    public static InputControl input;
    private void Awake() {
        input=this;
    }
    // 解锁鼠标 静态方法 可以直接调用
    public static void UnLockMouse(){
        Cursor.lockState=CursorLockMode.None;
    }
    // 锁定鼠标 静态方法 可以直接调用
    public static void LockMouse(){
        Cursor.lockState=CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        MoveInput();
        JumpInput();
        MouseInput();
    }

    public float Horizontal; // 虚拟轴Horizontal
    public float Vertical; // 虚拟轴Vertical

    // 移动输入
    private void MoveInput(){
        if(InParam.inParam.moveEnabled==true){
            Horizontal=Input.GetAxis("Horizontal");
            Vertical=Input.GetAxis("Vertical");
        }
        else{
            Horizontal=0;
            Vertical=0;
        }
    }

    public float MouseX; // 鼠标水平位移
    public float MouseY; // 鼠标竖直位移
    //鼠标输入
    private void MouseInput(){
        if(InParam.inParam.mouseEnabled==true){
            MouseX=Input.GetAxis("Mouse X");
            MouseY=Input.GetAxis("Mouse Y");
        }
        else{
            MouseX=0;
            MouseY=0;
        }
    }
    public float Jump=1;
    public KeyCode JumpKey=KeyCode.Space;
    //跳跃输入
    private void JumpInput(){
        if(InParam.inParam.jumpEnabled==true && Input.GetKey(JumpKey)){
            Jump=1;
        }
        else{
            Jump=0;
        }
    }
    public KeyCode EnterPlotKey=KeyCode.F;
}
