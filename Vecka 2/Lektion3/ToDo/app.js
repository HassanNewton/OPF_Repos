// ===== 1. Hämta element från DOM =====

// Inputfältet
const input = document.getElementById("todoInput");

// Knappen
const addBtn = document.getElementById("addBtn");

// Listan (<ul>)
const list = document.getElementById("todoList");

// ===== 2. Event: klick på "Lägg till" =====

addBtn.addEventListener("click", () => {
  // Hämta texten som användaren skrivit
  const text = input.value;

  // Om input är tom – gör ingenting
  if (text === "") return;

  // ===== 3. Skapa nytt list-element =====

  const li = document.createElement("li");
  li.textContent = text;

  // ===== 4. Event på varje todo =====
  // Klick på en todo = markera som klar

  li.addEventListener("click", () => {
    li.classList.toggle("done");
  });

  // ===== 5. Lägg till i DOM =====

  list.appendChild(li);

  // ===== 6. Töm inputfältet =====

  input.value = "";
});




