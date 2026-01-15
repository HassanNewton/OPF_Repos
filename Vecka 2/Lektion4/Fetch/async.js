// Async/Await =
// async → gör att en funktion AUTOMATISKT returnerar ett Promise
// await → gör att vi kan "vänta" på ett Promise INUTI en async-funktion

// Fördel:
// Vi kan skriva asynkron kod som om den vore synkron (rad för rad)

// Viktigt:
// await blockerar INTE JavaScript-tråden
// await pausar bara DENNA funktion tills Promiset är klart

// walkDog returnerar ett Promise
// Promiset kommer antingen:
// - resolve() → lyckat resultat
// - reject() → något gick fel

function walkDog() {
  return new Promise((resolve, reject) => {
    // setTimeout simulerar ett långsamt asynkront jobb (t.ex. API-anrop)
    setTimeout(() => {
      const dogWalked = true; // ändra denna för att testa reject

      if (dogWalked) {
        // Om allt gick bra → Promise blir "fulfilled"
        resolve("You walk the dog 🐕");
      } else {
        // Om något gick fel → Promise blir "rejected"
        reject("You DIDN'T walk the dog");
      }
    }, 1500); // tar 1.5 sekunder
  });
}

function cleanKitchen() {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      const kitchenCleaned = true; // testa false

      if (kitchenCleaned) {
        resolve("You clean the kitchen 🧹");
      } else {
        reject("You DIDN'T clean the kitchen");
      }
    }, 2500); // tar 2.5 sekunder
  });
}

function takeOutTrash() {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      const trashTakenOut = true; // testa false

      if (trashTakenOut) {
        resolve("You take out the trash ♻");
      } else {
        reject("You DIDN'T take out the trash");
      }
    }, 500); // tar 0.5 sekunder
  });
}

// async gör att denna funktion:
// - kan använda await
// - alltid returnerar ett Promise
async function doChores() {
  try {
    // await gör att vi väntar på att Promiset från walkDog ska bli klart
    const walkDogResult = await walkDog();
    console.log(walkDogResult);

    // Denna rad körs INTE förrän walkDog är klar
    const cleanKitchenResult = await cleanKitchen();
    console.log(cleanKitchenResult);

    // Denna körs sist
    const takeOutTrashResult = await takeOutTrash();
    console.log(takeOutTrashResult);

    // Körs bara om ALLA ovan lyckas
    console.log("You finished all the chores!");
  } catch (error) {
    // Om NÅGOT Promise rejectar → hoppar vi direkt hit
    console.error(error);
  }
}

// Startar hela flödet
doChores();
