var complexViewModule = angular.module('complexViewModule', []);

complexViewModule.controller('ComplexViewController', ['$http', '$scope', function ($http, $scope) {

    $scope.authorTable = [];
    $scope.bookTable = [];

    $scope.getData = function () {
        $http.get('/api/complextablesapi/getComplexAuthorView').then(function (authorResponse) {
            $scope.authorTable = authorResponse.data;
            console.log($scope.authorTable);
            $http.get('/api/complextablesapi/getComplexBookView').then(function (bookResponse) {
                $scope.bookTable = bookResponse.data;
                console.log($scope.bookTable);
            });
        });
    };

    $scope.getBookTable = function () {
        $http.get('/api/complextablesapi/getComplexBookView').then(function (response) {
            $scope.bookTable = response.data;
            console.log($scope.bookTable);
        });
    };

    $scope.redirectToReaderDetails = function (reader) {
        console.log(reader);
        sessionStorage.setItem('readerToDetail', reader.id);
        window.location.href = '/Readers/Details';
    };

    $scope.initialise = function () {
        $scope.getData();
    };

}]);