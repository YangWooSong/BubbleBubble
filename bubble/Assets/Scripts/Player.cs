using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public Vector2 inputDirection;
    [SerializeField]
    private Rigidbody rigid;
    public int JumpPower;
    private bool isMove;
    public float speed;
    //Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(inputDirection);
    }
    public void IsJump()
    {
        rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
    }
    public void Move(Vector2 inputDirection)
    {
        isMove = inputDirection.magnitude != 0;
        //animator.SetBool("isMove", isMove);
        Vector3 move = new Vector3(inputDirection.y, 0f, -inputDirection.x).normalized;
        if (isMove)
        {

            transform.position += move * Time.deltaTime * speed;
        }

        transform.position += move * Time.deltaTime * speed;
    }
}

