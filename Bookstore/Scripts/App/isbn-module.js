var isbnModule = angular.module('isbnModule', ['ui.bootstrap', 'dataProvider']);

isbnModule.controller('ISBNController', ['$scope', '$uibModal', 'isbnDataService', function ($scope, $uibModal, isbnDataService) {

    $scope.isbnList = [];
    $scope.createdISBN = {};

    $scope.detailedISBN = {};

    $scope.countryList = [
        'LT',
        'LV',
        'EST'
    ];

    $scope.getISBNList = function () {
        isbnDataService.getISBNList().then(function (response) {
            $scope.isbnList = response;
            console.log($scope.isbnList);
        });
    };

    $scope.getISBNById = function (id) {
        isbnDataService.getISBNById(id).then(function (response) {
            $scope.detailedISBN = response;
        });
    };

    $scope.createISBN = function () {
        isbnDataService.createISBN($scope.createdISBN).then(function () {
            window.location.href = '/ISBN/Index';
        });
    };

    $scope.updateISBNModal = function(item){
        var updateModal = $uibModal.open({
            templateUrl: 'updateISBNModal.html',
            controller: 'isbnModalController',
            controllerAs: 'modalCtrl',
            resolve: {
                mainScope: function(){
                    return $scope
                },
                isbn: function(){
                    return item;
                },
                countryList: function(){
                    return $scope.countryList;
                }
            }
        });
    };

    $scope.deleteISBNModal = function (item) {

        var updateModal = $uibModal.open({
            templateUrl: 'deleteISBNModal.html',
            controller: 'isbnModalController',
            controllerAs: 'modalCtrl',
            resolve: {
                mainScope: function () {
                    return $scope
                },
                isbn: function () {
                    return item;
                },
                countryList: function () {
                    return null;
                }
            }
        });
    };

    $scope.redirectToCreate = function () {
        window.location.href = '/ISBN/Create';
    };

    $scope.redirectToDetails = function (isbn) {
        window.location.href = '/ISBN/Details';
    };

    $scope.initialiseMainTable = function () {
        $scope.getISBNList();
    };

    $scope.initialiseDetails = function () {
        $scope.getISBNById(window.location.search.substring(1));
    }
}]);

isbnModule.controller('isbnModalController', ['$uibModalInstance', '$scope', 'mainScope', 'isbn', 'countryList', function ($uibModalInstance, $scope, mainScope, isbn, countryList) {
    $scope.modalISBN = {};
    angular.copy(isbn, $scope.modalISBN);
    $scope.countryList = countryList;

    $scope.cancel = function () {
        $scope.modalISBN = {};
        mainScope.getISBNList();
        $uibModalInstance.dismiss('cancel');
    };

    $scope.deleteISBN = function () {
        isbnDataService.deleteISBN($scope.modalISBN.id).then(function () {
            $scope.cancel();
        });
    };

    $scope.updateISBN = function () {
        isbnDataService.updateISBN($scope.modalISBN).then(function () {
            $scope.cancel();
        });
    };
}]);