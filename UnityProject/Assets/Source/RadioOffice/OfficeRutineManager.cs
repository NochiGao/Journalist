using UnityEngine;
using UnityEngine.UI;

public class OfficeRutineManager : MonoBehaviour
{
    public delegate void OnNewDaySignature();
    public event OnNewDaySignature OnNewDay;
	public Button onAirButton;
	public GameObject panelEndGame;
	public Text endGameText;

    private static OfficeRutineManager instance = null;
    public static OfficeRutineManager Instance { get { return instance; } }

    [SerializeField] private uint startingDay = 1;

    [SerializeField] private OnAirShowService airShowService = null;
    public OnAirShowService AirShowService { get { return airShowService; } }

    private uint currentDay = 1;
    public uint CurrentDay { get { return currentDay; } }

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

        NewsManager.Instance.RefreshAvailableNews();
    }

	public void OnEndGame (StatsManager.EndGameType endGameInfo)
    {
		Debug.LogWarning (endGameInfo.ToString());
		onAirButton.interactable = false;
		panelEndGame.SetActive (true);

        string str = string.Empty;
        switch( endGameInfo )
        {
            case StatsManager.EndGameType.VICTORIA_DEMOCRACIA: str = "El General Alcatraz se ve acorralado. Ha perdido su popularidad gracias al poder de transmisión de los medios. Anuncia un llamado a elecciones. ¡Has salvado la democracia y los nidos de Pajaronia! Ciertos grupos de influencia empiezan a sugerir tu nombre como uno de las candidatas."; break;
            case StatsManager.EndGameType.VICTORIA_DICTADURA: str = "El General Alcatraz te recibe en el Palacio Presidencial. Te agradece fuertemente y te informa que a partir de ahora sos la nueva Ministra de Comunicaciones. Todos los periodistas responden a vos. ¡Larga vida al régimen y a todo el alpiste que vas a poder acumular!"; break;
            case StatsManager.EndGameType.DERROTA_DESPIDO: str = "El rating es importante, ya sea en democracia o en una desalmada dictadura. Fuiste reemplazado por el programa de chimentos de la Garza Giménes."; break;
            case StatsManager.EndGameType.DERROTA_EXPROPIACION: str = "Exprópiese. La radio pasa a manos estatales. El régimen te da la opción de continuar trabajando de alpistera en los campos de alpiste o exiliarte en Murcielandia."; break;
            case StatsManager.EndGameType.DERROTA_BOMBA: str = "Todo es oscuridad. Lo último que escuchas es un gran graznido-estallido. Seguramente tu exceso de oficialismo crispó a los pájaros incorrectos."; break;
            case StatsManager.EndGameType.DERROTA_ENVENENADO: str = "Un grupo comando, sin identificar, entra como tormenta en la radio. Todos mueren y vos no sos la excepción. Con el régimen no se jode ni se grazna."; break;
        }

		endGameText.text = str;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            AdvanceDay();
        }
        if (Input.GetKey(KeyCode.F8))
        {
            AdvanceDay();
        }
    }

	public void OnAirButton()
	{
        AdvanceDay();
	}

    public void AdvanceDay()
    {
        airShowService.BeginShow(NewsManager.Instance.AvailableNews.ToArray());

        currentDay++;
        daysElapsed++;
        
		OnNewDay ();
    }
}
