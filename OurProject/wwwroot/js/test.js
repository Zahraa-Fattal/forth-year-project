/*superVisor*/
    var superVersionId = document.getElementById('superVersionId').value;
    var options = document.getElementById('superVisor').options;
    for (let i = 0; i < options.length; i++) {
        if (options[i].value == superVersionId) {
            options[i].setAttribute("selected", "");
        }
}
/*storeKeeper*/
var storeKeeperId = document.getElementById('StoreKeeperId').value;
var options = document.getElementById('storeKeeper').options;
for (let i = 0; i < options.length; i++) {
    if (options[i].value == storeKeeperId) {
        options[i].setAttribute("selected", "");
    }
}
/*store*/
var storeId = document.getElementById('StoreId').value;
var options = document.getElementById('store').options;
for (let i = 0; i < options.length; i++) {
    if (options[i].value == storeId) {
        options[i].setAttribute("selected", "");
    }
}
/*Study Branch*/
var studyBranchId = document.getElementById('StudyBranchId').value;
var options = document.getElementById('StudyBranch').options;
for (let i = 0; i < options.length; i++) {
    if (options[i].value == studyBranchId) {
        options[i].setAttribute("selected", "");
    }
}

function changeImage() {
    var saveimage = document.getElementById('save-image').value;
    $("#oldImage").attr('value', saveimage);
    $("#image").attr('src', saveimage);
}

//var gender = document.getElementById('gender').value;
//var male = document.getElementById('male');
//var female = document.getElementById('female');
//if (gender == 1) {
//    male.setAttribute("checked", "");
//}
//else {
//    female.setAttribute("checked", "");
//}
