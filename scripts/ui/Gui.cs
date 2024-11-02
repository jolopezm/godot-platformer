using Godot;
using System;

public partial class Gui : Control
{
    private Label runSliderValue;
    private HSlider runVelocitySlider;
	private Label jumpSliderValue;
	private HSlider jumpHeightSlider;
    private Label accSliderValue;
	private HSlider accelerationSlider;
    private Label fricSliderValue;
	private HSlider frictionSlider;

    public override void _Ready()
    {
        // Obtener nodos para velocidad de carrera
        runSliderValue = GetNode<Label>("RunVelocitySlider/RunSliderValue");
        runVelocitySlider = GetNode<HSlider>("RunVelocitySlider");
        runVelocitySlider.ValueChanged += OnRunVelocitySliderValueChanged;
        runSliderValue.Text = $"{runVelocitySlider.Value}";

		// Obtener nodos para altura de salto
		jumpSliderValue = GetNode<Label>("JumpHeightSlider/JumpSliderValue");
		jumpHeightSlider = GetNode<HSlider>("JumpHeightSlider");
		jumpHeightSlider.ValueChanged += OnJumpHeightSliderValueChanged;
        jumpSliderValue.Text = $"{jumpHeightSlider.Value}";

        accSliderValue = GetNode<Label>("AccelerationSlider/AccSliderValue");
		accelerationSlider = GetNode<HSlider>("AccelerationSlider");
		accelerationSlider.ValueChanged += OnAccelerationSliderValueChanged;
        accSliderValue.Text = $"{accelerationSlider.Value}";

        fricSliderValue = GetNode<Label>("FrictionSlider/FricSliderValue");
		frictionSlider = GetNode<HSlider>("FrictionSlider");
		frictionSlider.ValueChanged += OnFrictionSliderValueChanged;
        fricSliderValue.Text = $"{frictionSlider.Value}";

    }

    private void OnRunVelocitySliderValueChanged(double value) {
        runSliderValue.Text = $"{value}";
    }

	private void OnJumpHeightSliderValueChanged(double value) {
		jumpSliderValue.Text = $"{value}";
	}

    private void OnAccelerationSliderValueChanged(double value) {
		accSliderValue.Text = $"{value}";
	}

    private void OnFrictionSliderValueChanged(double value) {
		fricSliderValue.Text = $"{value}";
	}
}
