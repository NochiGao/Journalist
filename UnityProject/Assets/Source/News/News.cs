using System.Collections.Generic;

public struct NewsWeight
{
    private UnityEngine.Vector2 weightRange;
    public UnityEngine.Vector2 WeightRange { get { return weightRange; } }

    private float actualWeight;
    public float ActualWeight { get { return actualWeight; } }

    public NewsWeight(float minRange, float maxRange)
    {
        weightRange = new UnityEngine.Vector2(minRange, maxRange);
        actualWeight = UnityEngine.Random.Range(weightRange.x, weightRange.y);
    }
}

public class NewsValues
{
    public NewsWeight opWeight;
    public NewsWeight ofWeight;
    public NewsWeight conversionWeight;
	public float timeAssigned;
}

public class NewsRequisites
{
    public int day;
    public List<int> requiredIDs;
    public List<int> excludedIDs;
}

public class News
{
    public int ID;

    private string title = string.Empty;
    public string Title { get { return title; } }

    private string description = string.Empty;
    public string Description { get { return description; } }

    private string photo = string.Empty;
    public string Photo { get { return photo;} }
    
    private NewsValues newsValues = new NewsValues();
	public NewsValues NewsValues { get { return newsValues; } set { newsValues = value;}}

    private NewsRequisites newsRequisites = new NewsRequisites();
    public NewsRequisites NewsRequisites { get { return newsRequisites; } set { newsRequisites = value; } }

    public News(int ID, string title, string description, NewsValues newsValues, NewsRequisites newsRequisites )
    {
        this.ID = ID;
        this.title = title;
        this.description = description;
        this.newsValues = newsValues;
        this.newsRequisites = newsRequisites;
    }

    public News(int ID, string title, string description, string photo,
        double minOpWeight, double maxOpWeight, double minOfWeight, double maxOfWeight, double minConversionWeight, double maxConversionWeight,
        int requiredDay, List<int> requireds, List<int> excludeds )
    {
        this.title = title;
        this.description = description;
        this.photo = photo;

        newsValues = new NewsValues
        {
            opWeight = new NewsWeight((float)minOpWeight, (float)maxOpWeight),
            ofWeight = new NewsWeight((float)minOfWeight, (float)maxOfWeight),
            conversionWeight = new NewsWeight((float)minConversionWeight, (float)maxConversionWeight),
			timeAssigned = 1
        };

        NewsRequisites = new NewsRequisites
        {
            day = requiredDay,
            requiredIDs = requireds,
            excludedIDs = excludeds
        };
    }

    public string GetAssignedTimeString(bool normalized)
    {
        return normalized ? UnityEngine.Mathf.RoundToInt((newsValues.timeAssigned * 100)).ToString() + "%" : UnityEngine.Mathf.RoundToInt(UnityEngine.Mathf.Lerp(0, 60, newsValues.timeAssigned)).ToString() + " mins";
    }
}
