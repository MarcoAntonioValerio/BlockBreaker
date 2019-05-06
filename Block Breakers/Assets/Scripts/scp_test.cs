using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scp_test : MonoBehaviour
{
    private int ballsNumber = 9;
    private int playersNumber = 10;

    [SerializeField] TextMeshProUGUI OutputBox;

    private bool preIncrement = false;
    private bool postIncrement = false;

    private string postIncrementMessage;
    private string preIncrementMessage;
    private string resetMessage = "values have been reset!";


    private void Update()
    {
        TextChanger();
    }

    //PostIncrement
    public void Test_01()
    {
        if (ballsNumber++ == playersNumber)
        {
            Debug.Log("Not understood");
        }
        else
        {
            postIncrementMessage = "It increments after, making it NOT EQUAL to the playersNumber.";
            postIncrement = true;

        }        
    }

    //PreIncrement
    public void Test_02()
    {
        if (++ballsNumber == playersNumber)
        {
            preIncrementMessage = "It increments before, making it EQUAL to the playersNumber.";
            preIncrement = true;
        }
        
        //Resetting the value to the original one
        ballsNumber = 9;
    }


    //Method to output text result
    private void TextChanger()
    {
        if (postIncrement == true)
        {
            OutputBox.text = postIncrementMessage;
        }
        else if (preIncrement == true)
        {
            OutputBox.text = preIncrementMessage;
        }
    }

    //Resetting the value to the original one
    public void ValuesResetter()
    {
        OutputBox.text = resetMessage;
        ballsNumber = 9;
        preIncrement = false;
        postIncrement = false;
    }
}
