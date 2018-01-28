using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OnAirShowRenderer : MonoBehaviour
{
    public UnityEvent OnBeginShow = new UnityEvent();
    public UnityEvent OnEndShow = new UnityEvent();
    public UnityEvent OnBeginNewsTalk = new UnityEvent();
    public UnityEvent OnEndNewsTalk = new UnityEvent();

    [SerializeField] private Text title = null;
    [SerializeField] private Text subtitle = null;

    private OnAirShowService airShow = null;

    private void Start()
    {
        airShow = OfficeRutineManager.Instance.AirShowService;
        if (airShow == null)
        {
            Debug.LogWarning("Couldn't retrieve air show service.");
        }

        airShow.OnBeginProgramEvent += OnBeginProgram;
        airShow.OnEndProgramEvent += OnEndProgram;

        airShow.OnNewsTalkBeginEvent += OnBeginTalk;
        airShow.OnNewsTalkEndEvent += OnEndTalk;
    }

    private void OnBeginProgram()
    {
        OnBeginShow.Invoke();

        float ratingDifference = StatsManager.Instance.GetDeltaStats().rating;
        title.text = ratingDifference < 0.0f ? "-" + ratingDifference + "%" : "+" + ratingDifference + "%";
        subtitle.text = "Día " + OfficeRutineManager.Instance.CurrentDay.ToString();
    }

    private void OnEndProgram()
    {
        OnEndShow.Invoke();
    }

    private void OnBeginTalk(int indexInProgram)
    {
        //title.text = airShow.CurrentProgram[indexInProgram].Title.ToUpper();
        //subtitle.text = airShow.CurrentProgram[indexInProgram].Description;
        OnBeginNewsTalk.Invoke();
    }

    private void OnEndTalk(int indexInProgram)
    {
        OnEndNewsTalk.Invoke();
    }
}
