using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LetterClickController : MonoBehaviour, IPointerClickHandler{

    public char thisLetter;
    ShowRandomLetters showLetterController = ShowRandomLetters.GetInstance();

	void Start () {
		
	}
	

	void Update () {
		
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        showLetterController.IsSelectCorrect(thisLetter);
    }


}
