using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Snap : MonoBehaviour
{

    [SerializeField] private SpriteRenderer m_SpriteRenderer;
    [SerializeField] private float timeBetweenFrames;
    [SerializeField] private Sprite beforeSprite;
    [SerializeField] private Sprite afterSprite;
    BubbleScript bs;
    ScoreBoard scoreboard;
    //public BubbleScript bs1;
    private BubblesManager bm;
    public PlayerInput playerInput;
    //private bool left = playerInput.actions["Left"];


    void Start()
    {
        scoreboard = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreBoard>();
        bm = GameObject.FindGameObjectWithTag("BubbleManager").GetComponent<BubblesManager>();
        Debug.Log("Calling gamestart");
        bm.GameStart();
    }

    public void OnLeft()
    {
        var left = playerInput.actions["Left"];
        if (!left.WasPerformedThisFrame() && left.IsPressed())
        {
        Debug.Log("OnLeft");
        DoSnap("left");
        }

    }

    public void OnRight()
    {
        var right = playerInput.actions["Right"];
        if (!right.WasPerformedThisFrame() && right.IsPressed())
        {
        Debug.Log("OnRight");
        DoSnap("right");
        }
    }

    private void DoSnap(string side)
    {
        //play animation
        StartCoroutine(DoAnimation(timeBetweenFrames));
        //Debug.Log("Snapped " + side);

        //handle score
        scoreboard.HandleScore(bm.PopBubble(side));
    }                                             
    
    
    IEnumerator DoAnimation(float waitTime)
    {
        m_SpriteRenderer.sprite = afterSprite;
        yield return new WaitForSeconds(waitTime);
        m_SpriteRenderer.sprite = beforeSprite;
    }
}
