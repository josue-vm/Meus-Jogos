using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSys
{
    public static void SaveBingo (List<string> bingo)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Bingo.bg";
        FileStream stream = new FileStream(path, FileMode.Create);

        BingoData data = new BingoData(bingo);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static BingoData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/Bingo.bg";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            BingoData data = formatter.Deserialize(stream) as BingoData;
            stream.Close();
            return data;
        }
        else
        {
            string[] bg =  { "Cloroquina", "Inverdades", "Renan Caprichando", "Omar de Saco Cheio", "Falou Merda", "Falou Merda Novamente", "DJ Raul", "Suando Frio", "Renan Puto", "E o PT ???", "Carteirada", "Imprimiu a Internet", "Marcos Interrompendo", "Mácara Caindo", "Recreio", "Randolfe Lacrando", "ÓDIO!!!", "Microfone Merda", "CLAP!!!", "Conexão Merda", "Pedindo Calma", "Flávio Cagando", "Randolfe Puto", "Áudio do Zap!", "Discurso Inspirador", "Picareta", "Contarato te Prendeu", "Ameaças", "Simoninha Brava", "Motosserra", "Narrativa", "Rinha de velho", "olhar nos olhos", "EITA", "Narrativas", "Veneno", "imprimiu no modo escuro", "bate e volta Randolfe e Omar", "bonita camisa", "puxa-saco", "ketchup", "CRI ME", "POESIA", "\"as pessoas nas ruas\"", "SANHA", "abordado nas ruas", "pedir escusas", "me erre", "conluio", "habeas corpus", "VISHHHH", "slides", "fluxograma", "power point", "organograma", "deboche", "sorri com soraya", "tá cocô"};
            List<string> bingo = new List<string>(bg);
            BingoData data = new BingoData(bingo);
            SaveBingo(bingo);
            return data;
        }
    }

    public static BingoData LoadSave(string p)
    {
        string path = p;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            BingoData data = formatter.Deserialize(stream) as BingoData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Erro arquivo não encontrado!");
            return null;
        }
    }

    public static void ExportBingo(List<string> d, string path)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        BingoData data = new BingoData(d);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveToText()
    {
        string path = Application.dataPath + "/Importar/" + "Bingo.bg";
        string pathTxt = Application.dataPath + "/Importar/" + "strings.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            BingoData data = formatter.Deserialize(stream) as BingoData;
            stream.Close();

            List<string> str = data._bingoData;
            var text = File.CreateText(pathTxt);
            foreach (string t in str)
            {
                text.Write("\"" + t + "\"" + ", ");
            }
            text.Close();
        }
    }
}
