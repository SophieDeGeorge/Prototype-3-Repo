using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BubbleScript : MonoBehaviour
{
    [SerializeField] private CircleCollider2D bubble_cldr;
    public Transform tf;
    [SerializeField] private GameObject parentBubble;
    [SerializeField] private float incSpeed;
    private Vector3 incSpeedVector = new Vector3(0.1f, 0.1f, 0f);
    [SerializeField] private float missRange;
    [SerializeField] private float badRange;
    [SerializeField] private float goodRange;
    [SerializeField] private float perfectRange;
    private BubblesManager bm;
    private AudioManager am;

    void Start()
    {
        bm = GameObject.FindGameObjectWithTag("BubbleManager").GetComponent<BubblesManager>();
        incSpeed = 2.0f;
        am = GameObject.FindGameObjectWithTag("BubbleManager").GetComponent<AudioManager>();
    }
    public string NoteType()
    {
            if (tf.localScale.x > missRange)
            {
                return "miss";
            } else if (tf.localScale.x > perfectRange)
            {
                return "perfect";
            } else if (tf.localScale.x > goodRange)
            {
                return "good";
            } else if (tf.localScale.x > badRange)
            {
                return "bad";
            } else
            {
                return "miss";
            }
    }

    // Update is called once per frame
    void Update()
    {
        if (tf.localScale.x < 0.5)
        {
            tf.localScale +=  incSpeed * incSpeedVector * Time.deltaTime;
        } else
        {
            am.PopSFX();
            parentBubble.SetActive(false);
            bm.ResetBubble(parentBubble, tf);
        }
    }
}
