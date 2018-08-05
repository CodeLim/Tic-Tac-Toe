using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyCell : MonoBehaviour
{
    public Text mLabel;
    public Button mButton;
    public Main mMain;

    public void Fill()
    {
        mButton.interactable = false;

        // Set childed text
        mLabel.text = mMain.GetTurnCharacter();

        // Switch turns
        mMain.Switch();
    }
}
