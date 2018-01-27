using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StatsManager : MonoBehaviour {

	private static StatsManager instance = null; //Unica instancia que va a existir de esta clase

	//Singleton pattern
	public static StatsManager Instance
	{
		get
		{
			if (instance==null)
			{
				instance = new StatsManager();
			}
			return instance;
		}
	}

	public Text statisticsDisplay;

	private int audiencia_oficialismo = 100;
	private int audiencia_oposicion = 100;
	private int oficialismo_no_audiencia = 400;
	private int oposicion_no_audiencia = 400;

	public void Start()
	{
		NewsManager.Instance.OnNewsChosen += OnNewsChosen;
		displayStatistics ();
	}

	public void OnNewsChosen(News news) 
	{
		float deltaOf = news.NewsValues.ofWeight.ActualWeight * (((4 / 3f) * news.NewsValues.timeAssigned) - (1 / 3f));
		float deltaOp = news.NewsValues.opWeight.ActualWeight * (((4 / 3f) * news.NewsValues.timeAssigned) - (1 / 3f));
		float deltaConv = news.NewsValues.conversionWeight.ActualWeight * news.NewsValues.timeAssigned;

		int deltaOfToPeople = Mathf.RoundToInt(deltaOf * (oficialismo_no_audiencia + audiencia_oficialismo));
		int deltaOpToPeople = Mathf.RoundToInt(deltaOp * (oposicion_no_audiencia + audiencia_oposicion));
		int deltaConvToPeople = Mathf.RoundToInt(deltaConv * (audiencia_oposicion + audiencia_oficialismo));

		if (deltaOfToPeople < 0) 
		{
			Decrease_audiencia_oficialismo (-deltaOfToPeople);
		}
		else if (deltaOfToPeople > 0) 
		{
			Increase_audiencia_oficialismo (deltaOfToPeople);
		}

		if (deltaOpToPeople < 0) 
		{
			Decrease_audiencia_oposicion (-deltaOpToPeople);
		}
		else if (deltaOpToPeople > 0) 
		{
			Increase_audiencia_oposicion (deltaOpToPeople);
		}

		if (deltaConvToPeople < 0) {
			
			Convert_to_oposicion (-deltaConvToPeople);
		} 
		else if (deltaConvToPeople > 0) 
		{
			Convert_to_oficialismo (deltaConvToPeople);
		}

		displayStatistics ();
		statisticsDisplay.text += "Conversion de personas: " + deltaConvToPeople + 
			"\n\nDelta personas oficialismo: " + deltaOfToPeople +
			"\nDelta personas oposicion: " + deltaOpToPeople;
	}

	public void displayStatistics() 
	{
		int pobTotal = audiencia_oposicion + audiencia_oficialismo + oposicion_no_audiencia + oficialismo_no_audiencia;
		int audiencia = audiencia_oposicion + audiencia_oficialismo;

		statisticsDisplay.text = "Audiencias: \n\n" +
		"Rating: " + (audiencia * 100) / pobTotal + "%\n" +
		"Audiencia de la oposicion: " + (audiencia_oposicion * 100) / audiencia + "%\n" +
		"Audiencia del oficialismo " + (audiencia_oficialismo * 100) / audiencia + "%\n\n" +
		"Audiencia oposicion personas: " + audiencia_oposicion + "\n" +
		"Audiencia oficialismo personas: " + audiencia_oficialismo + "\n\n" +
		"Oposicion no audiencia: " + oposicion_no_audiencia + "\n" +
		"Oficialismo no audiencia: " + oficialismo_no_audiencia + "\n";
	}

	public void Increase_audiencia_oficialismo(int amount) 
	{
		if (oficialismo_no_audiencia - amount >= 0)
		{
			oficialismo_no_audiencia -= amount;
			audiencia_oficialismo += amount;
		}
	}

	public void Decrease_audiencia_oficialismo(int amount)
	{
		if (audiencia_oficialismo - amount >= 0) 
		{
			audiencia_oficialismo -= amount;
			oficialismo_no_audiencia += amount;
		}
	}

	public void Increase_audiencia_oposicion(int amount) 
	{
		if (oposicion_no_audiencia - amount >= 0)
		{
			oposicion_no_audiencia -= amount;
			audiencia_oposicion += amount;
		}
	}

	public void Decrease_audiencia_oposicion(int amount)
	{
		if (audiencia_oposicion - amount >= 0) 
		{
			audiencia_oposicion -= amount;
			oposicion_no_audiencia += amount;
		}
	}

	//Convierte de oposicion a oficialismo
	public void Convert_to_oficialismo(int amount) 
	{
		if (audiencia_oposicion - amount >= 0)
		{
			audiencia_oposicion -= amount;
			audiencia_oficialismo += amount;
		}
	}

	//Convierte de oficialismo a oposicion
	public void Convert_to_oposicion(int amount) 
	{
		if (audiencia_oficialismo - amount >= 0)
		{
			audiencia_oficialismo -= amount;
			audiencia_oposicion += amount;
		}
	}
}

