var isbnModule = angular.module('isbnModule', []);

isbnModule.controller('ISBNController', ['$http', '$scope', function ($http, $scope) {

    $scope.isbnList = [];
    $scope.createdISBN = {};

    $scope.detailedISBN = {};

    $scope.countryList = [
        'LT',
        'LV',
        'EST'
    ];

    $scope.getISBNList = function () {
        $http.get('/api/isbnapi/getall').then(function (data) {
            $scope.isbnList = data.data;
            console.log($scope.isbnList);
        });
    };

    $scope.getISBNById = function (id) {
        $http.get('/api/isbnapi/GetISBNDetailsById/' + id).then(function (response) {
            $scope.detailedISBN = response.data;
        });
    };

    $scope.createISBN = function () {
        $http.post('/api/isbnapi/create', $scope.createdISBN);
    };

    $scope.deleteISBN = function (item) {
        $http.post('/api/isbnapi/delete', item).then(function () {
            $scope.getISBNList();
        });
    };

    $scope.redirectToCreate = function () {
        window.location.href = '/ISBN/Create';
    };

    $scope.redirectToDetails = function (isbn) {
        sessionStorage.setItem('isbnToDetail', isbn.id);
        window.location.href = '/ISBN/Details';
    };

    $scope.initialiseMainTable = function () {
        $scope.getISBNList();
    };

    $scope.initialiseDetails = function () {
        $scope.getISBNById(sessionStorage.getItem('isbnToDetail'));
    }
}]);