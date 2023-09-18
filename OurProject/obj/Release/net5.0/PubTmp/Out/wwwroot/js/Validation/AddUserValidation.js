//validation
const form = document.getElementById('form');
const name = document.getElementById('name');
const username = document.getElementById('Username');
const Roll = document.getElementById('Roll');
const PhoneNumber = document.getElementById('PhoneNumber');
const Date = document.getElementById('Date');




function checkInputs() {
    const nameValue = name.value.trim(); 
    const UsernameValue = Username.value.trim();
    const RollValue = Roll.value;
    const PhoneNumberValue = PhoneNumber.value.trim();
    const DateValue = Date.value;
    var b = 0;

   

        $.ajax({

            type: 'GET',
            url: "/Check/CheckUserName?username=" + UsernameValue,
            success: function (data, ev) {
                if (ev.first !== true) {
                    ev.first = true;
                    if (nameValue === '') {
                        setErrorFor(name, 'الرجاء أدخال اسم الموظف');
                    }
                    else {
                        setSuccessFor(name);
                        b = b + 1;

                    }
                    if (UsernameValue === '') {
                        setErrorFor(username, 'الرجاء أدخال البريد الإلكنروني');
                    }

                    else if (!isGmail(UsernameValue)) {
                        setErrorFor(username, 'الرجاء التأكد من صحة البريد الإلكنروني');
                    }
                    else if (data == false) {
                        setErrorFor(username, 'عذرا هذا البريد الالكتروني مأخوذ');
                    }
                    else {
                        setSuccessFor(username);
                        b = b + 1;
                    }
                    if (RollValue == -1) {
                        setErrorFor(Roll, 'الرجاء أختيار اسم المشرف');
                    }
                    else {
                        setSuccessFor(Roll);
                        b = b + 1;

                    }
                    if (PhoneNumberValue === '') {
                        setErrorFor(PhoneNumber, 'الرجاء أدخال رقم الهاتف');
                    }
                    else if (!isPhoneNumber(PhoneNumberValue)) {
                        setErrorFor(PhoneNumber, 'الرجاء ادخال رقم هاتف بطول 10 ارقام ويبدأ ب 09');
                    }
                    else {
                        setSuccessFor(PhoneNumber);
                        b = b + 1;

                    }
                    if (DateValue === '') {
                        setErrorFor(Date, 'الرجاء أدخال تاريخ التعيين');
                    }
                    else {
                        setSuccessFor(Date);
                        b = b + 1;

                    }

                    if (b == 5) {
                        document.getElementById('AddUser').click();
                    }
                  
                }
            }
        });

    
  
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
    return /^09([0-9]{8})$/.test(number);
}

