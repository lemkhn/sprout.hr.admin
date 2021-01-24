$(document).ready(function () {
    var employee = new Employee();
    employee.Init();
});

function Employee() {
    var _employeeFunc = this;

    this.Init = () => {
        //! since i have no data base I'm saving my data in the localStorage of the browser
        var employeeList = JSON.parse(localStorage.getItem('EmployeeList'));

        if (IsEmpty(employeeList)) {
            _employeeFunc.GetEmployees();
        } else {
            _employeeFunc.DrawTable(employeeList);
        }

        $('#txtBirthDate').prop('max', function () {
            return new Date().toJSON().split('T')[0];
        });

        $('.next-page-toggle').unbind().click(function () {
            $(this).closest('.header').siblings('.inner-forms').find('.wrapper').toggleClass('next-page');
            $(this).toggleClass('clicked');

            var buttonId = $(this).data('button-id')

            if ($(this).hasClass('clicked')) {
                $(buttonId).removeClass('btn-primary').addClass('btn-success');
                $(buttonId).html('<i class="fa fa-list" aria-hidden="true"></i> ' + $(this).data('off'));
            } else {
                $(buttonId).removeClass('btn-success').addClass('btn-primary');
                $(buttonId).html('<i class="fa fa-plus" aria-hidden="true"></i> ' + $(this).data('on'));
            }
        });

        $('#tblEmployee').click('.nav-container .compute-salary', (e) => {
            let employeeId = e.target.dataset.empDtls;

            _employeeFunc.GetEmployee(employeeId);
        });

        $('#btnSubmitEmployee').unbind().click(() => {
            let salary = $('#txtEmployeeSalary').val().trim().match(/^\d+(\.\d{0,2})?$/) !== null ? $('#txtEmployeeSalary').val().trim() : null;
            let birthDate = isNaN(Date.parse($('#txtBirthDate').val())) ? null : moment($('#txtBirthDate').val()).format('MM/DD/YYYY');

            let employeeDtl = {
                EmployeeName: $('#txtEmployeeName').val(),
                BirthDate: birthDate,
                TinNumber: $('#txtTINNumber').val(),
                EmployeeType: $("#txtEmployeeType :selected").val(),
                EmployeeSalary: salary
            }

            if (!hasNull(employeeDtl)) {
                _employeeFunc.AddEmployee(employeeDtl);
            } else {
                alert("Incorrect/Incomplete Form. Re-check your inputs.");
            }
        });
    };

    this.GetEmployees = () => {
        $.get("../Home/GetEmployees", (resp) => {
            var response = JSON.parse(resp);

            if (response.Status === 1) {
                //! since i have no data base I'm saving my data in the localStorage of the browser
                localStorage.setItem('EmployeeList', JSON.stringify(response.Data));
                _employeeFunc.DrawTable(response.Data);
            } else {
                alert(response.Message);
            }
        }).fail((ex) => {
            alert(ex.statusText);
        });
    };

    this.DrawTable = (employeeList) => {
        $('#tblEmployee').DataTable({
            info: false,
            sort: false,
            paging: true,
            autoWidth: false,
            lengthChange: false,
            pagingType: "simple_numbers",       
            data: employeeList,
            columns: [
                {
                    data: 'EmployeeName',
                    render: (data, type, full, meta) => {
                        return '<span>' + data + '</span><br/><div class="nav-container"><a class="compute-salary" data-emp-Dtls="' + full.EmployeeId + '" href="#"><i aria-hidden="true" class="fa fa-pencil"></i> Compute Salary </a></div>';
                    }
                },
                {
                    data: 'BirthDate',
                    render: (data, type, full, meta) => {
                        return `<span>${moment(data).format('MM/DD/YYYY')}</span>`;
                    }
                },
                {
                    data: 'TinNumber'
                },
                {
                    data: 'EmployeeSalary'
                },
                {
                    data: 'EmployeeType',
                    render: (data, type, full, meta) => {
                        return data.toUpperCase() == 'REGULAR' ? `<span class="badge badge-primary">${data}</span>` : `<span class="badge badge-warning">${data}</span>`;
                    }
                }
            ],
            responsive: {
                details: {
                    renderer: function (api, rowIdx, columns) {
                        var data = $.map(columns, function (col, i) {
                            return col.hidden ?
                                '<tr data-dt-row="' + col.rowIndex + '" data-dt-column="' + col.columnIndex + '">' +
                                '<td>' + col.title + ':' + '</td> ' +
                                '<td>' + col.data + '</td>' +
                                '</tr>' :
                                '';
                        }).join('');

                        return data ?
                            $('<table/>').append(data) :
                            false;
                    }
                }
            },
        });
    }

    this.GetEmployee = (employeeId) => {
        //! since i have no data base I'm saving my data in the localStorage of the browser
        var employeeList = JSON.parse(localStorage.getItem('EmployeeList'));

        $.post("../Home/GetEmployee", { employeeList, employeeId }, (resp) => {
            var response = JSON.parse(resp);

            if (response.Status == 1) {
                DeleteCookie("employeeId");
                SetCookie("employeeId", response.Data.EmployeeId, 1);

                DeleteCookie("employeeType");
                SetCookie("employeeType", response.Data.EmployeeType, 1);

                window.location.href = `/Salary`;
            } else {
                alert(response.Message);
            }
        }).fail((ex) => {
            alert(ex.statusText);
        });
    };

    this.AddEmployee = (employeeDtl) => {
        var employeeList = JSON.parse(localStorage.getItem('EmployeeList'));

        $.post("../Home/AddEmployee", { employeeDtl, employeeList }, (resp) => {
            var response = JSON.parse(resp);

            if (response.Status === 1) {
                //! since i have no data base I'm saving my data in the localStorage of the browser
                localStorage.setItem('EmployeeList', JSON.stringify(response.Data));

                $('#tblEmployee').DataTable().clear().destroy();
                _employeeFunc.DrawTable(response.Data);

                alert('Successfully added new employee.');

                $('#btnClearForm').click();
                $('#btnPageToggle').click();
            } else {
                alert(response.Message);
            }
        }).fail((ex) => {
            alert(ex.statusText);
        });
    };
}