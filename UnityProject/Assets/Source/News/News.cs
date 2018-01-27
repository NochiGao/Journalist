public struct NewsWeight
{
    private UnityEngine.Vector2 weightRange;
    public UnityEngine.Vector2 WeightRange { get { return weightRange; } }

    private float actualWeight;
    public float ActualWeight { get { return actualWeight; } }

	private bool visited;

    public NewsWeight(float minRange, float maxRange)
    {
        weightRange = new UnityEngine.Vector2(minRange, maxRange);
        actualWeight = UnityEngine.Random.Range(weightRange.x, weightRange.y);
    }
}

public struct NewsValues
{
    public NewsWeight opWeight;
    public NewsWeight ofWeight;
    public NewsWeight conversionWeight;
	public float timeAssigned;
}

public class News
{
    private string title = string.Empty;
    public string Title { get { return title; } }

    private string description = string.Empty;
    public string Description { get { return description; } }

    private NewsValues newsValues = new NewsValues();
    public NewsValues NewsValues { get { return newsValues; } }

    public News(string title, string description, NewsValues newsValues)
    {
        this.title = title;
        this.description = description;
        this.newsValues = newsValues;
    }

    public News(string title, string description, double minOpWeight, double maxOpWeight, double minOfWeight, double maxOfWeight, double minConversionWeight, double maxConversionWeight)
    {
        this.title = title;
        this.description = description;

        newsValues = new NewsValues
        {
            opWeight = new NewsWeight((float)minOpWeight, (float)maxOpWeight),
            ofWeight = new NewsWeight((float)minOfWeight, (float)maxOfWeight),
            conversionWeight = new NewsWeight((float)minConversionWeight, (float)maxConversionWeight)
        };
    }
}
