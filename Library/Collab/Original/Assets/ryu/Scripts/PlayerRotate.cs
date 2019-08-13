using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            MoveObject();
        }

        MouseRotation();
    }

    void MoveObject()
    {
        float keyHorizontal = Input.GetAxis("Horizontal");
        float keyVertical = Input.GetAxis("Vertical");

        transform.Translate(Vector2.right * speed * Time.smoothDeltaTime * keyHorizontal, Space.World);
        transform.Translate(Vector2.up * speed * Time.smoothDeltaTime * keyVertical, Space.World);
    }

    void MouseRotation()
    {
        Vector3 mPosition = Input.mousePosition;
        Vector3 oPosition = transform.position;

        mPosition.z = oPosition.z - Camera.main.transform.position.z;

        Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);

        float dy = target.y - oPosition.y;
        float dx = target.x - oPosition.x;

        float rotateDegree = ((Mathf.Atan2(dy, dx) * Mathf.Rad2Deg) - 56.432f - 71.553f + 55.359f - 18f);

        if (rotateDegree <= -75.0f)
        {
            rotateDegree = -75.0f;
        }
        else if (rotateDegree >= 75.0f)
        {
            rotateDegree = 75.0f;
        }

        transform.rotation = Quaternion.Euler(0f, 0f, rotateDegree);
    }
}
