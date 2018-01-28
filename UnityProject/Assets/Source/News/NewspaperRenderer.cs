using UnityEngine;
using UnityEngine.UI;

public class NewspaperRenderer : MonoBehaviour
{
    public bool showTimeAssigned = true;
    public bool showTimesNormalized = true;
	public GameObject redCross;

    [SerializeField] private Text titleTextUI = null;
    [SerializeField] private Text descriptionTextUI = null;
    [SerializeField] private Transform assignedTextUITransform = null;
    [SerializeField] private Text assignedTimeTextUI = null;

    [Space]
    [SerializeField] private Transform photoFrame = null;
    [SerializeField] private Image photoImageUI = null;
    [SerializeField] private Transform hiddenPhotoTransform = null;
    [SerializeField] private Transform shownPhotoTransform = null;

    private News news = null;
    public News News { get { return news; } }

    private JournalistDesktopRenderer journalistDesktopRenderer = null;
    public JournalistDesktopRenderer JournalistDesktopRenderer { get { return journalistDesktopRenderer; } }

    private bool hasPhoto = false;
    
    [SerializeField] private Vector3 minSize = Vector3.one * 1.25f;
    [SerializeField] private Vector3 maxSize = Vector3.one * 0.75f;

    private void Update()
    {
        transform.localScale = Vector3.Lerp(minSize, maxSize, news.NewsValues.timeAssigned);

		if (news.GetAssignedTimeString (showTimesNormalized) == "0 mins") {
			redCross.SetActive (true);
			showTimeAssigned = false;
		} else {
			redCross.SetActive (false);
			showTimeAssigned = true;
		}

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
    }
    
    public void SetNewsReference(News news)
    {
        this.news = news;

        titleTextUI.text = news.Title;
        descriptionTextUI.text = news.Description;
        
        photoImageUI.sprite = NewsImagesDatabase.GetImage(news.Photo);

        if (photoImageUI.sprite == null)
        {
            photoFrame.gameObject.SetActive(false);
            hasPhoto = false;
        }

        hasPhoto = true;
    }

    public void SetJournalistDesktopReference(JournalistDesktopRenderer journalistDesktopRenderer)
    {
        this.journalistDesktopRenderer = journalistDesktopRenderer;
    }

    public void ShowPhoto()
    {
        photoFrame.SetParent(shownPhotoTransform, false);
    }

    public void HidePhoto()
    {
        photoFrame.SetParent(hiddenPhotoTransform, false);
    }
}
