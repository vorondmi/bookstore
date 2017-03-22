var authorModule = angular.module('authorModule', ['ui.bootstrap', 'dataProvider']);

authorModule.controller('AuthorController', ['$scope', '$location', '$uibModal', 'authorDataService', function ($scope, $location, $uibModal, authorDataService) {

    $scope.authors = [];
    $scope.detailedAuthor = {};

    $scope.createdAuthor = {
        alive: false
    };

    $scope.getAuthorList = function () {
        authorDataService.getAuthorList().then(function (response) {
            $scope.authors = response;
        });
    }

    $scope.getAuthorById = function (id) {
        authorDataService.getAuthorById(id).then(function (response) {
            $scope.detailedAuthor = response;
        });
    };

    $scope.createAuthor = function () {
        authorDataService.createAuthor($scope.createdAuthor).then(function () {
            $scope.createdAuthor = {};
            window.location.href = '/Authors/Index';
        });
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
        window.location.href = '/Authors/Details';
    };

    $scope.initialiseMainTable = function () {
        $scope.getAuthorList();
    };

    $scope.initialiseDetails = function () {
        $scope.getAuthorById(window.location.search.substring(1));
    }
}]);

authorModule.controller('authorModalController', ['$uibModalInstance', '$scope', 'mainScope', 'author', 'authorDataService', function ($uibModalInstance, $scope, mainScope, author, authorDataService) {
    $scope.modalAuthor = {};
    angular.copy(author, $scope.modalAuthor);

    $scope.cancel = function () {
        $scope.modalAuthor = {};
        mainScope.getAuthorList();
        $uibModalInstance.dismiss('cancel');
    };

    $scope.updateAuthor = function () {
        authorDataService.updateAuthor($scope.modalAuthor).then(function () {
            $scope.cancel();
        });
    };

    $scope.deleteAuthor = function () {
        authorDataService.deleteAuthor($scope.modalAuthor.id).then(function () {
            $scope.cancel();
        });
    };
}]);
    