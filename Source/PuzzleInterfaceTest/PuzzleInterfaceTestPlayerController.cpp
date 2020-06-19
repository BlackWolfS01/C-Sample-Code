// Copyright 1998-2019 Epic Games, Inc. All Rights Reserved.

#include "PuzzleInterfaceTestPlayerController.h"

APuzzleInterfaceTestPlayerController::APuzzleInterfaceTestPlayerController()
{
	bShowMouseCursor = true;
	bEnableClickEvents = true;
	bEnableTouchEvents = true;
	DefaultMouseCursor = EMouseCursor::Crosshairs;
}
