using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float zombieHp = 10f;
    public Transform targetTransform;
    public float followSpeed = 2f;
    public Transform spawnpoint;
    public Animator animator;
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
        }
        if (zombieHp <= 0)
        {
            animator.SetBool("Death", true);
            Destroy(gameObject, 3f);
        }
    }
    public void zombiespawn()
    {
        // ���� ����
        GameObject zombie = Instantiate(gameObject, spawnpoint.position, Quaternion.identity);
        // ���� �÷��̾ ��������� ����
        Zombie zombieScript = zombie.GetComponent<Zombie>();
        zombieScript.targetTransform = targetTransform;
    }
}
