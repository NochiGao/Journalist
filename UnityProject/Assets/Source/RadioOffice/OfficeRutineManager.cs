﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OfficeRutineManager : MonoBehaviour
{
    public delegate void OnNewDaySignature();
    public event OnNewDaySignature OnNewDay;
	public Button onAirButton;
	public GameObject panelEndGame;
	public Text endGameText;
	public GameObject winOf;
	public GameObject winOp;
	public GameObject loss;

    private static OfficeRutineManager instance = null;
    public static OfficeRutineManager Instance { get { return instance; } }

    [SerializeField] private uint startingDay = 1;

    [SerializeField] private OnAirShowService airShowService = null;
    public OnAirShowService AirShowService { get { return airShowService; } }

    private uint currentDay = 1;
    public uint CurrentDay { get { return currentDay; } }

    public string GetCurrentDayString()
    {
        return currentDay + " de enero";
    }

    private uint daysElapsed = 0;
    public uint DaysElapsed { get { return daysElapsed; } }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentDay = startingDay;
        daysElapsed = 0;

        //NewsManager.Instance.RefreshAvailableNews();
    }

	public void OnEndGame (StatsManager.EndGameType endGameInfo)
    {
		Debug.LogWarning (endGameInfo.ToString());
		onAirButton.interactable = false;
		onAirButton.enabled = false;
		panelEndGame.SetActive (true);

        string str = string.Empty;
        switch( endGameInfo )
        {
		case StatsManager.EndGameType.VICTORIA_DEMOCRACIA: 
			str = "El General Alcatraz se ve acorralado. Ha perdido su popularidad gracias al poder de transmisión de los medios. Anuncia un llamado a elecciones. ¡Has salvado la democracia y los nidos de Pajaronia! Ciertos grupos de influencia empiezan a sugerir tu nombre como uno de las candidatas."; 
			winOp.SetActive (true);
			break;
			case StatsManager.EndGameType.VICTORIA_DICTADURA: 
			str = "El General Alcatraz te recibe en el Palacio Presidencial. Te agradece fuertemente y te informa que a partir de ahora sos la nueva Ministra de Comunicaciones. Todos los periodistas responden a vos. ¡Larga vida al régimen y a todo el alpiste que vas a poder acumular!"; 
			winOf.SetActive (true);
			break;
			case StatsManager.EndGameType.DERROTA_DESPIDO: 
			str = "El rating es importante, ya sea en democracia o en una desalmada dictadura. Fuiste reemplazado por el programa de chimentos de la Garza Giménes."; 
			loss.SetActive (true);
			break;
			case StatsManager.EndGameType.DERROTA_EXPROPIACION:
			str = "Exprópiese. La radio pasa a manos estatales. El régimen te da la opción de continuar trabajando de alpistera en los campos de alpiste o exiliarte en Murcielandia."; 
			loss.SetActive (true);
			break;
			case StatsManager.EndGameType.DERROTA_BOMBA: 
			str = "Todo es oscuridad. Lo último que escuchas es un gran graznido-estallido. Seguramente tu exceso de oficialismo crispó a los pájaros incorrectos."; 
			loss.SetActive (true);
			break;
			case StatsManager.EndGameType.DERROTA_ENVENENADO: 
			str = "Un grupo comando, sin identificar, entra como tormenta en la radio. Todos mueren y vos no sos la excepción. Con el régimen no se jode ni se grazna."; 
			loss.SetActive (true);
			break;
        }

		endGameText.text = str;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.F8))
        {
            AdvanceDay();
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            OnMainMenuButton();
        }
    }

	public void OnAirButton()
	{
        AdvanceDay();
	}

    public void AdvanceDay()
    {
        currentDay++;
        daysElapsed++;
        
		OnNewDay ();
        airShowService.BeginShow(NewsManager.Instance.AvailableNews.ToArray());
    }

	public void OnMainMenuButton() {
		SceneManager.LoadScene ("start_menu", LoadSceneMode.Single);
	}
}
