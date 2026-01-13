const button = document.getElementById("loadBtn");
const list = document.getElementById("userList");

button.addEventListener("click", loadUsers);

async function loadUsers() {
  list.innerHTML = "<li>Laddar...</li>";

  try {
    const response = await fetch("https://jsonplaceholder.typicode.com/users");

    const users = await response.json();

    list.innerHTML = "";

    users.forEach((user) => {
      const li = document.createElement("li");
      li.textContent = user.name;
      list.appendChild(li);
    });
  } catch (error) {
    list.innerHTML = "<li>Kunde inte ladda data</li>";
  }
}
