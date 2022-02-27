using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    public Scene scene;

    public void TriggerScene()
    {
        FindObjectOfType<SceneManeger>().StartDialogue(scene);
    }
}
