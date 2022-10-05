using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraController cam;

    private void GoNextStaging(Collider2D collision)
    {
        GoNextStage(collision);
    }





private void GoNextStage(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x)
                cam.MoveToNewRoom(nextRoom);
            else
                cam.MoveToNewRoom(previousRoom);
        }
    }
}
