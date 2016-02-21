using UnityEngine;
using System.Collections;
/// <summary>
/// トリガー判定を
/// </summary>
public class TriggerReceiver : MonoBehaviour {
	
	public GameObject receiver;

#region MonoBehaviourEvent
	private void OnTriggerEnter(Collider coll) {
		Notify("OnTriggerEnter", coll);
	}
	private void OnTriggerExit(Collider coll) {
		Notify("OnTriggerExit", coll);
	}
#endregion
	private void Notify (string eventName, object item) {
		if(receiver) {
			receiver.SendMessage(eventName, item, SendMessageOptions.DontRequireReceiver);
		}
	}
}