var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url:'/employee/getall'},
        "columns": [
            { data: 'firstName', "width": "25%" },
            { data: 'lastName', "width": "15%" },
            { data: 'company', "width": "10%" },
            { data: 'designation', "width": "15%" },
            { data: 'degree', "width": "10%" },
            { data: 'department', "width": "10%" },
            { data: 'country', "width": "10%" },
            { data: 'city', "width": "10%" },
            { data: 'shirtSize', "width": "10%" },
            {
                data: 'empID',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                     <a href="/employee/edit?id=${data}" class="btn btn-primary mx-2"> Edit</a>
                     <a href="/employee/delete/${data}" class="btn btn-danger mx-2"> Delete</a>
                    </div>`
                },
                "width": "25%"
            }
        ]
    });
}

