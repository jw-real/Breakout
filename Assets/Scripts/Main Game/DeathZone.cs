using UnityEngine;
using UnityEngine.EventSystems;

public class DeathZone : MonoBehaviour
{
    public EventTrigger.TriggerEvent deathTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ball ball = collision.GetComponent<Ball>();

        if (ball != null)
        {
            BaseEventData eventData = new BaseEventData(EventSystem.current);
            deathTrigger.Invoke(eventData);
        }
    }
}

