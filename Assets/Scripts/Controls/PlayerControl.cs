using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private CharacterController character;  // 人物移动容器
    private Animator animator; // 人物动画容器
    void Start()
    {
        character=GetComponent<CharacterController>();
        animator=transform.GetChild(0).GetChild(0).GetComponent<Animator>();
    }
    void Update()
    {
        move();
        rotate();
        animPlay();
    }
    public float walkSpeed; // 移动速度
    public float runSpeed; 
    public float JumpHeight;

    public Vector3 moveInXZ=Vector3.zero;
    public Vector3 moveInY=Vector3.zero;

    // 控制人物移动
    private void move(){
        moveInXZ=transform.forward*InputControl.input.Vertical+transform.right*InputControl.input.Horizontal; // 获得移动的方向和位移 就是一个向量

        moveInXZ=moveInXZ.normalized; // 防止斜着走时过快

        moveInY.y+=JumpHeight*InputControl.input.Jump; // 跳跃的高度

        // 移动
        if(CharacterParam.param.isPlot!=true){
            if(Input.GetKey(KeyCode.LeftShift)){
                moveInXZ*=runSpeed;
            }
            else{
                moveInXZ*=walkSpeed;
            }
            character.Move(moveInXZ*Time.deltaTime);
        }
        else{
            moveInXZ=Vector3.zero;
        }
        character.Move(moveInY*Time.deltaTime);
    }
    private float angleY=0; 
    public float maxAngle; // 最大仰角
    public float minAngle; // 最小俯角

    // 摄像机旋转
    private void rotate(){
        angleY-=InputControl.input.MouseY; // 累计绕x轴旋转的角度
        angleY=Mathf.Clamp(angleY,-maxAngle,-minAngle); // 限制绕x轴旋转的角度
        
        Camera.main.transform.localRotation=Quaternion.Euler(angleY,0,0); //摄像机绕x轴旋转

        transform.Rotate(Vector3.up,InputControl.input.MouseX); // 人物绕Z轴旋转
    }
    // 控制人物动画播放
    private void animPlay(){
        animator.SetFloat("stopOrMove",moveInXZ.magnitude);
        transform.GetChild(0).GetChild(0).transform.localPosition=Vector3.zero;
        transform.GetChild(0).GetChild(0).transform.localRotation=Quaternion.Euler(Vector3.zero);
    }
}
