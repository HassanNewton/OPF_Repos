// ===== HÄMTA ELEMENT FRÅN DOM =====
// Vi sparar referenser till DOM-element så vi kan använda dem senare.
// Knappar
const helloBtn = document.getElementById("helloBtn");
const addTextBtn = document.getElementById("addTextBtn");
const clearBtn = document.getElementById("clearBtn");

// Input
const textInput = document.getElementById("textInput");

// Container där alla nya element hamnar
const container = document.getElementById("container");

///--HELLO WORLD KNAPPEN--///
// Lyssnar på click
// Skapar nytt DOM-element
// Fyller det med text
// Ger det ett ID
// Lägger till det i DOM-trädet

helloBtn.addEventListener("click", () => {
  // Skapar ett nytt div-element
  const div = document.createElement("div");

  // Sätter textinnehåll
  div.textContent = "Hello World";

  // Sätter ID (enligt uppgiften)
  div.id = "hello-world-div";

  // Lägger in div:en i containern
  container.appendChild(div);
});

// classList.add() → styling för flera element
// prompt() → enkel interaktion
// Event inuti event → fullt tillåtet och vanligt

addTextBtn.addEventListener("click", () => {
  // Hämtar text från input
  const text = textInput.value;

  // Om input är tom → gör inget
  if (text === "") return;

  // Skapar nytt div-element
  const div = document.createElement("div");

  // Sätter text
  div.textContent = text;

  // Sätter class för styling
  div.classList.add("text-item");

  // BONUS: gör texten redigerbar vid klick
  div.addEventListener("click", () => {
    const newText = prompt("Ändra text:", div.textContent);

    if (newText !== null) {
      div.textContent = newText;
    }
  });

  // Lägger till i containern
  container.appendChild(div);

  // Tömmer inputfältet
  textInput.value = "";
});

// Alla skapade divar ligger i container
// innerHTML = "" tar bort dem från DOM
// Alternativet hade varit .remove() i loop

clearBtn.addEventListener("click", () => {
  // Tar bort allt innehåll i containern
  container.innerHTML = "";
});
