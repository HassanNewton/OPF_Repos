// ===================================
// 1️⃣ Variabler: let och const
// ===================================

// let = kan ändras
let age = 25;
age = 26;

// const = kan inte pekas om
const name = "Alex";
// name = "Eva"; ❌ inte tillåtet

// JavaScript är weakly typed
let x = 5;
x = "hej"; // helt okej i JS

// ===================================
// 2️⃣ Datatyper i JavaScript
// ===================================

let number = 10; // number (ingen int / double)
let text = "hej"; // string
let isActive = true; // boolean
let nothing = null; // medvetet tomt värde
let notDefined; // undefined (ej tilldelad)

// ===================================
// 3️⃣ If-sats (ingen djupdykning)
// ===================================

if (age >= 18) {
  console.log("Vuxen");
} else {
  console.log("Barn");
}

// ===================================
// 4️⃣ Funktioner
// ===================================

// Vanlig funktion (liknar C#-metod)
function add(a, b) {
  return a + b;
}

// Arrow function (vanlig i modern JS)
const subtract = (a, b) => a - b;

// ===================================
// 5️⃣ DOM – hämta element
// ===================================

// Hämta element från HTML
const btn = document.getElementById("btn");
const output = document.getElementById("output");

// ===================================
// 6️⃣ Events
// ===================================

// Click-event
btn.addEventListener("click", () => {
  // Kör funktion
  const result = add(2, 3);
  color();
  // Uppdatera DOM
  output.textContent = "Resultat: " + result;
});

// Mouseover-event
btn.addEventListener("mouseover", () => {
  btn.style.backgroundColor = "lightblue";
});

// Mouseout-event (musen lämnar)
btn.addEventListener("mouseout", () => {
  btn.style.backgroundColor = "";
});

function showPage(pageName) {
  document.getElementById("content").textContent =
    "Du är på sidan: " + pageName;
}

function color() {
  let buttons = document.querySelectorAll("button");

  buttons.forEach((button) => (button.style.backgroundColor = "pink"));
}
