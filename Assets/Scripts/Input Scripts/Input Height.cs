using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class InputHeight : MonoBehaviour
{
    private string allowedCharacters = "0123456789.";
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private GameObject projectileShooter;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnValueChangedH()
    {
        // Validate the input value for the specific input field
        int numberCharacterCount = 0;
        string newValue = inputField.text;
        string validatedValue = "";

        bool decimalPointAdded = false;

        foreach (char c in newValue)
        {
            // Check if the character is in the allowedCharacters string
            Debug.Log(c);
            Debug.Log(allowedCharacters);
            if (allowedCharacters.Contains(c.ToString()))
            {
                Debug.Log("in");
                Debug.Log(numberCharacterCount);
                // makes sure that a max of 3sf for the input
                if (numberCharacterCount == 3)
                    continue;
                Debug.Log("in");
                // makes sure that if the first character is a decimal point to ignore it
                if (c == '.' && validatedValue.Length == 0)
                    continue;

                Debug.Log("in");

                // Ensure only one decimal point is added
                if (c == '.' && !decimalPointAdded)
                {
                    validatedValue += c;
                    decimalPointAdded = true;
                }
                else if (c != '.')
                {
                    validatedValue += c;
                    numberCharacterCount++;
                }
            }
        }
        // Update the input field text with only the allowed characters
        inputField.text = validatedValue;
    }
    public void OnEndEditH()
    {
        // If the last character is a decimal point, add a zero
        string text = inputField.text;
        if (text.EndsWith(".") || text.EndsWith("-"))
        {
            inputField.text += "1";
        }

        // If left empty, set text to "0"
        if (string.IsNullOrEmpty(text))
        {
            inputField.text = "1";
        }

        float initialHeight = float.Parse(inputField.text);
        projectileShooter.transform.position = new Vector3(0.0f, initialHeight, 0.0f);
        Debug.Log(GameControl.control.initialPosition.y + GameControl.control.veryInitialPosition.y + initialHeight);
        GameControl.control.initialPosition.y =  GameControl.control.veryInitialPosition.y + initialHeight;
    }

}
