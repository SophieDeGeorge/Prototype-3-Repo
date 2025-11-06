using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapLeft : MonoBehaviour
{
    private static Animation anim;
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
    }

   public static void OnLeft()
    {
        //play animation
        Debug.Log("before anim left");
        anim.Play("snapAnimation");
        Debug.Log("past anim left");
    
        //handle bubble
    }
}
