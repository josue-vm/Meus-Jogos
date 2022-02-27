using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSceneTrigger : MonoBehaviour
{
    public FinalScene finalScene;

    public void TriggerScene()
    {
        FindObjectOfType<FinalSceneManeger>().StartDialogue(finalScene);
    }
}
