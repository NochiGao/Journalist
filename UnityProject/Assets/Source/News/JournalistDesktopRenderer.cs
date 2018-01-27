using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalistDesktopRenderer : MonoBehaviour
{
    [SerializeField] private List<NewspaperRenderer> newspapersRendererPrefabs = new List<NewspaperRenderer>();
    //[SerializeField] private float randomPositionRange = 10;
    [SerializeField] private GridLayoutGroup newspapersGrid = null;
    [SerializeField] private Vector3 chosenNewspaperPosition = Vector3.zero;
    public Vector3 ChosenNewspaperPosition { get { return chosenNewspaperPosition; } }

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

        foreach (var news in newsManager.AvailableNews)
        {
            InstantiateNewspapers(news);
        }
    }
    public void RemoveNewspapers()
    {
        for (int i = 0; i < newspapersGrid.transform.childCount; i++)
        {
            Destroy(newspapersGrid.transform.GetChild(i).gameObject);
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
        newspaperRenderer.SetJournalistDesktopReference(this);
        newspaperRenderer.SetNewsReference(news);
        newspaperRenderer.transform.SetParent(newspapersGrid.transform);
        //newspaperRenderer.SetPosition(Random.insideUnitCircle * randomPositionRange);

        newspapersRenderers.Add(newspaperRenderer);
    }
}
