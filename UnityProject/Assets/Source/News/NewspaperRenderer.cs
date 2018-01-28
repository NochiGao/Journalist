using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NewspaperRenderer : MonoBehaviour
{
    public bool showTimeAssigned = true;
    public bool showTimesNormalized = true;

    [SerializeField] private Text titleTextUI = null;
    [SerializeField] private Text descriptionTextUI = null;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    [SerializeField] private Transform assignedTextUITransform = null;
    [SerializeField] private Text assignedTimeTextUI = null;
    [SerializeField] private Image photoImageUI = null;
=======
    [SerializeField] private float scaleOnChosen = 1.0f;
>>>>>>> Stashed changes
=======
    [SerializeField] private float scaleOnChosen = 1.0f;
>>>>>>> Stashed changes

    private News news = null;
    public News News { get { return news; } }

    private JournalistDesktopRenderer journalistDesktopRenderer = null;
    public JournalistDesktopRenderer JournalistDesktopRenderer { get { return journalistDesktopRenderer; } }
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    
    [SerializeField] private Vector3 minSize = Vector3.one * 1.25f;
    [SerializeField] private Vector3 maxSize = Vector3.one * 0.75f;

    private void Update()
    {
        transform.localScale = Vector3.Lerp(minSize, maxSize, news.NewsValues.timeAssigned);

        if (showTimeAssigned)
        {
            if (!assignedTextUITransform.gameObject.activeSelf)
            {
                assignedTextUITransform.gameObject.SetActive(true);
            }

            assignedTimeTextUI.text = news.GetAssignedTimeString(showTimesNormalized);
        }
        else
        {
            if (assignedTextUITransform.gameObject.activeSelf)
            {
                assignedTextUITransform.gameObject.SetActive(false);
            }
        }
=======
=======
>>>>>>> Stashed changes

    private Vector3 originalScale = Vector3.one;

    private void Start()
    {
        NewsManager.Instance.OnNewsChosen += OnNewsChosen;
        originalScale = transform.localScale;
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
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
        
        photoImageUI.sprite = NewsImagesDatabase.GetImage(news.Photo);

        if (photoImageUI.sprite == null)
        {
            photoImageUI.enabled = false;
        }
    }

    public void SetJournalistDesktopReference(JournalistDesktopRenderer journalistDesktopRenderer)
    {
        this.journalistDesktopRenderer = journalistDesktopRenderer;
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
