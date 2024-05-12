using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //this lets us access all the Canvas features

public class UIManager : MonoBehaviour
{
    public Text speedLabel;
    public Text scoreLabel;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get the speed from the rigidbody and save it
        speed = GetComponent<Rigidbody>().velocity.magnitude;
        //round the speed to remove the decimal places
        speed = Mathf.Round(speed);
        //what we want is: "Speed: [new line] 70"
        speedLabel.text = "Speed:\n" + speed.ToString();

        scoreLabel.text = "Score:\n" + GetComponent<MarbleController>().score.ToString();
    }
}
