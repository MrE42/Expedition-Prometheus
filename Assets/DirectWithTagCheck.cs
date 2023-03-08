using UnityEngine.XR.Interaction.Toolkit;

public class DirectWithTagCheck : XRDirectInteractor
{
    public string targetTag = string.Empty;
    public bool not = false;

    public override bool CanHover(XRBaseInteractable interactable)
    {
        return base.CanHover(interactable) && MatchUsingTag(interactable);
    }

    public override bool CanSelect(XRBaseInteractable interactable)
    {
        return base.CanSelect(interactable) && MatchUsingTag(interactable);
    }

    private bool MatchUsingTag(XRBaseInteractable interactable)
    {
        if (not) {
            return !interactable.CompareTag(targetTag);
        } else
        {
            return interactable.CompareTag(targetTag);
        }
    }
}
