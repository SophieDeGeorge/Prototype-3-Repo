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
    ScoreBoard scoreboard;
    public BubbleScript bs1;
    public BubblesManager bm;

    void Start()
    {
        //BubbleScript bs = GameObject.FindGameObjectWithTag("Bubble").GetComponent<BubbleScript>();
        
        ScoreBoard scoreboard = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreBoard>();
        bm = GameObject.FindGameObjectWithTag("BubbleManager").GetComponent<BubblesManager>();
        //BubbleScript bs = bm.FindObject("Bubble 1");
        //bs1 = GameObject.Find("/Bubbles/Bubble 1/bubbleInner").GetComponent<BubbleScript>();
        Debug.Log("Calling gamestart");
        bm.GameStart();
    }

    public void OnLeft()
    {
        snap("left");
    }

    public void OnRight()
    {
        snap("right");
    }

    private void snap(string side)
    {
        //play animation
        StartCoroutine(DoAnimation(timeBetweenFrames));
        Debug.Log("Snapped " + side);

        //handle score
        scoreboard.HandleScore(bm.PopBubble(side)); //swap out bs1.NoteType with a new function inside of the bubbles manager
    }                                                 // let the bubble manager do the work since it has the queue
    
    
    IEnumerator DoAnimation(float waitTime)
    {
        Debug.Log("inside corountine");
        m_SpriteRenderer.sprite = afterSprite;
        yield return new WaitForSeconds(waitTime);
        m_SpriteRenderer.sprite = beforeSprite;
        Debug.Log("after corountine");
    }
}
