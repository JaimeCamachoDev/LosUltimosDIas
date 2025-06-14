using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    public float speed = 3f;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float h = 0f;
        float v = 0f;

        if (Input.GetKey(KeyCode.A)) h = -1f;
        if (Input.GetKey(KeyCode.D)) h = 1f;
        if (Input.GetKey(KeyCode.S)) v = -1f;
        if (Input.GetKey(KeyCode.W)) v = 1f;

        Vector2 dir = new Vector2(h, v);

        if (dir.sqrMagnitude > 0.01f)
        {
            if (Mathf.Abs(h) > Mathf.Abs(v))
            {
                animator.SetInteger("Direction", h > 0 ? 2 : 3); // derecha / izquierda
            }
            else
            {
                animator.SetInteger("Direction", v > 0 ? 1 : 0); // arriba / abajo
            }
        }

        animator.SetBool("IsMoving", dir.sqrMagnitude > 0.01f);

        dir.Normalize();
        transform.position += new Vector3(dir.x, dir.y, 0f) * speed * Time.deltaTime;
    }
}
