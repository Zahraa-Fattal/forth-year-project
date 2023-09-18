/*StudyBranch*/
var StudyBranchValue = document.getElementById('StudyBranchValue').value;
var options = document.getElementById('StudyBranch').options;
for (let i = 0; i < options.length; i++) {
    if (options[i].value == StudyBranchValue) {
        options[i].setAttribute("selected", "");
    }
}

/*MainCity*/
var MainCityValue = document.getElementById('MainCityValue').value;
var options = document.getElementById('mainCity').options;
for (let i = 0; i < options.length; i++) {
    if (options[i].value == MainCityValue) {
        options[i].setAttribute("selected", "");
    }
}



/*Room*/
var RoomNameValue = document.getElementById('RoomNameValue').value;
var RoomValue = document.getElementById('RoomValue').value;
var options = document.getElementById('Room').options;
for (let i = 0; i < options.length; i++) {
    if (options[i].value == RoomValue) {
        options[i].setAttribute("selected", "");
    }
}






/*MainCity*/
function getCountry() {
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
        /*Country*/
        var CountryValue = document.getElementById('CountryValue').value;
        var options1 = document.getElementById('country').options;
        for (let i = 0; i < options1.length; i++) {
            if (options1[i].value == CountryValue) {
                options1[i].setAttribute("selected", "");
            }
        }
    });
    
  
}
/*FreeRooms*/
function getFreeRooms() {
    var oldSuggestedUnitId = document.getElementById("oldSuggestedUnitId").value;
    var options = document.getElementById('StudyBranch').options;
    var id = options[options.selectedIndex].value;
    var ok = false;
    var data =
    {
        "StudyBranch": id,
        "mail": $('#dot-1').is(":checked"),
        "femail": $('#dot-2').is(":checked"),
    };
    $.ajax({
        type: 'POST',
        url: "/Check/GetRoomValidation",
        data: JSON.stringify(data),
        contentType: 'application/json',
        error: function () {
            $('#Room').empty();
            $('#Room').append($('<option>', { value: -1, text: 'لايوجد' }));
        }

    }).done(function (data) {
        console.log(data);
        $('#Room').empty();
        // our ajax call is finished, we have the data returned from the server in a var called data
        // loop through our returned data and add an option to the select for each province returned
        $('#Room').append($('<option>', { value: -1, text: 'لايوجد' }));
        $.each(data.getFreeRoomsByUnitIdDtos, function (i, item) {
            $('#Room').append($('<option>', { value: item.id, text: item.name }));
            if (oldSuggestedUnitId == data.newSugestedUnitId) {
                if (RoomValue == item.id) {
                    ok = true;
                }
            }
            else {
                ok = true;
            }
         
        });
        if (!ok) {
            var OldRoomValue = document.getElementById('RoomValue').value;
            if (OldRoomValue!=-1) {
                $('#Room').append($('<option>', { value: RoomValue, text: RoomNameValue }));
            }
        
        }
        var options = document.getElementById('Room').options;
        for (let i = 0; i < options.length; i++) {
            if (options[i].value == RoomValue) {
                options[i].setAttribute("selected", "");
            }
        }
      
    });
}







function checkInputs() {
    //validation
    const form = document.getElementById('form');
    const name = document.getElementById('name');
    const Room = document.getElementById('Room');
    const mainCity = document.getElementById('mainCity');
    const PhoneNumber = document.getElementById('PhoneNumber');
    const studyBranch = document.getElementById('StudyBranch');
    const UnivercityNumber = document.getElementById('UniversityId');
    const NationalNumber = document.getElementById('NationalId');
    const Malecheck = document.getElementById('dot-1');
    const Femalecheck = document.getElementById('dot-2');


    const nameValue = name.value.trim();
    const RoomValue = Room.value;
    const mainCityValue = mainCity.value;
    const PhoneNumberValue = PhoneNumber.value.trim();
    const studyBranchValue = studyBranch.value;
    const UnivercityNumberValue = UnivercityNumber.value.trim();
    const NationalNumberValue = NationalNumber.value.trim();
    const MalecheckValue = $("#dot-1").is(":checked");
    const FemalecheckValue = $("#dot-2").is(":checked");
    if (MalecheckValue) {
        $("#gender").attr('value', "true");
    }
    else {
        $("#gender").attr('value', "false");
    }
                
   
    /*isAvailable(UsernameValue);*/
    var b = 0;
    var data =
    {
        "StudyBranch": $('#StudyBranch').val(),
        "mail": $('#dot-1').is(":checked"),
        "femail": $('#dot-2').is(":checked"),
    };

    $.ajax({
        type: 'POST',
        url: "/Check/GetUnitValidation",
        data: JSON.stringify(data),
        contentType: 'application/json',
        success: function (data)
        {
                if (nameValue === '') {
                    setErrorFor(name, 'الرجاءأدخل اسم الطالب ');
                }
                else {
                    setSuccessFor(name);
                    b = b + 1;

                }
               
                if (RoomValue == -1) {
                    setErrorFor(Room, 'الرجاء اختيار غرفة');
                }

                else {
                    setSuccessFor(Room);
                    b = b + 1;
                }
                if (mainCityValue == -1) {
                    setErrorFor(mainCity, 'الرجاء أختيار اسم المحافظة');
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
            else if (data != null) {
                setUniteName(studyBranch, data);
                b = b + 1;
            }
            else {
                setErrorFor(studyBranch, 'لا يوجد وحدة متاحة')
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
                    document.getElementById('addStudent').click();
                }
             
            
        },
        error: function () {
            setErrorFor(studyBranch, 'لا يوجد وحدة متاحة');
        }

    })

              







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
function setUniteName(input, message) {
    const big = input.parentElement;
    const small = big.querySelector('small');

    small.innerText = message;
    big.className = 'big correct correct1';

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


