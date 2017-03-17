var authorModule = angular.module('authorModule', ['ui.bootstrap']);

authorModule.controller('AuthorController', ['$scope', '$http', '$location', '$uibModal', function ($scope, $http, $location, $uibModal) {

    $scope.authors = [];
    $scope.detailedAuthor = {};

    $scope.createdAuthor = {
        alive: false
    };

    $scope.getAuthorList = function () {
        $http.get("/api/authorsapi/getall").then(function (response) {
            $scope.authors = response.data;
        });
    }

    $scope.getAuthorById = function (id) {
        $http.get('/api/authorsapi/GetAuthorDetailsById/' + id).then(function (response) {
            $scope.detailedAuthor = response.data;
        });
    };

    $scope.createAuthor = function () {
        $http.post("/api/authorsapi/create", $scope.createdAuthor).then(function () {

        });

        window.location.href = '/Authors/Index';
    }

    $scope.deleteAuthorModal = function (item) {
        var deleteModal = $uibModal.open({
            templateUrl: 'deleteAuthorModal.html',
            controller: 'authorModalController',
            controllerAs: 'modalCtrl',
            resolve: {
                mainScope: function(){
                    return $scope;
                },
                author: function () {
                    return item;
                }
            }
        });
    };

    $scope.updateAuthorModal = function (item) {
        console.log($scope);
        var updateModal = $uibModal.open({
            templateUrl: 'updateAuthorModal.html',
            controller: 'authorModalController',
            controllerAs: 'modalCtrl',
            resolve: {
                mainScope: function(){
                    return $scope;
                },
                author: function () {
                    return item;
                }
            }
        });
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

authorModule.controller('authorModalController', ['$uibModalInstance', '$http', '$scope', 'mainScope', 'author', function ($uibModalInstance, $http, $scope, mainScope, author) {
    $scope.modalAuthor = {};
    angular.copy(author, $scope.modalAuthor);

    $scope.cancel = function () {
        $scope.modalAuthor = {};
        mainScope.getAuthorList();
        $uibModalInstance.dismiss('cancel');
    };

    $scope.updateAuthor = function () {
        $http.post('/api/authorsapi/update', $scope.modalAuthor).then(function () {
            $scope.cancel();
        });
    };

    $scope.deleteAuthor = function () {
        $http.post("/api/authorsapi/delete", $scope.modalAuthor).then(function () {
            $scope.cancel();
        });
    };
}]);
    