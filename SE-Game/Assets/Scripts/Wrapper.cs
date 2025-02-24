using UnityEngine;

public class Wrapper : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Convert world point to Viewport so it's in 0->1 range.
        Vector2 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        // If it's moved out of the viewport wrap to opposite side.
        Vector2 moveAdjustment = Vector2.zero;
        if (viewportPosition.x < 0)
        {
            moveAdjustment.x += 1;
        }
        else if (viewportPosition.x > 1)
        {
            moveAdjustment.x -= 1;
        }
        else if (viewportPosition.y < 0)
        {
            moveAdjustment.y += 1;
            Destroy(gameObject);
        }
        else if (viewportPosition.y > 1)
        {
            //moveAdjustment.y -= 1;
        }

        // Convert back into world coordinates before assigning.
        transform.position = Camera.main.ViewportToWorldPoint(viewportPosition + moveAdjustment);
    }
}
