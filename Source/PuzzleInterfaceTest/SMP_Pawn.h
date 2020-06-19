// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Pawn.h"
#include "SMP_Pawn.generated.h"

UCLASS()
class PUZZLEINTERFACETEST_API ASMP_Pawn : public APawn
{
	GENERATED_UCLASS_BODY()

public:

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

	void TriggerClick();
	void TraceForSphere(const FVector& Start, FVector& End, bool bDrawDebugHelpers);

	class ASMP_StarSystemObject* CurrentStarFocus;
public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

	// Called to bind functionality to input
	virtual void SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent) override;

};
