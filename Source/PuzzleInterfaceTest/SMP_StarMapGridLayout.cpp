// Fill out your copyright notice in the Description page of Project Settings.


#include "SMP_StarMapGridLayout.h"
#include "Components/TextRenderComponent.h"
#include "Engine/World.h"
#include "Math/UnrealMathUtility.h"
#include "SMP_StarSystemObject.h"

#define LOCTEXT_NAMESPACE "PuzzleBlockGrid"
// Sets default values
ASMP_StarMapGridLayout::ASMP_StarMapGridLayout()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

	DummyRoot = CreateDefaultSubobject<USceneComponent>(TEXT("Dummy0"));
	RootComponent = DummyRoot;

	ScoreText = CreateDefaultSubobject<UTextRenderComponent>(TEXT("ScoreText0"));
	ScoreText->SetRelativeLocation(FVector(10.0f, 0.0f, 0.0f));
	ScoreText->SetRelativeRotation(FRotator(0.0, 0.0f, 90.0));
	ScoreText->SetText(FText::Format(LOCTEXT("ScoreFmt", "Score: {0}"), FText::AsNumber(0)));
	ScoreText->SetupAttachment(DummyRoot);

	Size = 5;
}

// Called when the game starts or when spawned
void ASMP_StarMapGridLayout::BeginPlay()
{
	Super::BeginPlay();
	
	const int32 NumSpheres = Size + Size;

	for (int32 _SystemNum = 0; _SystemNum < NumSpheres; _SystemNum++) {
		
		const FVector SphereLoc = GetRandLoc() + GetActorLocation();

		ASMP_StarSystemObject* NewSphere = GetWorld()->
			SpawnActor< ASMP_StarSystemObject >(SphereLoc, FRotator(0.0f, 0.0f, 0.0f));
	
		if (NewSphere != nullptr) {
			NewSphere->Grid_Owner = this;
		}
	}
}

float ASMP_StarMapGridLayout::RandSpacing() const {
	return FMath::RandRange(-200.0f,200.0f);
}

FVector ASMP_StarMapGridLayout::GetRandLoc() const {
	float XOffset, YOffset, ZOffset;
	XOffset = RandSpacing();
	YOffset = RandSpacing();
	ZOffset = RandSpacing();
	return FVector(XOffset, YOffset, ZOffset);
}

// Called every frame
void ASMP_StarMapGridLayout::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

void ASMP_StarMapGridLayout::AddScore()
{
	Score++;
	ScoreText->SetText(FText::Format(LOCTEXT("ScoreFmt", "Score: {0}"), FText::AsNumber(Score)));
}

#undef LOCTEXT_NAMESPACE