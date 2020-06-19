// Copyright 1998-2019 Epic Games, Inc. All Rights Reserved.

#include "PuzzleInterfaceTestGameMode.h"
#include "PuzzleInterfaceTestPlayerController.h"
#include "PuzzleInterfaceTestPawn.h"

APuzzleInterfaceTestGameMode::APuzzleInterfaceTestGameMode()
{
	// no pawn by default
	DefaultPawnClass = APuzzleInterfaceTestPawn::StaticClass();
	// use our own player controller class
	PlayerControllerClass = APuzzleInterfaceTestPlayerController::StaticClass();
}
