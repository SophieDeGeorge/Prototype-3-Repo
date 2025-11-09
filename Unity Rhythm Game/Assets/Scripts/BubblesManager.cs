using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BubblesManager : MonoBehaviour
{
    [SerializeField] private GameObject[] bubbles;
    [SerializeField] private float timeBetweenBubbles;
    private Queue<GameObject> bubbleQueueLeft = new Queue<GameObject>();
    private Queue<GameObject> bubbleQueueRight = new Queue<GameObject>();
    private Transform btf;

    [SerializeField] private float badRange;
    [SerializeField] private float goodRange;
    [SerializeField] private float perfectRange;
    [SerializeField] private float missRange;
    private GameObject curBubble;
    private Vector3 startingScale = new Vector3(0.1f, 0.1f, 0.3f);



    // Start is called before the first frame update
    void Start()
    {
        badRange = 0.2f;
        goodRange = 0.4f;
        perfectRange = 0.45f;
        missRange = 0.6f;
        GameStart();
    }

    public void GameStart()
    {

        foreach(GameObject bubble in bubbles) {
            bubble.SetActive(false);
        }
            StartCoroutine(BubbleEnabler(Random.Range(0, 6))); // 6 is excluded
        
    }

    public string PopBubble(string side)
    {
        if (side == "left")
        {
            if (bubbleQueueLeft.Count != 0)
            {
                curBubble = bubbleQueueLeft.Dequeue();
                btf = curBubble.GetComponent<Transform>();
                btf = btf.transform.Find("bubbleInner").GetComponent<Transform>();

                string result = NoteType(btf);
                ResetBubble(curBubble, btf);
                return result;
            }
            
        }
        else if (side == "right")
        {
            if (bubbleQueueRight.Count != 0)
            {
                curBubble = bubbleQueueRight.Dequeue();
                btf = curBubble.GetComponent<Transform>();
                btf = btf.transform.Find("bubbleInner").GetComponent<Transform>();

                string result = NoteType(btf);
                ResetBubble(curBubble, btf);
                return result;
            }
        }
        return "miss";
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
        }
        else if (bubbleTransform.localScale.x > perfectRange)
        {
            return "perfect";
        }
        else if (bubbleTransform.localScale.x > goodRange)
        {
            return "good";
        }
        else if (bubbleTransform.localScale.x > badRange)
        {
            return "bad";
        }
        else
        {
            return "miss";
        }
    }

    IEnumerator BubbleEnabler(int val)
    {

        if (val >= bubbles.Length || val < 0)
        {
            Debug.LogWarning("Error: BubbleEnabler only takes int values 1-6, was passed " + val);
        } else
        {
            if (bubbles[val].activeSelf)
            {
                StartCoroutine(BubbleEnabler(Random.Range(0, 6)));
            }
            else
            {
                bubbles[val].SetActive(true);
                if (val < 3)
                {
                    bubbleQueueLeft.Enqueue(bubbles[val]);
                    Debug.Log(bubbleQueueLeft);
                }
                else
                {
                    bubbleQueueRight.Enqueue(bubbles[val]);
                    Debug.Log(bubbleQueueRight);
                }
                yield return new WaitForSeconds(timeBetweenBubbles);
                StartCoroutine(BubbleEnabler(Random.Range(0, 6)));
            }
        }
    }
}