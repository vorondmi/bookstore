var bookModule = angular.module('bookModule', ['dataSaveModule']);

bookModule.controller('BookController', ['$http', '$scope', '$location', 'dataSaveService', function($http, $scope, $location, dataSaveService){

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

    $scope.deleteBook = function (item) {
        $http.post('/api/booksapi/delete', item).then(function () {
            $scope.getBookList();
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