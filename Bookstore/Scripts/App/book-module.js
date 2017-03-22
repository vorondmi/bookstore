var bookModule = angular.module('bookModule', ['ui.bootstrap']);

bookModule.controller('BookController', ['$uibModal', 'bookDataService', 'isbnDataService', 'readerDataService', 'authorDataService', '$scope', '$location', function ($uibModal, bookDataService, isbnDataService, readerDataService, authorDataService, $scope, $location) {

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
        return authorDataService.getAuthorList().then(function (authorsResponse) {
            return readerDataService.getReaderList().then(function (readersResponse) {
                return isbnDataService.getISBNList().then(function (isbnResponse) {
                    return {
                        authorList: authorsResponse,
                        readerList: readersResponse,
                        isbnList: isbnResponse,
                    }
                });
            });
        });
    };

    $scope.getBookList = function () {
        bookDataService.getBookList().then(function (response) {
            $scope.bookList = response;
        });
    };

    $scope.getBookById = function (id) {
        bookDataService.getBookById(id).then(function (response) {
            $scope.detailedBook = response;
            delete $scope.detailedBook.readers;
        });
    };

    $scope.createBook = function () {
        $scope.attachReadersToBook();
        console.log($scope.createdBook);
        
        bookDataService.createBook($scope.createdBook).then(function () {
            $scope.createdBook.readerIDs = [];
            window.location.href = '/Books/Index';
        });
    };

    $scope.updateBookModal = function (item) {
        $scope.getAuthorsReadersISBNs().then(function (response) {
            $scope.authorList = response.authorList;
            $scope.readerList = response.readerList;
            $scope.isbnList = response.isbnList;
        });
        
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
                    return $scope;
                }
            }
        });
    };

    $scope.redirectToCreate = function(){
        window.location.href = '/Books/Create';
    };

    $scope.redirectToDetails = function (book) {
        window.location.href = '/Books/Details';
    };

    $scope.initialiseMainTable = function () {
        $scope.getBookList();
    };

    $scope.initialiseDetails = function () {
        $scope.getBookById(window.location.search.substring(1));
    };

    $scope.initialiseCreate = function () {
        $scope.getAuthorsReadersISBNs().then(function (response) {
            $scope.authorList = response.authorList;
            $scope.readerList = response.readerList;
            $scope.isbnList = response.isbnList;
        });
    };
}]);

bookModule.controller('BookModalController', ['$uibModalInstance', 'bookDataService', '$scope', 'book', 'mainScope', function ($uibModalInstance, bookDataService, $scope, book, mainScope) {
    
    $scope.modalBook = {};
    $scope.authorList = {};
    $scope.readerList = {};
    $scope.isbnList = {};

    angular.copy(book, $scope.modalBook);
    console.log(book);
    console.log($scope.modalBook);

    mainScope.getAuthorsReadersISBNs().then(function (response) {
        $scope.authorList = response.authorList;
        $scope.readerList = response.readerList;
        $scope.isbnList = response.isbnList;
    });

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
        bookDataService.updateBook($scope.modalBook).then(function () {
            $scope.cancel();
        });
    };

    $scope.deleteBook = function () {
        bookDataService.deleteBook($scope.modalBook.id).then(function () {
            $scope.cancel();
        });
    };
}]);