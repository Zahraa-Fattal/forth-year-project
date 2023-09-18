function filterByStudentCount()
{
    var options = document.getElementById('dd1Counter').options;
    var id = options[options.selectedIndex].value;
    $("#SelectedStudentNumber").attr('value', id);

    document.getElementById('FilterByStudentCount').click();
}