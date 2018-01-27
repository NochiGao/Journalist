using System.Collections.Generic;
using UnityEngine;

public class JournalistDesktopRenderer : MonoBehaviour
{
    [SerializeField] private List<NewspaperRenderer> newspapersRendererPrefabs = new List<NewspaperRenderer>();
    [SerializeField] private float randomPositionRange = 10;

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
        foreach (var news in newsManager.AvailableNews)
        {
            InstantiateNewspapers(news);
        }
    }

    public void InstantiateNewspapers(News news)
    {
        if (newspapersRendererPrefabs.Count == 0)
        {
            Debug.LogWarning("No news renderer prefabs were set");
            return;
        }
        
        NewspaperRenderer newspaperRenderer = Instantiate(newspapersRendererPrefabs[Random.Range(0, newspapersRendererPrefabs.Count)], Vector3.zero, Quaternion.identity);
        newspaperRenderer.SetNewsReference(news);
        newspaperRenderer.SetPosition(Random.insideUnitCircle * randomPositionRange);

        newspapersRenderers.Add(newspaperRenderer);
    }


}
