using UnityEngine;

public class PlanetRotate : MonoBehaviour
{
    public float rotatePerSec = 0.2f;
    public Vector3 pivot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(pivot*Time.deltaTime*360*rotatePerSec);
    }
}
