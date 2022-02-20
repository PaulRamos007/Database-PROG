function deleteEmployee(empId) {
    $.ajax({
        type: 'GET',
        url: '/Home/DeleteEmployee/?empId=' + empId,
        data: {},
        success: function (data) {
            alert('Employee ID: ' + empId + ' was deleted.');
            window.location.reload();
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
    });
}

function updateEmployee(rowId) {
    var fName = $('#' + rowId).find('[name="fName"]').val();
    var lName = $('#' + rowId).find('[name="lName"]').val();
    var empId = $('#' + rowId).find('[name="empId"]').val();
    var depoId = $('#' + rowId).find('[name="depoItem"]').val();

    var employee = {
        First_Name: fName,
        Last_Name: lName,
        Emp_Id: empId,
        Dept_Id: depoId
    }

    $.ajax({
        type: "POST",
        url: "/Home/UpsertEmployee/",
        data: JSON.stringify(employee),
        success: function (data) {
            alert("Employee ID: " + empId + " was updated.");
            window.location.reload();
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
    });
}

function saveEmployee() {
    var fName = document.getElementById('fName').value;
    var lName = document.getElementById('lName').value;
    var newDepoId = document.getElementById('depoItem').value;

    var employee = {
        First_Name: fName,
        Last_Name: lName,
        Dept_Id: newDepoId
    }

    $.ajax({
        type: 'POST',
        url: '/Home/UpsertEmployee/',
        data: JSON.stringify(employee),
        success: function (data) {
            alert('Employee: ' + fName + ' ' + lName + ' was saved.');
            window.location.reload();
        },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
    });
}

function search() {
    var searchTerm = document.getElementById('txtSearch').value;

    window.location.href = "/Home/Index/?searchTerm=" + searchTerm;
}