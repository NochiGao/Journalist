using UnityEngine;
using UnityEngine.UI;

public class NewspaperRenderer : MonoBehaviour
{
    [SerializeField] private Text titleTextUI = null;
    [SerializeField] private Text descriptionTextUI = null;
    [SerializeField] private float scaleOnChosen = 1.0f;

    private News news = null;
    public News News { get { return news; } }

    private JournalistDesktopRenderer journalistDesktopRenderer = null;
    public JournalistDesktopRenderer JournalistDesktopRenderer { get { return journalistDesktopRenderer; } }

    private Vector3 originalScale = Vector3.one;

    private void Start()
    {
        NewsManager.Instance.OnNewsChosen += OnNewsChosen;
        originalScale = transform.localScale;
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

    public void OnNewsChosen(News news)
    {
        if (news == this.news)
        {
            //SetPosition(journalistDesktopRenderer.ChosenNewspaperPosition, Space.World);
            transform.localScale = originalScale * scaleOnChosen;
        }
    }

    private void OnDestroy()
    {
        NewsManager.Instance.OnNewsChosen -= OnNewsChosen;
    }
}
