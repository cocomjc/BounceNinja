using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 touchPos = touch.position;
                float dist = Vector3.Dot(transform.position - Camera.main.transform.position, Camera.main.transform.forward);
                touchPos.z = dist;
                touchPos = Camera.main.ScreenToWorldPoint(touchPos);
                touchPos.z = transform.position.z;
                GetComponent<PlayerManager>().MovePlayer(touchPos);
            }
        }
    }
}
