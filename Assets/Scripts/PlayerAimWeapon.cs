using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    public Camera camera;
    public Rigidbody2D rb;
    public Animator animator;
    public Transform aimTransform;
    public SpriteRenderer weapon;
    Vector2 mousePos;
    // Update is called once per frame
    void Update()
    {
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - rb.position;

        animator.SetFloat("Horizontal", lookDir.x);
        animator.SetFloat("Vertical", lookDir.y);

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        Vector3 localScale = Vector3.one;
        if (angle > 90 || angle < -90) {
            localScale.y = -1f;
        } else {
            localScale.y = 1f;
        }
        aimTransform.localScale = localScale;


        // make weapon appear behind character
        if (angle > 0) {
            weapon.sortingOrder = 0;
        } else {
            weapon.sortingOrder = 10;
        }
    }
}
