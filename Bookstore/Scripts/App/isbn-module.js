var isbnModule = angular.module('isbnModule', []);

isbnModule.controller('ISBNController', ['$http', '$scope', '$uibModal', function ($http, $scope, $uibModal) {

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
        $http.post('/api/isbnapi/create', $scope.createdISBN).then(function () {
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

isbnModule.controller('isbnModalController', ['$uibModalInstance', '$scope', '$http', 'mainScope', 'isbn', 'countryList', function ($uibModalInstance, $scope, $http, mainScope, isbn, countryList) {
    $scope.modalISBN = {};
    angular.copy(isbn, $scope.modalISBN);
    $scope.countryList = countryList;

    $scope.cancel = function () {
        $scope.modalISBN = {};
        mainScope.getISBNList();
        $uibModalInstance.dismiss('cancel');
    };

    $scope.deleteISBN = function () {
        $http.post('/api/isbnapi/delete', $scope.modalISBN).then(function () {
            $scope.cancel();
        });
    };

    $scope.updateISBN = function () {
        $http.post('/api/isbnapi/update', $scope.modalISBN).then(function () {
            $scope.cancel();
        });
    };
}]);