using System.Collections;
using UnityEngine;

namespace PlayerNS
{
    public class Bubble : MonoBehaviour
    {
        [SerializeField] private GameObject bubble;
        [SerializeField] private float bubbleLifeTime;

        private void Start()
        {
            bubble.SetActive(false);
        }

        private void OnEnable()
        {
            ProjectileManager.OnShoot += StartBubble;
        }

        private void OnDisable()
        {
            ProjectileManager.OnShoot -= StartBubble;
        }

        private void StartBubble()
        {
            StartCoroutine(BubbleRoutine());
        }

        private IEnumerator BubbleRoutine()
        {
            bubble.SetActive(true);
            yield return new WaitForSeconds(bubbleLifeTime);
            bubble.SetActive(false);
        }
    }
}