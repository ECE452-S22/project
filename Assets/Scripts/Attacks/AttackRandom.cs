using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRandom : Attack
{
    public static void ShootOnDemand(GameObject enemy, GameObject missile, float shootSpeed, Transform shootPos) 
    {
        List<int> randomList = new List<int>();
        while (randomList.Count < 5)
        {
            int angle = 0;
            System.Random r = new System.Random();
            angle = r.Next(0, 360);
            if (!randomList.Contains(angle))
            {
                randomList.Add(angle);
                GameObject newMissile = Instantiate(missile, shootPos.position, Quaternion.identity) as GameObject;
                newMissile.GetComponent<Rigidbody2D>().velocity = new Vector2(-shootSpeed * Time.fixedDeltaTime * Mathf.Cos((angle * Mathf.PI) / 180), -shootSpeed * Time.fixedDeltaTime * Mathf.Sin((angle * Mathf.PI) / 180));
                newMissile.transform.SetParent(GameObject.Find(Constants.CANVAS_OBJECT).transform, true);
                newMissile.transform.SetSiblingIndex(4);
                EnemyAI.laserSound.Play();
            }
        }
    }

    public static IEnumerator ShootInWaves(GameObject enemy, GameObject missile, float delay, int ammo, float shootSpeed, Transform shootPos)
    {
        while (ammo > 0)
        {
            ShootOnDemand(enemy, missile, shootSpeed, shootPos);
            ammo -= 1;
            yield return new WaitForSeconds(delay);
        }
        enemy.SendMessage(Constants.EMPTY_AMMO, 0);
    }
}
