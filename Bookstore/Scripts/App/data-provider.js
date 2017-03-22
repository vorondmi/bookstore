var dataProvider = angular.module('dataProvider', []);

dataProvider.service('authorDataService', ['$http', function ($http) {

    this.getAuthorList = function () {
        return $http.get("/api/authorsapi").then(function (response) {
            return response.data;
        });
    }

    this.getAuthorById = function (authorId) {
        return $http.get('/api/authorsapi/' + authorId).then(function (response) {
            return response.data;
        });
    };

    this.createAuthor = function (authorToCreate) {
        return $http.put("/api/authorsapi", authorToCreate).then(function () {
            return {};
        });
    }

    this.updateAuthor = function (authorToUpdate) {
        return $http.post('/api/authorsapi', authorToUpdate).then(function () {
            return {};
        });
    };

    this.deleteAuthor = function (authorId) {
        return $http.delete("/api/authorsapi/" + authorId).then(function () {
            return {};
        });
    };
}]);

dataProvider.service('isbnDataService', ['$http', function ($http) {

    this.getISBNList = function () {
        return $http.get('/api/isbnapi').then(function (response) {
            return response.data;
        });
    };

    this.getISBNById = function (isbnId) {
        return $http.get('/api/isbnapi/' + isbnId).then(function (response) {
            return response.data;
        });
    };

    this.createISBN = function (isbnToCreate) {
        return $http.put('/api/isbnapi', isbnToCreate).then(function () {
            return {};
        });
    };

    this.updateISBN = function (isbnToUpdate) {
        return $http.post('/api/isbnapi', isbnToUpdate).then(function () {
            return {};
        });
    };

    this.deleteISBN = function (isbnId) {
        return $http.delete('/api/isbnapi/' + isbnId).then(function () {
            return {};
        });
    };
}]);

dataProvider.service('readerDataService', ['$http', function ($http) {

    this.getReaderList = function () {
        return $http.get('/api/readersapi').then(function (response) {
            return response.data;
        });
    };

    this.getReaderById = function (readerId) {
        return $http.get('/api/readersapi/' + readerId).then(function (response) {
            return response.data;
        });
    };

    this.createReader = function (readerToCreate) {
        return $http.put('/api/readersapi', readerToCreate).then(function () {
            return {};
        });
    };

    this.updateReader = function (readerToUpdate) {
        return $http.post('/api/readersapi', readerToUpdate).then(function () {
            return {};
        });
    };

    this.deleteReader = function (readerId) {
        return $http.delete('/api/readersapi/' + readerId).then(function () {
            return {};
        });
    };
}]);

dataProvider.service('bookDataService', ['$http', function ($http) {

    this.getBookList = function () {
        return $http.get('/api/booksapi').then(function (response) {
            return response.data;
        });
    };

    this.getBookById = function (bookId) {
        return $http.get('/api/booksapi/' + bookId).then(function (response) {
            return response.data;
        });
    };

    this.createBook = function (bookToCreate) {
        return $http.put('/api/booksapi', bookToCreate).then(function () {
            return {};
        });
    };

    this.updateBook = function (bookToUpdate) {
        return $http.post('/api/booksapi', bookToUpdate).then(function () {
            return {};
        });
    };

    this.deleteBook = function (bookId) {
        return $http.delete('/api/booksapi/' + bookId).then(function () {
            return {};
        });
    };
}]);