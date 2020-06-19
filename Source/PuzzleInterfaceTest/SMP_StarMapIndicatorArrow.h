// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "SMP_StarMapIndicatorArrow.generated.h"

UCLASS()
class PUZZLEINTERFACETEST_API ASMP_StarMapIndicatorArrow : public AActor
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	ASMP_StarMapIndicatorArrow();

	class USceneComponent* DummyRoot;

	class UStaticMeshComponent* ConeMesh;

	class ASMP_StarMapGridLayout* Grid_Owner;

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

};
