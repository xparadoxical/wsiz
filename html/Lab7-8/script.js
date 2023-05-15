//zad 2

function hasValue(input) {
    return lengthAtLeast(input, 1);
}

function lengthAtLeast(input, length) {
    return input.value.length >= length;
}

function hasEmailAddress(input) {
    const emailRegex = /[a-z0-9_+\.]+@[a-z0-9_+\.]+\.(com|pl)/;
    return emailRegex.test(input.value);
}

function hasHardPassword(input) {
    const pass = input.value;
    
}

//zad 4
function isAdultBirthDate(date) {
    const now = Date.now();
    const year = parseInt(now.getFullYear());
    const eighteenYearsAgo = 

    return date - eighteenYearsAgo;
}