using System.Collections;
using UnityEngine;

public class OnAirShowService : MonoBehaviour
{
    public delegate void ProgramEventSignature();
    public event ProgramEventSignature OnBeginProgramEvent;
    public event ProgramEventSignature OnEndProgramEvent;

    public delegate void GivingNewsSignature(int indexInProgram);
    public event GivingNewsSignature OnNewsTalkEndEvent;
    public event GivingNewsSignature OnNewsTalkBeginEvent;

    [SerializeField] private float timeBeforeBeginTalks = 1.0f;
    [SerializeField] private float secondsPerNews = 1.0f;

    private News[] currentProgram = new News[0];
    public News[] CurrentProgram { get { return currentProgram; } }

    public void BeginShow(News[] program)
    {
        if (program == null || program.Length > 0)
        {
            Debug.LogWarning("Can't begin show, there is not a defined program.");
        }

        currentProgram = program;

        if (OnBeginProgramEvent != null)
        {
            OnBeginProgramEvent();
        }

        StartCoroutine(BeginTalks());
    }

    private void Start()
    {
        OnNewsTalkEndEvent += OnNewsGiven;
    }

    private void GiveNews(int indexInProgram)
    {
        StartCoroutine(TalkAboutNews(indexInProgram));
    }

    private void OnNewsGiven(int indexInProgram)
    {
        if (indexInProgram < currentProgram.Length - 1)
        {
            GiveNews(indexInProgram + 1);
        }
        else
        {
            if (OnEndProgramEvent != null)
            {
                OnEndProgramEvent();
            }
        }
    }

    private IEnumerator BeginTalks()
    {
        yield return new WaitForSeconds(timeBeforeBeginTalks);

        GiveNews(0);
    }

    private IEnumerator TalkAboutNews(int indexInProgram)
    {
        if (OnNewsTalkBeginEvent != null)
        {
            OnNewsTalkBeginEvent(indexInProgram);
        }

        yield return new WaitForSeconds(secondsPerNews);

        if (OnNewsTalkEndEvent != null)
        {
            OnNewsTalkEndEvent(indexInProgram);
        }
    }
}
