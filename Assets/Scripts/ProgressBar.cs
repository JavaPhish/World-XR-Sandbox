using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    /* Yes i couldve used getComponent, but it works in the editor
    outside of playmode if i just use public variables */
    public Slider progress;
    public Text progressText;

    public void UpdateText()
    {
        progressText.text = (progress.value * 100f).ToString() + "%";
    }

}
