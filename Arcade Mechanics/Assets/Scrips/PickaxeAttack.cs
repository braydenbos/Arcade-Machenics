using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickaxeAttack : MonoBehaviour
{
    public Animator animator;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("enemie") && animator.GetCurrentAnimatorStateInfo(0).IsName("Armature|attack"))
        {
            GameObject enemy = collision.collider.gameObject;

            CapsuleCollider capsuleCollider = enemy.GetComponent<CapsuleCollider>();
            Destroy(capsuleCollider);

            Rigidbody rigidbody = enemy.GetComponent<Rigidbody>();
            Destroy(rigidbody);

            Animator animatorEnemie = enemy.GetComponent<Animator>();
            Destroy(animatorEnemie);

            enemy.AddComponent<SelfDistruct>();
        }
    }
}
