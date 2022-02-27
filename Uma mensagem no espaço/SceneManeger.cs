using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManeger : MonoBehaviour
{
    public Text dialogueText;
    public Text hintText;
    public InputField readWord;
    public GameObject painel;
    public Scene scene;

    private Queue<string> dialogues;
    private int count = 0;
    private static int countScenes = 0;
    private string[] sceneOrder = {"Scene2", "Scene3", "Scene4", "Scene5", "Scene6", "FinalScene" };

    // Start is called before the first frame update
    void Start()
    {
        dialogues = new Queue<string>();
        StartDialogue(scene);
    }

    public void StartDialogue(Scene scenes)
    {

        dialogues.Clear();

        foreach (string scene in scenes.messeges)
        {
            dialogues.Enqueue(scene);
        }
     
        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if (dialogues.Count == 0)
        {
            if (answerField() == true)
            {
                NextScene();
            } else {
                SetPanelTrue();
                StartCoroutine(Close());
            }
        } else{
            string dialogue = dialogues.Dequeue();
            dialogueText.text = dialogue;
        }

        IEnumerator Close()
        {
            yield return new WaitForSeconds(1f);
            painel.SetActive(false);
        }
    }

    void SetPanelTrue ()
    {
        painel.SetActive(true);
    }

    void SetPanelFalse()
    {
        painel.SetActive(true);
    }

    bool answerField()
    {
        if (readWord.text == scene.answer)
        {
            return true;
        }
        else 
        { 
            return false;
        }
    }

    void EndDialogue()
    {
        Debug.Log("End Dialog");
    }

    public void GetInputField()
    {
        Debug.Log(readWord.text);
    }

    public void NextHint()
    {
        if (count > scene.hints.Length-1)
        {
            count = 0;
            hintText.text = scene.hints[0];
        }
        else
        {
            hintText.text = scene.hints[count];
            count += 1;
        }
    }

    public void NextScene ()
    {
        if (countScenes < sceneOrder.Length)
        {
            SceneManager.LoadScene(sceneOrder[countScenes]);
            countScenes += 1;
        }       
    }
}
