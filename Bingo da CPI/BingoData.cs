using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BingoData
{
    public List<string> _bingoData;

    public BingoData(List<string> bingo)
    {
        _bingoData = bingo;
    }
}
