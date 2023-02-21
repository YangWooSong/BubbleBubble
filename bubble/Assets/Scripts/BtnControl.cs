using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnControl : MonoBehaviour
{
    public bool isShoot = false;
    public bool isJump = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
       
    }

    public void IsShoot()
    {
        isShoot = true;
        Debug.Log(isShoot);
        Invoke("Delay", 1f);
       
    }

    public void IsJump()
    {
        isJump = true;
        Invoke("Delay", 1f);
    }
    void Delay()
    {
        if (isJump)
        {
            isJump = false;
        }

        if (isShoot)
        {
            isShoot = false;
        }
        Debug.Log("µÙ∑π¿Ã");
    }
}
