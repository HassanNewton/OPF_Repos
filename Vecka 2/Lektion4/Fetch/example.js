// Fetch API vs Axios 
//-----------------------------------------------------------------------
fetch("https://api.example.com/users")
  .then((response) => {
    return response.json();
  })
  .then((data) => {
    console.log(data);
  });

//-----------------------------------------------------------------------
axios.get("https://api.example.com/users").then((response) => {
  console.log(response.data);
});
// Axios gör automatiskt:
// HTTP-anropet
// JSON-parsningen

//-----------------------------------------------------------------------
async function loadUsers() {
  const response = await fetch("https://api.example.com/users");
  const data = await response.json();
  console.log(data);
}

//-----------------------------------------------------------------------
async function loadUsers() {
  try {
    const response = await fetch(url);
    const data = await response.json();
    console.log(data);
  } catch (error) {
    console.log("Något gick fel:", error);
  }
}

//-----------------------------------------------------------------------
async function loadUsers() {
  const response = await axios.get("https://api.example.com/users");
  console.log(response.data);
}
