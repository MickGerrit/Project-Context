using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Positioner : MonoBehaviour {

    public GameObject snap0;
    public GameObject snap1;

    public GameObject object0;
    public GameObject object1;

    public Text text0;

    public int number0;
    public int number1;

    public string code0 = "";

    private int codeLength = 0;
    public int maxCodeLength;


    private KeyCode[] keyCodes = {
         KeyCode.Alpha0,
         KeyCode.Alpha1,
         KeyCode.Alpha2,
         KeyCode.Alpha3,
         KeyCode.Alpha4,
         KeyCode.Alpha5,
         KeyCode.Alpha6,
         KeyCode.Alpha7,
         KeyCode.Alpha8,
         KeyCode.Alpha9,
         KeyCode.Backspace,
     };

    // Update is called once per frame
    void Update()
    {
        //string veranderen
        text0.text = code0;
        if (code0.Length >= 1)
        {
            Debug.Log(code0[0]);
            number0 = code0[0] - 48;

            if (code0.Length >= 2)
            {

                number1 = code0[1] -48;
                Debug.Log(number1);
            }
        }
        //posities
        switch (number0)
        {
            case 0:
                object0.transform.position = snap0.transform.position;
                break;
            case 1:
                object1.transform.position = snap0.transform.position;
                break;

        }

        switch (number1)
        {
            case 0:
                object0.transform.position = snap1.transform.position;
                break;
            case 1:
                object1.transform.position = snap1.transform.position;
                break;
        }

        //setactive of niet, kunnen we ook nog veranderen naar instantiate als nodig is
        if (codeLength < maxCodeLength)
        {
            TurnOff();
        }
        else if(codeLength == maxCodeLength)
        {
            SetActive();
        }

        //checken van welk nummer is ingedrukt
        for (int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                int numberPressed = i;
                //Debug.Log(numberPressed);
                code0 += i;
                Debug.Log(code0);
                codeLength += 1;

                if (i == 10)
                {
                    codeLength = 0;
                    code0 = "";
                    Debug.Log("deleted");
                }
            }
        }
    }

    void SetActive()
    {
        object0.SetActive(true);
        object1.SetActive(true);
    }
    void TurnOff()
    {
        object0.SetActive(false);
        object1.SetActive(false);
    }
}
