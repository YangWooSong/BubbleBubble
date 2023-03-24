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
    private bool isJump = false;
    public bool getWeapon = false;
    private int shootCount;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        animator.SetBool("isMove", false);
        shootCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Move(inputDirection);
    }
    public void IsJump()
    {
        if(isJump == true)
        {
            rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            isJump = false;
        }
        
    }
    public void GetWeapon()
    {
        getWeapon = !getWeapon;
        animator.SetBool("getWeapon", getWeapon);
    }
    public void IsShoot()
    {
      
        if (getWeapon == true)
        {
           
            if(animator.GetBool("isShoot") == false)
            {
                animator.SetBool("isShoot", true);
                Invoke("ShootSetting", 1f);
                shootCount += 1;
                Invoke("LoadTrueSetting", 0.5f);
            }
            

        }
    }

    private void ShootSetting()
    {
        animator.SetBool("isShoot", false);

    }

    private void LoadTrueSetting()
    {
        if (shootCount > 4)
        {

                Debug.Log("¿Â¿¸");
                animator.SetBool("isLoad", true);
                Invoke("LoadFalseSetting", 1f);
                shootCount = 0;

        }
    }
    private void LoadFalseSetting()
    {
        animator.SetBool("isLoad", false);
    }
    public void Move(Vector2 inputDirection)
    {
        isMove = inputDirection.magnitude != 0;

        Vector3 move = new Vector3(inputDirection.y, 0f, -inputDirection.x).normalized;
        if (isMove)
        {

            transform.position += move * Time.deltaTime * speed;     
        }

        transform.position += move * Time.deltaTime * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") isJump = true;
    }
}

