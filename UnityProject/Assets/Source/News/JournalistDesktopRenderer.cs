using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalistDesktopRenderer : MonoBehaviour
{
    [SerializeField] private List<NewspaperRenderer> newspapersRendererPrefabs = new List<NewspaperRenderer>();
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    [SerializeField] private NewspapersPositioningService newspapersPositioning = null;
    
=======
=======
>>>>>>> Stashed changes
    //[SerializeField] private float randomPositionRange = 10;
    [SerializeField] private GridLayoutGroup newspapersGrid = null;
    [SerializeField] private Vector3 chosenNewspaperPosition = Vector3.zero;
    public Vector3 ChosenNewspaperPosition { get { return chosenNewspaperPosition; } }

>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
<<<<<<< Updated upstream
        for (int i = 0; i < newsManager.AvailableNews.Count; i++)
=======
=======
>>>>>>> Stashed changes
        foreach (var news in newsManager.AvailableNews)
>>>>>>> Stashed changes
        {
            InstantiateNewspapers(newsManager.AvailableNews[i], i);
        }
    }
    public void RemoveNewspapers()
    {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        newspapersRenderers.ForEach(newspapers => Destroy(newspapers.gameObject));
        newspapersRenderers.Clear();
=======
=======
>>>>>>> Stashed changes
        for (int i = 0; i < newspapersGrid.transform.childCount; i++)
        {
            Destroy(newspapersGrid.transform.GetChild(i).gameObject);
        }
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
        newspaperRenderer.transform.SetParent(newspapersGrid.transform);
        //newspaperRenderer.SetPosition(Random.insideUnitCircle * randomPositionRange);
>>>>>>> Stashed changes
=======
        newspaperRenderer.transform.SetParent(newspapersGrid.transform);
        //newspaperRenderer.SetPosition(Random.insideUnitCircle * randomPositionRange);
>>>>>>> Stashed changes

        newspapersPositioning.PositionPapersRandom(newspaperRenderer, forIndex);
        newspapersRenderers.Add(newspaperRenderer);
    }
}
