using UnityEngine;

public class HammerController : MonoBehaviour
{   
    public bool leftSide;
    void Start()
    {
        if (leftSide)
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, -10f);
        else
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 10f);
    }
}
