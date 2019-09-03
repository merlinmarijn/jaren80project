using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    public bool CorrectChoice;
    public QuizManager QM;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(string name) {
    }

    public void Button_Pressed()
    {
        if (CorrectChoice == true)
        {
            QM.ActivateSetQuestion();
        } else { QM.Wrong();}
    }
}
