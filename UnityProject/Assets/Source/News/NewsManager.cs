﻿using System.Collections.Generic;
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
        newsPool.AddRange(new List<News>(NewsDefinitions.GetNewsDatabase()));

        RefreshAvailableNews();
    }

    public List<News> GetFilteredNews()
    {
        List<News> retList = new List<News>();

        foreach( News news in newsPool)
        {
            if( !news.NewsRequisites.requiredIDs.All( n => previousNews.Any( o => o.ID==n ) ) )
                continue;
            
            if( news.NewsRequisites.excludedIDs.Any( n => previousNews.Any( o => o.ID==n ) ) )
                continue;

            if( news.NewsRequisites.day!=0 && news.NewsRequisites.day!=OfficeRutineManager.Instance.CurrentDay )
                continue;

            if( availableNews.Any( m => news.NewsRequisites.requiredIDs.Any( n => n==m.ID ) ) )
            {
                Debug.LogWarning( "Removing news '" + news.Title + "' because it requires ID " + news.NewsRequisites.requiredIDs.First() );
                continue;
            }

            retList.Add(news);
        }

        return retList;
    }

    public void AddAvailableNews( News news )
    {
        availableNews.Add( news );
        newsPool.Remove( news );
        previousNews.Add( news );
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

        foreach( News news in obligatoryNews )
            AddAvailableNews( news );

        //Select random news from news database
        for (int i = availableNews.Count; i < availableNewsCount; i++)
        {
            filteredNews = GetFilteredNews();

            if( filteredNews.Count==0)
            {
                Debug.Log("No hay mas noticias disponibles!");
                break;
            }

            int randomRoll = Random.Range(0, filteredNews.Count);

            News randomNew = filteredNews[randomRoll];
            AddAvailableNews(randomNew);
        }

        if(debugLog) Debug.Log("Available news refreshed.");

        if (OnAvailableNewsRefreshed != null)
        {
            OnAvailableNewsRefreshed();
        }

        return true;
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
