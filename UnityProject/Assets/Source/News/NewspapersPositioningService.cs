using UnityEngine;

public class NewspapersPositioningService : MonoBehaviour
{
    [SerializeField] private Transform newsAPositions;
    [SerializeField] private Transform newsBPositions;
    [SerializeField] private Transform newsCPositions;

    public void PositionPapersRandom(NewspaperRenderer newspapers, int forRandom)
    {
        Transform targetPositionParent = null;
        switch (forRandom)
        {
            case 0:
                targetPositionParent = newsAPositions;
                break;
            case 1:
                targetPositionParent = newsBPositions;
                break;
            case 2:
                targetPositionParent = newsCPositions;
                break;
        }
        if (targetPositionParent == null)
        {
            Debug.LogWarning("Couln't find a proper allocation for newspapers");
            return;
        }
        
        Transform targetTransform = targetPositionParent.GetChild(Random.Range(0, targetPositionParent.childCount));
        if (targetTransform == null)
        {
            Debug.LogWarning("Couln't find a proper allocation for newspapers");
            return;
        }
        newspapers.transform.SetParent(targetTransform, false);
    }
}
