using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsersName : MonoBehaviour
{
    public TMPro.TextMeshProUGUI HomeNameInput;
    public TMPro.TextMeshProUGUI AwayNameInput;
    public TMPro.TextMeshProUGUI HomeOutput;
    public TMPro.TextMeshProUGUI AwayOutput;



    // Update is called once per frame
    void Update()
    {
        HomeOutput.SetText(HomeNameInput.text);
        AwayOutput.SetText(AwayNameInput.text);
    }
}
