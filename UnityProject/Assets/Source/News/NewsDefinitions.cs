public static class NewsDefinitions
{
    private static News[] definedNews =
    {
        new News("Ultimo Momento", "Exploto el verano", 0.0f, 0.5f, 0.0f, 0.5f, 0.0f, 0.5f),
    };

    public static News[] GetNewsDatabase()
    {
        if (definedNews != null)
        {
            return definedNews;
        }

        return new News[0];
    }
}
