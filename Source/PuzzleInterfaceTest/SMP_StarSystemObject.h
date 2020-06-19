// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "SMP_StarSystemObject.generated.h"

UCLASS()
class PUZZLEINTERFACETEST_API ASMP_StarSystemObject : public AActor
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	ASMP_StarSystemObject();

	class USceneComponent* DummyRoot;

	class UStaticMeshComponent* SphereMesh;

	class ASMP_StarMapGridLayout* Grid_Owner;

	void HandleClicked();

	void Highlighted(bool _On);
protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

	bool sIsActive;

	UPROPERTY()
	class UMaterial* baseMaterial;

	UPROPERTY()
	class UMaterialInstance* NormalMaterial;

	UPROPERTY()
	class UMaterialInstance* BlueMaterial;

	UPROPERTY()
	class UMaterialInstance* RedMaterial;

	UFUNCTION()
	void SphereClicked(UPrimitiveComponent* ClickedComp, FKey ButtonClicked);

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

	FORCEINLINE class USceneComponent* GetDummyRoot() const { 
		return DummyRoot; 
	}

	FORCEINLINE class UStaticMeshComponent* GetSphereMesh() const {
		return SphereMesh;
	}

};
