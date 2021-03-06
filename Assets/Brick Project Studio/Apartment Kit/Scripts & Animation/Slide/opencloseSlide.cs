using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

namespace SojaExiles

{
	public class opencloseSlide : MonoBehaviour
	{
    	public SteamVR_Action_Boolean fireAction;
    	public Interactable interactable;
		public Animator openandclosewindow;
		public bool open;

		void Start()
		{
			interactable = GetComponent<Interactable>();
			openandclosewindow = GetComponent<Animator>();
			fireAction = SteamVR_Actions._default.InteractUI;
			open = false;
		}

		void Update() {
			if (interactable.hoveringHand != null) {
				SteamVR_Input_Sources source = interactable.hoveringHand.handType;

				if (fireAction[source].stateDown) {
					if (open == false) {
						StartCoroutine(opening());
					} else if (open == true) {
						StartCoroutine(closing());
					}
				}
			}
		}

		IEnumerator opening()
		{
			openandclosewindow.Play("OpeningSlide");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			openandclosewindow.Play("ClosingSlide");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}