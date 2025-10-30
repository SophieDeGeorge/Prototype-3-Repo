using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SliderFunctions : MonoBehaviour
{
    public static float slideDecay = 0.1f;

    public Slider Slider;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject slider = Find
        //Slider.value = 0.99f;
    }
    
    public static void changeDecay(float x)
    {
        slideDecay = x;
    }

    // Update is called once per frame
    void Update()
    {
        Slider.value -= slideDecay * Time.deltaTime;

        //if (Slider.value == 0){gameOver();}
    }
}
