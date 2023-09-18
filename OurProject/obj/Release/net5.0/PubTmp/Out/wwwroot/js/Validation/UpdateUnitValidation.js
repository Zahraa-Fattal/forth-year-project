//validation
const form = document.getElementById('form');
const name = document.getElementById('name');
const superVisor = document.getElementById('superVisor');
const storeKeeper = document.getElementById('storeKeeper');
const studyBranch = document.getElementById('StudyBranch');
const store = document.getElementById('store');




function checkInputs() {
    const nameValue = name.value.trim();
    const superVisorValue = superVisor.value;
    const storeKeeperValue = storeKeeper.value;
    const studyBranchValue = studyBranch.value;
    const storeValue = store.value;
    var x = nameValue.count;
    var b = 0;

    if (nameValue === '') {
        setErrorFor(name, 'الرجاء أدخال اسم الوحدة');
    } else if (x < 2) {
        setErrorFor(name, 'الرجاء أدخال اسم الوحدة اكبر من حرفين');
    }
    else {
        setSuccessFor(name);
        b = b+1;
    }
    if (superVisorValue == -1) {
        setErrorFor(superVisor, 'الرجاء أختيار اسم المشرف');
    } else {
        setSuccessFor(superVisor);
        b = b + 1;
    }
    if (storeKeeperValue == -1) {
        setErrorFor(storeKeeper, 'الرجاء أختيار اسم أمين المستودع');
    } else {
        setSuccessFor(storeKeeper);
        b = b + 1;
    }
    if (studyBranchValue == -1) {
        setErrorFor(studyBranch, 'الرجاء أختيار الفرع الدراسي');
    } else {
        setSuccessFor(studyBranch);
        b = b + 1;
    }
    if (storeValue == -1) {
        setErrorFor(store, 'الرجاء أختيار المستودع');
    } else {
        setSuccessFor(store);
        b = b + 1;
    }
    if (b == 5) {
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