var readerModule = angular.module('readerModule', []);

readerModule.controller('ReaderController', ['$scope', '$http', function ($scope, $http) {
    
    $scope.readerList = [];
    $scope.createdReader = {};

    $scope.detailedReader = {};

    $scope.genreList = [
        'Drama',
        'Comedy',
        'SciFi'
    ];

    $scope.getReaderList = function(){
        $http.get('/api/readersapi/getall').then(function(data){
            $scope.readerList = data.data;
            console.log($scope.readerList);
        });
    };

    $scope.getReaderById = function (id) {
        $http.get('/api/readersapi/GetReaderDetailsById/' + id).then(function (response) {
            $scope.detailedReader = response.data;
        });
    };

    $scope.createReader = function () {
        $http.post('/api/readersapi/create', $scope.createdReader);
    };

    $scope.deleteReader = function (item) {
        $http.post('/api/readersapi/delete', item).then(function () {
            $scope.getReaderList();
        });      
    };

    $scope.redirectToCreate = function () {
        window.location.href = '/Readers/Create';
    };

    $scope.redirectToDetails = function (reader) {
        sessionStorage.setItem('readerToDetail', reader.id);
        window.location.href = '/Readers/Details';
    };

    $scope.initialiseMainTable = function () {
        $scope.getReaderList();
    };

    $scope.initialiseDetails = function () {
        $scope.getReaderById(sessionStorage.getItem('readerToDetail'));
    }
}]);