using System.Collections;
using System.Collections.Generic;
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

	private int audiencia_oficialismo = 100;
	private int audiencia_oposicion = 100;
	private int oficialismo_no_audiencia = 400;
	private int oposicion_no_audiencia = 400;

	public void Start()
	{
		NewsManager.Instance.OnNewsChosen += OnNewsChosen;
	}

	public void OnNewsChosen(News news) 
	{
		float deltaOf = news.NewsValues.ofWeight * (((4 / 3) * news.NewsValues.timeAssigned) - (1 / 3));
		float deltaOp = news.NewsValues.opWeight * (((4 / 3) * news.NewsValues.timeAssigned) - (1 / 3));
		float deltaConv = news.NewsValues.conversionWeight * news.NewsValues.timeAssigned;

		int deltaOfToPeople = deltaOf * (oficialismo_no_audiencia + audiencia_oficialismo);
		int deltaOpToPeople = deltaOp * (oposicion_no_audiencia + audiencia_oposicion);
		int deltaConvToPeople = deltaConv * (audiencia_oposicion + audiencia_oficialismo);

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
			Decrease_audiencia_oposicion (-deltaOfToPeople);
		}
		else if (deltaOpToPeople > 0) 
		{
			Increase_audiencia_oposicion (deltaOfToPeople);
		}

		if (deltaConvToPeople < 0) {
			
			Convert_to_oposicion (-deltaConvToPeople);
		} 
		else if (deltaConvToPeople > 0) 
		{
			Convert_to_oficialismo (deltaConvToPeople);
		}
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

