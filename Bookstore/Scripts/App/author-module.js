var authorModule = angular.module('authorModule', []);

authorModule.controller('AuthorController', ['$scope', '$http', '$location', function ($scope, $http, $location) {

    $scope.authors = [];
    $scope.detailedAuthor = {};

    $scope.createdAuthor = {
        alive: false
    };

    $scope.getAuthorList = function () {
        $http.get("/api/authorsapi/getall").then(function (response) {
            $scope.authors = response.data;
            console.log(response.data);
            console.log($scope.authors);
        });
    }

    $scope.getAuthorById = function (id) {
        $http.get('/api/authorsapi/GetAuthorDetailsById/' + id).then(function (response) {
            $scope.detailedAuthor = response.data;
        });
    };

    $scope.createAuthor = function () {
        console.log($scope.createdAuthor);

        $http.post("/api/authorsapi/create", $scope.createdAuthor);

        //window.location.href = '/Authors';
    }

    $scope.deleteAuthor = function (item) {
        $http.post("/api/authorsapi/delete", item).then(function () {
            $scope.getAuthorList();
        });
    };

    $scope.updateAuthor = function (item) {

    };

    $scope.redirectToCreate = function () {
        window.location.href = '/Authors/Create';
    };

    $scope.redirectToDetails = function (author) {
        sessionStorage.setItem('authorToDetail', author.id);
        window.location.href = '/Authors/Details';
    };

    $scope.initialiseMainTable = function () {
        $scope.getAuthorList();
    };

    $scope.initialiseDetails = function () {
        $scope.getAuthorById(sessionStorage.getItem('authorToDetail'));
    }
}]);
    