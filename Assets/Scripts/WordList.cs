using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordList {

    public List<string> list = new List<string>();

    WordList()
    {
        list.Add("fox");
        list.Add("bear");
        list.Add("cow");
    }

    public static WordList instance = null;

    public static WordList GetInstance()
    {
        if (instance == null)
        {
            instance = new WordList();
        }

        return instance;
    }


}
