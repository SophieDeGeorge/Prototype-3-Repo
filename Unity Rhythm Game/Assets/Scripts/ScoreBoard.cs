using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateScore(int score)
    {
        //somethin
        Debug.Log("YEAHHH");
    }

    public void HandleScore(string quality)
    {
        if (quality == "miss")
        {
            UpdateScore(0);
        }
        else if (quality == "bad")
        {
            UpdateScore(50);
        }
        else if (quality == "good")
        {
            UpdateScore(100);
        }
        else if (quality == "perfect")
        {
            UpdateScore(200);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
