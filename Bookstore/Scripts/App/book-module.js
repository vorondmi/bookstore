﻿var bookModule = angular.module('bookModule', ['dataSaveModule']);

bookModule.controller('BookController', ['$uibModal', '$http', '$scope', '$location', 'dataSaveService', function($uibModal, $http, $scope, $location, dataSaveService){

    $scope.bookList = [];
    $scope.authorList = [];
    $scope.isbnList = [];
    $scope.readerList = [];

    $scope.detailedBook = {};

    $scope.createdBook = {
        readerIDs : []
    };

    $scope.attachReadersToBook = function () {
        $scope.readerList.forEach(function (reader) {
            if (reader.isReader === true) {
                $scope.createdBook.readerIDs.push(reader.id);
            };
        });
    };

    $scope.getAuthorsReadersISBNs = function () {
        $http.get('/api/booksapi/GetAuthorsReadersISBNs').then(function (response) {
            $scope.authorList = response.data.authors;
            $scope.isbnList = response.data.isbns;
            $scope.readerList = response.data.readers;
        });
    };

    let getAuthorReadersISBNs = new Promise($scope.getAuthorsReadersISBNs()).

    $scope.getBookList = function () {
        $http.get('/api/booksapi/getall').then(function (data) {
            $scope.bookList = data.data;
        });
    };

    $scope.createBook = function () {
        $scope.attachReadersToBook();
        $http.post('/api/booksapi/create', $scope.createdBook).then(function () {
            $scope.createdBook.readerIDs = [];
            window.location.href = '/Books/Index';
        });
    };

    $scope.updateBookModal = function (item) {
        $scope.getAuthorsReadersISBNs();
        console.log($scope.authorList);
        console.log($scope.isbnList);
        console.log($scope.readerList);
        var updateModal = $uibModal.open({
            templateUrl: 'updateBookModal.html',
            controller: 'BookModalController',
            controllerAs: 'modalCtrl',
            resolve: {
                book: function () {
                    return item;
                },
                mainScope: function () {
                    return $scope;
                }
            }
        });
    };

    $scope.deleteBookModal = function (item) {
        var updateModal = $uibModal.open({
            templateUrl: 'deleteBookModal.html',
            controller: 'BookModalController',
            controllerAs: 'modalCtrl',
            resolve: {
                book: function () {
                    return item;
                },
                mainScope: function () {
                    return null;
                }
            }
        });
    };

    $scope.getBookById = function (id) {
        $http.get('/api/booksapi/GetBookDetailsById/' + id).then(function (response) {
            $scope.detailedBook = response.data;
        });
    };

    $scope.redirectToCreate = function(){
        window.location.href = '/Books/Create';
    };

    $scope.redirectToDetails = function (book) {
        sessionStorage.setItem('bookToDetail', book.id);
        window.location.href = '/Books/Details';
    };

    $scope.initialiseMainTable = function () {
        $scope.getBookList();
    };

    $scope.initialiseDetails = function () {
        $scope.getBookById(sessionStorage.getItem('bookToDetail'));
    }
}]);

bookModule.controller('BookModalController', ['$uibModalInstance', '$http', '$scope', 'book', 'mainScope', function ($uibModalInstance, $http, $scope, book, mainScope) {
    
    $scope.modalBook = {};

    angular.copy(book, $scope.modalBook);

    $scope.authorList = mainScope.authorList;
    $scope.isbnList = mainScope.isbnList;
    $scope.readerList = mainScope.readerList;

    console.log(mainScope);
    console.log(mainScope.authorList);
    console.log(mainScope.isbnList);
    console.log(mainScope.readerList);

    $scope.attachReadersToBook = function () {
        $scope.readerList.forEach(function (reader) {
            if (reader.isReader === true) {
                $scope.modalBook.readerIDs.push(reader.id);
            };
        });
    };

    $scope.cancel = function () {
        $scope.modalBook = {};
        mainScope.getBookList();
        $uibModalInstance.dismiss('cancel');
    }

    $scope.updateBook = function () {
        $scope.attachReadersToBook();
        $http.post('/api/booksapi/update', $scope.modalBook).then(function () {
            $scope.cancel();
        });
    };

    $scope.deleteBook = function () {
        $http.post('/api/booksapi/delete', $scope.modalBook).then(function () {
            $scope.cancel();
        });
    };
}]);