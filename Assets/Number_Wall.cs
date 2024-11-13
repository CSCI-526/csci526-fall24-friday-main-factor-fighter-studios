using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Number_Wall : MonoBehaviour 
{
    public static Number_Wall instance;
    public static bool isNumberWallActive = false;
    public int areaSize;
    public int givenSide;
    public int answer;
    public GameObject mathProblemPanel;
    public GameObject operatorsPanel;
    public GameObject input;
    public TMP_InputField inputField;
    public static bool isGamePaused = false;
    //private string mathProblem;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //mathProblem = "What is ?";
        mathProblemPanel.SetActive(false);
        answer = areaSize / givenSide;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNumberWallActive = true;
            PauseGame();
            Debug.Log("Player has reached the number wall!");

            mathProblemPanel.SetActive(true);
            operatorsPanel.SetActive(true);
        }
    }

    public bool CheckAnswer()
    {
        inputField.text = inputField.text.Trim();
        if (inputField.text == answer.ToString())
        {
            Debug.Log("Number Wall Correct answer!");
            mathProblemPanel.SetActive(false);
            //operatorsPanel.SetActive(false);
            ResumeGame();
            return true;
        }
        else
        {
            Debug.Log("Number Wall Incorrect answer!");
            return false;
        }
    }

    public static void PauseGame()
    {
        Time.timeScale = 0f;
        isGamePaused = true;
        Debug.Log("Game paused");
    }

    public static void ResumeGame()
    {
        Time.timeScale = 1f;
        isGamePaused = false;
        isNumberWallActive = false;
        Debug.Log("Game resumed");
    }
}