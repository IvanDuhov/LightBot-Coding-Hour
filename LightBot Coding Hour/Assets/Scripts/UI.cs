﻿using UnityEngine;
using System.Collections;
using System.Diagnostics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour 
{
	public Button main;

	public Sprite BG;
	public Sprite ENG;

	public bool English;

	Character ch;
	private string lang;

	private AudioSource ass;

	public Image Audio;
	public Sprite onn;
	public Sprite off;


	void Start()
	{
		string fix = PlayerPrefs.GetString ("English");
		if ((fix != null) && (main != null)) {
			main.image.sprite = ENG;
			PlayerPrefs.SetString ("English", "true");
		}

		ass = FindObjectOfType<AudioSource> ();
		ch = FindObjectOfType<Character> ();
		lang = PlayerPrefs.GetString ("English");

		if (main != null) {
			if (lang == "true") {
				main.image.sprite = ENG;
			} else
				main.image.sprite = BG;
		}
	}

	void Update()
	{
		if (Audio != null) {
			if (ass == null)
				return;
			if (ass.isPlaying == true)
				Audio.sprite = onn;
			else
				Audio.sprite = off;
		}
	}

	public void DevHelpPass()
	{
		PlayerPrefs.SetString ("B1", "true");
		PlayerPrefs.SetString ("B2", "true");
		PlayerPrefs.SetString ("B3", "true");
		PlayerPrefs.SetString ("B4", "true");
		PlayerPrefs.SetString ("B5", "true");
		PlayerPrefs.SetString ("B6", "true");
		PlayerPrefs.SetString ("B7", "true");
		PlayerPrefs.SetString ("B8", "true");

		PlayerPrefs.SetString ("P1", "true");
		PlayerPrefs.SetString ("P2", "true");
		PlayerPrefs.SetString ("P3", "true");
		PlayerPrefs.SetString ("P4", "true");
		PlayerPrefs.SetString ("P5", "true");
		PlayerPrefs.SetString ("P6", "true");

	}

	public void DevHelpRestart()
	{
		PlayerPrefs.DeleteAll ();
	}

	public void AudioControl()
	{
		if (ass.isPlaying == true) {
			ass.Pause ();
			Audio.sprite = off;
		} else {
			ass.Play ();
			Audio.sprite = onn;
		}
	}

	public void OpenPDF()
	{
		ProcessStartInfo process;
		process = new ProcessStartInfo(Application.dataPath+"/Resources/Ins.pdf");
		Process.Start (process);
	}

	public void ChooseLanguage()
	{
		if (main.image.sprite == BG) 
		{
			main.image.sprite = ENG;
			PlayerPrefs.SetString ("English","true");
		} 
		else 
		{
			main.image.sprite = BG;
			PlayerPrefs.SetString ("English","false");
		} 
	}

	public void SwitchToProc1()
	{
		ch.procedure1Selected = true;
		ch.procedure2Selected = false;

		ch.mainPanel.color = ch.offColour;
		ch.Proc1Panel.color = ch.activeColour;

		if (ch.Proc2Panel != null) {
			ch.Proc2Panel.color = ch.offColour;
		}
	}

	public void SwitchToproc2()
	{
		ch.procedure2Selected = true;
		ch.procedure1Selected = false;

		ch.mainPanel.color = ch.offColour;
		ch.Proc1Panel.color = ch.offColour;

		if (ch.Proc2Panel != null) {
			ch.Proc2Panel.color = ch.activeColour;
		}
	}

	public void SwitchToMain()
	{
		ch.procedure1Selected = false;
		ch.procedure2Selected = false;

		ch.Proc1Panel.color = ch.offColour;
		ch.mainPanel.color = ch.activeColour;

		if (ch.Proc2Panel != null) {
			ch.Proc2Panel.color = ch.offColour;
		}
	}

	#region Scene Managemnt
	public void BackToSelectionMenu()
	{
		SceneManager.LoadScene ("SelectionMenu");
	}

	public void BackToProcedures()
	{
		SceneManager.LoadScene ("Procedures");
	}

	public void BackToBasic()
	{
		SceneManager.LoadScene ("Basic");
	}

	public void Level1()
	{
		SceneManager.LoadScene ("Level 1");
	}

	public void from1to2()
	{
		SceneManager.LoadScene ("Level 2");
	}

	public void from2to3()
	{
		SceneManager.LoadScene ("Level 3");
	}

	public void from3to4()
	{
		SceneManager.LoadScene ("Level 4");
	}

	public void from4to5()
	{
		SceneManager.LoadScene ("Level 5");
	}

	public void from5to6()
	{
		SceneManager.LoadScene ("Level 6");
	}

	public void from6to7()
	{
		SceneManager.LoadScene ("Level 7");
	}

	public void from7to8()
	{
		SceneManager.LoadScene ("Level 8");
	}

	public void ProcedureButton1()
	{
		SceneManager.LoadScene ("Level P1");
	}

	public void ProcedureButton2()
	{
		SceneManager.LoadScene ("Level P2");
	}

	public void ProcedureButton3()
	{
		SceneManager.LoadScene ("Level P3");
	}

	public void ProcedureButton4()
	{
		SceneManager.LoadScene ("Level P4");
	}

	public void ProcedureButton5()
	{
		SceneManager.LoadScene ("Level P5");
	}

	public void ProcedureButton6()
	{
		SceneManager.LoadScene ("Level P6");
	}

	public void MainStart()
	{
		SceneManager.LoadScene ("Menu");
	}

	public void Exit()
	{
		Application.Quit ();
	}
	#endregion
}