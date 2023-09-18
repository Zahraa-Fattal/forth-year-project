//validation
const form = document.getElementById('form');
function inputPercent(StudentChosen, StudentTaken, StoreDetailsAmount) {
    {

       

        const StudentAmontChosen = document.getElementById(StudentChosen);
        const StudentTaken1 = document.getElementById(StudentTaken);

        var StudentAmontChosenValue = parseInt($('#' + StudentChosen).val());
        var StudentTakenValue = parseInt($('#' + StudentTaken).val());
        var StoreDetailsAmountValue = parseInt($('#' + StoreDetailsAmount).val());

        var sum = StudentAmontChosenValue + StudentTakenValue;

        if (sum > 2) {
            setErrorFor(StudentAmontChosen, 'لا يمكنك اخد اكتر من أداتين');
        }
        else if (sum > StoreDetailsAmountValue) {
            setErrorFor(StudentAmontChosen, 'لا يوجد أدوات متوفرة');
        }
        else {
            setSuccessFor(StudentAmontChosen);
         
        }
      
     

    }
}

function checkValidation()
{
    const ChooseOne = document.getElementById('ChooseOne');
    
    const bigall = document.querySelectorAll('.big');
    var b = 0;
    for (let i = 0; i < bigall.length-1; i++) {
        if (bigall[i].className == 'big error') {
            return false;
        }
        if (bigall[i].className == 'big correct') {
            b = b + 1;
        }
    }
    if (b != 0) {
       
        return true
    }
    else {
        setErrorFor(ChooseOne, "الرجاء اختيار معدة واحدة على الأقل");
        return false;
    }

   
  


}



function setErrorFor(input, message) {
    const big = input.parentElement;
    const small = big.querySelector('small');

    small.innerText = message;
    big.className = 'big error';
}
function setErrorForWithOutMessage(input) {
    const big = input.parentElement;

    big.className = 'big error';
}
function setSuccessFor(input) {
    const big = input.parentElement;
    big.className = 'big correct';
}