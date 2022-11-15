/************************************************************
************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

// using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

using System.Text.RegularExpressions;

/************************************************************
************************************************************/
public class inputField_Manager : MonoBehaviour
{
	[SerializeField] TMP_InputField inputField;
	int counter = 0;
	float t_onEndEdit = 0;
	
	/******************************
	******************************/
    void Start()
    {
		inputField.onFocusSelectAll = true;
    }
	
	/******************************
	******************************/
    void Update()
    {
		/********************
		********************/
		if(Input.GetKey(KeyCode.LeftAlt)){
			if(Input.GetKeyDown(KeyCode.Alpha0)){
				// Invoke("inputField_select", 3.0f);
				inputField_select();
			}else if(Input.GetKeyDown(KeyCode.Alpha1)){
				// Invoke("inputField_activate", 3.0f);
				inputField_activate();
			}else if(Input.GetKeyDown(KeyCode.Alpha2)){
				// Invoke("inputField_UnFocus", 3.0f);
				inputField_UnFocus();
			}else if(Input.GetKeyDown(KeyCode.Alpha3)){
				inputField_UnFocus2();
			}else if(Input.GetKeyDown(KeyCode.P)){
				Debug.Log(inputField.isFocused);
			}
		}
		
		if(Input.GetKeyDown(KeyCode.Return)){
			if(Time.time - t_onEndEdit < 0.1f){
				onEndEdit_byEnter();
			}else{
				string str_message = String.Format("Enter pressed : {0}", counter);
				Debug.Log(str_message);
			}
		}else if(Input.GetKeyDown(KeyCode.P)){
			string str_message = String.Format("isFocused = {0}, isActiveAndEnabled = {1}", inputField.isFocused, inputField.isActiveAndEnabled);
			Debug.Log(str_message);
		}
		
		counter++;
    }
	
	/******************************
	******************************/
	public void inputField_select(){
		string str_message = String.Format("inputField_select : {0}", counter);
		Debug.Log(str_message);
		inputField.Select();
	}
	
	/******************************
	******************************/
	public void inputField_activate(){
		string str_message = String.Format("inputField_activate : {0}", counter);
		Debug.Log(str_message);
		inputField.ActivateInputField();
	}
	
	/******************************
	******************************/
	public void inputField_UnFocus(){
		string str_message = String.Format("inputField_UnFocus by using interactable : {0}", counter);
		Debug.Log(str_message);
		
		inputField.interactable = false;
		inputField.interactable = true;
	}
	
	/******************************
	******************************/
	public void inputField_UnFocus2(){
		string str_message = String.Format("inputField_UnFocus by using SetSelectedGameObject(null) : {0}", counter);
		Debug.Log(str_message);
		
		EventSystem.current.SetSelectedGameObject(null);
	}
	
	/******************************
	******************************/
	public void onEndEdit_byEnter(){
		string str_message = String.Format("onEndEdit_byEnter : {0}", counter);
		Debug.Log(str_message);
		
		// inputField_activate();
	}
	
	/******************************
	******************************/
	public void onEndEdit(string str_val){
		/********************
		********************/
		t_onEndEdit = Time.time;
		
		/********************
		********************/
		string str_message = String.Format("OnEndEdit : {0}", counter);
        Debug.Log(str_message);
		
		/********************
			[SerializeField] TMP_InputField inputField;
			
			string input = inputField.text;
			Debug.Log(input);
		としても良いが、こちらでもOK
		********************/
        Debug.Log(str_val);
		
		// input 直後にinput fieldの掃除する場合
		// inputField.text = "";
		
		// inputField_select();	// 何も起きない.
		// inputField_activate();
		
		// Focus 外す場合
		/*
		inputField.interactable = false;
		inputField.interactable = true;
		*/
	}
	
	/******************************
	******************************/
	public void onSelect(string str_val){
		string str_message = String.Format("OnSelect : {0}", counter);
        Debug.Log(str_message);
	}
	
	/******************************
	******************************/
	public void onDeSelect(string str_val){
		string str_message = String.Format("OnDeSelect : {0}", counter);
        Debug.Log(str_message);
	}
	
	/******************************
	******************************/
	public void onValueChanged(string str_val){
		string str_message = String.Format("onValueChanged : {0} : {1}", counter, str_val);
		// Debug.Log(str_message);
	}
}
