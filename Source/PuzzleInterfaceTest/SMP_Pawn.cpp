// Fill out your copyright notice in the Description page of Project Settings.


#include "SMP_Pawn.h"
#include "SMP_StarSystemObject.h"
#include "GameFramework/PlayerController.h"
#include "Engine/World.h"
#include "DrawDebugHelpers.h"

// Sets default values
ASMP_Pawn::ASMP_Pawn(const FObjectInitializer& ObjectInitializer)
	: Super(ObjectInitializer)
{
 	// Set this pawn to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
	AutoPossessPlayer = EAutoReceiveInput::Player0;
}

// Called when the game starts or when spawned
void ASMP_Pawn::BeginPlay()
{
	Super::BeginPlay();
	
}

void ASMP_Pawn::TriggerClick()
{
	if (CurrentStarFocus) {
		CurrentStarFocus->HandleClicked();
	}
}

void ASMP_Pawn::TraceForSphere(const FVector& Start, FVector& End, 
	bool bDrawDebugHelpers) {
	FHitResult HitResult;

	GetWorld()->LineTraceSingleByChannel(HitResult, Start, End, ECC_Visibility);

	if (bDrawDebugHelpers)
	{
		DrawDebugLine(GetWorld(), Start, HitResult.Location, FColor::Red);
		DrawDebugSolidBox(GetWorld(), HitResult.Location, FVector(20.0f), FColor::Red);
	}
	if (HitResult.Actor.IsValid()) {
		ASMP_StarSystemObject* HitSphere = 
			Cast<ASMP_StarSystemObject>(HitResult.Actor.Get());

		if (CurrentStarFocus != HitSphere) {
			if (CurrentStarFocus) {
				CurrentStarFocus->Highlighted(false);
			}
			if (HitSphere) {
				HitSphere->Highlighted(true);
			}
			CurrentStarFocus = HitSphere;
		}
	} else if (CurrentStarFocus) {
		CurrentStarFocus->Highlighted(false);
		CurrentStarFocus = nullptr;
	}
}

// Called every frame
void ASMP_Pawn::Tick(float DeltaTime){
	Super::Tick(DeltaTime);
	
	if (APlayerController* PC = Cast<APlayerController>(GetController())) {
		FVector Start, Dir, End;
		PC->DeprojectMousePositionToWorld(Start, Dir);
		End = Start + (Dir * 8000.0f);
		TraceForSphere(Start, End, false);
	}
}

// Called to bind functionality to input
void ASMP_Pawn::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);
	PlayerInputComponent->BindAction("TriggerClick", EInputEvent::IE_Pressed, this, &ASMP_Pawn::TriggerClick);
}