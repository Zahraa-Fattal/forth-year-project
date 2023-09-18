//validation

const form = document.getElementById('form');



function checkInputs(name, phone) {

    const username = document.getElementById(name);
    const phoneNumber = document.getElementById(phone);
    const nameValue = username.value.trim();
    const phoneNumberValue = phoneNumber.value.trim();
    var b = 0;

    if (nameValue === '' || phoneNumberValue === '') {
        setErrorFor(phoneNumber, 'الرجاء أدخال كافة البيانات');
    } 
    else {
        setSuccessFor(phoneNumber);
        b = b + 1;
    }
    
    if (b == 1) {
        return true;
    }
    else {
        return false;
    }
}

function setErrorFor(input, message) {
    const big = input.parentElement;
    const small = big.querySelector('small');

    small.innerText = message;
    big.className = 'big error';
}
function setSuccessFor(input) {
    const big = input.parentElement;
    big.className = 'big correct';
}