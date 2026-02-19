using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    [SerializeField] private GameObject a;

    private Rigidbody rb;
    private float speed=1;
    private float horizontal = 0;
    private float vertical = 0;

    void Awake(){
        Debug.Log("Awake!");
        rb = a.GetComponent<Rigidbody>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void Update(){
        horizontal = -Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate(){
        rb.AddTorque(transform.forward*horizontal, ForceMode.Force);
        rb.AddTorque(transform.right*vertical, ForceMode.Force);
    }


}
