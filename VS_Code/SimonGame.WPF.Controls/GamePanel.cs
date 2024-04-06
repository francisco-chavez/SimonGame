
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SimonGame.WPF.Controls;


public class GamePanel
	: Panel
{

	#region Dependency Properties

	public static readonly DependencyProperty InnerRadiusProperty;

	public double InnerRadius
	{
		get { return (double) GetValue(InnerRadiusProperty); }
		set { SetValue(InnerRadiusProperty, value); }
	}


	public static readonly DependencyProperty OuterRadiusProperty;

	public double OuterRadius
	{
		get { return (double) GetValue(InnerRadiusProperty); }
		set { SetValue(InnerRadiusProperty, value); }
	}


	public static readonly DependencyProperty ButtonCountProperty;

	public int ButtonCount
	{
		get { return (int) GetValue(ButtonCountProperty); }
		set { SetValue(ButtonCountProperty, value); }
	}


	#region Callbacks & Coercion

	private static void DoNothingPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{

	}

	private static object CoerceInnerRadius(DependencyObject d, object baseValue)
	{
		return CoerceRadius(baseValue, 0.5);
	}

	private static object CoerceOuterRadius(DependencyObject d, object baseValue)
	{
		return CoerceRadius(baseValue, 0.9);
	}

	private static double CoerceRadius(object baseValue, double defaultValue)
	{
		var r = (double?) baseValue ?? defaultValue;

		r = r < 0.0 ? 0.0 : r;
		r = r < 1.0 ? r : 1.0;

		return r;
	}

	private static object CoerceButtonCount(object baseValue, object defaultValue)
	{
		var buttonCount = (int?) baseValue ?? 4;

		buttonCount = buttonCount < 3 ? 3 : buttonCount;
		buttonCount = buttonCount < 6 ? buttonCount : 6;

		return buttonCount;
	}

	#endregion

	#endregion


	#region Constructors

	static GamePanel()
	{
		InnerRadiusProperty = DependencyProperty.Register(
			nameof(InnerRadius),
			typeof(double),
			typeof(GamePanel), 
			new FrameworkPropertyMetadata(
				0.5, 
				FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange, 
				new PropertyChangedCallback(DoNothingPropertyChangedCallback), 
				new CoerceValueCallback(CoerceInnerRadius)));

		OuterRadiusProperty = DependencyProperty.Register(
			nameof(OuterRadius),
			typeof(double),
			typeof(GamePanel),
			new FrameworkPropertyMetadata(
				0.9,
				FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange,
				new PropertyChangedCallback(DoNothingPropertyChangedCallback),
				new CoerceValueCallback(CoerceOuterRadius)));

		ButtonCountProperty = DependencyProperty.RegisterAttached(
			nameof(ButtonCount), 
			typeof(int), 
			typeof(GamePanel), 
			new FrameworkPropertyMetadata(
				4,
				FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange,
				new PropertyChangedCallback(DoNothingPropertyChangedCallback),
				new CoerceValueCallback(CoerceButtonCount)));
	}

	#endregion


	protected override Size MeasureOverride(Size availableSize)
	{
		return base.MeasureOverride(availableSize);
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		return base.ArrangeOverride(finalSize);
	}

}
