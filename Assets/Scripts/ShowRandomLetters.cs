using System;
using System.Collections.Generic;
using UnityEngine;


public class ShowRandomLetters : MonoBehaviour {

    public GameObject[] colorBlocks;
    public GameObject[] letters;

    public  int letterCountOnceShow;  //每次游戏生成的字母数量

    GameObject canvas;
    float canvasWidth;
    float canvasHeight;

    WordList wordList;

    Dictionary<int, Vector3> letterPostionDic = new Dictionary<int, Vector3>();

    float horizontalDistance;
    float verticalDistance;

    string currentWord;
    char currentLetter;

    static ShowRandomLetters instance;
    public static ShowRandomLetters GetInstance()
    {
        if (instance == null)
        {
            instance = Activator.CreateInstance<ShowRandomLetters>();
        }
        return instance;
    }


	void Start () {

        canvas = GameObject.Find("Canvas");
        canvasWidth = canvas.GetComponent<RectTransform>().rect.width;
        canvasHeight = canvas.GetComponent<RectTransform>().rect.height;

        wordList = WordList.GetInstance();

        horizontalDistance = 200f;
        verticalDistance = 200f;

        int num = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                letterPostionDic.Add(num, new Vector3(180 + i * horizontalDistance, -400 + j * verticalDistance, 0));
                num++;
            }

        }

        ShowLetters(wordList.list[1]);
    }
	

	void Update () {
		


	}


    /// <summary>
    /// 实例化随机字母，其中包含给定单词的字母
    /// </summary>
    /// <param name="word"></param>
    void ShowLetters(string word)
    {

        for (int i = 0; i < letterCountOnceShow; i++)
        {
            float x = UnityEngine.Random.Range(-40f, 40f);

            float y = UnityEngine.Random.Range(-30f, 30f);

            Vector3 positionOffst = new Vector3(x, y, 0);

            int letterNum;

            if (i < word.Length)
            {
                letterNum = LetterNum(word.Substring(i, 1).ToCharArray()[0]);
                
            }
            else
            {
                letterNum = UnityEngine.Random.Range(0, 25);

            }

            GameObject letter = Instantiate(letters[letterNum], letterPostionDic[i] + positionOffst, transform.rotation);
            letter.transform.SetParent(canvas.transform, false);
            letter.GetComponent<LetterClickController>().thisLetter = (char)letterNum;

        }
        
    }


    /// <summary>
    /// 计算是26个字母中的第几个
    /// </summary>
    /// <param name="letter"></param>
    /// <returns></returns>
    int LetterNum(char letter)
    {
        return ((int)letter - 97);

    }


    public void IsSelectCorrect(char selectedLetter)
    {
        if (currentLetter == selectedLetter)
        {
            

        }
    }



}
