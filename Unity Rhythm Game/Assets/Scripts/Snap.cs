using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Snap : MonoBehaviour
{

    [SerializeField] private SpriteRenderer m_SpriteRenderer;
    [SerializeField] private float timeBetweenFrames;

    [SerializeField] private Sprite beforeSprite;
    [SerializeField] private Sprite afterSprite;


    public void OnLeft()
    {
        Debug.Log("Left func");
        //play animation
        StartCoroutine(DoAnimation(timeBetweenFrames));
        //handle bubble

    }

    public void OnRight()
    {
        Debug.Log("Left func");
        //play animation
        StartCoroutine(DoAnimation(timeBetweenFrames));
        //handle bubble

    }
    
    IEnumerator DoAnimation(float waitTime)
    {
        Debug.Log("inside corountine");
        m_SpriteRenderer.sprite = afterSprite;
        yield return new WaitForSeconds(waitTime);
        m_SpriteRenderer.sprite = beforeSprite;
        Debug.Log("after corountine");
    }
}
