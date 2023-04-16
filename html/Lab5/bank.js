function getAccount(index) {
	let v = localStorage[index];

	if (v === undefined) {
		console.debug("account at index", index, "doesn't exist");
		return null;
	}

	let account = JSON.parse(v);
	console.debug(index, account);
	return account;
}

function setAccount(index, account) {
	console.debug("setAccount", index, account);
	localStorage[index] = JSON.stringify(account);
}

function getLastIndex() {
	console.debug("localStorage.last:", localStorage.last);
	return parseInt(localStorage.last);
}


if (localStorage.last == null)
	localStorage.last = -1;

let params = new URLSearchParams(document.location.search);

const action = params.get("action");
if (action != "login" && action != "register") {
	let err = `"${action}" is an invalid action. Expected "login" or "register".`;
	alert(`Wystąpił błąd:\n${err}`);
	stop(); //stop loading the remaining HTML content
	throw new Error(err); //stop execution of the script
}

let account = null;

if (action == "register") {
	account = {
		id: getLastIndex() + 1,
		name: params.get("name"),
		surname: params.get("surname"),
		pin: params.get("pin"),
		balance: 0
	};

	localStorage.last = account.id;
	setAccount(account.id, account);

	alert(`Utworzono konto!\nNumer konta: ${account.id}`);
} else {
	let id = params.get("account");
	account = getAccount(id);

	if (account == null) {
		alert("Błąd: konto o podanym numerze nie istnieje.");
		stop();
		throw new Error(`Account ${id} does not exist.`);
	}

	if (account.pin != params.get("pin")) {
		alert("Błąd: nieprawidłowy PIN.");
		stop();
		throw new Error("Incorrect login information.");
	}
}

addEventListener("DOMContentLoaded", (event) => {
	console.debug("DOMContentLoaded");

	document.getElementById("account").innerHTML = account.id;
	document.getElementById("full-name").innerHTML = `${account.name} ${account.surname}`;

	let balanceLabel = document.getElementById("balance");
	function updateBalance() {
		balanceLabel.innerHTML = account.balance.toFixed(2);		
	}
	updateBalance();

	let atmForm = document.getElementById("atm");
	let incorrectPin = document.getElementById("incorrect-pin");
	let insufficientBalance = document.getElementById("insufficient-balance");

	function validatePIN() {
		let pinInput = atmForm.elements["pin"];
		let pin = pinInput.value;
		console.debug("validatePIN", pin, account.pin);

		pinInput.value = "";

		let result = pin == account.pin;

		incorrectPin.style.display = result ? "none" : "";
		return result;
	}

	atmForm.addEventListener("submit", (event) => {
		event.preventDefault();
		if (event.submitter.name != "cash-in")
			return;

		if (validatePIN()) {
			account.balance += atmForm.elements["amount"].valueAsNumber;
			setAccount(account.id, account);
			updateBalance();
		}
	});

	atmForm.addEventListener("submit", (event) => {
		event.preventDefault();
		if (event.submitter.name != "cash-out")
			return;

		let result = true;

		if (!validatePIN())
			result = false;

		let toSubtract = atmForm.elements["amount"].valueAsNumber;
		if (toSubtract > account.balance) {
			result = false;
			insufficientBalance.style.display = "";
		} else {
			insufficientBalance.style.display = "none";
		}

		if (!result)
			return;

		account.balance -= toSubtract;
		setAccount(account.id, account);
		updateBalance();
	});
});