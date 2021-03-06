﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFade : MonoBehaviour
{
	public float fadeDuration = 1f;
	public Image image;
	public AnimationCurve curve;

	void Start()
	{
		StartCoroutine(FadeIn());
	}

	public void FadeTo(string scene)
	{
		if (MusicController.Instance.isFading == true)
		{
			MusicController.Instance.interrupt = true;
		}
		else
		{
			MusicController.Instance.StopMusic();
		}
		StartCoroutine(FadeOut(scene));
	}

	IEnumerator FadeIn()
	{
		float time = fadeDuration;

		while (time > 0f)
		{
			time -= Time.deltaTime;
			float alhpa = curve.Evaluate(time);
			image.color = new Color(0f, 0f, 0f, alhpa);
			yield return 0;
		}
	}

	IEnumerator FadeOut(string scene)
	{
		float time = 0f;

		while (time < fadeDuration)
		{
			time += Time.deltaTime;
			float alhpa = curve.Evaluate(time);
			image.color = new Color(0f, 0f, 0f, alhpa);
			yield return 0;
		}
			
		SceneManager.LoadScene(scene);
	}
}
