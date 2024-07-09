using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed ; //speed of camera's movement
    private float currentPosX; //position of camera
    private Vector3 velocity = Vector3.zero;

    //player camera
    [SerializeField] private Transform player;
    [SerializeField] private float lookForwardDistance; // how much far camera can look forward
    [SerializeField] private float camSpeed ; //different from above
    private float lookahead;

private void Update()
{
    //room camera
   // transform.position = Vector3.SmoothDamp(transform.position,new Vector3(currentPosX , transform.position.y , transform.position.z),ref velocity , speed );
    //1-> current position of the camera , 2 -> destination  , 3 -> velocity vector , 4-> speed of the movement ( * delta time to frame independent)
    transform.position = new Vector3 (player.position.x + lookahead , transform.position.y , transform.position.z);
    //better player camera (to have limit value to look forward)
    lookahead = Mathf.Lerp(lookahead, (lookForwardDistance * player.localScale.x), Time.deltaTime * camSpeed);
}

public void MoveToNewRoom(Transform _newRoom)
{
    currentPosX = _newRoom.position.x; //when we enter new room we should change the position of the camera to the new room
}



}
