using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Snap : MonoBehaviour
{

    [SerializeField] private SpriteRenderer m_SpriteRenderer;
    [SerializeField] private float timeBetweenFrames;

    private static Sprite beforeSprite;
    private static Sprite afterSprite;

    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        beforeSprite = Resources.Load<Sprite>("Textures/snappingBefore");
        afterSprite = Resources.Load<Sprite>("Textures/snappingAfter");
    }

    public static void OnLeft()
    {
        //play animation
        //StartCoroutine(doAnimation(timeBetweenFrames));
        //handle bubble
    }

    public static void OnRight()
    {
        //play animation


        //handle bubble
    }
    
    IEnumerator doAnimation(float waitTime)
    {
        m_SpriteRenderer.sprite = afterSprite;
        yield return new WaitForSeconds(waitTime);
        m_SpriteRenderer.sprite = beforeSprite;
    }

    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
