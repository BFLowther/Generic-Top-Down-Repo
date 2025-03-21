using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.Collections.Generic;

public class UIScript : MonoBehaviour
{
	public AudioMixer am;
	public TMP_Dropdown resolutionDropdown;

	private Resolution[] resolutions; 

	private void Start()
	{
		resolutions = Screen.resolutions;

		resolutionDropdown.ClearOptions();

		int currentResolutionIndex = 0;
		List<string> options = new List<string>();

		for (int i= 0;i < resolutions.Length; i++)
		{
			string option = resolutions[i].width + " x " + resolutions[i].height;
			options.Add(option);

			if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
			{
				currentResolutionIndex = i;
			}			
		}

		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = currentResolutionIndex;
		resolutionDropdown.RefreshShownValue();
	}
	public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

	public void QuitGame()
	{
		Application.Quit();
	}

	public void MasterVolume(float volume)
	{
		am.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
	}

	public void SetQuality(int qualityIndex)
	{
		QualitySettings.SetQualityLevel(qualityIndex, true);
	}

	public void SetFullScreen(bool isFullScreen)
	{
		Screen.fullScreen = isFullScreen;
	}
}
