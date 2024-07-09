using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed ; //speed of camera's movement
    private float currentPosX; //position of camera
    private Vector3 velocity = Vector3.zero;

private void Update()
{
    transform.position = Vector3.SmoothDamp(transform.position,new Vector3(currentPosX , transform.position.y , transform.position.z),ref velocity , speed * Time.deltaTime);
    //1-> current position of the camera , 2 -> destination  , 3 -> velocity vector , 4-> speed of the movement ( * delta time to frame independent)
}

public void MoveToNewRoom(Transform _newRoom)
{
    currentPosX = _newRoom.position.x; //when we enter new room we should change the position of the camera to the new room
}



}
