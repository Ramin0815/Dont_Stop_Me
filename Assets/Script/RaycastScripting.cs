using UnityEngine;

public class RaycastScripting : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10) && Input.GetMouseButtonDown(0))
            Debug.Log("The ray hit:" + hit.collider.gameObject.name);
        */

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            Debug.Log("hit!");
        }
    }
}
