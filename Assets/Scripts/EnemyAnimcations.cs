using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimcations : MonoBehaviour
{
    [SerializeField] EnemyWeapon weapon;

    public void EnableWeapon()
    {
        print(name + " turning on weapon");
        weapon.ColliderEnabled();
    }

    public void DisableWeapon()
    {
        weapon.ColliderEnabled(false);
    }
}