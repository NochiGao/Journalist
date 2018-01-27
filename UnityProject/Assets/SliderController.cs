using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour {

	public Slider slider1;
	public Slider slider2;
	public Slider slider3;
	public Text text1;
	public Text text2;
	public Text text3;

	public void OnValueUpdate()
	{
		float sum = slider1.normalizedValue + slider2.normalizedValue + slider3.normalizedValue;

		text1.text = (60 * slider1.normalizedValue / sum).ToString("0 mins");
		text2.text = (60 * slider2.normalizedValue / sum).ToString("0 mins");
		text3.text = (60 * slider3.normalizedValue / sum).ToString("0 mins");

		NewsManager.Instance.SetTime(0, slider1.normalizedValue / sum);
		NewsManager.Instance.SetTime(1, slider1.normalizedValue / sum);
		NewsManager.Instance.SetTime(2, slider1.normalizedValue / sum);
	}

}
