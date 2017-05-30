
var app = angular.module('app', ['ui.grid', 'ui.grid.edit', 'ui.grid.rowEdit', 'ui.grid.cellNav', 'blockUI', 'ngCookies', 'ui.grid.pagination']);

var Objectos;

var finalizado = "";
var count = 0;
var total = 0;

var nomearquivofull = "";

app.controller("CtrlLogin", ['$scope', '$http', 'uiGridConstants', 'blockUI', '$parse', '$cookies', '$cookieStore', '$timeout', 'dateFilter', '$interval',
function ($scope, $http, uiGridConstants, blockUI, parse, $cookies, $cookieStore, $timeout, dateFilter, $interval) {

    Objectos = $scope;

    $scope.CreateUser = function () {


        var data = {
            Username: $scope.CreateAccount.Username,
            Password: $scope.CreateAccount.Password,
            RepeatPassword: $scope.CreateAccount.RepeatPassword
        };

        var config = {
            params: data,
            headers: { 'Accept': 'application/json' }
        };

        $http.post(window.location.origin + '/api/webapi/Index/CreateUser', config).then(function (data) {


        });
    }

    $scope.NomeArquivo = function () {

        //var model = $scope.Users;

        var data = {
            Username: $scope.Users.Username,
            Password: $scope.Users.Password,
        };

        var config = {
            params: data,
            headers: { 'Accept': 'application/json' }
        };

        var autentic = 'http://localhost:51346/api/WebApplicationAccess'

        $http.get(autentic).then(function (context)
        {

            var teste = context;
        });

        //$http.get(window.location.origin + '/api/webapi/Login/Login', config).then(function (data) {


        //});
    }


}]);

$('.toggle').on('click', function () {
    $('.container').stop().addClass('active');
});

$('.close').on('click', function () {
    $('.container').stop().removeClass('active');
});