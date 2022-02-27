using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Scene
{
    [TextArea(3, 10)]
    public string[] messeges;
    public string answer;
    [TextArea(3, 10)]
    public string[] hints;

}
