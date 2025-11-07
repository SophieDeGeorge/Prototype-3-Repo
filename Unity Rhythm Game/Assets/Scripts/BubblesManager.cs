using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesManager : MonoBehaviour
{
    [SerializeField] private GameObject bubble1;
    [SerializeField] private GameObject bubble2;
    [SerializeField] private GameObject bubble3;
    [SerializeField] private GameObject bubble4;
    [SerializeField] private GameObject bubble5;
    [SerializeField] private GameObject bubble6;

    // Start is called before the first frame update
    void Start()
    {

    }
    
    IEnumerator BubbleEnabler(int val)
    {
        if (val == 1)
        {
            bubble1.SetActive(true);
        }
        if (val == 2)
        {
            bubble2.SetActive(true);
        }
        if (val == 3)
        {
            bubble3.SetActive(true);
        }
        if (val == 4)
        {
            bubble4.SetActive(true);
        }
        if (val == 5)
        {
            bubble5.SetActive(true);
        }
        if (val == 6)
        {
            bubble6.SetActive(true);
        } else
        {
            Debug.Log("Something has gone terribly wrong");
        }

        yield return new WaitForSeconds(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
