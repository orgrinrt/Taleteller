using Godot;
using GDMechanic.Wiring;
using GDMechanic.Wiring.Attributes;

public class Binder : Control
{
	public override void _Ready()
    {
        this.Wire();
    }   
}