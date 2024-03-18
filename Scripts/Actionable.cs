using Godot;
using DialogueManagerRuntime;

namespace Helpers
{

	public partial class Actionable : Area2D
	{

		[Export] public Resource DialogueResource;
		[Export] public string DialogueStart = "start";

		public void Action()
		{
			DialogueManager.ShowDialogueBalloon(DialogueResource, DialogueStart);
		}
	}
}