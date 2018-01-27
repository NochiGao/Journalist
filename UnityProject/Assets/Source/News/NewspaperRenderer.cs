using UnityEngine;
using UnityEngine.UI;

public class NewspaperRenderer : MonoBehaviour
{
    [SerializeField] private Text titleTextUI = null;
    [SerializeField] private Text descriptionTextUI = null;

    private News news = null;
    public News News { get { return news; } }

    private JournalistDesktopRenderer journalistDesktopRenderer = null;
    public JournalistDesktopRenderer JournalistDesktopRenderer { get { return journalistDesktopRenderer; } }
    
    [SerializeField] private Vector3 minSize = Vector3.one * 1.25f;
    [SerializeField] private Vector3 maxSize = Vector3.one * 0.75f;

    private void Update()
    {
        transform.localScale = Vector3.Lerp(minSize, maxSize, news.NewsValues.timeAssigned);
    }

    public void SetPosition(Vector2 position, Space space = Space.Self)
    {
        switch (space)
        {
            case Space.World:
                transform.position = position;
                break;
            case Space.Self:
                transform.localPosition = position;
                break;
            default:
                break;
        }
    }

    public void SetNewsReference(News news)
    {
        this.news = news;

        titleTextUI.text = news.Title;
        descriptionTextUI.text = news.Description;
    }

    public void SetJournalistDesktopReference(JournalistDesktopRenderer journalistDesktopRenderer)
    {
        this.journalistDesktopRenderer = journalistDesktopRenderer;
    }
}
