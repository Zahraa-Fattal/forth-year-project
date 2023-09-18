
function DateInformation() {

    var NationalNumberValue = document.getElementById('NationalNumber').value.trim();




    $.ajax({
        type: 'GET',
        url: "/Check/GetDate?NationalNumber=" + NationalNumberValue,
        success: function (data) {
            if (data != null) {

                document.getElementById('finalDate').innerHTML = data.finalDate;
                document.getElementById('displayname').innerHTML = data.studentName;
                document.getElementById('unitname').innerHTML = data.unitName;

                document.getElementById('modaltrigger').click();
                return true;
            }
            else {

            }
        },
        error: function () {
            document.getElementById('erorremodaltrigger').click();
            return true;
        }

    });
}


const form = document.getElementById('form');
const name = document.getElementById('name');
const NationalNumber = document.getElementById('NationalNumber');

function checkInputs() {
    const NationalNumberValue = NationalNumber.value.trim();
    var b = 0;

    if (NationalNumberValue === '') {
        setErrorFor(NationalNumber, 'الرجاء أدخل رقمك الوطني');
    }
    else if (!isPhoneNumber(NationalNumberValue)) {
        setErrorFor(NationalNumber, 'الرجاء ادخال رقم وطني بطول 11 رقم');
    }
    else {
        setSuccessFor(NationalNumber);
        b = b + 1;
    }
 
    if (b == 1) {
        DateInformation();
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
function isGmail(email) {
    return /^([A-Za-z0-9_\-\.])+\@([gmail|GMAIL])+\.(com)$/.test(email);
}
function isPhoneNumber(number) {
    return /([0-9]{11})$/.test(number);
}