/***********************************************************************
 * FETCH & AXIOS – OLIKA SÄTT ATT HÄMTA DATA FRÅN ETT API
 *
 * Mål med denna fil:
 * - Visa SAMMA sak på olika sätt
 * - Jämföra syntax, läsbarhet och beteende
 * - Förstå asynkron JavaScript (Promises & async/await)
 ***********************************************************************/

const URL = "https://api.example.com/users";

/***********************************************************************
 * 1️ FETCH + .then()  (Promise-kedja – mellansteget)
 ***********************************************************************/

function fetchWithThen() {
  console.log("START fetchWithThen");

  fetch(URL)
    .then((response) => {
      // response är INTE datan
      // det är ett HTTP-svar (status, headers, body)
      return response.json(); // returnerar ett NYTT Promise
    })
    .then((data) => {
      // data är nu färdig JavaScript-data
      console.log("DATA:", data);
    })
    .catch((error) => {
      console.log("Fel inträffade:", error);
    });

  console.log("SLUT fetchWithThen");
}

/***********************************************************************
 * 2️⃣ AXIOS + .then()
 ***********************************************************************/

function axiosWithThen() {
  console.log("START axiosWithThen");

  axios
    .get(URL)
    .then((response) => {
      // Axios gör automatiskt:
      // 1. HTTP-anropet
      // 2. JSON-parsningen
      console.log("DATA:", response.data);
    })
    .catch((error) => {
      console.log("Axios-fel:", error);
    });

  console.log("SLUT axiosWithThen");
}

/***********************************************************************
 * 3️⃣ FETCH + async / await  (standard idag)
 ***********************************************************************/

async function fetchWithAsyncAwait() {
  console.log("START fetchWithAsyncAwait");

  const response = await fetch(URL);
  const data = await response.json();

  console.log("DATA:", data);

  console.log("SLUT fetchWithAsyncAwait");
}

/***********************************************************************
 * 4️⃣ FETCH + async / await + try/catch (robust variant)
 ***********************************************************************/

async function fetchWithTryCatch() {
  console.log("START fetchWithTryCatch");

  try {
    const response = await fetch(URL);

    // Fetch kastar INTE fel automatiskt vid 404/500
    if (!response.ok) {
      throw new Error("HTTP-fel: " + response.status);
    }

    const data = await response.json();
    console.log("DATA:", data);
  } catch (error) {
    console.log("Något gick fel:", error.message);
  }

  console.log("SLUT fetchWithTryCatch");
}

/***********************************************************************
 * 5️⃣ AXIOS + async / await (vanligast i verkliga projekt)
 ***********************************************************************/

async function axiosWithAsyncAwait() {
  console.log("START axiosWithAsyncAwait");

  try {
    const response = await axios.get(URL);

    // Axios kastar automatiskt fel vid 404/500
    console.log("DATA:", response.data);
  } catch (error) {
    console.log("Axios-fel:", error.message);
  }

  console.log("SLUT axiosWithAsyncAwait");
}
