using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float zombieHp = 10f;
    public Transform targetTransform;
    public float followSpeed = 2f;
    public Transform spawnpoint;
    private Animator animator;
    private bool isAttacking = false;
    void Start()
    {
        InvokeRepeating("zombiespawn", 30f, 30f);
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (targetTransform != null)
        {
            // Move towards the target transform at a constant speed
            transform.position = Vector3.MoveTowards(transform.position,
                targetTransform.position, followSpeed * Time.deltaTime);
            // Rotate towards the target transform
            transform.LookAt(targetTransform);
            animator.SetBool("Walk", true);
            if (isAttacking)
            {
                animator.SetBool("Attack", true);
            }
        }
        if (zombieHp <= 0)
        {
            animator.SetBool("Death", true);
            Destroy(gameObject, 3f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            isAttacking = true;
            other.GetComponent<Player>().HP -= 2;
        }
    }
    public void zombiespawn()
    {
        // 좀비 생성
        GameObject zombie = Instantiate(gameObject, spawnpoint.position, Quaternion.identity);
        // 좀비를 플레이어를 따라오도록 설정
        Zombie zombieScript = zombie.GetComponent<Zombie>();
        zombieScript.targetTransform = targetTransform;
    }
}
