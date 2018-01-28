
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
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
	public Text dateDisplay;
	public float ratingToLose = 0.1f;
	public float audienciaOpToLose = 0.9f;
	public float audienciaOfToLose = 0.9f;
	public float paisOpToWin = 0.75f;
	public float paisOfToWin = 0.75f;
	public int maxDaysToLose = 30;

	private int audiencia_oficialismo = 100;
	private int audiencia_oposicion = 100;
	private int oficialismo_no_audiencia = 400;
	private int oposicion_no_audiencia = 400;

	public enum EndGameType {
		DERROTA_DESPIDO,
		DERROTA_ENVENENADO,
		DERROTA_BOMBA,
		DERROTA_EXPROPIACION,
		VICTORIA_DEMOCRACIA,
		VICTORIA_DICTADURA
	}

	public void Start()
	{
		OfficeRutineManager.Instance.OnNewDay += OnNewDay;
		DisplayStatistics ();
	}

	public void OnNewDay() 
	{
		List<News> newses = NewsManager.Instance.AvailableNews;
		int totalDeltaOf = 0;
		int totalDeltaOp = 0;
		int totalDeltaConv = 0;

		foreach (News news in newses) 
		{
			float deltaOf = 0f;
//			if( news.NewsValues.ofWeight.ActualWeight > 0 )
//				deltaOf = news.NewsValues.ofWeight.ActualWeight * (3f * news.NewsValues.timeAssigned - 1f);
//			else
				deltaOf = news.NewsValues.ofWeight.ActualWeight * 2f * news.NewsValues.timeAssigned;

			float deltaOp = 0f;
//			if( news.NewsValues.opWeight.ActualWeight > 0 )
//				deltaOp = news.NewsValues.opWeight.ActualWeight * (3f * news.NewsValues.timeAssigned - 1f);
//			else
				deltaOp = news.NewsValues.opWeight.ActualWeight * 2f * news.NewsValues.timeAssigned;

			float deltaConv = news.NewsValues.conversionWeight.ActualWeight * 2f * news.NewsValues.timeAssigned;

			int deltaOfToPeople = Mathf.RoundToInt (deltaOf * (oficialismo_no_audiencia + audiencia_oficialismo));
			int deltaOpToPeople = Mathf.RoundToInt (deltaOp * (oposicion_no_audiencia + audiencia_oposicion));
			int deltaConvToPeople = Mathf.RoundToInt (deltaConv * (audiencia_oposicion + audiencia_oficialismo));

			Debug.Log( "News '" + news.Title + "': deltaOf=" + deltaOfToPeople + " deltaOp=" + deltaOpToPeople + " deltaConv=" + deltaConvToPeople );

			totalDeltaOf += deltaOfToPeople;
			totalDeltaOp += deltaOpToPeople;
			totalDeltaConv += deltaConvToPeople;

			if (deltaConvToPeople < 0) {
				Convert_to_oposicion (-deltaConvToPeople);
			} else if (deltaConvToPeople > 0) {
				Convert_to_oficialismo (deltaConvToPeople);
			}

			if (deltaOfToPeople < 0) {
				Decrease_audiencia_oficialismo (-deltaOfToPeople);
			} else if (deltaOfToPeople > 0) {
				Increase_audiencia_oficialismo (deltaOfToPeople);
			}

			if (deltaOpToPeople < 0) {
				Decrease_audiencia_oposicion (-deltaOpToPeople);
			} else if (deltaOpToPeople > 0) {
				Increase_audiencia_oposicion (deltaOpToPeople);
			}

		}

		DisplayStatistics ();
//		statisticsDisplay.text += "Conversion de personas: " + totalDeltaConv +
//			"\n\nDelta personas oficialismo: " + totalDeltaOf +
//			"\nDelta personas oposicion: " + totalDeltaOp;

		CheckEndingConditions ();

		NewsManager.Instance.RefreshAvailableNews();
	}

	public void CheckEndingConditions()
	{
		int pobTotal = audiencia_oposicion + audiencia_oficialismo + oposicion_no_audiencia + oficialismo_no_audiencia;
		int audiencia = audiencia_oposicion + audiencia_oficialismo;
		float rating = audiencia / (float)pobTotal;
		float audienciaOp = audiencia_oposicion / (float)audiencia;
		float audienciaOf = audiencia_oficialismo / (float)audiencia;
		float paisOp = (oposicion_no_audiencia + audiencia_oposicion) / (float)pobTotal;
		float paisOf = (oficialismo_no_audiencia + audiencia_oficialismo) / (float)pobTotal;

		if (rating < ratingToLose) {	
			OfficeRutineManager.Instance.OnEndGame(EndGameType.DERROTA_DESPIDO);
		} else if (audienciaOp > audienciaOpToLose) {		
			OfficeRutineManager.Instance.OnEndGame (EndGameType.DERROTA_ENVENENADO);
		} else if (audienciaOf > audienciaOfToLose) {		
			OfficeRutineManager.Instance.OnEndGame (EndGameType.DERROTA_BOMBA);
		} else if (paisOp > paisOpToWin) {
			OfficeRutineManager.Instance.OnEndGame (EndGameType.VICTORIA_DEMOCRACIA);
		} else if(paisOf > paisOfToWin) {
			OfficeRutineManager.Instance.OnEndGame (EndGameType.VICTORIA_DICTADURA);
		} else if(OfficeRutineManager.Instance.CurrentDay > maxDaysToLose) {
			OfficeRutineManager.Instance.OnEndGame (EndGameType.DERROTA_EXPROPIACION);
		}
	}

	public void DisplayStatistics() 
	{
		int pobTotal = audiencia_oposicion + audiencia_oficialismo + oposicion_no_audiencia + oficialismo_no_audiencia;
		int audiencia = audiencia_oposicion + audiencia_oficialismo;

		dateDisplay.text = OfficeRutineManager.Instance.CurrentDay + " de enero";

		int percent_audiencia_oficialismo = (audiencia_oficialismo * 100) / audiencia;
		int percent_poblacion_oficialismo = ((audiencia_oficialismo + oficialismo_no_audiencia) * 100) / pobTotal;

		statisticsDisplay.text = "Rating: " + (audiencia * 100) / pobTotal + "%\n\n" +
		"Audiencia\n" + 
		"*Oficialismo: " + percent_audiencia_oficialismo + "%\n" +
		"*Oposición: " + (100 - percent_audiencia_oficialismo) + "%\n\n" +

		"Población\n" + 
		"*Oficialismo: " + percent_poblacion_oficialismo + "%\n" +
		"*Oposición: " + (100 - percent_poblacion_oficialismo) + "%\n\n";

		Debug.Log( "Audiencia oposicion personas: " + audiencia_oposicion + "\t" +
		"Audiencia oficialismo personas: " + audiencia_oficialismo + "\t" +
		"Oposicion no audiencia: " + oposicion_no_audiencia + "\t" +
		"Oficialismo no audiencia: " + oficialismo_no_audiencia );
	}

	public void Increase_audiencia_oficialismo(int amount) 
	{
		int realAmount = Mathf.Min(amount,oficialismo_no_audiencia);
		oficialismo_no_audiencia -= realAmount;
		audiencia_oficialismo += realAmount;
	}

	public void Decrease_audiencia_oficialismo(int amount)
	{
		int realAmount = Mathf.Min(amount,audiencia_oficialismo);
		audiencia_oficialismo -= realAmount;
		oficialismo_no_audiencia += realAmount;
	}

	public void Increase_audiencia_oposicion(int amount) 
	{
		int realAmount = Mathf.Min(amount, oposicion_no_audiencia);
		oposicion_no_audiencia -= realAmount;
		audiencia_oposicion += realAmount;
	}

	public void Decrease_audiencia_oposicion(int amount)
	{
		int realAmount = Mathf.Min(amount,audiencia_oposicion);
		audiencia_oposicion -= realAmount;
		oposicion_no_audiencia += realAmount;
	}

	//Convierte de oposicion a oficialismo
	public void Convert_to_oficialismo(int amount) 
	{
		int realAmount = Mathf.Min(amount,audiencia_oposicion);
		audiencia_oposicion -= realAmount;
		audiencia_oficialismo += realAmount;
	}

	//Convierte de oficialismo a oposicion
	public void Convert_to_oposicion(int amount) 
	{
		int realAmount = Mathf.Min(amount,audiencia_oficialismo);
		audiencia_oficialismo -= realAmount;
		audiencia_oposicion += realAmount;
	}
}

