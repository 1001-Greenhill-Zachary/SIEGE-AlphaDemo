/* -----------------------------------------------------------------------------
FILE NAME:      Utils.cs
AUTHOR:         Zach Greenhill and Curtis Burchfield
E-MAIL:         zgreenhill@nevada.unr.edu or cburchfield@nevada.unr.edu
DESCRIPTION:    Static class of uitilies for other scripts
NOTES:          
---------------------------------------------------------------------------- */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    

    public static float EPSILON = 0.01f;
    public static bool ApproximatelyEqual(float a, float b)
    {
        return Mathf.Abs(a - b) < EPSILON;
    }

    public static float Clamp(float val, float min, float max)
    {
        if (val < min)
            val = min;
        if (val > max)
            val = max;
        return val;
    }

    public static float AngleDiffPosNeg(float a, float b)
    {
        float diff = a - b;

        if (diff > 180)
            return diff - 360;
        
        if (diff < -180)
            return diff + 360;
        
        return diff;
    }

    public static float Degrees360(float angleDegrees)
    {
        while (angleDegrees >= 360)
            angleDegrees -= 360;
        while (angleDegrees < 0)
            angleDegrees += 360;
        return angleDegrees;
    }

    public static float getComponentHeading(Vector3 a, Vector3 b)
    {
        Vector3 dest = a - b;
        float x = Mathf.Abs(dest.x);
        float z = Mathf.Abs(dest.z);
        float newHeading = Mathf.Atan(x / z) * Mathf.Rad2Deg;
        if (dest.x < 0)
        {
            if (dest.z < 0)
            {
                newHeading += 180;
            }
            else
            {
                newHeading = 360 - newHeading;
            }
        }
        else if (dest.z < 0)
        {
            newHeading += 90;
        }

        return newHeading;
    }

    public static float ToDegrees(float radians)
    {
        float degrees = radians * (180 / Mathf.PI);
        //degrees = degrees + 180;
        return degrees;
    }

    public static GameObject GetTarget(string targetingMode, TowerEntity tower)
    {
        GameObject target = null;
        if (targetingMode == TowerMgr.inst.targetingModes[0])//farthestAlong
        {
            target = FindFarthestAlongEnemy(tower);
        }
        if (targetingMode == TowerMgr.inst.targetingModes[1])//mostHealth
        {
            target = FindMostHealthEnemy(tower);
        }
        if (targetingMode == TowerMgr.inst.targetingModes[2])//fastest
        {
            target = FindFastestEnemy(tower);
        }
        if (targetingMode == TowerMgr.inst.targetingModes[3])//closest
        {
            target = FindClosestEnemy(tower);
        }
        if (targetingMode == TowerMgr.inst.targetingModes[4])//leastAlong/last
        {
            target = FindLeastAlongEnemy(tower);
        }
        if (targetingMode == TowerMgr.inst.targetingModes[5])//slowest
        {
            target = FindSlowestEnemy(tower);
        }
        if (targetingMode == TowerMgr.inst.targetingModes[6])//leastHealth
        {
            target = FindLeastHealthEnemy(tower);
        }

        return target;
    }

    public static GameObject FindFarthestAlongEnemy(TowerEntity tower)
    {
        GameObject target = null;
        float farthestAlong = -1;
        Vector3 currentPosition = tower.position;
        for (int i = 0; i < EnemyMgr.inst.spawnedEnemies.Count; i++)
        {
            Vector3 direction = EnemyMgr.inst.spawnedEnemies[i].GetComponent<EnemyEntity>().position - currentPosition;
            float distanceSquaredToTarget = direction.sqrMagnitude;
            if (farthestAlong < EnemyMgr.inst.spawnedEnemies[i].GetComponent<EnemyEntity>().distanceTraveled 
                && distanceSquaredToTarget < (tower.range * tower.range))
            {
                //Debug.Log("Distance: " + distanceSquaredToTarget + "RANGE: " + tower.range);
                farthestAlong = EnemyMgr.inst.spawnedEnemies[i].GetComponent<EnemyEntity>().distanceTraveled;
                target = EnemyMgr.inst.spawnedEnemies[i];
            }
        }
        return target;
    }

    public static GameObject FindMostHealthEnemy(TowerEntity tower)
    {
        GameObject target = null;
        float mostHealth = 0;
        //float distanceSquared = Mathf.Infinity;
        Vector3 currentPosition = tower.position;
        for (int i = 0; i < EnemyMgr.inst.spawnedEnemies.Count; i++)
        {
            Vector3 direction = EnemyMgr.inst.spawnedEnemies[i].GetComponent<EnemyEntity>().position - currentPosition;
            float distanceSquaredToTarget = direction.sqrMagnitude;

            if (mostHealth < EnemyMgr.inst.spawnedEnemies[i].GetComponent<EnemyEntity>().health
                && distanceSquaredToTarget < (tower.range * tower.range))
            {
                mostHealth = EnemyMgr.inst.spawnedEnemies[i].GetComponent<EnemyEntity>().health;
                target = EnemyMgr.inst.spawnedEnemies[i];
            }
        }
        return target;
    }

    public static GameObject FindFastestEnemy(TowerEntity tower)
    {
        GameObject target = null;
        float fastestSpeed = 0;
        //float distanceSquared = Mathf.Infinity;
        Vector3 currentPosition = tower.position;
        for (int i = 0; i < EnemyMgr.inst.spawnedEnemies.Count; i++)
        {
            Vector3 direction = EnemyMgr.inst.spawnedEnemies[i].GetComponent<EnemyEntity>().position - currentPosition;
            float distanceSquaredToTarget = direction.sqrMagnitude;

            if (fastestSpeed < EnemyMgr.inst.spawnedEnemies[i].GetComponent<EnemyEntity>().speed
                && distanceSquaredToTarget < (tower.range * tower.range))
            {
                fastestSpeed = EnemyMgr.inst.spawnedEnemies[i].GetComponent<EnemyEntity>().speed;
                target = EnemyMgr.inst.spawnedEnemies[i];
            }
        }
        return target;
    }

    public static GameObject FindClosestEnemy(TowerEntity tower)
    {
        GameObject closestTarget = null;
        float distanceSquared = Mathf.Infinity;
        Vector3 currentPosition = tower.position;
        for (int i = 0; i < EnemyMgr.inst.spawnedEnemies.Count; i++)
        {
            Vector3 direction = EnemyMgr.inst.spawnedEnemies[i].GetComponent<EnemyEntity>().position - currentPosition;
            float distanceSquaredToTarget = direction.sqrMagnitude;
            if (distanceSquaredToTarget < distanceSquared && distanceSquaredToTarget < (tower.range * tower.range))
            {
                distanceSquared = distanceSquaredToTarget;
                closestTarget = EnemyMgr.inst.spawnedEnemies[i];
            }
        }
        return closestTarget;
    }

    public static GameObject FindLeastAlongEnemy(TowerEntity tower)
    {
        GameObject target = null;
        float leastAlong = Mathf.Infinity;
        //float distanceSquared = Mathf.Infinity;
        Vector3 currentPosition = tower.position;
        for (int i = 0; i < EnemyMgr.inst.spawnedEnemies.Count; i++)
        {
            Vector3 direction = EnemyMgr.inst.spawnedEnemies[i].GetComponent<EnemyEntity>().position - currentPosition;
            float distanceSquaredToTarget = direction.sqrMagnitude;

            if (leastAlong > EnemyMgr.inst.spawnedEnemies[i].GetComponent<EnemyEntity>().distanceTraveled
                && distanceSquaredToTarget < (tower.range * tower.range))
            {
                leastAlong = EnemyMgr.inst.spawnedEnemies[i].GetComponent<EnemyEntity>().distanceTraveled;
                target = EnemyMgr.inst.spawnedEnemies[i];
            }
        }
        return target;
    }

    public static GameObject FindSlowestEnemy(TowerEntity tower)
    {
        GameObject target = null;
        float slowestSpeed = Mathf.Infinity;
        //float distanceSquared = Mathf.Infinity;
        Vector3 currentPosition = tower.position;
        for (int i = 0; i < EnemyMgr.inst.spawnedEnemies.Count; i++)
        {
            Vector3 direction = EnemyMgr.inst.spawnedEnemies[i].GetComponent<EnemyEntity>().position - currentPosition;
            float distanceSquaredToTarget = direction.sqrMagnitude;

            if (slowestSpeed > EnemyMgr.inst.spawnedEnemies[i].GetComponent<EnemyEntity>().speed
                && distanceSquaredToTarget < (tower.range * tower.range))
            {
                slowestSpeed = EnemyMgr.inst.spawnedEnemies[i].GetComponent<EnemyEntity>().speed;
                target = EnemyMgr.inst.spawnedEnemies[i];
            }
        }
        return target;
    }

    public static GameObject FindLeastHealthEnemy(TowerEntity tower)
    {
        GameObject target = null;
        float leastHealth = Mathf.Infinity;
        //float distanceSquared = Mathf.Infinity;
        Vector3 currentPosition = tower.position;
        for (int i = 0; i < EnemyMgr.inst.spawnedEnemies.Count; i++)
        {
            Vector3 direction = EnemyMgr.inst.spawnedEnemies[i].GetComponent<EnemyEntity>().position - currentPosition;
            float distanceSquaredToTarget = direction.sqrMagnitude;

            if (leastHealth > EnemyMgr.inst.spawnedEnemies[i].GetComponent<EnemyEntity>().health
                && distanceSquaredToTarget < (tower.range * tower.range))
            {
                leastHealth = EnemyMgr.inst.spawnedEnemies[i].GetComponent<EnemyEntity>().health;
                target = EnemyMgr.inst.spawnedEnemies[i];
            }
        }
        return target;
    }


}
