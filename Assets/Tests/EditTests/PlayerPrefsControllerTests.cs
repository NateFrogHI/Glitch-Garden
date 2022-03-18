using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    [TestFixture]
    public class PlayerPrefsControllerTests
    {
        const string MASTER_VOLUME_KEY = "master volume";
        const string DIFFICULTY_KEY = "difficulty";

        [SetUp]
        public void Init()
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, 0f);
            PlayerPrefs.SetInt(DIFFICULTY_KEY, 0);
        }

        [Test]
        public void GetMasterVolume()
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, .3f);
            Assert.AreEqual(.3f, PlayerPrefsController.GetMasterVolume());
        }

        [Test]
        public void SetMasterVolumeBelowLimit()
        {
            LogAssert.Expect(LogType.Error, "Master volume is out of range");
            PlayerPrefsController.SetMasterVolume(-.1f);
        }

        [Test]
        public void SetMasterVolumeLowLimit()
        {
            PlayerPrefsController.SetMasterVolume(0f);
            Assert.AreEqual(0f, PlayerPrefs.GetFloat(MASTER_VOLUME_KEY));
        }

        [Test]
        public void SetMasterVolumeMidRange()
        {
            PlayerPrefsController.SetMasterVolume(.5f);
            Assert.AreEqual(.5f, PlayerPrefs.GetFloat(MASTER_VOLUME_KEY));
        }

        [Test]
        public void SetMasterVolumeHighLimit()
        {
            PlayerPrefsController.SetMasterVolume(1f);
            Assert.AreEqual(1f, PlayerPrefs.GetFloat(MASTER_VOLUME_KEY));
        }

        [Test]
        public void SetMasterVolumeAboveLimit()
        {
            LogAssert.Expect(LogType.Error, "Master volume is out of range");
            PlayerPrefsController.SetMasterVolume(1.1f);
        }

        [Test]
        public void GetDifficulty()
        {
            PlayerPrefs.SetInt(DIFFICULTY_KEY, 2);
            Assert.AreEqual(2, PlayerPrefsController.GetDifficulty());
        }

        [Test]
        public void SetDifficultyBelowLimit()
        {
            LogAssert.Expect(LogType.Error, "Difficulty is out of range");
            PlayerPrefsController.SetDifficulty(-1);
        }

        [Test]
        public void SetDifficultyLowLimit()
        {
            PlayerPrefsController.SetDifficulty(0);
            Assert.AreEqual(0, PlayerPrefs.GetInt(DIFFICULTY_KEY));
        }

        [Test]
        public void SetDifficultyMidRange()
        {
            PlayerPrefsController.SetDifficulty(4);
            Assert.AreEqual(4, PlayerPrefs.GetInt(DIFFICULTY_KEY));
        }

        [Test]
        public void SetDifficultyHighLimit()
        {
            PlayerPrefsController.SetDifficulty(9);
            Assert.AreEqual(9, PlayerPrefs.GetInt(DIFFICULTY_KEY));
        }

        [Test]
        public void SetDifficultyAboveLimit()
        {
            LogAssert.Expect(LogType.Error, "Difficulty is out of range");
            PlayerPrefsController.SetDifficulty(10);
        }
    }
}
