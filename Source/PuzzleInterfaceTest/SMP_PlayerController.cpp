// Fill out your copyright notice in the Description page of Project Settings.


#include "SMP_PlayerController.h"

ASMP_PlayerController::ASMP_PlayerController() {
	bShowMouseCursor = true;
	bEnableClickEvents = true;
	bEnableTouchEvents = true;
	DefaultMouseCursor = EMouseCursor::Crosshairs;
}