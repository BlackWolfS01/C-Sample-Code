// Fill out your copyright notice in the Description page of Project Settings.

#include "UObject/ConstructorHelpers.h"
#include "SMP_StarMapGridLayout.h"
#include "Components/StaticMeshComponent.h"
#include "Engine/StaticMesh.h"
#include "Materials/MaterialInstance.h"
#include "SMP_StarSystemObject.h"

// Sets default values
ASMP_StarSystemObject::ASMP_StarSystemObject()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

	struct FConstructorStatics {
		ConstructorHelpers::FObjectFinderOptional<UStaticMesh> PlaneMesh;
		ConstructorHelpers::FObjectFinderOptional<UMaterial> baseMaterial;
		ConstructorHelpers::FObjectFinderOptional<UMaterialInstance> NormalMaterial;
		ConstructorHelpers::FObjectFinderOptional<UMaterialInstance> BlueMaterial;
		ConstructorHelpers::FObjectFinderOptional<UMaterialInstance> RedMaterial;
		FConstructorStatics()
			: PlaneMesh(TEXT("StaticMesh'/Game/InteractiveStarMapPuzzle/SphereMesh.SphereMesh'"))
			, baseMaterial(TEXT("Material'/Game/InteractiveStarMapPuzzle/NewMaterial.NewMaterial'"))
			, NormalMaterial(TEXT("MaterialInstanceConstant'/Game/InteractiveStarMapPuzzle/EM_Normal.EM_Normal'"))
			, BlueMaterial(TEXT("MaterialInstanceConstant'/Game/InteractiveStarMapPuzzle/EM_Correct.EM_Correct'"))
			, RedMaterial(TEXT("MaterialInstanceConstant'/Game/InteractiveStarMapPuzzle/EM_Incorrect.EM_Incorrect'")) {
		}
	};

	static FConstructorStatics ConstructorStatics;

	DummyRoot = CreateDefaultSubobject<USceneComponent>(TEXT("Dummy"));
	RootComponent = DummyRoot;

	SphereMesh = CreateDefaultSubobject<UStaticMeshComponent>(TEXT("SphereMesh"));
	SphereMesh->SetStaticMesh(ConstructorStatics.PlaneMesh.Get());
	SphereMesh->SetRelativeScale3D(FVector(0.5f, 0.5f, 0.5f));
	SphereMesh->SetRelativeLocation(FVector(1.f, 0.f, 0.f));
	SphereMesh->SetMaterial(0, ConstructorStatics.NormalMaterial.Get());
	SphereMesh->SetupAttachment(DummyRoot);

	baseMaterial = ConstructorStatics.baseMaterial.Get();
	NormalMaterial = ConstructorStatics.NormalMaterial.Get();
	BlueMaterial = ConstructorStatics.BlueMaterial.Get();
	RedMaterial = ConstructorStatics.RedMaterial.Get();
}

// Called when the game starts or when spawned
void ASMP_StarSystemObject::BeginPlay()
{
	Super::BeginPlay();
	
}

void ASMP_StarSystemObject::SphereClicked(UPrimitiveComponent* ClickedComp, FKey ButtonClicked) {
	HandleClicked();
}

void ASMP_StarSystemObject::HandleClicked()
{
	if (!sIsActive) {
		sIsActive = true;
		SphereMesh->SetMaterial(0, RedMaterial);

		if (Grid_Owner != nullptr) {
			Grid_Owner->AddScore();
		}
	}
}

void ASMP_StarSystemObject::Highlighted(bool _On)
{
	if (sIsActive) {
		return;
	}

	if (_On) {
		SphereMesh->SetMaterial(0, NormalMaterial);
	}
	else {
		SphereMesh->SetMaterial(0, BlueMaterial);
	}
}

// Called every frame
void ASMP_StarSystemObject::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

