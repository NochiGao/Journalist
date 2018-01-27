using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalistDesktopRenderer : MonoBehaviour
{
    [SerializeField] private List<NewspaperRenderer> newspapersRendererPrefabs = new List<NewspaperRenderer>();
    [SerializeField] private NewspapersPositioningService newspapersPositioning = null;
    
    private NewsManager newsManager = null;
    private List<NewspaperRenderer> newspapersRenderers = new List<NewspaperRenderer>();

    private void Start()
    {
        newsManager = NewsManager.Instance;
        if (newsManager == null)
        {
            Debug.LogError("Couldn't retrieve NewsManager instance!");
        }
        else
        {
            newsManager.OnAvailableNewsRefreshed += OnAvailableNewsRefreshed;
        }
    }

    private void OnAvailableNewsRefreshed()
    {
        RedrawAvailableNews();
    }

    public void RedrawAvailableNews()
    {
        RemoveNewspapers();

        for (int i = 0; i < newsManager.AvailableNews.Count; i++)
        {
            InstantiateNewspapers(newsManager.AvailableNews[i], i);
        }
    }
    public void RemoveNewspapers()
    {
        newspapersRenderers.ForEach(newspapers => Destroy(newspapers.gameObject));
        newspapersRenderers.Clear();
    }

    public void InstantiateNewspapers(News news, int forIndex)
    {
        if (newspapersRendererPrefabs.Count == 0)
        {
            Debug.LogWarning("No news renderer prefabs were set");
            return;
        }
        
        NewspaperRenderer newspaperRenderer = Instantiate(newspapersRendererPrefabs[Random.Range(0, newspapersRendererPrefabs.Count)], Vector3.zero, Quaternion.identity);
        newspaperRenderer.SetJournalistDesktopReference(this);
        newspaperRenderer.SetNewsReference(news);

        newspapersPositioning.PositionPapersRandom(newspaperRenderer, forIndex);
        newspapersRenderers.Add(newspaperRenderer);
    }
}
