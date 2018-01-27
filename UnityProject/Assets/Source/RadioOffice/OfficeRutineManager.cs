using UnityEngine;

public class OfficeRutineManager : MonoBehaviour
{
    public delegate void OnNewDaySignature();
    public event OnNewDaySignature OnNewDay;

    private static OfficeRutineManager instance = null;
    public static OfficeRutineManager Instance { get { return instance; } }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        NewsManager.Instance.RefreshAvailableNews();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (OnNewDay != null)
            {
                OnNewDay();
            }
        }
    }

	public void OnAirButton()
	{
		OnNewDay ();
	}
}
