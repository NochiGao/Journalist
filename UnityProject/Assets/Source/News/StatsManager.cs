
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public struct RadioStats
{
    public float rating;
}

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

    // private Dictionary<uint, StoredStats> historicalStats = new Dictionary<uint, StoredStats>();
    // public Dictionary<uint, StoredStats> HistoricalStats { get { return historicalStats; } }

    private float deltaRating = 0;
	private float deltaPorcentajeAudienciaOficialismo = 0;
	private float deltaPorcentajePoblacionOficialismo = 0;

    public RadioStats GetDeltaStats()
    {
        return new RadioStats();
    }

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
        StoreCurrentStatics();
	}

	public void OnNewDay() 
	{
		List<News> newses = NewsManager.Instance.AvailableNews;
		int totalDeltaOf = 0;
		int totalDeltaOp = 0;
		int totalDeltaConv = 0;

		int baseAudiencia = audiencia_oposicion + audiencia_oficialismo;
		int baseOficialismo = oficialismo_no_audiencia + audiencia_oficialismo;
		int baseOposicion = oposicion_no_audiencia + audiencia_oposicion;

		foreach (News news in newses) 
		{
			float deltaOf = 0f;
			if( news.NewsValues.ofWeight.ActualWeight > 0 )
				deltaOf = news.NewsValues.ofWeight.ActualWeight * (2.5f * news.NewsValues.timeAssigned - 0.5f);
			else
				deltaOf = news.NewsValues.ofWeight.ActualWeight * 2f * news.NewsValues.timeAssigned;

			float deltaOp = 0f;
			if( news.NewsValues.opWeight.ActualWeight > 0 )
				deltaOp = news.NewsValues.opWeight.ActualWeight * (2.5f * news.NewsValues.timeAssigned - -0.5f);
			else
				deltaOp = news.NewsValues.opWeight.ActualWeight * 2f * news.NewsValues.timeAssigned;

			float deltaConv = news.NewsValues.conversionWeight.ActualWeight * 2f * news.NewsValues.timeAssigned;

			int deltaOfToPeople = Mathf.RoundToInt (deltaOf * baseOficialismo);
			int deltaOpToPeople = Mathf.RoundToInt (deltaOp * baseOposicion);
			int deltaConvToPeople = Mathf.RoundToInt (deltaConv * baseAudiencia);

			Debug.Log( "News '" + news.Title + "': deltaOf=" + deltaOfToPeople + " deltaOp=" + deltaOpToPeople + " deltaConv=" + deltaConvToPeople );

			totalDeltaOf += deltaOfToPeople;
			totalDeltaOp += deltaOpToPeople;
			totalDeltaConv += deltaConvToPeople;
		}

		int DeltaAudienciaOposicion = 0;
		int DeltaAudienciaOficialismo = 0;
		int DeltaOposicionNoAudiencia = 0;
		int DeltaOficialismoNoAudiencia = 0;

		if (totalDeltaConv < 0) {
			int delta = Convert_to_oposicion (-totalDeltaConv);
			DeltaAudienciaOposicion += delta;
			DeltaAudienciaOficialismo -= delta;
		} else if (totalDeltaConv > 0) {
			int delta = Convert_to_oficialismo (totalDeltaConv);
			DeltaAudienciaOficialismo += delta;
			DeltaAudienciaOposicion -= delta;
		}

		if (totalDeltaOf < 0) {
			int delta = Decrease_audiencia_oficialismo (-totalDeltaOf);
			DeltaOficialismoNoAudiencia += delta;
			DeltaAudienciaOficialismo -= delta;

		} else if (totalDeltaOf > 0) {
			int delta = Increase_audiencia_oficialismo (totalDeltaOf);
			DeltaAudienciaOficialismo += delta;
			DeltaOficialismoNoAudiencia -= delta;
		}

		if (totalDeltaOp < 0) {
			int delta = Decrease_audiencia_oposicion (-totalDeltaOp);
			DeltaOposicionNoAudiencia += delta;
			DeltaAudienciaOposicion -= delta;
		} else if (totalDeltaOp > 0) {
			int delta = Increase_audiencia_oposicion (totalDeltaOp);
			DeltaAudienciaOposicion += delta;
			DeltaOposicionNoAudiencia -= delta;
		}

		deltaRating = (DeltaAudienciaOficialismo + DeltaAudienciaOposicion) / (float) GetTotalPopulation();
		deltaPorcentajeAudienciaOficialismo = DeltaAudienciaOficialismo / (float) baseAudiencia;
		deltaPorcentajePoblacionOficialismo = ( DeltaAudienciaOficialismo + DeltaOficialismoNoAudiencia ) / (float) GetTotalPopulation();

		DisplayStatistics ();
        StoreCurrentStatics();

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

	public string GetDeltaStringPercent( float number )
	{
		int roundedNumber = Mathf.RoundToInt(number*100);

		if( roundedNumber > 0 )
			return "<size=16><color=green>▲" + roundedNumber.ToString("0") + "%</color></size>";

		if( roundedNumber < 0 )
			return "<size=16><color=red>▼" + Mathf.Abs(roundedNumber).ToString("0") + "%</color></size>";;

		return "";
	}

	public void DisplayStatistics() 
	{
		int pobTotal = GetTotalPopulation();
        int audiencia = GetAudience();

		dateDisplay.text = OfficeRutineManager.Instance.CurrentDay + " de enero";

		int percent_audiencia_oficialismo = (audiencia_oficialismo * 100) / audiencia;
		int percent_poblacion_oficialismo = ((audiencia_oficialismo + oficialismo_no_audiencia) * 100) / pobTotal;

		int rating = (int)(GetRating()*100);

		statisticsDisplay.text = "<size=24>Rating: " +  rating + "%</size> " + GetDeltaStringPercent(GetRatingDelta()) + "\n\n" +
		
		"<size=24>Audiencia</size>\n" + 
		"  Oficialismo: " + percent_audiencia_oficialismo + "%" + GetDeltaStringPercent(deltaPorcentajeAudienciaOficialismo) + "\n" +
		"  Oposición: " + (100 - percent_audiencia_oficialismo) + "%" + GetDeltaStringPercent(-deltaPorcentajeAudienciaOficialismo) + "\n\n" +

		"<size=24>Población</size>\n" + 
		"  Oficialismo: " + percent_poblacion_oficialismo + "%" + GetDeltaStringPercent(deltaPorcentajePoblacionOficialismo) + "\n" +
		"  Oposición: " + (100 - percent_poblacion_oficialismo) + "%" + GetDeltaStringPercent(-deltaPorcentajePoblacionOficialismo) + "\n\n";

		Debug.Log( "Audiencia oposicion personas: " + audiencia_oposicion + "\t" +
		"Audiencia oficialismo personas: " + audiencia_oficialismo + "\t" +
		"Oposicion no audiencia: " + oposicion_no_audiencia + "\t" +
		"Oficialismo no audiencia: " + oficialismo_no_audiencia );
	}

    public float GetRating()
    {
        return GetAudience() / (float) GetTotalPopulation();
    }

	public float GetRatingDelta()
	{
		return deltaRating;
	}

	public float GetOfficialismAudiencePercentDelta()
	{
		return deltaPorcentajeAudienciaOficialismo;
	}

	public float GetOfficialismPopulationPercentDelta()
	{
		return deltaPorcentajePoblacionOficialismo;
	}

    public int GetAudience()
    {
        return audiencia_oposicion + audiencia_oficialismo;
    }

    public int GetTotalPopulation()
    {
        return audiencia_oposicion + audiencia_oficialismo + oposicion_no_audiencia + oficialismo_no_audiencia;
    }

    public void StoreCurrentStatics()
    {
        /*
        StoredStats statsToStore = new StoredStats();
        statsToStore.rating = GetRating();

        historicalStats.Add(OfficeRutineManager.Instance.CurrentDay, statsToStore);
        Debug.Log("stored " + historicalStats[OfficeRutineManager.Instance.CurrentDay]);
        */


    }

	public int Increase_audiencia_oficialismo(int amount) 
	{
		int realAmount = Mathf.Min(amount,oficialismo_no_audiencia);
		oficialismo_no_audiencia -= realAmount;
		audiencia_oficialismo += realAmount;
		return realAmount;
	}

	public int Decrease_audiencia_oficialismo(int amount)
	{
		int realAmount = Mathf.Min(amount,audiencia_oficialismo);
		audiencia_oficialismo -= realAmount;
		oficialismo_no_audiencia += realAmount;
		return realAmount;
	}

	public int Increase_audiencia_oposicion(int amount) 
	{
		int realAmount = Mathf.Min(amount, oposicion_no_audiencia);
		oposicion_no_audiencia -= realAmount;
		audiencia_oposicion += realAmount;
		return realAmount;
	}

	public int Decrease_audiencia_oposicion(int amount)
	{
		int realAmount = Mathf.Min(amount,audiencia_oposicion);
		audiencia_oposicion -= realAmount;
		oposicion_no_audiencia += realAmount;
		return realAmount;
	}

	//Convierte de oposicion a oficialismo
	public int Convert_to_oficialismo(int amount) 
	{
		int realAmount = Mathf.Min(amount,audiencia_oposicion);
		audiencia_oposicion -= realAmount;
		audiencia_oficialismo += realAmount;
		return realAmount;
	}

	//Convierte de oficialismo a oposicion
	public int Convert_to_oposicion(int amount) 
	{
		int realAmount = Mathf.Min(amount,audiencia_oficialismo);
		audiencia_oficialismo -= realAmount;
		audiencia_oposicion += realAmount;
		return realAmount;
	}
}

