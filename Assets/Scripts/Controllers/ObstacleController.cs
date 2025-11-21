using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<CollisionSystem>().ActCollided += killAnt;
        GetComponent<CollisionSystem>().ActTriggered += killAnt;
    }

    private void OnDisable()
    {
        GetComponent<CollisionSystem>().ActCollided -= killAnt;
        GetComponent<CollisionSystem>().ActTriggered -= killAnt;
    }
    public void killAnt(GameObject ant)
    {
        EventController.ObstacleTouchedEvent(ant);
    }
}
