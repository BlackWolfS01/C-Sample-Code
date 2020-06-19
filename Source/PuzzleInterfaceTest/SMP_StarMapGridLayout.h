// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "SMP_StarMapGridLayout.generated.h"

UCLASS()
class PUZZLEINTERFACETEST_API ASMP_StarMapGridLayout : public AActor
{
	GENERATED_BODY()

	class USceneComponent* DummyRoot;

	class UTextRenderComponent* ScoreText;
public:	
	ASMP_StarMapGridLayout();

	int32 Score;

	int32 Size;


protected:
	virtual void BeginPlay() override;

private:
	virtual float RandSpacing() const;

	virtual FVector GetRandLoc() const;

public:	
	virtual void Tick(float DeltaTime) override;

	void AddScore();

	FORCEINLINE USceneComponent* GetDummyRoot() const {
		return DummyRoot;
	}
	FORCEINLINE UTextRenderComponent* GetScoreText() const {
		return ScoreText;
	}
};
