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

    public GameObject createStep;
    public GameObject captureStep;

    private bool nextstep = false;

    public void UpdateText()
    {
        progressText.text = ((int)(progress.value * 100f)).ToString() + "%";
    }

    void Update()
    {
        /* there is probably a better way to do this but im
           trying to finish within 2 days */
        if (progress.value >= 1 && !nextstep)
        {
            createStep.SetActive(true);
            captureStep.SetActive(false);
            nextstep = true;
        }
    }

}
