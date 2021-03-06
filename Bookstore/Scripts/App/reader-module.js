﻿var readerModule = angular.module('readerModule', ['ui.bootstrap', 'dataProvider']);

readerModule.controller('ReaderController', ['$uibModal', '$scope', '$location', 'readerDataService', function ($uibModal, $scope, $location, readerDataService) {
    
    $scope.readerList = [];
    $scope.createdReader = {};

    $scope.detailedReader = {};

    $scope.genreList = [
        'Drama',
        'Comedy',
        'SciFi'
    ];

    $scope.urlparams = window.location.search.substring(1);

    $scope.getReaderList = function(){
        readerDataService.getReaderList().then(function(response){
            $scope.readerList = response;
            console.log($scope.readerList);
        });
    };

    $scope.getReaderById = function (id) {
        readerDataService.getReaderById(id).then(function (response) {
            $scope.detailedReader = response;
        });
    };

    $scope.createReader = function () {
        readerDataService.createReader($scope.createdReader).then(function () {
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
        window.location.href = '/Readers/Details';
    };

    $scope.initialiseMainTable = function () {
        $scope.getReaderList();
    };

    $scope.initialiseDetails = function () {
        $scope.getReaderById(window.location.search.substring(1));
    }
}]);

readerModule.controller('ReaderModalController', ['$uibModalInstance', 'readerDataService', '$scope', 'mainScope', 'reader', 'genreList', function ($uibModalInstance, readerDataService, $scope, mainScope, reader, genreList) {
    $scope.modalReader = {};
    angular.copy(reader, $scope.modalReader);
    $scope.genreList = genreList;

    $scope.cancel = function () {
        $scope.modalISBN = {};
        mainScope.getReaderList();
        $uibModalInstance.dismiss('cancel');
    };

    $scope.deleteReader = function () {
        readerDataService.deleteReader($scope.modalReader.id).then(function () {
            $scope.cancel();
        });
    };

    $scope.updateReader = function () {
        readerDataService.updateReader($scope.modalReader).then(function () {
            $scope.cancel();
        });
    };
}]);