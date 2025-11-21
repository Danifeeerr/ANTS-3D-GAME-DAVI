using System.Collections.Generic;
using UnityEngine;

public class FormationController : MonoBehaviour
{
    public List<Transform> followers = new List<Transform>();

    public int columns = 4;         // Cuántos por fila
    public float spacingX = 5f;   // Distancia lateral
    public float spacingZ = 5f;   // Distancia detrás del player
    public float smooth = 5f;

    private void Update()
    {
        UpdateFormation();
    }


    void UpdateFormation()
    {
        for (int i = 0; i < followers.Count; i++)
        {
            int column = i % columns;          
            int row = i / columns;             
    
            Vector3 offset = (-transform.forward * (row + 1) * spacingZ) + (transform.right * (column - (columns-1)/2f) * spacingX);

            Vector3 targetPos = transform.position + offset;
        
            followers[i].position = Vector3.Lerp(
                followers[i].position,
                targetPos,
                Time.deltaTime * smooth
            );
        }
    }

    public void AddFollower(Transform f)
    {
        followers.Add(f);
        EventController.FollowersUpdateEvent(followers.Count);
    }

    public void RemoveFollower(Transform f)
    {
        followers.Remove(f);
        EventController.FollowersUpdateEvent(followers.Count);
    }

    public float getParticipants()
    {
        return followers.Count;
    }
}
