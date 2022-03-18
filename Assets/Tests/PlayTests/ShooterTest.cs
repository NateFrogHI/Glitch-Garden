using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    [TestFixture]
    public class ShooterTest
    {
        const string PROJECTILE_PARENT_NAME = "Projectiles";

        private Shooter CreateNewShooter()
        {
            GameObject gameObject = new GameObject();
            Shooter shooter = gameObject.AddComponent<Shooter>();
            shooter.gameObject.AddComponent<Animator>();
            return shooter;
        }

        [UnityTest]
        public IEnumerator FireCreatesProjectile()
        {
            GameObject gun = new GameObject();
            GameObject gameObject = new GameObject();
            Projectile projectile = gameObject.AddComponent<Projectile>();
            Shooter shooter = CreateNewShooter();
            shooter.SetTestVariables(projectile, gun);

            // Wait one frame Shooter's start method to run
            yield return null;

            GameObject projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
            Assert.AreEqual(projectileParent.transform.childCount, 0);
            shooter.Fire();
            Assert.AreEqual(projectileParent.transform.childCount, 1);
        }
    }
}
