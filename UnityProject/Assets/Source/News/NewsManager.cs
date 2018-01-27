using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NewsManager : MonoBehaviour
{
    public bool debugLog = true;

    public delegate void AvailableNewsRefreshedSignature();
    public event AvailableNewsRefreshedSignature OnAvailableNewsRefreshed;
    
    private static NewsManager instance = null;
    public static NewsManager Instance { get { return instance; } }

    private List<News> newsPool = new List<News>();
    public List<News> NewsPool { get { return NewsPool; } }

    private List<News> previousNews = new List<News>();

    private List<News> availableNews = new List<News>();
    public List<News> AvailableNews { get { return availableNews; } }

    private int availableNewsCount = 3;

	public void SetTime( int news, float time )
	{
		availableNews [news].NewsValues.timeAssigned = time;
	}

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        OfficeRutineManager.Instance.OnNewDay += OnNewDay;
        newsPool.AddRange(new List<News>(NewsDefinitions.GetNewsDatabase()));
    }

    public List<News> GetFilteredNews()
    {
        return newsPool.Where( m => m.NewsRequisites.requiredIDs.All( n => previousNews.Any( o => o.ID==n ))
            && !m.NewsRequisites.excludedIDs.Any( n => previousNews.Any( o => o.ID==n ) ) ).ToList();
    }

    public bool RefreshAvailableNews()
    {
        if (newsPool.Count < availableNewsCount)
        {
            Debug.LogWarning("not enough news in the news pool");
            return false;
        }

        availableNews = new List<News>();

        List<News> filteredNews = GetFilteredNews();

        List<News> obligatoryNews = filteredNews.Where( m => OfficeRutineManager.Instance.CurrentDay==m.NewsRequisites.day ).ToList();

        if( obligatoryNews.Count>3 )
        {
            Debug.LogError( "Hay mas que 3 noticias obligatorias en el día " + OfficeRutineManager.Instance.CurrentDay );
            foreach( News news in obligatoryNews )
                Debug.LogError( news.ToString() );
        }

        availableNews.AddRange( obligatoryNews );

        //Select random news from news database
        for (int i = availableNews.Count; i < availableNewsCount; i++)
        {
            filteredNews = GetFilteredNews();

            int randomRoll = Random.Range(0, newsPool.Count);

            Debug.Log( "filteredNews=" + filteredNews.Count + ", roll=" + randomRoll  );

            News randomNew = filteredNews[randomRoll];
            availableNews.Add(randomNew);
            newsPool.Remove(randomNew);
            previousNews.Add(randomNew);
        }

        if(debugLog) Debug.Log("Available news refreshed.");

        PrintAvailableNews();

        if (OnAvailableNewsRefreshed != null)
        {
            OnAvailableNewsRefreshed();
        }

        return true;
    }

    private void OnNewDay()
    {
        RefreshAvailableNews();
    }

    public void PrintAvailableNews()
    {
        if (debugLog) Debug.Log("Available news: ");
        for (int i = 0; i < availableNews.Count; i++)
        {
            if (debugLog) Debug.Log(availableNews[i].Title + " (" + i + ")");
        }
    }
}
