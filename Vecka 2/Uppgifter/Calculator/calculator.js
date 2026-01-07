// Hjälpfunktion
function isValidNumber(value) {
  return typeof value !== "boolean" && !isNaN(Number(value));
}

// Grundoperationer
function add(a, b) {
  if (!isValidNumber(a)) return "First number was not a number";
  if (!isValidNumber(b)) return "Second number was not a number";
  return Number(a) + Number(b);
}

function subtract(a, b) {
  if (!isValidNumber(a)) return "First number was not a number";
  if (!isValidNumber(b)) return "Second number was not a number";
  return Number(a) - Number(b);
}

function multiply(a, b) {
  if (!isValidNumber(a)) return "First number was not a number";
  if (!isValidNumber(b)) return "Second number was not a number";
  return Number(a) * Number(b);
}

function divide(a, b) {
  if (!isValidNumber(a)) return "First number was not a number";
  if (!isValidNumber(b)) return "Second number was not a number";
  if (Number(b) === 0) return "Division by 0";
  return Number(a) / Number(b);
}
