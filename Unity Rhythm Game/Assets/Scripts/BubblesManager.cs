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
    private Queue<GameObject> bubbleQueueLeft = new Queue<GameObject>();
    private Queue<GameObject> bubbleQueueRight = new Queue<GameObject>();
    private Transform btf;
    
    [SerializeField] private float badRange;
    [SerializeField] private float goodRange;
    [SerializeField] private float perfectRange;
    [SerializeField] private float missRange;
    private GameObject curBubble;
    private Vector3 startingScale = new Vector3(0.2f, 0.2f, 0.3f);


    // Start is called before the first frame update
    void Start()
    {
        badRange = 0.2f;
        goodRange = 0.4f;
        perfectRange = 0.45f;
        missRange = 0.6f;
    }

    public void GameStart()
    {
        bubble1.SetActive(false);
        bubble2.SetActive(false);
        bubble3.SetActive(false);
        bubble4.SetActive(false);
        bubble5.SetActive(false);
        bubble6.SetActive(false);
        Debug.Log("Middle of GameStart()");
        StartCoroutine(BubbleEnabler(Random.Range(1, 7))); // 7 is excluded
        Debug.Log("End of GameStart()");
    }

    public string PopBubble(string side) //return quality and kill bubble
    {
        if (side == "left")
        {
            curBubble = bubbleQueueLeft.Dequeue();
            btf = curBubble.GetComponent<Transform>();
            btf = btf.transform.Find("bubbleInner").GetComponent<Transform>();
            ResetBubble(curBubble, btf);
        }
        else if (side == "right")
        {
            curBubble = bubbleQueueRight.Dequeue();
            btf = curBubble.GetComponent<Transform>();
            btf = btf.transform.Find("bubbleInner").GetComponent<Transform>(); //gets bubbleInner transform
            ResetBubble(curBubble, btf);
        }
        return NoteType(btf);
    }
    
    public void ResetBubble(GameObject bubble, Transform innerTransform)
    {
        bubble.SetActive(false);
        innerTransform.localScale = startingScale;

    }
    
    public string NoteType(Transform bubbleTransform)
    {
            if (bubbleTransform.localScale.x > missRange)
            {
                return "miss";
            } else if (bubbleTransform.localScale.x > perfectRange)
            {
                return "perfect";
            } else if (bubbleTransform.localScale.x > goodRange)
            {
                return "good";
            } else if (bubbleTransform.localScale.x > badRange)
            {
                return "bad";
            } else
            {
                return "miss";
            }
    }
    
    IEnumerator BubbleEnabler(int val)
    { //put all of this in a loop with the waitforseconds at the bottom of it
        Debug.Log("bubbleEnabler value = " + val);
        for (int i = 0; i < 100; i++)
        {
            Debug.Log("Got to loop " + i);

            if (val == 1)
            {
                if (bubble1.activeSelf == true)
                {
                    BubbleEnabler(Random.Range(1, 7));
                }
                else
                {
                    bubble1.SetActive(true);
                    bubbleQueueLeft.Enqueue(bubble1);
                }
            } else if (val == 2)
            {
                if (bubble2.activeSelf == true)
                {
                    BubbleEnabler(Random.Range(1, 7));
                } else
                {
                    bubble2.SetActive(true);
                    bubbleQueueLeft.Enqueue(bubble2);
                }
            } else if (val == 3)
            {
                if (bubble3.activeSelf == true)
                {
                    BubbleEnabler(Random.Range(1, 7));
                } else
                {
                    bubble3.SetActive(true);
                    bubbleQueueLeft.Enqueue(bubble3);
                }
            } else if (val == 4)
            {
                if (bubble4.activeSelf == true)
                {
                    BubbleEnabler(Random.Range(1, 7));
                } else
                {
                    bubble4.SetActive(true);
                    bubbleQueueRight.Enqueue(bubble4);
                }
            } else if (val == 5)
            {
                if (bubble5.activeSelf == true)
                {
                    BubbleEnabler(Random.Range(1, 7));
                } else
                {
                    bubble5.SetActive(true);
                    bubbleQueueRight.Enqueue(bubble5);
                }
            } else if (val == 6)
            {
                if (bubble6.activeSelf == true)
                {
                    BubbleEnabler(Random.Range(1, 7));
                } else
                {
                    bubble6.SetActive(true);
                    bubbleQueueRight.Enqueue(bubble6);
                }
            }

            {
                Debug.Log("Error: BubbleEnabler only takes int values 1-6, was passed " + val);
            }
            Debug.Log("End of BubbleEnabler()");
            yield return new WaitForSeconds(timeBetweenBubbles);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
