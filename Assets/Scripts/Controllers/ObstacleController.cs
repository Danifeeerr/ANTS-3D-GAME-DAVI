using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private void Start()
    {
        GetComponent<CollisionSystem>().ActCollided += killAnt;
        GetComponent<CollisionSystem>().ActTriggered += killAnt;
    }
    public void killAnt(GameObject ant)
    {
        EventController.ObstacleTouchedEvent(ant);
    }
}
