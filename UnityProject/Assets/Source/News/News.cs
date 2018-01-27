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

public struct NewsValues
{
    public NewsWeight opWeight;
    public NewsWeight ofWeight;
    public NewsWeight conversionWeight;
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

    public News(string title, string description, float minOpWeight, float maxOpWeight, float minOfWeight, float maxOfWeight, float minConversionWeight, float maxConversionWeight)
    {
        this.title = title;
        this.description = description;

        newsValues = new NewsValues
        {
            opWeight = new NewsWeight(minOpWeight, maxOpWeight),
            ofWeight = new NewsWeight(minOfWeight, maxOfWeight),
            conversionWeight = new NewsWeight(minConversionWeight, maxConversionWeight)
        };
    }
}
