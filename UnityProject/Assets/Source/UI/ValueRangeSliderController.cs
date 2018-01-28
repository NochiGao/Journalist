using UnityEngine;
using UnityEngine.UI;

public class ValueRangeSliderController : MonoBehaviour
{
    [SerializeField] private Slider minSlider = null;
    [SerializeField] private Slider maxSlider = null;
    
    private Vector3 newsTimesValues = Vector3.one * 0.33f;
    public bool debugLog = true;
    public bool resetSlidersOnNewsRefresh = true;

    [SerializeField][MinMaxCustomSlider] private ValueRange valueRange = null;

    float previousMaxSliderValue = 0.0f;

    private void Start()
    {
        minSlider.value = valueRange.MinValue;
        maxSlider.value = valueRange.MaxValue;
        previousMaxSliderValue = maxSlider.value;

        NewsManager.Instance.OnAvailableNewsRefreshed += OnAvailableNewsRefreshed;
    }

    private void OnAvailableNewsRefreshed()
    {
        if (resetSlidersOnNewsRefresh)
        {
            minSlider.value = 0.33f;
            maxSlider.value = 0.66f;
        }
    }

    private void Update()
    {
        float minSliderPreviousValue = minSlider.value;
        minSlider.value = Mathf.Clamp(minSlider.value, 0.0f, previousMaxSliderValue);
        maxSlider.value = Mathf.Clamp(maxSlider.value, minSlider.value, 1.0f);
        previousMaxSliderValue = maxSlider.value;

        newsTimesValues = new Vector3(minSlider.value, maxSlider.value - minSlider.value, 1.0f - maxSlider.value);
        if(debugLog) Debug.Log(newsTimesValues + " total: " + (newsTimesValues.x + newsTimesValues.y + newsTimesValues.z));

        AssignTimes();
    }

    private void AssignTimes()
    {
        if (NewsManager.Instance.AvailableNews.Count == 3)
        {
            NewsManager.Instance.SetTime(0, newsTimesValues.x);
            NewsManager.Instance.SetTime(1, newsTimesValues.y);
            NewsManager.Instance.SetTime(2, newsTimesValues.z);
        }
    }
}
