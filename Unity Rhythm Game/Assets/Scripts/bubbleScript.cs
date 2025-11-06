using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BubbleScript : MonoBehaviour
{
    [SerializeField] private CircleCollider2D bubble_cldr;
    [SerializeField] private GameObject badZone;            // set all zones in inspector
    private CircleCollider2D bad_cldr;                      // set colliders in start()
    [SerializeField] private GameObject goodZone;
    private CircleCollider2D good_cldr;
    [SerializeField] private GameObject perfectZone;
    private CircleCollider2D perfect_cldr;
    [SerializeField] private GameObject outline;
    private CircleCollider2D outline_cldr;

    public Transform tf;
    private Vector3 incSpeed = new Vector3(0.1f, 0.1f, 0f);
    private string noteZone;


    void Start()
    {
        //bubble_cldr = GetComponent<CircleCollider2D>(); 
        bad_cldr = badZone.GetComponent<CircleCollider2D>();
        good_cldr = goodZone.GetComponent<CircleCollider2D>();
        perfect_cldr = perfectZone.GetComponent<CircleCollider2D>();
        outline_cldr = outline.GetComponent<CircleCollider2D>();
        noteZone = "miss";
    }

/*
    private void OnTriggerEnter(CircleCollider2D bubble_cldr) 
    {
        if ()
        {                                                      // if collided with bad_cldr
            noteZone = "bad";
        }
        if ()
        {                                                       //good_cldr
            noteZone = "good";
        }
        if ()
        {                                                       //perfect_cldr
            noteZone = "perfect";
        }
        if ()
        {                                                       //outline cldr
            noteZone = "miss";
        }
    }
    */

    // Update is called once per frame
    void Update()
    {
        if (tf.localScale.x < 0.5)
        {
            tf.localScale += incSpeed * Time.deltaTime;
            //bubble_cldr.radius = bubble_cldr.radius * (incSpeedRadius * Time.deltaTime);
        } else
        {
            Destroy(gameObject);
        }
    }
}
