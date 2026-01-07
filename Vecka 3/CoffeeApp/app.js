// Detta är en annan origin än din frontend
// Det är exakt därför CORS behövs
const API_URL = "http://localhost:5291/api/coffee";

//Ladda alla kaffesorter från API:et
async function loadCoffees() {
  const errorEl = document.getElementById("error");
  errorEl.textContent = "";

  try {
    const response = await fetch(API_URL);

    if (!response.ok) {
      throw new Error("Failed to fetch coffees");
    }

    const coffees = await response.json();
    renderCoffees(coffees);
  } catch (error) {
    errorEl.textContent = error.message;
  }
}

//Visa olika kaffesorter på sidan
function renderCoffees(coffees) {
  const list = document.getElementById("coffee-list");
  list.innerHTML = "";

  coffees.forEach((c) => {
    const card = document.createElement("div");
    card.className = "card";

    card.innerHTML = `
            <h3>${c.name}</h3>
            <p>Origin: ${c.origin}</p>
            <p>Strength: ${c.strength}</p>
            <button onclick="deleteCoffee(${c.id})">Delete</button>
            <button onclick="updateCoffee(${c.id})">Update</button>
        `;

    list.appendChild(card);
  });
}

//Lägg till kaffesort POST
async function addCoffee() {
  const coffee = {
    name: document.getElementById("name").value,
    origin: document.getElementById("origin").value,
    strength: Number(document.getElementById("strength").value),
  };

  try {
    const response = await fetch(API_URL, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(coffee),
    });

    if (!response.ok) {
      throw new Error("Failed to add coffee");
    }

    loadCoffees();
  } catch (error) {
    document.getElementById("error").textContent = error.message;
  }
}

//Ta bort kaffesort DELETE
async function deleteCoffee(id) {
  try {
    const response = await fetch(`${API_URL}/${id}`, {
      method: "DELETE",
    });

    if (!response.ok) {
      throw new Error("Failed to delete coffee");
    }

    loadCoffees();
  } catch (error) {
    document.getElementById("error").textContent = error.message;
  }
}

async function updateCoffee(id) {
  const name = prompt("New name:");
  const origin = prompt("New origin:");
  const strength = prompt("New strength:");

  const updatedCoffee = {
    name,
    origin,
    strength: Number(strength),
  };

  try {
    const response = await fetch(`${API_URL}/${id}`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(updatedCoffee),
    });

    if (!response.ok) {
      throw new Error("Failed to update coffee");
    }

    loadCoffees();
  } catch (error) {
    document.getElementById("error").textContent = error.message;
  }
}

loadCoffees();
