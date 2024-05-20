using UnityEngine;

public class HourGlassController : MonoBehaviour
{

    Animator animator;

    

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isMirrored", !animator.GetBool("isMirrored"));
        }
    }


    public void HourChange()
    {

        
            animator.SetBool("isMirrored", !animator.GetBool("isMirrored"));
        

    }

}
