using System.Collections;
using BinaryEyes.Common.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BubbleWarIV.Components
{
    public sealed class Preloader
        : MonoBehaviour
    {
        public Headset HeadsetPrefab;
        public string LocationScene;

        private void Awake()
            => StartCoroutine(PrepareGame());

        private IEnumerator PrepareGame()
        {
            yield return null;
            this.LogMessage("PreparingGame");

            var headset = Instantiate(HeadsetPrefab).SetName(HeadsetPrefab.name);
            DontDestroyOnLoad(headset.gameObject);

            yield return SceneManager.LoadSceneAsync(LocationScene, LoadSceneMode.Additive);
            yield return new WaitUntil(() => GameLocation.Exists);

            headset.Fade.TurnTransparent();
            SceneManager.SetActiveScene(GameLocation.Instance.gameObject.scene);
            SceneManager.UnloadSceneAsync(gameObject.scene);
        }
    }
}