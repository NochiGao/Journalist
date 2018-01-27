using UnityEngine;
using UnityEngine.UI;

public class NewspaperRenderer : MonoBehaviour
{
    [SerializeField] private Text titleTextUI = null;
    [SerializeField] private Text descriptionTextUI = null;

    private News news = null;
    public News News { get { return news; } }
    
    public void SetPosition(Vector2 position)
    {
        transform.localPosition = position;
    }

    public void SetNewsReference(News news)
    {
        this.news = news;

        titleTextUI.text = news.Title;
        descriptionTextUI.text = news.Description;
    }
}
