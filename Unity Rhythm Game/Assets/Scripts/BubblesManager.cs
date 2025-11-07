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
    [SerializeField] private float timeBetweenBubbles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GameStart()
    {
        bubble1.SetActive(false);
        bubble2.SetActive(false);
        bubble3.SetActive(false);
        bubble4.SetActive(false);
        bubble5.SetActive(false);
        bubble6.SetActive(false);
        BubbleEnabler(Random.Range(1, 7)); // 7 is excluded
    }
    
    IEnumerator BubbleEnabler(int val)
    {
        if (val == 1)
        {
            bubble1.SetActive(true);
        }
        else if (val == 2)
        {
            bubble2.SetActive(true);
        }
        else if (val == 3)
        {
            bubble3.SetActive(true);
        }
        else if (val == 4)
        {
            bubble4.SetActive(true);
        }
        else if (val == 5)
        {
            bubble5.SetActive(true);
        }
        else if (val == 6)
        {
            bubble6.SetActive(true);
        } else
        {
            Debug.Log("Error: BubbleEnabler only takes int values 1-6, was passed " + val);
        }

        yield return new WaitForSeconds(timeBetweenBubbles);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
