﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public class DefineStrata : MonoBehaviour
{

    public RectTransform CanvasSlojevi;

    GameObject programManager;
    
double maxCurrentLayerDepth;

    ProgramState programState;
     int brojSlojeva ;

    public void DefineStrataInit()
    { 
        maxCurrentLayerDepth=0;
      programManager = GameObject.Find("ProgramManager");
        programState = programManager.GetComponent<ProgramState>();
   if  (programState.sirinaB != 0 && programState.duzinaL != 0 && programState.brojSlojeva <= 9)
        {

        CanvasSlojevi.gameObject.SetActive(true);
      
          }
     brojSlojeva  = programState.brojSlojeva;
      
        RectTransform textSloj = CanvasSlojevi.Find("TextSloj").GetComponent<RectTransform>();
        RectTransform textYoungModule = CanvasSlojevi.Find("TextYoungModul").GetComponent<RectTransform>();
        RectTransform inputSloj = CanvasSlojevi.Find("InputFieldSlojDo").GetComponent<RectTransform>();
        RectTransform inputYoungModule = CanvasSlojevi.Find("InputFieldYoungModul").GetComponent<RectTransform>();

int textSlojAnchorOffset = -270;
int textYoungModuleAnchorOffset = 17;
int inputSlojAnchorOffset = -70;
int inputFieldYoungModuleAnchorOffset = 213;

        // RectTransform labelX = Instantiate();
        

void InitStrataInput(RectTransform element, int offset, int increment, string text, string tag = "noTag"){
  RectTransform textSlojRect = Instantiate(element);
        textSlojRect.SetParent(CanvasSlojevi, false);
        textSlojRect.gameObject.SetActive(true);
        if ( textSlojRect.GetComponent<Text>()){
        textSlojRect.GetComponent<Text>().text=text;}
        textSlojRect.anchoredPosition = new Vector2 (0,0);
 textSlojRect.anchoredPosition= new Vector2(offset,(float)((-120-(increment)*35)));
 textSlojRect.gameObject.tag=tag;
// labelX.localScale=new Vector2 ((float)labelsScale,(float) labelsScale);


}

for (int i = 0; i<brojSlojeva; i++){

   if  (programState.sirinaB != 0 && programState.duzinaL != 0 && programState.brojSlojeva <= 9)
        {

     InitStrataInput(textSloj, textSlojAnchorOffset, i, "|"+(i+1)+ ". sloj(m)| Od:0 Do:", "textStrata"+(i+1));
InitStrataInput(textYoungModule, textYoungModuleAnchorOffset, i, "Youngov modul E:", "textStrata"+(i+1));
InitStrataInput( inputSloj, inputSlojAnchorOffset, i, "", "textStrataInput"+(i+1));
InitStrataInput( inputYoungModule, inputFieldYoungModuleAnchorOffset, i, "", "textStrataYoungInput"+(i+1));

      
          }




}

if (GameObject.FindGameObjectWithTag("textStrataInput"+(brojSlojeva))){
GameObject.FindGameObjectWithTag("textStrataInput"+(brojSlojeva)).GetComponent<InputField>().text= programState.dubinaZ.ToString();


}


    }


public void changeDepth(RectTransform CurrentInput){

     programManager = GameObject.Find("ProgramManager");
        programState = programManager.GetComponent<ProgramState>();


Debug.Log("______");
int clickedStrata =  Int32.Parse( CurrentInput.tag.Substring(CurrentInput.tag.Length-1));
InputField CurrentInputField = CurrentInput.GetComponent<InputField>();
bool canCnovertInput = double.TryParse(CurrentInputField.text, out double inputNumber);


if(inputNumber > programState.dubinaZ){

    inputNumber=programState.dubinaZ;
CurrentInput.GetComponent<InputField>().text =programState.dubinaZ.ToString();
}
maxCurrentLayerDepth = inputNumber;

if(clickedStrata != programState.brojSlojeva){
    
GameObject.FindGameObjectWithTag("textStrata"+(clickedStrata+1)).GetComponent<Text>().text="|"+(clickedStrata+1)+". sloj(m)| Od:"+inputNumber.ToString("0.00")+" Do:";
}
}

    public void ConfirmStrata()
    {
        bool everythingFine = true;
        programState.youngDefined = everythingFine;

     brojSlojeva  = programState.brojSlojeva;

programState.slojeviArray = new double[programState.brojSlojeva];

programState.youngModulArray = new double [programState.brojSlojeva];
for (int i = 0; i<brojSlojeva; i++){

bool canCnoverSlojevi = double.TryParse(GameObject.FindGameObjectWithTag("textStrataInput"+(i+1)).GetComponent<InputField>().text, out double slojevi);

programState.slojeviArray[i] =slojevi;



 bool canCnoverYoung = double.TryParse( GameObject.FindGameObjectWithTag("textStrataYoungInput"+(i+1)).GetComponent<InputField>().text, out double young);

if (everythingFine){

    everythingFine = canCnoverSlojevi;
    programState.youngDefined = everythingFine;
}

if (everythingFine){

    everythingFine = canCnoverYoung;
    programState.youngDefined = everythingFine;
}

 programState.youngModulArray[i]=young;
}


Debug.Log(programState.slojeviArray.Length);
Debug.Log(programState.youngModulArray.Length);


if (everythingFine){

CanvasSlojevi.gameObject.SetActive(false);
GameObject canvasParametri = GameObject.Find("CanvasParametri");
            canvasParametri.SetActive(false);

}





    }


}
