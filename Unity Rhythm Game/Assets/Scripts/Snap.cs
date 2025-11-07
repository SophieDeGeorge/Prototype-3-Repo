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
    BubbleScript bs;
    ScoreBoard sm;
    public BubbleScript bs1;

    void Start()
    {
        //BubbleScript bs = GameObject.FindGameObjectWithTag("Bubble").GetComponent<BubbleScript>();
        
        ScoreBoard sm = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreBoard>();
        BubblesManager bm = GameObject.FindGameObjectWithTag("BubbleManager").GetComponent<BubblesManager>();
        //BubbleScript bs = bm.FindObject("Bubble 1");
        bs1 = GameObject.Find("/Bubbles/Bubble 1/bubbleInner").GetComponent<BubbleScript>();
        bm.GameStart();
    }

    public void OnLeft()
    {
        snap();
    }

    public void OnRight()
    {
        snap();
    }

    private void snap()
    {
        //play animation
        StartCoroutine(DoAnimation(timeBetweenFrames));

        
        //handle score
        HandleScore(bs1.NoteType());
    }


    void HandleScore(string quality)
    {
        ///*
        if (quality == "miss")
        {
            sm.UpdateScore(0);
        } else if (quality == "bad")
        {
            sm.UpdateScore(50);
        } else if (quality == "good")
        {
            sm.UpdateScore(100);
        } else if (quality == "perfect")
        {
            sm.UpdateScore(200);
        }
        //*/
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
