using System.Collections.Generic;
using UnityEngine;

public class NewsManager : MonoBehaviour
{
    public delegate void NewsChosenSignature(News chosenNews);
    public event NewsChosenSignature OnNewsChosen;

    private static NewsManager instance = null;
    public static NewsManager Instance { get { return instance; } }

    private List<News> availableNews = new List<News>();
    public List<News> AvailableNews { get { return availableNews; } }

    private Queue<News> chosenNews = new Queue<News>();
    public Queue<News> ChosenNews { get { return ChosenNews; } }
    
    private int availableNewsCount = 5;

    private void Awake()
    {
        instance = this;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            RefreshAvailableNews();
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            ChoiceFromAvailableNews(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChoiceFromAvailableNews(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChoiceFromAvailableNews(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChoiceFromAvailableNews(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChoiceFromAvailableNews(4);
        }
    }

    private bool RefreshAvailableNews()
    {
        News[] newsDatabase = NewsDefinitions.GetNewsDatabase();

        if (newsDatabase.Length == 0)
        {
            Debug.LogWarning("No news defined in news database.");
            return false;
        }

        News[] newAvailableNews = new News[availableNewsCount];

        //Select random news from news database
        int definedNewsSize = newsDatabase.Length;
        for (int i = 0; i < newAvailableNews.Length; i++)
        {
            newAvailableNews[i] = newsDatabase[Random.Range(0, definedNewsSize)];
        }

        //Assign the results.
        availableNews = new List<News>(newAvailableNews);

        Debug.Log("Available news refreshed.");
        PrintAvailableNews();

        return true;
    }

    private void ChoiceFromAvailableNews(int index)
    {
        if (index > availableNews.Count)
        {
            Debug.Log("No news exists at index " + index + ".");
            return;
        }

        ChoiseFromAvailableNews(availableNews[index]);
    }

    private void ChoiseFromAvailableNews(News news)
    {
        if (!availableNews.Contains(news))
        {
            Debug.Log("\"" + news.Title + "\" new is not available.");
            return;
        }

        availableNews.Remove(news);
        Debug.Log("\"" + news.Title + "\" removed from available news.");
        chosenNews.Enqueue(news);
        Debug.Log("\"" + news.Title + "\" enqueued to chosen news.");

        if (OnNewsChosen != null)
        {
            OnNewsChosen(news);
        }

        PrintAvailableNews();
    }

    public void PrintAvailableNews()
    {
        Debug.Log("Available news: ");
        for (int i = 0; i < availableNews.Count; i++)
        {
            Debug.Log(availableNews[i].Title + " (" + i + ")");
        }
    }
}
