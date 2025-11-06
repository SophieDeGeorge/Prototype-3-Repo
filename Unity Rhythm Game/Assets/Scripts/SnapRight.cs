using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapRight : MonoBehaviour
{
    private static Animation anim;
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
    }

    public static void OnRight()
    {
        //play animation
        Debug.Log("before anim right");
        anim.Play("snapAnimation");
        Debug.Log("after anim right");

        //handle bubble
    }
}
