using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Projectile projectile;
    [SerializeField] GameObject gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if(IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            float spawnerPosDiff = Mathf.Abs(spawner.transform.position.y - transform.position.y);
            bool IsCloseEnough = (spawnerPosDiff <= Mathf.Epsilon);

            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if (!myLaneSpawner || myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        return true;

    }

    public void Fire()
    {
        Projectile newProjectile = Instantiate(projectile, gun.transform.position, transform.rotation);
        newProjectile.transform.parent = projectileParent.transform;
    }

#if UNITY_EDITOR
    public void SetTestVariables(Projectile testProjectile, GameObject testGun)
    {
        projectile = testProjectile;
        gun = testGun;
    }
#endif
}
