
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
                nexRoom.GetComponent<Room>().ActivateRoom(true); //when enter new room active the status to activate the enemies on there.
                prevRoom.GetComponent<Room>().ActivateRoom(false); // to deactive enemies in prev room.
            }
            else
            {
                cameraa.MoveToNewRoom(prevRoom);
                nexRoom.GetComponent<Room>().ActivateRoom(false); //when enter new room active the status to activate the enemies on there.
                prevRoom.GetComponent<Room>().ActivateRoom(true); // to deactive enemies in prev room.
            
            }
        }
    }


}
