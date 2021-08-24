using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Rigidbody2D rb;
    [SerializeField] float speed = 5;

    [SerializeField] private Vector2 leftGroundDetector = Vector2.zero;
    [SerializeField] private Vector2 rightGroundDetector = Vector2.zero;
    [SerializeField] private float overlapRadius = 1;
    [SerializeField] private float AttackRadius = 1;
    [SerializeField] private float retreatRadius = 1;


    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask playerLayer;


    private void Update()
    {
        if (CheckPlayerDistance(AttackRadius))
        {
            if (CheckPlayerDistance(retreatRadius))
            {
                Flee();
            }
            else
            {
                Attack();
            }
            if (Vector2.Distance(Physics2D.OverlapCircle((Vector2)this.transform.position, AttackRadius, playerLayer).gameObject.transform.position,(Vector2)this.gameObject.transform.position)<retreatRadius+1 && Vector2.Distance(Physics2D.OverlapCircle((Vector2)this.transform.position, AttackRadius, playerLayer).gameObject.transform.position, (Vector2)this.gameObject.transform.position) > retreatRadius - 1)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

              
            
    }




    private List<Vector2> CheckIfCanMove()
    {
        List<Vector2> moveableDirections = new List<Vector2>();
        if (Physics2D.OverlapCircle((Vector2)this.transform.position + leftGroundDetector, overlapRadius, groundLayer))
        {
            moveableDirections.Add( Vector2.left);
        }
        if (Physics2D.OverlapCircle((Vector2)this.transform.position + rightGroundDetector, overlapRadius, groundLayer))
        {
            moveableDirections.Add( Vector2.right);
        }
        if(moveableDirections.Count==0)
        {
            return null;
        }
        return moveableDirections;
    }

    private bool CheckPlayerDistance(float radius)
    {
        if (Physics2D.OverlapCircle((Vector2)this.transform.position, radius, playerLayer))
        {
            return true;
        }
        else
            return false;
    }

    private void Flee()
    {
        List<Vector2> directions = CheckIfCanMove();
        if (directions.Count == 2)
        {
            GameObject gb = Physics2D.OverlapCircle((Vector2)this.transform.position, AttackRadius, playerLayer).gameObject;
            if (gb.transform.position.x < this.transform.position.x)
            {
                rb.velocity = (new Vector2(Vector2.right.x * speed, rb.velocity.y));
            }
            else
            {
                rb.velocity = (new Vector2(Vector2.left.x * speed, rb.velocity.y));
            }
        }
        else
        {
            rb.velocity = (new Vector2(directions[0].x * speed, rb.velocity.y));
        }
        
    }

    private void Attack()
    {

            GameObject gb = Physics2D.OverlapCircle((Vector2)this.transform.position, AttackRadius, playerLayer).gameObject;
            if (gb.transform.position.x < this.transform.position.x)
            {
                rb.velocity = (new Vector2(Vector2.left.x * speed, rb.velocity.y));
            }
            else
            {
                rb.velocity = (new Vector2(Vector2.right.x * speed, rb.velocity.y));
            }
        

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector2)this.transform.position + leftGroundDetector, overlapRadius);
        Gizmos.DrawWireSphere((Vector2)this.transform.position + rightGroundDetector, overlapRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere((Vector2)this.transform.position, AttackRadius);

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere((Vector2)this.transform.position, retreatRadius);

    }

}
