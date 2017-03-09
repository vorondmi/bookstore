var authorModule = angular.module('authorModule', []);

//authorModule.service('DataService', ['$http', '$q', function ($http, $q) {

//    this.getMethod = function (url) {
//        $http.get(url).then(function (data) {
//            console.log("GET");
//            return data.data;
//        }, null, null);
//    }

//    this.postMethod = function (url) {
//        $http.post(url).then(function (data) {
//            console.log(data.data);
//        });
//    }
//}]);

authorModule.controller('AuthorController', ['$scope', '$http', function ($scope, $http) {

    $scope.authors = [];

    $http.get("/api/authorsapi/getall").then(function (data) {
        $scope.authors = data.data;
        console.log($scope.authors);
    });
}]);
    