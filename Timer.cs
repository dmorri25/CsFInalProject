using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int timeLeft;
    public Text timer, survived;
    private int timeSurvived = 0;
    private PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("TimeLoss");
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = ("" + timeLeft);
        survived.text = ("You Have Survived For: " + timeSurvived + " Seconds!");

        if (timeLeft <= 0)
        {
            StopCoroutine("TimeLoss");
            GameObject.FindGameObjectWithTag("Player").SetActive(false);
        }
    }

    IEnumerator TimeLoss()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
            timeSurvived++;
        }
    }
    void stopGame()
    {
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        GameObject.FindGameObjectWithTag("Mob").SetActive(false);
    }
}
