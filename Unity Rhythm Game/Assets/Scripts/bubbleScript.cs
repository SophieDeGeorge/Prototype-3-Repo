using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BubbleScript : MonoBehaviour
{
    [SerializeField] private CircleCollider2D bubble_cldr;
    [SerializeField] private GameObject badZone;            // set all zones in inspector
    private SphereCollider bad_cldr;                            // set colliders in start()
    [SerializeField] private GameObject goodZone;
    private SphereCollider good_cldr;
    [SerializeField] private GameObject perfectZone;
    private SphereCollider perfect_cldr;

    public Transform tf;
    private Vector3 incSpeed = new Vector3(0.1f, 0.1f, 0f);
    [SerializeField] private float incSpeedRadius;
    private float maxRadius = 4.3f;

    void Start()
    {
        //my_collider = GetComponent<SphereCollider>();
        bad_cldr = badZone.GetComponent<SphereCollider>();
        good_cldr = goodZone.GetComponent<SphereCollider>();
        perfect_cldr = perfectZone.GetComponent<SphereCollider>();
    }

    //bubble_cldr.OnCollisionEnter()

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
