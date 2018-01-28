using UnityEngine;
using UnityEngine.Events;

public class OnAirShowRenderer : MonoBehaviour
{
    public UnityEvent OnBeginShow = new UnityEvent();
    public UnityEvent OnEndShow = new UnityEvent();
    public UnityEvent OnBeginNewsTalk = new UnityEvent();
    public UnityEvent OnEndNewsTalk = new UnityEvent();

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
        OnBeginNewsTalk.Invoke();
    }

    private void OnEndTalk(int indexInProgram)
    {
        OnEndNewsTalk.Invoke();
    }
}
