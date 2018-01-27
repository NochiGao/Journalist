using UnityEngine;

public class OfficeRutineManager : MonoBehaviour
{
    public delegate void OnNewDaySignature();
    public event OnNewDaySignature OnNewDay;

    private static OfficeRutineManager instance = null;
    public static OfficeRutineManager Instance { get { return instance; } }

    [SerializeField] private uint startingDay = 0;

    private uint currentDay = 0;
    public uint CurrentDay { get { return currentDay; } }

    private uint daysElapsed = 0;
    public uint DaysElapsed { get { return daysElapsed; } }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        NewsManager.Instance.RefreshAvailableNews();

        currentDay = startingDay;
        daysElapsed = 0;
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
        currentDay++;
        daysElapsed++;

		OnNewDay ();
    }
}
