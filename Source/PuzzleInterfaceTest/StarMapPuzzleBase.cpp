// Fill out your copyright notice in the Description page of Project Settings.


#include "StarMapPuzzleBase.h"
#include "SMP_Pawn.h"
#include "SMP_PlayerController.h"

AStarMapPuzzleBase::AStarMapPuzzleBase() {
	DefaultPawnClass = ASMP_Pawn::StaticClass();
	PlayerControllerClass = ASMP_PlayerController::StaticClass();
}