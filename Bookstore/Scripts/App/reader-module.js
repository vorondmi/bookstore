var readerModule = angular.module('readerModule', []);

readerModule.controller('ReaderController', ['$uibModal', '$scope', '$http', function ($uibModal, $scope, $http) {
    
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
        $http.post('/api/readersapi/create', $scope.createdReader).then(function () {
            window.location.href = '/Readers/Index';
        });
    };

    $scope.updateReaderModal = function (item) {
        var updateModal = $uibModal.open({
            templateUrl: 'updateReaderModal.html',
            controller: 'ReaderModalController',
            controllerAs: 'modalCtrl',
            resolve: {
                reader: function () {
                    return item;
                },
                genreList: function () {
                    return $scope.genreList;
                }
            }
        });
    };

    $scope.deleteReaderModal = function (item) {
        var updateModal = $uibModal.open({
            templateUrl: 'deleteReaderModal.html',
            controller: 'ReaderModalController',
            controllerAs: 'modalCtrl',
            resolve: {
                reader: function () {
                    return item;
                },
                genreList: function () {
                    return null;
                }
            }
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

readerModule.controller('ReaderModalController', ['$uibModalInstance', '$scope', '$http', 'mainScope', 'reader', 'genreList', function ($uibModalInstance, $scope, $http, mainScope, reader, genreList) {
    $scope.modalReader = {};
    angular.copy(reader, $scope.modalReader);
    $scope.genreList = genreList;

    $scope.cancel = function () {
        $scope.modalISBN = {};
        mainScope.getReaderList();
        $uibModalInstance.dismiss('cancel');
    };

    $scope.deleteReader = function () {
        $http.post('/api/readersapi/delete', $scope.modalReader).then(function () {
            $scope.cancel();
        });
    };

    $scope.updateReader = function () {
        $http.post('/api/readersapi/update', $scope.modalReader).then(function () {
            $scope.cancel();
        });
    };
}]);