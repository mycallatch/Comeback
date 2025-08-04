using UnityEngine;

public class Camera : MonoBehaviour {
    [SerializeField]

    private Transform target;

    // Update is called once per frame
    void Update() {
        Vector3 position = transform.position;
        position.x = target.position.x;
        transform.position = position;
    }
}
