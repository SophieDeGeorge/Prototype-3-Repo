using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BubbleScript : MonoBehaviour
{
    [SerializeField] private CircleCollider2D bubble_cldr;
    public Transform tf;
    private Vector3 incSpeed = new Vector3(0.1f, 0.1f, 0f);
    [SerializeField] private float missRange;
    [SerializeField] private float badRange;
    [SerializeField] private float goodRange;
    [SerializeField] private float perfectRange;


    void Start()
    {
        //bubble_cldr = GetComponent<CircleCollider2D>(); 
        /*
        bad_cldr = badZone.GetComponent<CircleCollider2D>();
        good_cldr = goodZone.GetComponent<CircleCollider2D>();
        perfect_cldr = perfectZone.GetComponent<CircleCollider2D>();
        outline_cldr = outline.GetComponent<CircleCollider2D>();
        */
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
            tf.localScale += incSpeed * Time.deltaTime;
        } else
        {
            Destroy(gameObject);
        }
    }
}
