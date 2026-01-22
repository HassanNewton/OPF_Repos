const API_URL = "https://localhost:7283/api/products";

const list = document.getElementById("productList");
const loadBtn = document.getElementById("loadBtn");
const addBtn = document.getElementById("addBtn");

// ---------------------------
// GET ALL PRODUCTS
// ---------------------------
async function loadProducts() {
  list.innerHTML = "";

  const response = await fetch(API_URL);
  const products = await response.json();

  products.forEach((p) => {
    const li = document.createElement("li");
    li.textContent = `${p.name} – ${p.price} kr`;
    list.appendChild(li);
  });
}

// ---------------------------
// CREATE PRODUCT
// ---------------------------
async function addProduct() {
  const name = document.getElementById("nameInput").value;
  const price = Number(document.getElementById("priceInput").value);

  await fetch(API_URL, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      name: name,
      price: price,
    }),
  });

  loadProducts();
}

loadBtn.addEventListener("click", loadProducts);
addBtn.addEventListener("click", addProduct);
