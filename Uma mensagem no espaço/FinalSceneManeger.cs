using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalSceneManeger : MonoBehaviour
{
    public Text dialogueText;
    public GameObject painel;
    public GameObject menuInicial;
    public FinalScene finalScene;

    private Queue<string> dialogues;

    // Start is called before the first frame update
    void Start()
    {
        dialogues = new Queue<string>();
        StartDialogue(finalScene);
    }

    public void StartDialogue(FinalScene finalScenes)
    {

        dialogues.Clear();

        foreach (string scene in finalScenes.messeges)
        {
            dialogues.Enqueue(scene);
        }
     
        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if (dialogues.Count == 0)
        {
            SetPanelTrue();
        }
        else
        {
            string dialogue = dialogues.Dequeue();
            dialogueText.text = dialogue;
        }
    }

    void SetPanelTrue ()
    {
        dialogueText.text = "";
        painel.SetActive(true);
        menuInicial.SetActive(true);
    }

    public void openMenu ()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}