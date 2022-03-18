using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ProjectileTest
    {
        [UnityTest]
        public IEnumerator ProjectileHasDefaultDamage()
        {
            GameObject gameObject = new GameObject();
            Projectile projectile = gameObject.AddComponent<Projectile>();

            // Use this if you need to wait for something to happen like animated movement
            yield return null;

            Assert.AreEqual(10f, projectile.GetDamage());
        }
        [UnityTest]
        public IEnumerator ProjectileMovesRight()
        {
            GameObject gameObject = new GameObject();
            Projectile projectile = gameObject.AddComponent<Projectile>();
            Vector3 initialPos = projectile.transform.position;

            // Use this if you need to wait for something to happen like animated movement
            yield return null;

            Vector3 newPos = projectile.transform.position;
            Assert.That(initialPos.x < newPos.x);
        }
    }
}
