//validation
const form = document.getElementById('form');
const minDate = document.getElementById('minDate');
const maxDate = document.getElementById('maxDate');




function checkInputs() {
    const minDateValue = minDate.value;
    const maxDateValue = maxDate.value;
    var b = 0;
    var smallDate = new Date("1/1/0001 12:00:00");

    if (minDateValue === "" || maxDateValue==="") {
        setErrorFor(maxDate, 'الرجاء أدخال فترة زمنية');
    }
    else if (minDateValue == smallDate || maxDateValue == smallDate) {
        setErrorFor(maxDate, 'الرجاء أدخال فترة زمنية');
    }
    else if (minDateValue > maxDateValue ) {
        setErrorFor(maxDate, 'يجب ان تكون الفترة الزمنية الأولى أصغر من الفترة الزمنية الثانية');
    }
    else {
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