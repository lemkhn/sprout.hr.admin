$(document).ready(function () {
    var salary = new Salary();
    salary.Init();
});

function Salary() {
    var _salaryFunc = this;

    this.Init = () => {
        _salaryFunc.PopulateFields();

        $('.next-page-toggle').unbind().click(() => {
            $(this).closest('.header').siblings('.inner-forms').find('.wrapper').toggleClass('next-page');
            $(this).toggleClass('clicked');

            let buttonId = $(this).data('button-id')

            if ($(this).hasClass('clicked')) {
                $(buttonId).removeClass('btn-primary').addClass('btn-success');
                $(buttonId).html('<i class="fa fa-list" aria-hidden="true"></i> ' + $(this).data('off'));
            } else {
                $(buttonId).removeClass('btn-success').addClass('btn-primary');
                $(buttonId).html('<i class="fa fa-plus" aria-hidden="true"></i> ' + $(this).data('on'));
            }
        });

        $('#btnCalculateSalary').unbind().click(() => {
            let days = $('#txtDays').val().trim().match(/^\d+(\.\d{0,2})?$/) !== null ? $('#txtDays').val().trim() : null;

            let employeeTypeModel = {
                EmployeeTypeName: $('#txtEmployeeType').val(),
                MonthWorkdays: days,
                AbsenceCount: days,
                EmployeeRate: $('#txtEmployeeRate').val()
            }

            if (!hasNull(employeeTypeModel)) {
                _salaryFunc.CalculateSalary(employeeTypeModel);
            } else {
                alert("Incorrect/No Days set.");
            }
        });
    };

    this.CalculateSalary = (employeeTypeModel) => {
        $.post("../Salary/ComputeSalary", { employeeTypeModel }, (resp) => {
            var response = JSON.parse(resp);

            if (response.Status == 1) {
                $('#txtCalculatedSalary').val(response.Data.EmployeeSalary.toFixed(2));
            } else {
                alert(response.Message);
            }
        }).fail((ex) => {
            alert(ex.statusText);
        });
    }

    this.PopulateFields = () => {
        let employeeList = JSON.parse(localStorage.getItem('EmployeeList'));
        let employeeDtls = employeeList.filter(data => data.EmployeeId == GetCookie("employeeId"))[0];

        SetCookie("employeeDtls", employeeDtls, 1);

        $('#txtEmployeeName').val(employeeDtls.EmployeeName);
        $('#txtEmployeeType').val(employeeDtls.EmployeeType);
        $('#txtEmployeeRate').val(employeeDtls.EmployeeSalary);
    }
}