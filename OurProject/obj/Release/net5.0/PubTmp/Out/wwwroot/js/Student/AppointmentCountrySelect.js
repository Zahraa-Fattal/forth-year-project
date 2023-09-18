
/*MainCity*/
function getCountry () {
    var options = document.getElementById('mainCity').options;
    var id = options[options.selectedIndex].value;
    $.ajax({
        type: "GET",
        url: "/SignIn/GetCountry?id=" + id,
       
    }).done(function (data) {
        console.log(data);
        $('#country').empty();
        // our ajax call is finished, we have the data returned from the server in a var called data
        // loop through our returned data and add an option to the select for each province returned
        $('#country').append($('<option>', { value: -1, text: 'لايوجد' }));
        $.each(data, function (i, item) {
            $('#country').append($('<option>', { value: item.id, text: item.countryName }));
        });
    });
}


function bookdate() {
    var city;
    if ($('#country').val()!=-1) {
        city = $('#country').val();
    }
    else {
        city = $('#mainCity').val();
    }
    var data =
    {
        "Name": $('#fullname').val(),
        "Email": $('#Email').val(),
        "PhoneNumber": $('#phoneNumber').val(),
        "SuggestedUnitId": -1,
        "NationalId": $('#NationalNumber').val(),
        "UniversityId": $('#UnivercityNumber').val(),
        "Image": $('#save-image').val(),
        "Gender": $("#Malecheck").is(":checked"),
        "Recorded": false,
        "UnitRoomFk": null,
        "StudyBranchId": $('#studyBranch').val(),
        "CityId": city,

    };
    var btn = document.getElementById('book');
    btn.setAttribute('disabled', '');
    btn.innerText ="....جاري حجز موعد";
    $.ajax({
        type: 'POST',
        url: "/Student/BookDate",
        data: JSON.stringify(data),
        contentType:'application/json',
        success: function (data) {
            if (data != null) {
                
                document.getElementById('finalDate').innerHTML = data.finalDate;
                document.getElementById('displayname').innerHTML = $('#fullname').val();
                document.getElementById('unitname').innerHTML = data.unitName;
                    
                document.getElementById('modaltrigger').click();
                btn.removeAttribute('disabled');
                btn.innerText="حجز موعد";
                return true;
            }
            else {
                
            }
        },
        error: function () {
            console.log(data);
            document.getElementById('erorremodaltrigger').click();
            btn.removeAttribute('disabled');
            return true;
        }
       
    });

    return false;
}




//validation
const form = document.getElementById('form');
const name = document.getElementById('fullname');
const email = document.getElementById('Email');
const mainCity = document.getElementById('mainCity');
const country = document.getElementById('country');
const PhoneNumber = document.getElementById('phoneNumber');
const studyBranch = document.getElementById('studyBranch');
const UnivercityNumber = document.getElementById('UnivercityNumber');
const NationalNumber = document.getElementById('NationalNumber');
const Malecheck = document.getElementById('Malecheck');
const Femalecheck = document.getElementById('Femalecheck');




function checkInputs() {
    const nameValue = name.value.trim();
    const emailValue = email.value.trim();
    const mainCityValue = mainCity.value;
    const countryValue = country.value;
    const PhoneNumberValue = PhoneNumber.value.trim();
    const studyBranchValue = studyBranch.value;
    const UnivercityNumberValue = UnivercityNumber.value.trim();
    const NationalNumberValue = NationalNumber.value.trim();
    const MalecheckValue = $("#Malecheck").is(":checked");
    const FemalecheckValue = $("#Femalecheck").is(":checked");
    /*isAvailable(UsernameValue);*/
    var b = 0;

  


        $.ajax({

            type: 'GET',
            url: "/Check/CheckStudentEmail?Email=" + emailValue +"&NationalNumber="+ NationalNumberValue,
            success: function (data, ev) {
                if (ev.first !== true) {
                    ev.first = true;
                    if (nameValue === '') {
                        setErrorFor(name, 'الرجاءأدخل اسمك ');
                    }
                    else {
                        setSuccessFor(name);
                        b = b + 1;

                    }
                    if (emailValue === '') {
                        setErrorFor(email, 'الرجاء أدخال البريد الإلكنروني');
                    }
                    else if (data.email == false) {
                        setErrorFor(email, 'عذرا هذا البريد الالكتروني مأخوذ');
                    }
                    else if (!isGmail(emailValue)) {
                        setErrorFor(email, 'الرجاء التأكد من صحة البريد الإلكنروني');
                    }
                    else if (data.email) {
                        setSuccessFor(email);
                        b = b + 1;
                    }
                    if (mainCityValue == -1) {
                        setErrorFor(mainCity, 'الرجاء أختيار اسم المحافظة');
                    }
                    else if (mainCityValue == 1 && countryValue == -1)
                    {
                        setErrorFor(mainCity, 'لا يجوز لسكان محافظة حلب التسجيل في السكن');

                    }
                    else {
                        setSuccessFor(mainCity);
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
                    if (studyBranchValue == -1) {
                        setErrorFor(studyBranch, 'الرجاء اختيار فرعك الدراسي');
                    }
                    else {
                        setSuccessFor(studyBranch);
                        b = b + 1;

                    }
                    if (UnivercityNumberValue === '') {
                        setErrorFor(UnivercityNumber, 'الرجاءأدخال رقمك الجامعي');
                    }
                    else if (!isUnivercityNumber(UnivercityNumberValue)) {
                        setErrorFor(UnivercityNumber, 'يجب ان يكون الرقم الجامعي بطول 4 خانات او اكثر');
                    }
                    else {
                        setSuccessFor(UnivercityNumber);
                        b = b + 1;

                    }
                    if (NationalNumberValue === '') {
                        setErrorFor(NationalNumber, 'الرجاءأدخال رقمك الوطني');
                    }
                    else if (!isNationalNumber(NationalNumberValue)) {
                        setErrorFor(NationalNumber, 'الرجاء ادخال رقم وطني بطول 11 رقم');
                    }
                    else if (data.national == false) {
                        setErrorFor(NationalNumber, 'هذا الرقم الوطني مأخوذ');
                    }
                    else {
                        setSuccessFor(NationalNumber);
                        b = b + 1;

                    }
                    if (MalecheckValue == false && FemalecheckValue == false) {
                        setErrorFor(Femalecheck, 'الرجاءاختيار جنسك');
                    }
                    else {
                        b = b + 1;
                        setSuccessFor(Femalecheck)
                    }

                    if (b == 8) {
                        bookdate();
                    }
                    else {
                        return false;
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
function isUnivercityNumber(number) {
    return /([0-9]{4})$/.test(number);
}
function isNationalNumber(number) {
    return /([0-9]{11})$/.test(number);
}
