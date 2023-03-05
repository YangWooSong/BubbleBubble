using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCharacterController : MonoBehaviour
{
    [SerializeField]
    private Transform characterBody;

    [SerializeField]
    private Transform cameraArm;

    Animator animator;
    public GameObject Btn;
    //public Rigidbody rb;
    public Vector2 inputDirection;
    private bool isMove = false;
    void Start()
    {
        animator = characterBody.GetComponent<Animator>();

    }

    private void Update()
    {
        // LookAround();
        Shoot();
        //Move(inputDirection); 
        Jump();
    }
    private void LookAround()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 camAngle = cameraArm.rotation.eulerAngles;

        cameraArm.rotation = Quaternion.Euler(camAngle.x - mouseDelta.y, camAngle.y + mouseDelta.x, camAngle.z);

        float x = camAngle.x - mouseDelta.y;
        if (x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        else
        {
            x = Mathf.Clamp(x, 335f, 361f);
        }

        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);
    }
    public void Move(Vector2 inputDirection)
    {
        Vector2 moveInput = inputDirection;
        if (moveInput.magnitude != 0)
        {
            isMove = true;
            Debug.Log(isMove);
        }
        else
        {
            isMove = false;
            Debug.Log(isMove);
        }

        animator.SetBool("isMove", isMove);
        if (isMove)
        {
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;
            Debug.Log(moveDir);
            characterBody.forward = moveDir;
            transform.position += moveDir * Time.deltaTime * 5f;
            
        }
    }

    public void Shoot()
    {
        animator.SetBool("isShoot", Btn.GetComponent<BtnControl>().isShoot);
    }
    public void Jump()
    {
        if(Btn.GetComponent<BtnControl>().isJump == true)
        {
           //Debug.Log(Btn.GetComponent<BtnControl>().isJump);

            //rb.AddForce(Vector3.up * 100, ForceMode.Impulse); 
            //이친구가 점프못함 이거는 캐릭터 고치고 해결을 같이 해봅시다 양송이
            //윽
        }
        
    }
}
