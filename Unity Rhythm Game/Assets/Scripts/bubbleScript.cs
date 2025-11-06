using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bubbleScript : MonoBehaviour
{

    public Transform tf;
    private Vector3 incSpeed = new Vector3(0.1f, 0.1f, 0f);

    void Start()
    {
        
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
