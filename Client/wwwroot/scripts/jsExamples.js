export function showAlert(message) {
    alert(message);
}

export function emailRegistration(message) {
    const result = prompt(message);
    if (result === '' || result === null)
        return 'Please provide an email'
    const returnMessage = 'Hi ' + result.split('@')[0] + ' your email: ' + result + ' has been accepted.';
    return returnMessage;
}