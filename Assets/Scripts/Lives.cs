using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    [SerializeField] int lives = 5;
    Text livesText;

    void Start()
    {
        livesText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }

    public void TakeLife()
    {
        if (lives >= 1)
        {
            lives--;
            UpdateDisplay();
            if (lives <= 0)
            {
                FindObjectOfType<LevelController>().HandleLoseCondition();
            }
        }
    }
}
