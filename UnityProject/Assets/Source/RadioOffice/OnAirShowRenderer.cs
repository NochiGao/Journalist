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

        int ratingDelta = Mathf.RoundToInt(StatsManager.deltaRating*100);
        int poblacionOficialistaDelta = Mathf.RoundToInt(StatsManager.deltaPorcentajePoblacionOficialismo*100);
        int audienciaOficialistaDelta = Mathf.RoundToInt(StatsManager.deltaPorcentajeAudienciaOficialismo*100);

        if( poblacionOficialistaDelta>=2 )
            subtitle.text = "La imagen positiva del gobierno subió " + poblacionOficialistaDelta.ToString("0") + "%";
        else if( poblacionOficialistaDelta<=-2 )
            subtitle.text = "La imagen positiva del gobierno bajó " + Mathf.Abs(poblacionOficialistaDelta).ToString("0") + "%";
        else if( audienciaOficialistaDelta>=2 )
            subtitle.text = "Nuestros oyentes oficialistas subieron " + audienciaOficialistaDelta.ToString("0") + "%";
        else if( audienciaOficialistaDelta<=-2 )
            subtitle.text = "Nuestros oyentes opositores subieron " + Mathf.Abs(audienciaOficialistaDelta).ToString("0") + "%";
        else if( ratingDelta > 0 )
            subtitle.text = "El rating subió " + ratingDelta.ToString("0") + "%";
        else if( ratingDelta < 0 )
            subtitle.text = "El rating bajó " + Mathf.Abs(ratingDelta).ToString("0") + "%";
        else
            subtitle.text = "Sin mayores novedades...";

        title.text = OfficeRutineManager.Instance.GetCurrentDayString();

        AudioManager.Instance.MusicInGameStart();
        AudioManager.Instance.SetRadioNews();
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
