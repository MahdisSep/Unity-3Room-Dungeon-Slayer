
using UnityEngine;

public class door : MonoBehaviour
{
    [SerializeField] private Transform prevRoom;
    [SerializeField] private Transform nexRoom;
    [SerializeField]private CameraController cameraa;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(collision.transform.position.x < transform.position.x)
            {
                cameraa.MoveToNewRoom(nexRoom);
            }
            else
            {
                cameraa.MoveToNewRoom(prevRoom);
            }
        }
    }


}
