﻿

   

var app = angular.module('myapp', []);
app.controller("HomeController", function ($scope, $http) {
    debugger;
    $scope.InsertData = function () {
        debugger
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            $scope.Employe = {};
            $scope.Employe.Ordernumber = $scope.Ordernumber;
            $scope.Employe.Customername = $scope.Customername;
            //$scope.Employe.Id = $scope.EmpAge;
            $http({
                method: "POST",
                url: "/Home/Insert_Employee",
                datatype: "json",
                data: JSON.stringify($scope.Employe)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllData();
                $scope.Ordernumber = "";
                $scope.Customername = "";
               
            })
        } else {
            $scope.Employe = {};
            $scope.Employe.Ordernumber = $scope.Ordernumber;
            $scope.Employe.Customername = $scope.Customername;
            $scope.Employe.orderId = document.getElementById("EmpID_").value;
            $http({
                method: "post",
                url: "http://localhost:1316/Home/Update_Employee",
                datatype: "json",
                data: JSON.stringify($scope.Employe)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllData();
                $scope.Ordernumber = "";
                $scope.Customername = "";
               
                document.getElementById("btnSave").setAttribute("value", "Submit");
                document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
                document.getElementById("spn").innerHTML = "Add New Employee";
            })
        }
    }
    $scope.GetAllData = function () {

        $http({
            method: "get",
            url: "http://localhost:1316/Home/Get_AllEmployee"
        }).then(function (response) {
            $scope.employees = response.data;
        }, function () {
            alert("Error Occur");
        })
    };
    $scope.DeleteEmp = function (Emp) {
        $http({
            method: "post",
            url: "http://localhost:1316/Home/Delete_Employee",
            datatype: "json",
            data: JSON.stringify(Emp)
        }).then(function (response) {
            alert(response.data);
            $scope.GetAllData();
        })
    };
    $scope.UpdateEmp = function (Emp) {
        debugger
        document.getElementById("EmpID_").value = Emp.orderId;
        $scope.Customername = Emp.Customername;

        $scope.Ordernumber = Emp.Ordernumber;
    

            document.getElementById("btnSave").setAttribute("value", "Update");
            document.getElementById("btnSave").style.backgroundColor = "Yellow";
            document.getElementById("spn").innerHTML = "Update Employee Information";
       
    };
           
})