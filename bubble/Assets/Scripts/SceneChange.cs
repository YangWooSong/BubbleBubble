using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
   public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    //public void To_01_Map()
    //{
    //    SceneManager.LoadScene("01_Map");
    //}
    //public void To_02_Map()
    //{
    //    SceneManager.LoadScene("02_Map");
    //}
    //public void To_03_Map()
    //{
    //    SceneManager.LoadScene("03_Map");
    //}
}
