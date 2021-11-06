using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class BehindScene : MonoBehaviour
{
    public Text score_text;
    public Text diamond_score_text;

    public static int score_count;
    public static int diamond_count;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Add Score
        AddScore();

        //Add Diamond
        AddDiamond();
    }

    private void AddScore()
    {
        score_text.text = "Kill Points : " + score_count;
    }

    private void AddDiamond()
    {
        diamond_score_text.text = "" + diamond_count;
    }
    
}
