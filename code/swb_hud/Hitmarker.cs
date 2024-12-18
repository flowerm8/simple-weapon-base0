﻿using Sandbox.UI;

namespace SWB.HUD;

/*
 * Base your custom hitmarker on HitmarkerPanel and simply add to the weapon
 */

public class Hitmarker : Panel
{
	private Marker activeMarker;

	public Hitmarker()
	{
		StyleSheet.Load( "/swb_hud/Hitmarker.cs.scss" );
	}

	public void Create( bool isKill )
	{
		activeMarker?.Delete( true );
		activeMarker = new Marker( this, isKill );
	}

	public class Marker : Panel
	{
		public Marker( Panel parent, bool isKill )
		{
			Parent = parent;

			var leftTopBar = Add.Panel( "leftTopBar" );
			var lefBottomBar = Add.Panel( "leftBottomBar" );
			var rightTopBar = Add.Panel( "rightTopBar" );
			var rightBottomBar = Add.Panel( "rightBottomBar" );

			string sharedStyling = isKill ? "sharedBarStylingKill" : "sharedBarStyling";
			leftTopBar.AddClass( sharedStyling );
			lefBottomBar.AddClass( sharedStyling );
			rightTopBar.AddClass( sharedStyling );
			rightBottomBar.AddClass( sharedStyling );

			Lifetime();
		}

		async void Lifetime()
		{
			await GameTask.Delay( 100 );
			AddClass( "fadeOut" );
			await GameTask.Delay( 300 );
			Delete();
		}
	}
}
