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

    void Start()
    {
        BubbleScript bs = GameObject.FindGameObjectWithTag("Bubble").GetComponent<BubbleScript>();
        ScoreBoard sm = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreBoard>();
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
        HandleScore(bs.NoteType());
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
