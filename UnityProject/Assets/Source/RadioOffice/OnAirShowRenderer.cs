using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OnAirShowRenderer : MonoBehaviour
{
    public UnityEvent OnBeginShow = new UnityEvent();
    public UnityEvent OnEndShow = new UnityEvent();
    public UnityEvent OnBeginNewsTalk = new UnityEvent();
    public UnityEvent OnEndNewsTalk = new UnityEvent();

    [SerializeField] private Text newsTitle = null;
    [SerializeField] private Text newsDescription = null;

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
    }

    private void OnEndProgram()
    {
        OnEndShow.Invoke();
    }

    private void OnBeginTalk(int indexInProgram)
    {
        newsTitle.text = airShow.CurrentProgram[indexInProgram].Title.ToUpper();
        newsDescription.text = airShow.CurrentProgram[indexInProgram].Description;
        OnBeginNewsTalk.Invoke();
    }

    private void OnEndTalk(int indexInProgram)
    {
        OnEndNewsTalk.Invoke();
    }
}
