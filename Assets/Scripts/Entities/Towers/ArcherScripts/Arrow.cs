using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private Vector2 endLocation;
    [SerializeField]
    private int flightDuration;

    private Vector2 vectorChange;
    private int frames = 0;

    public Vector2 EndLocation { get => endLocation; set => endLocation = value; }
    public int FlightDuration { get => flightDuration; set => flightDuration = value; }

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        vectorChange = new Vector2(EndLocation.x - transform.position.x, EndLocation.y - transform.position.y);
        vectorChange = vectorChange * (1f / (float)FlightDuration);

        Quaternion newRotation = Quaternion.LookRotation(Vector3.forward,vectorChange);
        newRotation = Quaternion.Euler(new Vector3(0, 0, newRotation.eulerAngles.z + 90));
        transform.rotation = newRotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(vectorChange.x, vectorChange.y, 0);
        if(frames > FlightDuration)
        {
            Destroy(gameObject);
        }
        frames++;
    }
}
